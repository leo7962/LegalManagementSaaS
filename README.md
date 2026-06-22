# LegalManagementSaaS

LegalManagementSaaS is a web application for managing legal cases, clients and related workflows. It combines a .NET backend and a React + TypeScript frontend to deliver a modern, full-stack SaaS experience for legal teams.

## Key Features
- Case and client management
- Role-based access (placeholder)
- CRUD APIs for core domain entities
- SPA frontend built with React and TypeScript

## Architecture
- Backend: .NET 10 (ASP.NET Core) — RESTful API and business logic
- Frontend: React + TypeScript — located in `legalmanagementsaas.client`
- Solution: `LegalManagementSaaS.slnx` at the repository root

## Prerequisites
- .NET 10 SDK (dotnet) — https://dotnet.microsoft.com/
- Node.js (LTS) and npm — https://nodejs.org/
- Optional: Visual Studio 2022/2026 or VS Code

## Quickstart (Development)

1. Clone the repository

   git clone https://github.com/leo7962/LegalManagementSaaS.git
   cd LegalManagementSaaS

2. Restore and build the .NET solution

   dotnet restore "LegalManagementSaaS.slnx"
   dotnet build "LegalManagementSaaS.slnx"

3. Install frontend dependencies and start the client

   cd legalmanagementsaas.client
   npm install
   npm start

   The client typically runs at http://localhost:3000 (check console output).

4. Run the backend API (from solution root or using Visual Studio)

   dotnet run --project <path-to-backend-project>

   Replace `<path-to-backend-project>` with the actual backend project path in the solution. In Visual Studio open `LegalManagementSaaS.slnx` and run the solution to launch both backend and frontend (if configured).

## Configuration
- Environment variables and secrets should be provided via .env files or your preferred secret manager. Typical values include database connection strings, JWT secrets, and third-party API keys.

## Testing
- Run .NET tests:

  dotnet test

- Run frontend tests (if present):

  cd legalmanagementsaas.client
  npm test

## Build & Production
- Produce a production build of the frontend:

  cd legalmanagementsaas.client
  npm run build

- Host the built frontend with any static host or serve it from the backend by configuring static file middleware.
- Use standard deployment patterns for ASP.NET Core (containerization, cloud services, or IIS).

## Contributing
- Fork the repository, create a feature branch, make changes, and open a pull request.
- Follow the existing code style and include tests for new behavior when applicable.

## License
This project is provided under the MIT License — see the LICENSE file for details (if present).

## Contact
For questions or issues, open an issue on the project's GitHub repository.

---
Generated README for the LegalManagementSaaS project.
