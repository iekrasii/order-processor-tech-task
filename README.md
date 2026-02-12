# Order Processor Tech Task

## Project Overview

This is an asynchronous order processing app built with C#/.NET. It processes multiple orders concurrently, validates them, and logs the results.

## How to Run

### Prerequisites
- .NET SDK 8.0 or higher

### Running the Application

From the directory /OrdersProcessor run:
```bash
dotnet run
```

From the directory /OrdersProcessor.Tests run:
### Running Tests
```bash
dotnet test
```

## Architecture Diagram

```mermaid
flowchart LR
    Program.cs --> ServiceContainer
    ServiceContainer --> OrderService
    OrderService -->|in parallel| ProcessOrderAsync
    ProcessOrderAsync --> Logging[Success or Failure Log]
```

## Completed Bonus Tasks

- ✅ 1: Asynchronous Processing
- ✅ 2: Add Order (CRUD)
- ✅ 3: IOrderValidator
- ✅ 4: Unit Tests
- ✅ 5: Configuration via appsettings.json