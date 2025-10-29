# 🧮 Net8CalcApp

[![GitHub repo size](https://img.shields.io/github/repo-size/Achintha-999/Net8CalcApp?color=blue)](https://github.com/Achintha-999/Net8CalcApp)
[![Language: C#](https://img.shields.io/badge/language-C%23-blue?logo=csharp)](https://docs.microsoft.com/dotnet/csharp/)
[![Platform: Windows](https://img.shields.io/badge/platform-windows-lightgrey?logo=windows)](https://www.microsoft.com/windows)
[![Target: .NET 8](https://img.shields.io/badge/.NET-8.0-512bd4?logo=.net)](https://dotnet.microsoft.com/)
[![Issues](https://img.shields.io/github/issues/Achintha-999/Net8CalcApp)](https://github.com/Achintha-999/Net8CalcApp/issues)

A simple and intuitive calculator application built with C# and Windows Forms, targeting .NET 8.0. This project demonstrates basic arithmetic operations and a user-friendly interface for learning and practical use.

---

Table of Contents
- About
- Demo / Screenshots
- Features
- How it works (architecture & flow)
- Requirements
- Installation & Quick Start
- Usage
- Design & UI
- Implementation notes
- Tests & Quality
- Contributing
- Roadmap / TODO
- License
- Acknowledgements

---

About
-----
Net8CalcApp is a small Windows Forms calculator application intended as an educational example of building a desktop GUI app with .NET 8 and C#. It focuses on clarity, simplicity, and useful core calculator functionality.

Features
--------
- ✅ Basic arithmetic: add, subtract, multiply, divide
- ✅ Decimal numbers and chaining operations
- ✅ Clear (C) and All Clear (AC)
- ✅ Backspace / delete last digit
- ✅ Keyboard support (digits, + - * /, Enter, Backspace)
- ✅ Simple, readable UI implemented in WinForms

Demo / Screenshots
------------------
> Add real screenshots to repository at `assets/screenshot-*.png` and update these links.

- Main window (placeholder)
  ![Calculator Screenshot](assets/screenshot-1.png)

How it works — high-level
-------------------------
Net8CalcApp uses an event-driven Windows Forms UI with a small "Calculator Engine" responsible for holding the current state and performing numeric operations.

Flow (user perspective):
1. User clicks or types digits → UI appends digits to the display.
2. User chooses an operator (+, -, ×, ÷) → Engine stores current value and operator.
3. User inputs the next number and presses = → Engine computes using stored value, operator, and current input, then displays the result.
4. Special buttons (C, AC, ←) manipulate display or engine state.

Core components (typical)
- Program.cs: application entry point (Application.Run(MainForm)).
- MainForm.cs (WinForms): UI layout, button click / key press handlers.
- CalculatorEngine.cs: pure logic class that performs calculations and maintains state (currentValue, pendingOperator, inputBuffer, hasDecimal).
- Resources/Assets: icons and screenshots.

Simplified architecture (ASCII)
- UI (MainForm)  <---->  CalculatorEngine
     ^  event handlers         ^  stateless math operations & state machine
     |                         |
  Keyboard input             Calculation methods

CalculatorEngine responsibilities
- Accept numeric input append/pop
- Handle unary/binary operations and operator precedence (simple left-to-right for basic calculator)
- Validate divide-by-zero
- Normalize rounding/precision for display
- Provide formatted string for UI display

Requirements
------------
- OS: Windows (Windows Forms desktop)
- .NET SDK: .NET 8.0 (recommended)
  - https://dotnet.microsoft.com/download/dotnet/8.0
- IDE (recommended):
  - Visual Studio 2022/2023 with .NET Desktop Development workload OR
  - JetBrains Rider OR
  - Visual Studio Code (with C# extension; Windows Forms designer not available)
- Hardware: any modern PC capable of running Windows & .NET apps

Installation & Quick Start
--------------------------
Clone repository
```bash
git clone https://github.com/Achintha-999/Net8CalcApp.git
cd Net8CalcApp
```

Open and run
- Visual Studio
  - Open the solution (.sln) or project (.csproj).
  - Press F5 to build and run.

- dotnet CLI (if project is a SDK-style WinForms project)
  - Build:
    ```
    dotnet build
    ```
  - Run from the project folder:
    ```
    dotnet run --framework net8.0
    ```
  Note: Running WinForms via dotnet CLI works on Windows; ensure your project file targets `UseWindowsForms` and `TargetFramework` net8.0.

Usage
-----
Buttons:
- 0–9 : digits
- . : decimal point
- +, −, ×, ÷ : operators
- = or Enter : evaluate
- AC : all clear (reset)
- C : clear current entry
- ← or Backspace : delete last digit

Keyboard shortcuts:
- Numbers: direct numeric keys
- + - * / : operator keys
- Enter = Evaluate
- Backspace = Delete last digit
- Escape = AC (optional: if implemented)

Design & UI
-----------
Visual goals
- Clean, high-contrast display area for current input and result.
- Large buttons arranged 4x5 grid for easy clicking.
- Clear typography for numbers and operators.

Layout suggestion (grid)
- Display row: large single-line label
- Row 1: AC | C | ← | ÷
- Row 2: 7 | 8 | 9 | ×
- Row 3: 4 | 5 | 6 | −
- Row 4: 1 | 2 | 3 | +
- Row 5: ± | 0 | . | =

Colors & binding
- Primary color for operators for emphasis.
- Neutral background and rounded button shapes.
- Buttons implement MouseDown/Click with short press animation (optional).

Implementation notes & best practices
-----------------------------------
- Keep CalculatorEngine logic separated from UI so it can be unit-tested.
- Avoid floating point rounding surprises: consider using decimal for monetary-like precision.
- Sanitize input to avoid multiple decimals in the same number.
- Handle divide-by-zero gracefully (display "Error" or "∞" and lock until AC).

Example pseudo-code for calculator logic
```csharp
public class CalculatorEngine {
    private decimal? storedValue = null;
    private string pendingOp = null;
    private string input = "0";

    public void EnterDigit(char digit) { /* append or replace input */ }
    public void EnterDecimalPoint() { /* allow only once */ }
    public void SetOperator(string op) {
        if (storedValue == null) storedValue = decimal.Parse(input);
        else storedValue = Compute(storedValue.Value, decimal.Parse(input), pendingOp);
        pendingOp = op;
        input = "0";
    }
    public string Evaluate() {
        if (pendingOp != null && storedValue != null) {
            var result = Compute(storedValue.Value, decimal.Parse(input), pendingOp);
            ClearStateKeepResult(result);
            return result.ToString();
        }
        return input;
    }
    private decimal Compute(decimal a, decimal b, string op) { /* + - * / with checks */ }
}
```

Testing & Quality
-----------------
- Add unit tests for CalculatorEngine:
  - Simple operations: 2+2=4, 6/3=2
  - Chained operations: 2+3×4 (depending on precedence support)
  - Decimal behavior: 0.1+0.2 (use decimal to avoid binary float surprises)
  - Divide-by-zero handling

- Manual UI tests:
  - Keyboard input
  - Button clicks
  - Edge cases (long input, repeated equals, operator change mid-entry)

Contributing
------------
Contributions are welcome! Suggested workflow:
1. Fork the repo
2. Create a feature branch (feature/clear-history or fix/bug-name)
3. Commit changes with clear message
4. Open a Pull Request describing the change and why it helps

When opening issues, please include:
- Steps to reproduce (if bug)
- Expected behavior vs actual behavior
- Screenshots or logs (if available)
- OS / .NET SDK version

Roadmap / TODO
--------------
- [ ] Add unit tests for CalculatorEngine
- [ ] Add memory functions (M+, M-, MR, MC)
- [ ] Add history log that shows previous calculations
- [ ] Implement keyboard-only mode and accessibility improvements
- [ ] Improve styling and add dark theme

License
-------
No license file is currently included in the repository. If you want a permissive license, add a LICENSE file such as the MIT license:

MIT License (example — add to LICENSE file)
```
MIT License

Copyright (c) YEAR Achintha-999

Permission is hereby granted, free of charge, to any person obtaining a copy...
```

Acknowledgements
----------------
- Built with .NET and Windows Forms
- Example UI layout inspired by common calculator apps

Contact
-------
Project owner: Achintha-999 — https://github.com/Achintha-999

---

Need a custom README variant? I can:
- Add screenshots (if you upload images or point to existing assets)
- Produce a smaller README for a release page
- Generate a matching LICENSE file (MIT/Apache) and add it to the repo
- Create a CONTRIBUTING.md and ISSUE_TEMPLATEs

