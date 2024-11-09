# C# Test Templates

This project aims to provide some test templates with examples in C# Programming Language. The idea is to present all type of possible tests (as a Performance, Stress, Load, Mutant, Acessibility, etc) in different contexts, services and apps.

However, inittially it's focused just in Unit, Integration and E2E Tests.

## Documentation

<details open="open">
<summary>Test Types</summary>

- [Unit Tests](#unit-tests)
- [Integration Tests](#integration-tests)
- [E2E Tests](#e2e-tests)

</details>

---

## Requirements

- .Net Core 3.1
- Docker
- Docker Compose
- Xunit
- Selenium
- RestSharp
- Moq

### Unit Tests

The purpose of this type of test is to validate that each unit of the software code performs as expected. Usually these tests are created and performed during the development and the most of the bugs in software can be identified in this activity.

To create a better understanding about these tests, it was created an templates to use it with business rules or data access. The both approach are focused in minor part of the software, i.e method, and all integrated parts with other softwares or technologies are mocked using Moq.

To run these tests, it's possible use directly the 'Test Explorer' interface or by command line (```dotnet test```).

### Integration Tests

Integration Tests we are focused in validate the service layer, which other services are called by our application. For it, it was create some tests to check some HTTP status code in GET and POST methods.

To run these tests, it's possible use directly the 'Test Explorer' interface or by command line (```dotnet test```).

#### E2E Tests

Lastly, we create a test to check a fake website using Selenium. This type of test needs to be considered in smaller scale than unit and integration tests.

To run these tests, it's necessairy to up docker compose.: 
```docker-compose up``` it's possible use directly the 'Test Explorer' interface or by command line (dotnet test).

These test are performed in Selenium Grid and to view in real time the execution is necessairy use remote desktop softwares as "VCN Viewer".

it's possible use directly the 'Test Explorer' interface or by command line (```dotnet test```).

## Contacts and Maintainers

If you have questions or suggestions, please contact the current maintainers.

andrevdrodrigues@gmail.com