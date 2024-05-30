# Selenium Automation 

### Automatin Project Created With
- Selenium WebDriver
- xUnit
- C#
- .Net
- Visual Studio IDE
- Allure
-Karate

## Setup
1. Clone repository ``https://github.com/kvale17/SeleniumAutomationCS.git``
2. Restore project ``dotnet restore``

## Run UI Tests
``dotnet test``

## Generate and Open Allure Report for UI Tests
``allure serve``

## Run Karate API Tests
```java -jar KarateTests\karate.jar KarateTests\*.feature```

## Open Karate Test Report
```start KarateTests\target\karate-reports\karate-summary.html```
