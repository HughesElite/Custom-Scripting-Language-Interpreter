# Custom Scripting Language Interpreter (BOOSE)

A scripting language interpreter built in C# on top of a fixed abstract DLL interface, with a Windows Forms front end for writing and running scripts against a bitmap canvas.

## What it does

Type commands into a text box and the interpreter parses and executes them, drawing shapes and text onto a canvas in real time. Supports typed variables (int, real, boolean), arrays, while loops, if statements, and drawing commands like `moveto`, `drawto`, `circle`, `rect`, and `pen`.

## The constraint

Built against a precompiled DLL provided by the module tutor, defining a fixed set of interfaces that couldn't be modified. Every command had to be implemented to conform to that contract, including working around restriction counters the DLL enforced.

## Architecture

- **Factory pattern** — `AppCommandFactory` returns the correct command class for each keyword
- **Canvas** — `AppCanvas` implements `ICanvas`, handling all drawing operations
- **Parser** — `AppParser` extends the base `Parser`, removing the DLL's line count restrictions
- **BooseReset** — resets static counters to avoid hitting restriction limits inherited from the DLL

## Testing

MSTest suite covering core canvas operations (movement, drawing, multi-line programs).

## Documentation

Full XML doc comments across all classes, with HTML API reference generated via DocFX.

## Stack

C# · Windows Forms · MSTest · DocFX
