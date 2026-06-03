# myOnionAndPotatoApp

A minimalist **South African micro-pantry tracker** for potatoes and onions — built as a portfolio learning project with **.NET MAUI** and **C#**.

## About

myOnionAndPotatoApp strips kitchen inventory down to two essentials: **potatoes** and **onions**. Tap +/- to update counts, with a gentle daily check-in ritual and playful low-stock nudges planned — all wrapped in warm, earthy SA-inspired tones.

## Tech stack

- .NET MAUI (Android)
- C# · XAML · MVVM
- CommunityToolkit.Mvvm

## Project structure

```
myOnionAndPotatoApp/
  ROADMAP.md                  ← Phase-by-phase development plan
  SpudAndUi/                  ← MAUI application folder
    MyOnionAndPotatoApp.csproj
    Models/
    ViewModels/
    Views/
    Components/
```

## Getting started

### Prerequisites

1. [.NET 10 SDK](https://dot.net/download)
2. MAUI workload: `dotnet workload install maui-android`
3. [Android Studio](https://developer.android.com/studio) (for Android SDK + device pairing)
4. Environment variables (if builds fail with Java errors):
   - `JAVA_HOME` → `C:\Program Files\Android\Android Studio\jbr`
   - `ANDROID_HOME` → `%LOCALAPPDATA%\Android\Sdk`

The project `.csproj` can set `JavaSdkDirectory` automatically when that JBR path exists.

### Run on a device

```powershell
cd SpudAndUi
dotnet build -t:Run -f net10.0-android
```

Pair your phone via wireless debugging in Android Studio, or connect via USB. Accept the install prompt on your device when it appears.

## Current status

**Phase 2 in progress** — +/- pantry tracking works on Android (potato and onion counts, minimum 0). Next: save counts with Preferences, then activity log.

**Phase 1 complete** — project setup, MVVM structure, UI shell (Pantry + Log tabs), data model, and device deployment.

See [ROADMAP.md](./ROADMAP.md) for the full 5-phase plan and next steps.

## License

Personal portfolio / learning project.
