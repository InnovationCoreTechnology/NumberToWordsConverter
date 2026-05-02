# Number To Words Converter - Design & Approach Document

---

## 1. Problem Understanding

The requirement is to build a web-based application that converts a numeric currency input into its equivalent words representation.

The system should correctly handle:

- Numeric input conversion into words
- Currency format (Dollars and Cents)
- Proper grammatical structure (singular/plural rules)
- Clean and consistent output formatting through a web endpoint

### Example

**Input:**
123.45

**Output:**
ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS

---

## 2. Approach Implemented

### 2.1 Service Layer Based Architecture

The core conversion logic is implemented inside a dedicated service layer (`INumberToWordsService`) instead of placing logic inside the controller.

This ensures:

- Clear separation between API layer and business logic
- Reusability across multiple entry points (Web / API / Tests)
- Easier unit testing of business logic
- Better maintainability as system scales

---

### 2.2 MVC Pattern Selection

ASP.NET Core MVC was chosen instead of Minimal API because:

- The application includes a UI layer
- MVC provides structured separation (Controller, Model, View)
- Works well with AJAX-based interactions
- Easier organization for medium-complexity business logic

---

### 2.3 Separation of Responsibilities

The application follows clean separation of layers:

- **Controller** → Handles HTTP requests and responses
- **Service Layer** → Contains core business logic
- **Models** → Defines request and response contracts
- **Common Layer** → Shared response structure and utilities
- **Constants Layer** → Number mappings and currency definitions

---

## 3. Key Design Decisions

### 3.1 Standardized Service Response Wrapper

A generic response model (`ServiceResponse<T>`) is used across the application.

Benefits:

- Consistent API response structure
- Simplifies frontend handling (AJAX integration)
- Centralized success/failure handling

---

### 3.2 Enum + Attribute Based Status Handling

Instead of hardcoding messages and codes, an Enum + Attribute-based system is used.

Each status contains:

- Status Code (e.g., `NTW01`)
- Message (e.g., "Conversion completed successfully")

Benefits:

- Avoids duplication of string literals
- Centralized status management
- Easy to extend and maintain

---

### 3.3 Custom Number-to-Words Conversion Logic

A fully custom implementation is used instead of external libraries.

Reasoning:

- Full control over currency formatting (Dollars & Cents)
- Accurate grammatical handling (singular/plural rules)
- No external dependency risk
- Predictable behavior across environments

The logic is implemented in a modular and iterative way for readability and maintainability.

---

### 3.4 AJAX-Based UI Interaction

The frontend communicates with the backend using AJAX (jQuery-based implementation).

Flow:

1. User enters amount
2. Client-side validation runs
3. AJAX request sent to controller
4. Service processes request
5. JSON response returned
6. UI updates dynamically

Benefits:

- No full page reloads
- Better user experience
- Faster interaction
- Reduced server rendering overhead

---

## 4. Frontend Implementation

### 4.1 JavaScript (External JS File)

Responsibilities:

- Input validation (numeric + decimal rules)
- Prevent invalid formats
- AJAX request handling
- Loader management
- Error handling
- UI update logic

Key validations:

- Numeric only input
- Max 2 decimal places
- Max length restriction
- Prevent invalid zero values
- Range validation

---

### 4.2 UI (Razor View)

Built using:

- Bootstrap card layout
- Center-aligned form design
- Input + validation message
- Convert button
- Result display section

---

### 4.3 CSS (External File)

Improvements:

- Clean modern UI
- Rounded input fields
- Highlighted result box
- Responsive layout support
- Simple and readable design system

---

## 5. API Design (Controller)

### GET Endpoint

Returns the UI view:

- Initializes empty response model
- Loads Razor page

---

### POST Endpoint

Handles AJAX request:

- Accepts JSON input
- Calls service layer
- Returns structured `ServiceResponse<T>` JSON

---

## 6. Service Layer Design

### Responsibilities:

- Convert numeric amount into words
- Handle:
  - Dollars conversion
  - Cents conversion
  - Grammar rules
  - Edge cases (0, negative values)

---

### Conversion Strategy:

- Split input into:
  - Integer part → Dollars
  - Decimal part → Cents

- Uses:
  - Units (0–9)
  - Teens (10–19)
  - Tens (20–90)
  - Scales (Thousand, Million, etc.)

---

## 7. Testing Strategy

The application includes both **Service Layer Testing** and **Controller Layer Testing**.

---

### 7.1 Service Layer Testing

Real service implementation is tested directly.

Coverage includes:

- Negative values
- Zero values
- Whole number conversion
- Decimal handling
- Singular vs plural validation
- Edge cases

---

### 7.2 Controller Testing

Controller is tested using a **Fake In-Memory Service**:

- Isolates controller behavior
- Ensures API contract correctness
- Avoids dependency on business logic

---

### 7.3 Fake Service Implementation

Used for predictable test behavior:

- Returns fixed response
- Simulates success/failure cases
- Keeps controller tests lightweight

---

### 7.4 Test Helpers

Custom assertion extensions:

- `ShouldBeSuccess`
- `ShouldBeFailure`
- `ShouldContain`
- `ShouldNotContain`

Benefits:

- Improves readability
- Reduces repetitive assertions
- Faster test writing

---

## 8. Trade-offs

### 8.1 No External Libraries

✔ Full control over logic  
✘ More manual implementation effort  

---

### 8.2 Reflection-Based Status Handling

✔ Centralized metadata system  
✘ Minor runtime overhead  

---

### 8.3 Fake Services in Testing

✔ Simple and fast tests  
✘ Less flexibility than mocking frameworks  

---

## 9. Final Summary

This implementation follows production-ready Full Stack development principles with a strong focus on:

- Clean layered architecture
- Separation of concerns
- Service-based business logic
- Dependency-free implementation
- Consistent API response structure
- Fully tested service and controller layers
- Responsive AJAX-based UI with validation

### Final Outcome:

A scalable, maintainable, and testable system suitable for real-world enterprise applications and technical assessments.