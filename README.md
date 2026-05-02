# Number To Words Converter (ASP.NET Core MVC)

This is a simple ASP.NET Core MVC application that converts numeric currency values into their equivalent words.

Example:

Input: `123.45`  
Output: `ONE HUNDRED TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS`

---

## Overview

The goal of this project is to demonstrate clean service-based architecture, proper separation of concerns, and a consistent response model for both UI interactions.

The application takes a numeric value from the UI, processes it in the service layer, and returns a structured response that is consumed via AJAX.

---

## Features

- Converts decimal currency values into words
- Handles dollars and cents separately
- Supports correct singular and plural formatting
- Input validation (including negative values)
- Consistent response structure using `ServiceResponse<T>`
- Status codes managed using enums with metadata attributes
- AJAX-based UI without full page refresh
- Unit tested service and controller logic

---

## Tech Stack

- ASP.NET Core MVC (.NET 8)
- C#
- jQuery (AJAX)
- xUnit (unit testing)
- In-memory fake implementations for testing

> No external mocking frameworks were used to keep tests simple and dependency-free.

---

## How to Run  

1. Clone the repository  
git clone https://github.com/InnovationCoreTechnology/NumberToWordsConverter.git  

2. Navigate to project folder  
cd NumberToWordsConverter  

3. Restore dependencies  
dotnet restore  

4. Run the application  
dotnet run  

5. Open browser  
https://localhost:7443  

---

## Architecture

The solution follows a layered architecture approach:

- Controller Layer – handles HTTP requests and responses  
- Service Layer – contains core conversion logic  
- Common Response Model – ensures consistent API structure  
- Enum + Attribute-based status system – standardizes response codes and messages  
- Test Layer – uses fake implementations for isolated testing  

The design focuses on readability, maintainability, and separation of concerns.

---

## Controller Interaction (MVC + AJAX Flow)

This application does not expose a standalone Web API.  
Instead, it uses ASP.NET Core MVC Controller actions with AJAX-based communication from the UI.

### Convert Number To Words

**Controller Action:**  
POST /NumberToWords/NumberToWordsIndex  

---

### Request Payload (AJAX)

```json
{
  "amount": 123.45
}
