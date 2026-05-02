# Number To Words Converter (ASP.NET Core MVC)

This is a simple ASP.NET Core MVC application that converts numeric currency values into their equivalent words.

Example:

Input: `123.45`  
Output: `ONE HUNDRED TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS`

---

## Overview

The goal of this project is to demonstrate clean service-based architecture, proper separation of concerns, and a consistent response model for both UI and API interactions.

The application takes a numeric value from the UI, processes it in the service layer, and returns a structured response that is consumed via AJAX.

---

## Features

- Converts decimal currency values into words
- Handles dollars and cents separately
- Supports correct singular and plural formatting
- Input validation (including negative values)
- Consistent API response structure using `ServiceResponse<T>`
- Status codes managed using enums with metadata attributes
- AJAX-based UI without full page refresh
- Unit tested service and controller logic

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

## Tech Stack

- ASP.NET Core MVC (.NET 8)
- C#
- jQuery (AJAX)
- xUnit (unit testing)
- In-memory fake implementations for testing

> No external mocking frameworks were used to keep tests simple and dependency-free.

---

## Response Format

All service responses follow a consistent structure:

```json
{
  "success": true,
  "data": "ONE HUNDRED DOLLARS",
  "code": "NTW01",
  "message": "Conversion completed successfully"
}