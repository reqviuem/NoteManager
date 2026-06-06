# NoteManager

A full-stack note management application built with ASP.NET Core and Angular.

---

## Prerequisites

Install the following:

- [Docker](https://www.docker.com/products/docker-desktop)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8)
- [Node.js](https://nodejs.org/) (v24 or higher)

---

## Running the Backend

### 1. Start the database

From the solution root:

```bash
docker compose up -d
```

This starts a PostgreSQL 16 database on port `5433`.

### Data

The database comes pre-loaded with 7 sample notes automatically when the API starts for the first time.

### 2. Run the API

```bash
cd NoteManager.API
dotnet run
```

The API will start on `http://localhost:5159`.

Entity Framework migrations run automatically on startup.

---

## Running the Frontend

Open a new terminal:

```bash
cd note-manager-client
npm install
npm start
```

The app will be available at `http://localhost:4200`.

### Language support

The app supports English, Spanish, Bulgarian and Austrian German. Use the language switcher in the top right corner.

---

## Running the E2E Tests

Make sure both the backend and frontend are running, then:

```bash
cd note-manager-client
npx cypress open
```

In the Cypress window select **E2E Testing**, then click **notes.cy.ts** to run the tests.

To run tests without the UI:

```bash
npx cypress run
```

---
