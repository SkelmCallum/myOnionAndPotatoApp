# Spud & Ui — Development Roadmap

**The South African Micro-Pantry Tracker**

A minimalist app to track potatoes and onions — built with **.NET MAUI** and **C#**, targeting **Android**.

---

## App overview

| | |
|---|---|
| **Purpose** | Hyper-focused pantry tracker for potatoes and onions only |
| **Aesthetic** | Clean, warm SA tones (cream, terracotta, earthy greens/golds) |
| **Stack** | .NET MAUI · C# · XAML · MVVM · CommunityToolkit.Mvvm |
| **Target** | Android (physical device or emulator) |

---

## Learning objectives

- **State management** — increment/decrement counts across screens in real time
- **Data persistence** — save counts locally (SQLite)
- **UI & micro-interactions** — layouts, animations, optional sound
- **Notifications** — daily check-ins and low-stock alerts
- **Professional workflow** — clean structure, testing, documentation

---

## Phase 1: Foundation & Setup (Complete)

**Goal:** Clean project structure and foundational state management.

### Tasks

- [x] Configure project (.NET MAUI, Android-only target)
- [x] MVVM folder structure (`Models/`, `ViewModels/`, `Views/`, `Components/`)
- [x] Core data model (`VegetableItem`, `VegetableType`)
- [x] South African color palette (`Resources/Styles/Colors.xaml`)
- [x] `HomeViewModel` with `[ObservableProperty]`
- [x] Tab navigation (`AppShell` — Pantry + Log)
- [x] UI shell: `HomePage`, `LogPage`, `PantryCard` (placeholder +/- buttons)
- [x] Dependency injection in `MauiProgram.cs`
- [x] Deploy to Android device

### Key files

- `SpudAndUi/Models/VegetableItem.cs`
- `SpudAndUi/ViewModels/HomeViewModel.cs`
- `SpudAndUi/Views/HomePage.xaml`, `SpudAndUi/Views/LogPage.xaml`
- `SpudAndUi/Components/PantryCard.xaml`
- `SpudAndUi/AppShell.xaml`, `SpudAndUi/MauiProgram.cs`

---

## Phase 2: Core Tracking Logic

**Goal:** Working +/- buttons, persistence, and a basic activity log.

### Tasks

- [ ] Wire +/- buttons on `PantryCard` to `HomeViewModel` commands
- [ ] Prevent negative counts (minimum 0)
- [ ] Persist pantry state locally (SQLite or Preferences for MVP)
- [ ] Load saved counts on app start
- [ ] Log entries when items are added or used (timestamp + vegetable + delta)
- [ ] Bind `LogPage` to a `LogViewModel` showing history (newest first)
- [ ] Empty state when no log entries exist

### Learning focus

- `ICommand` / `[RelayCommand]` from CommunityToolkit.Mvvm
- Async save/load patterns
- Single source of truth for pantry state

---

## Phase 3: Aesthetic & Interaction

**Goal:** South African visual polish and satisfying micro-interactions.

### Tasks

- [ ] Refine typography and spacing (global styles)
- [ ] Replace default app icon/splash with SA-themed assets
- [ ] Subtle animations on card tap / count change
- [ ] Optional sound effects on +/- press
- [ ] Responsive layout for different phone/tablet sizes
- [ ] Consider replacing deprecated `Frame` with `Border` in `PantryCard`

### Learning focus

- XAML styles and resources
- MAUI animations (`Animation`, `Scale`, etc.)
- Asset pipeline (images, fonts, raw audio)

---

## Phase 4: Check-ins & Notifications

**Goal:** Gentle daily prompts and low-stock awareness.

### Tasks

- [ ] Local notification scheduler for daily check-in
  - e.g. *"Udlile na namhlanje?"* / *"Have you eaten today?"*
- [ ] Low-stock rule (e.g. count < 3) → in-app warning or notification
- [ ] User settings: enable/disable notifications, optional time of day
- [ ] Handle Android notification permissions (API 33+)

### Learning focus

- Local notifications in .NET MAUI
- Background scheduling constraints on Android
- Conditional logic tied to live pantry state

---

## Phase 5: Polish & Testing

**Goal:** Portfolio-ready quality and documented learning.

### Tasks

- [ ] UI pass: alignment, padding, transitions
- [ ] Manual test checklist (tabs, counts, persistence, log, notifications)
- [ ] Fix bugs and state-sync issues
- [ ] Add screenshots to README
- [ ] Document what you learned in each phase (this file or `docs/LEARNING.md`)
- [ ] Optional: GitHub Actions build (Android compile only)

### Learning focus

- QA mindset, regression testing
- README as portfolio artifact
- Reflecting on architecture decisions

---

## How to build & run

### Prerequisites

- .NET 10 SDK + MAUI Android workload
- Android SDK (via Android Studio)
- `JAVA_HOME` → Android Studio `jbr`
- `ANDROID_HOME` → `%LOCALAPPDATA%\Android\Sdk`

### Deploy to phone (wireless or USB)

```powershell
$env:JAVA_HOME = "C:\Program Files\Android\Android Studio\jbr"
$env:ANDROID_HOME = "$env:LOCALAPPDATA\Android\Sdk"
$env:PATH = "$env:JAVA_HOME\bin;$env:ANDROID_HOME\platform-tools;$env:PATH"

cd SpudAndUi
dotnet build -t:Run -f net10.0-android
```

On some phones (e.g. Xiaomi), enable **Install via USB** in Developer options and accept the install prompt when it appears.

### Manual APK install

After a successful build, the signed APK is at:

```
SpudAndUi/bin/Debug/net10.0-android/com.companyname.spudandui-Signed.apk
```

Copy to your device and install manually if wireless deploy is unavailable.

---

## Architecture (MVVM)

```
SpudAndUi/
  Models/          → VegetableItem, log entries (Phase 2)
  ViewModels/      → HomeViewModel, LogViewModel
  Views/           → HomePage, LogPage (XAML)
  Components/      → PantryCard (reusable)
  AppShell.xaml    → Tab navigation
  MauiProgram.cs   → DI registration
```

---

## Phase 1 comprehension checkpoint

Before starting Phase 2, you should be able to explain:

1. What MVVM is and why Model, View, and ViewModel are separated
2. What `[ObservableProperty]` does and why we use it
3. What data binding is and how the View updates when the ViewModel changes

---

*Last updated: May 2026*
