# MBApps — Hybrid MVC + Blazor Server Boilerplate

## Stack
- ASP.NET Core 8 MVC + Blazor Server (hybrid)
- Radzen Blazor components
- Blazored.LocalStorage / SessionStorage
- Blazorise
- FluentValidation
- Newtonsoft.Json
- MySQL (via MBApiLibrary)

## Project References
- `MBApiLibrary` — shared data access and models library

## Folder Structure

```
MBApps/
├── Applications/          # Blazor components organized by module
│   ├── SampleModule/
│   │   └── Blazor/
│   │       └── _SampleComponent.razor
│   └── Vars/              # Global app variables/constants
├── Controllers/           # MVC Controllers
├── DataAccess/            # Local data access (if any outside MBApiLibrary)
├── keys/                  # Security keys / certs
├── Models/                # MVC ViewModels
├── Reports/               # Report definitions
├── StartupConfig/         # Extension methods for Program.cs
│   └── Library/           # Scoped service classes (SessionService, etc.)
├── Views/                 # MVC Razor Views (.cshtml)
│   ├── Home/
│   ├── Sample/
│   └── Shared/            # Layouts
├── wwwroot/               # Static files
├── _Imports.razor         # Global Blazor using directives
├── Program.cs
└── appsettings.json
```

## Pattern: MVC View hosting a Blazor Component

**Controller:**
```csharp
public IActionResult Index() => View();
```

**View (.cshtml):**
```cshtml
@inject UserClaimsContextService _claimsContext
@{
    Layout = "~/Views/Shared/_MainLayout.cshtml";
    var uc = _claimsContext.Build(User);
}
<div>
    @(await Html.RenderComponentAsync<_YourComponent>(RenderMode.ServerPrerendered, new { UserClaims = uc }))
</div>
```

**Component (.razor):**
```razor
<div class="card">
    <!-- your UI here -->
</div>

@code {
    [Parameter] public UserClaimsModel? UserClaims { get; set; }
}
```

## TODOs after cloning
1. Update `appsettings.json` — connection strings, domain, company info
2. Add your `AddApiInjectionServices()` scoped registrations in `StartupConfig/ApiExt.cs`
3. Replace `object` with actual `UserClaimsModel` in `UserClaimsContextService` and components
4. Add your modules under `Applications/`
5. Register additional scoped services in `StartupConfig/MBAppsScope.cs`
