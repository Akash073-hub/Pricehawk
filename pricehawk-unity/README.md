# PriceHawk for Unity

This is a Unity version of the PriceHawk React Native demo in `../pricehawk`. It recreates the Home, Product, Alerts, and Spend views as a responsive Unity UI. Product prices and alert states are saved locally with `PlayerPrefs`.

## Open and run

1. Install Unity 2022.3 LTS or newer with the modules for your target platform.
2. In Unity Hub, choose **Add project from disk** and select this `pricehawk-unity` folder.
3. Wait for Unity Package Manager to resolve `com.unity.ugui`.
4. Unity automatically creates `Assets/Scenes/PriceHawk.unity` and adds it to the build scene list. Press **Play**. The app creates its canvas and EventSystem automatically at startup, so the scene does not need other objects.
5. To make a build, select Android, iOS, or another target in **File → Build Settings**, then choose **Build**. The startup scene is registered automatically.

## Features

- Dashboard with six tracked iPhone models and mock discounts.
- Product view with selectable products, time ranges, price history, store comparisons, and a simulated ₹2,000 price drop.
- Price alerts with target validation, deletion, and simulated price changes.
- Spend overview with budget, category, monthly, and recent order summaries.
- Local persistence of demo prices and alerts.

The app uses the same sample data as the React Native prototype. It does not fetch real retailer prices or send operating system notifications; messages from simulated alert hits are written to the Unity Console.

## Project files

- `Assets/Scripts/PriceHawkApp.cs` – app bootstrap, UI, demo data, interactions, and persistence.
- `Assets/Editor/PriceHawkProjectSetup.cs` – creates and registers the startup scene when opened in the Unity Editor.
- `Packages/manifest.json` – Unity UI package dependency.
- `ProjectSettings/ProjectVersion.txt` – Unity Editor version used for this project.
