# CSharp Cal

A simple, lightweight Windows Forms calculator application written in C#. CSharp Cal provides a straightforward UI for basic arithmetic operations — a good starter project for beginners learning WinForms and C#.

---

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

## Features

- Addition, subtraction, multiplication, division
- Clear / reset functionality
- Basic error handling (handles division by zero and invalid numeric input)
- Minimal dependencies — runs as a regular .NET Framework WinForms app

## Screenshots

![Calculator UI](https://via.placeholder.com/600x400?text=Calculator+UI+Screenshot)

## Requirements

- Visual Studio 2022 or later (recommended) with the ".NET desktop development" workload
- .NET Framework 4.7.2 or later
- Windows OS (WinForms desktop app)

## Project structure

Root of the solution:

- Form1.cs — main form logic and event handlers
- Form1.Designer.cs — auto-generated UI layout code
- Form1.resx — form resources
- Program.cs — application entry point
- CSharp Cal.sln — Visual Studio solution
- CSharp Cal.csproj — project file

Build artifacts:
- bin/
- obj/

## Getting started (Quick)

1. Clone the repository:
   git clone <repository-url>

2. Open the solution:
   - Double-click `CSharp Cal.sln` or open it from Visual Studio (File → Open → Project/Solution).

3. Build and run:
   - In Visual Studio: Build (Ctrl+Shift+B) then Run (F5).
   - Alternatively, from a Developer Command Prompt you can run:
     msbuild "CSharp Cal.sln" /p:Configuration=Debug
     (Note: msbuild is available with Visual Studio / Build Tools on Windows.)

## How to use

- Click numeric buttons to enter numbers.
- Click an operation (+ − × ÷).
- Enter the next number and press `=` to compute the result.
- Press `C` (or Clear) to reset the calculator.

Behavior notes:
- Division by zero is handled and will show an appropriate error message instead of crashing.
- Invalid numeric input is guarded against by the UI and parsing logic.

## Troubleshooting

- If the app won't build:
  - Ensure Visual Studio has the .NET Desktop Development workload installed.
  - Confirm the project targets a compatible .NET Framework version installed on your machine.
- If UI looks broken:
  - Open the Designer file (`Form1.Designer.cs`) in Visual Studio Designer to inspect layout properties.

## Contributing

Contributions are welcome. Suggested workflow:
1. Fork the repo.
2. Create a feature branch (git checkout -b feature/your-change).
3. Make changes, run and test locally in Visual Studio.
4. Open a pull request with a clear description of the change.

Please keep changes small and focused. If you intend to add features (history, parentheses, keyboard input, scientific operations) open an issue first to discuss scope.

## License

This project is released under the MIT License. See the `LICENSE` file for details.

---


