# myOnionAndPotatoApp — Development Roadmap

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
- **Data persistence** — save counts locally (Preferences for MVP, SQLite later)
- **UI & micro-interactions** — layouts, animations, optional sound
- **Notifications** — daily check-ins and low-stock alerts
- **Professional workflow** — clean structure, testing, documentation

---

## Current status (June 2026)

- **Phase 1:** Complete  
- **Phase 2:** In progress — +/- commands and non-negative counts working on Android device  
- **Next:** Preferences persistence, then activity log + LogViewModel  

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
- [x] UI shell: HomePage, LogPage, PantryCard (count display; +/- wired in Phase 2)
- [x] Dependency injection in `MauiProgram.cs`
- [x] Deploy to Android device

### Key files

- `SpudAndUi/Models/VegetableItem.cs`
- `SpudAndUi/ViewModels/HomeViewModel.cs`
- `SpudAndUi/Views/HomePage.xaml`, `SpudAndUi/Views/LogPage.xaml`
- `SpudAndUi/Components/PantryCard.xaml`
- `SpudAndUi/AppShell.xaml`, `SpudAndUi/MauiProgram.cs`
- `SpudAndUi/Components/PantryCard.xaml.cs` (command bindable properties)
- `SpudAndUi/MyOnionAndPotatoApp.csproj` (app project; `JavaSdkDirectory` set for Windows builds)

---

## Phase 2: Core Tracking Logic

**Goal:** Working +/- buttons, persistence, and a basic activity log.

### Tasks

- [x] Wire +/- buttons on `PantryCard` to `HomeViewModel` commands
- [x] Prevent negative counts (minimum 0)
- [ ] Persist pantry state locally (SQLite or Preferences for MVP)
- [ ] Load saved counts on app start
- [ ] Log entries when items are added or used (timestamp + vegetable + delta)
- [ ] Bind `LogPage` to a `LogViewModel` showing history (newest first)
- [ ] Empty state when no log entries exist

### Learning focus

- `ICommand` / `[RelayCommand]` from CommunityToolkit.Mvvm
- Passing commands into `PantryCard` via bindable properties
- `HomePage` gets `HomeViewModel` in `OnHandlerChanged` (Shell + `DataTemplate` + DI)
- `VegetableItem` as `ObservableObject` for live count updates
- Async save/load patterns (next: Preferences persistence)
- Single source of truth for pantry state
- Debugging Appshell issues 

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
- `JAVA_HOME` → `C:\Program Files\Android\Android Studio\jbr` (if not set in `.csproj`)
- `ANDROID_HOME` → `%LOCALAPPDATA%\Android\Sdk`

> **Note:** `MyOnionAndPotatoApp.csproj` sets `JavaSdkDirectory` when Android Studio’s JBR exists on `C:`, so you may not need manual `JAVA_HOME` in every terminal.

### Deploy to phone (USB or wireless)

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

Copy to your device and install manually if deploy from the PC is unavailable.

### Troubleshooting

| Error | Likely fix |
|-------|------------|
| `XA5300` — Java SDK not found | Set `JAVA_HOME` or build with `-p:JavaSdkDirectory="C:\Program Files\Android\Android Studio\jbr"` |
| `XA0010` — No available device | Connect phone via USB/wireless debugging; run `adb devices` |
| Active Shell item not set | Ensure `AppShell.xaml` has tabs; `HomePage` loads `HomeViewModel` via `OnHandlerChanged` |

---

## Architecture (MVVM)

```
myOnionAndPotatoApp/
  ROADMAP.md
  SpudAndUi/                    ← MAUI app folder
    MyOnionAndPotatoApp.csproj  ← build entry (namespace: SpudAndUi)
    Models/          → VegetableItem (+ log entries in Phase 2)
    ViewModels/      → HomeViewModel (+ LogViewModel in Phase 2)
    Views/           → HomePage, LogPage (XAML)
    Components/      → PantryCard (+/- command bindings)
    AppShell.xaml    → Tab navigation (Pantry + Log)
    MauiProgram.cs   → DI registration
```

---

## Comprehension checkpoints

### Phase 1

1. What MVVM is and why Model, View, and ViewModel are separated
2. What `[ObservableProperty]` does and why we use it
3. What data binding is and how the View updates when the ViewModel changes

### Phase 2 (after tasks 1–2)

1. How `[RelayCommand]` exposes `IncreasePotatoCommand` to XAML
2. Why `PantryCard` uses bindable properties for `IncreaseCommand` / `DecreaseCommand`
3. Why changing `Potato.Count` requires `VegetableItem` to be observable

---

*Last updated: 3 June 2026*
