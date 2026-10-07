# Time Exchange Platform

A web application for exchanging skills and services using **time points** instead of money. Users publish offers, request help through agreements, and transfer hours when a provider accepts an exchange.

## Features

- **User accounts** — register, log in, log out (ASP.NET Core Identity)
- **Password reset** — email-based reset flow via SMTP
- **Service offers** — browse active offers, view details, create and delete offers
- **Agreements** — request an exchange for a number of hours; providers can accept or cancel
- **Time points** — when a provider accepts, hours move from the receiver’s balance to the provider’s
- **My Agreements** — view your balance and all agreements where you are provider or receiver
- **Docker Compose** — run the app and PostgreSQL together

> Models for skills, service requests, reviews, and notifications exist in the database layer and are reserved for future features.

## Tech stack

| Layer | Technology |
|--------|------------|
| Runtime | .NET 10 |
| Web | ASP.NET Core MVC (Razor views) |
| Auth | ASP.NET Core Identity |
| ORM | Entity Framework Core 10 |
| Database | PostgreSQL (Npgsql) |
| Email | SMTP (`EmailSettings`) |
| UI | Bootstrap, jQuery |
| Containers | Docker / Docker Compose |

## How it works

1. A user creates an **offer** (title, category, description).
2. Another user opens the offer and creates an **agreement** for N hours.
3. The offer is marked inactive once an agreement is created.
4. The **provider** (offer owner) can **accept** or **cancel** a pending agreement.
5. On **accept**, the receiver must have enough time points; then:
   - receiver balance decreases by N hours
   - provider balance increases by N hours

### Agreement statuses

| Status | Meaning |
|--------|---------|
| `Pending` | Waiting for the provider |
| `Accepted` | Provider accepted; time points transferred |
| `Cancelled` | Provider cancelled |
| `Completed` | Reserved for future use |

Only the provider can change status, and only while the agreement is still `Pending`.

## Project structure

```
TimeExchangePlatform/
├── Controllers/          # Account, Offer, Agreement
├── Data/                 # TEPDbContext (EF Core)
├── Models/               # Domain entities & enums
├── ViewModels/           # Form / page models
├── Views/                # Razor UI
├── Services/             # Offer, Agreement, Email services
├── Migrations/           # EF Core migrations
├── wwwroot/              # Static assets (CSS, JS, libs)
├── Properties/           # launchSettings.json
├── Dockerfile
├── docker-compose.yml
├── appsettings.json
└── Program.cs
```

### Main routes

| Area | Route | Auth |
|------|--------|------|
| Offers list (home) | `/Offer/Index` | Public |
| Offer details | `/Offer/OfferDetails?offerId=` | Public |
| Create offer | `/Offer/CreateOffer` | Required |
| Delete offer | `POST /Offer/DeleteOffer` | Required |
| Create agreement | `/Agreement/CreateAgreement?offerId=` | Required |
| My agreements | `/Agreement/GetUserAgreements` | Required |
| Accept / cancel | `POST` on Agreement actions | Required (provider) |
| Login / Register | `/Account/Login`, `/Account/Register` | Public |
| Password reset | `/Account/VerifyEmail` → email → `/Account/ChangePassword` | Public |

Default route: `{controller=Offer}/{action=Index}/{id?}`.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/) (for local runs without Docker)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (optional, for Compose)

## Getting started

### Option A — Docker Compose (recommended)

From the project root:

```bash
docker compose up --build
```

- App: [http://localhost:5000](http://localhost:5000)
- PostgreSQL: `localhost:5432`

Migrations run automatically on startup (`Database.Migrate()` in `Program.cs`).

Stop with `Ctrl+C`, or in detached mode:

```bash
docker compose up --build -d
docker compose down
```

### Option B — Local development

1. Start PostgreSQL and create a database (default name: `TimeExchangePlatformDb`), or use the Compose `db` service only:

   ```bash
   docker compose up db -d
   ```

2. Set the connection string (see [Configuration](#configuration)).

3. Restore and run:

   ```bash
   dotnet restore
   dotnet run
   ```

4. Open the app:
   - HTTP: [http://localhost:5296](http://localhost:5296)
   - HTTPS: [https://localhost:7109](https://localhost:7109)

Migrations are applied on startup; you do not need to run `dotnet ef database update` manually unless you prefer to.

## Configuration

Settings live in `appsettings.json` / environment variables (double underscore for nesting).

### Connection string

```json
"ConnectionStrings": {
  "DatabaseConnectionString": "Host=localhost;Port=5432;Database=TimeExchangePlatformDb;Username=postgres;Password=YOUR_PASSWORD"
}
```

Environment variable example:

```text
ConnectionStrings__DatabaseConnectionString=Host=localhost;Port=5432;Database=TimeExchangePlatformDb;Username=postgres;Password=YOUR_PASSWORD
```

### Email (password reset)

```json
"EmailSettings": {
  "From": "your@email.com",
  "SmtpServer": "smtp.gmail.com",
  "Port": 587,
  "Username": "your@email.com",
  "Password": "YOUR_APP_PASSWORD"
}
```

For Gmail, use an [App Password](https://support.google.com/accounts/answer/185833), not your normal account password.

**Do not commit real SMTP passwords or production secrets.** Prefer [User Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) locally:

```bash
dotnet user-secrets set "EmailSettings:Password" "YOUR_APP_PASSWORD"
dotnet user-secrets set "ConnectionStrings:DatabaseConnectionString" "Host=localhost;Port=5432;Database=TimeExchangePlatformDb;Username=postgres;Password=YOUR_PASSWORD"
```

### Identity password rules (current)

- Minimum length: 8
- Non-alphanumeric / upper / lower: not required
- Unique email: required
- Confirmed email: not required for sign-in

## Domain model (overview)

| Entity | Role |
|--------|------|
| `User` | Identity user + profile fields (`FullName`, `Bio`, `City`, `TimePoints`, `IsPremiumMember`, …) |
| `Offer` | Service listing owned by a user (`IsActive` filters the catalog) |
| `Agreement` | Exchange between provider and receiver for an offer and hour count |
| `Skill` | User skills (schema ready) |
| `Request` | Service requests (schema ready) |
| `Review` | Ratings between users (schema ready) |
| `Notification` | User notifications (schema ready) |

## Development notes

- Services are registered in `Program.cs`: `IOfferService`, `IAgreementService`, `IEmailService`.
- Controllers stay thin; business logic for offers/agreements lives in the services layer.
- `[Authorize]` protects agreement actions and offer create/delete. Browsing offers is public.

## License

No license file is included in the repository yet. Add one if you plan to distribute or open-source the project.
