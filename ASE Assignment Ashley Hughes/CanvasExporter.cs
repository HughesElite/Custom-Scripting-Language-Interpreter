using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using BOOSE;

namespace ASE_Assignment_Ashley_Hughes
{
    /// <summary>
    /// Utility class for exporting canvas images to various file formats.
    /// This can be used in any form without needing to inherit from a specific class.
    /// </summary>
    public static class CanvasExporter
    {
        /// <summary>
        /// Shows an export dialog and saves the canvas bitmap to the selected format.
        /// </summary>
        /// <param name="canvas">The canvas containing the bitmap to export.</param>
        /// <param name="owner">The parent form that will own the dialog.</param>
        /// <returns>True if the export was successful, false otherwise.</returns>
        public static bool ExportCanvasImage(ICanvas canvas, IWin32Window owner)
        {
            try
            {
                // Gets the bitmap from the canvas
                Bitmap bitmap = (Bitmap)canvas.getBitmap();

                if (bitmap == null)
                {
                    MessageBox.Show(owner, "No image to export.", "Export Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Configure save file dialog
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.Title = "Export Canvas";
                    saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif";
                    saveFileDialog.DefaultExt = "png";

                    // Shows save dialog
                    if (saveFileDialog.ShowDialog(owner) == DialogResult.OK)
                    {
                        // Determine the format based on the file extension
                        ImageFormat format = GetImageFormatFromExtension(saveFileDialog.FileName);

                        // Create a copy of the bitmap to avoid issues with the original being used by the canvas
                        using (Bitmap bitmapCopy = new Bitmap(bitmap))
                        {
                            // Save the bitmap
                            bitmapCopy.Save(saveFileDialog.FileName, format);

                            // Show success message
                            MessageBox.Show(owner, "Canvas exported successfully.", "Export Complete",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            return true;
                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(owner, $"Error exporting image: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Log the error
                ErrorLogger.Instance.LogError($"Error exporting canvas: {ex.Message}");

                return false;
            }
        }

        /// <summary>
        /// Determines the appropriate ImageFormat based on the file extension.
        /// </summary>
        /// <param name="filePath">The file path to analyze.</param>
        /// <returns>The corresponding ImageFormat.</returns>
        private static ImageFormat GetImageFormatFromExtension(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    return ImageFormat.Jpeg;
                case ".bmp":
                    return ImageFormat.Bmp;
                case ".gif":
                    return ImageFormat.Gif;
                case ".png":
                default:
                    return ImageFormat.Png;
            }
        }

        /// <summary>
        /// Directly exports the canvas to a specified file path without showing a dialog.
        /// Useful for automated saving or when the path is already known.
        /// </summary>
        /// <param name="canvas">The canvas to export.</param>
        /// <param name="filePath">The file path to save to.</param>
        /// <returns>True if successful, false otherwise.</returns>
        public static bool ExportCanvasToFile(ICanvas canvas, string filePath)
        {
            try
            {
                // Get the bitmap from the canvas
                Bitmap bitmap = (Bitmap)canvas.getBitmap();

                if (bitmap == null)
                {
                    ErrorLogger.Instance.LogError("No image to export.");
                    return false;
                }

                // Create directory if it doesn't exist
                string directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Determine the format based on the file extension
                ImageFormat format = GetImageFormatFromExtension(filePath);

                // Creates a copy of the bitmap and saves it
                using (Bitmap bitmapCopy = new Bitmap(bitmap))
                {
                    bitmapCopy.Save(filePath, format);
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorLogger.Instance.LogError($"Error exporting canvas to file: {ex.Message}");
                return false;
            }
        }
    }
}