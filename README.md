# Quality Assurance and Verification in SDLC (C# and .NET)

This repository demonstrates how to set up automated verification for your code in C# and .NET. It focuses on key verification topics essential for ensuring the quality of your software:

- **Unit Testing**  
  Validates that small units of your code, such as individual class methods, function as designed.

- **Integration Testing**  
  Confirms that multiple components or modules work together as intended.

- **End-to-End Testing**  
  Ensures that the entire system can support real-world user journeys effectively.

## Run Locally

1. Clone Repository
2. Install Extensions
3. Run tests from the `Test Explorer` tab
4. Watch Output

## Setup for own projects

1. Create a new solution

    ```sh
    dotnet new sln
    ```

2. Create a new project

    ```sh
    dotnet new console --output Application
    ```

3. Create a new test project

    ```sh
    dotnet new xunit --output Application.Tests
    ```

4. Link everything up

    ```sh
    dotnet sln add Application
    dotnet sln add Application.Tests
    ```
    
5. Add the `Application` to the Tests dependency

    ```sh
    dotnet add Application.Tests reference Application
    ```

6. Setup you IDE with a visualizer, like [.NET Core Test Explorer](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer)

7. Open test explorer and run tests.

8. Add more tests to the project.

## Terminology

### Software Development Life Cycle (SDLC) Phases

The Software Development Life Cycle (SDLC) outlines the steps for developing a software product. While there are variations, this repository assumes an iterative, DevOps-based SDLC with the following phases:

1. **Plan**  
   Conduct market research, define problems, and produce actionable solutions using specified architectures and designs.

2. **Implement**  
   Develop or modify code to meet the specifications defined during the planning phase.

3. **Verification**  
   Test the system against the specifications to confirm it solves the given problem. This includes activities such as:
   - Code style checks (linting)
   - Build validation (smoke testing)
   - Unit testing (validating methods and units of work)
   - Integration testing
   - End-to-end testing and more

4. **Delivery**  
   Package the system into a new release, apply versioning (e.g., Semantic Versioning), and publish it to a registry.

5. **Deploy**  
   Prepare and launch the software, including last-mile configurations like hosting on a server, assigning a domain name, and enabling TLS certificates.

6. **Operation**  
   Maintain and support the software, ensuring it remains functional and available.

7. **Monitoring**  
   Collect feedback from users and system instrumentation to gather insights. Use metrics such as performance data, error rates, and user behavior to inform the next iteration of the development cycle.

### Key Concepts

- **Verification**  
  Verification ensures that the software behaves as intended, answering questions like:  
  - Can the system run successfully?  
  - Can users sign in?  
  - Does the resource class handle CRUD operations correctly?  
  - Are edge cases accounted for?

- **Validation**  
  Validation determines if the software meets actual user needs. This step is broader and aims to answer:  
  - Did we design the right product?  

### Aspects to Verify

TODO! Aggregate and collect this to a more ingestible set of categories. It's just a brain dump, with duplicates, at the moment.
This section provides an overview of various aspects of software verification. Examples are included to illustrate each concept.

- **Latency**  
  Measure the time it takes for the system to respond to a request.  
  *Example:* Checking the time it takes for an API to return a response for a given query.

- **Resource Consumption**  
  Monitor how much memory, CPU, disk space, or network bandwidth the system uses during operation.  
  *Example:* Measuring memory usage during a bulk data import.

- **Load Testing**  
  Assess the system's performance under varying levels of demand.  
  *Example:* Simulating 1,000 concurrent users accessing a website.

- **Resiliency**  
  Test how well the system recovers from failures or adverse conditions.  
  *Example:* Simulating a network outage to test retry mechanisms.

- **Scalability**  
  Verify the system's ability to handle increasing loads.  
  *Example:* Ensuring that adding additional servers improves response times.

- **Compliance**  
  Ensure adherence to relevant regulations and standards.  
  *Example:* Verifying GDPR compliance by testing for proper handling of user consent.

- **Correctness**  
  Validate that the software behaves as specified in the requirements.  
  *Example:* Ensuring that a calculator correctly adds two numbers.

- **Contract Testing**  
  Check that APIs and interfaces adhere to their defined specifications.  
  *Example:* Validating that a REST API returns the correct status codes and data formats.

- **Units of Work**  
  Test individual methods or functions for correctness.  
  *Example:* Writing a unit test for a function that calculates tax rates.

- **Fuzz Testing**  
  Use randomized or invalid inputs to uncover bugs and vulnerabilities.  
  *Example:* Sending malformed JSON to an API endpoint to test error handling.

- **Property Testing**  
  Verify that a method holds true under various inputs by exploring edge cases.  
  *Example:* Testing that a sorting function works regardless of array size or order.

- **Integration Testing**  
  Confirm that modules work together as intended.  
  *Example:* Testing the interaction between a web application and its database.

- **User Journeys**  
  Simulate real-world workflows from a user's perspective.  
  *Example:* Testing the end-to-end process of user registration and login.

- **Security**  
  Assess the system’s ability to protect against threats.  
  *Example:* Testing for SQL injection vulnerabilities.

- **Performance**  
  Evaluate throughput and response times under normal and peak conditions.  
  *Example:* Measuring the time it takes to process 1,000 database transactions.

- **Accessibility**  
  Ensure usability by people with disabilities, adhering to WCAG standards.  
  *Example:* Testing screen reader compatibility on a web form.

- **Maintainability**  
  Test how easily the system can be updated or debugged.  
  *Example:* Reviewing code for adherence to coding standards and documentation.

- **Portability**  
  Check if the system runs on different environments with minimal changes.  
  *Example:* Verifying that a web app works across Chrome, Firefox, and Safari.

- **Observability**  
  Ensure the system provides adequate logs, metrics, and traces for diagnosis.  
  *Example:* Checking that all API errors are logged with sufficient details.

- **Usability**  
  Assess how intuitive and user-friendly the system is.  
  *Example:* Conducting a usability test for a new feature in a mobile app.

- **Internationalization (i18n) and Localization (l10n)**  
  Verify support for multiple languages and regional formats.  
  *Example:* Testing currency formatting for users in the US, UK, and Japan.

- **Data Integrity**  
  Ensure data is stored and processed without corruption.  
  *Example:* Verifying that a database maintains consistent data during updates.

- **Backward Compatibility**  
  Ensure new changes don’t break older versions.  
  *Example:* Checking that an updated API version supports older client applications.

- **Regressions**  
  Ensure resolved issues do not reappear in newer versions.  
  *Example:* Running regression tests on a critical bug fix after every release.

- **Convergence Rate**  
  Verify synchronization in eventually consistent systems.  
  *Example:* Testing database replicas for consistency after updates.

- **Deterministic Simulation Testing**  
  Simulate reproducible usage patterns to observe expected outcomes.  
  *Example:* Running the same sequence of events in a simulation to ensure results match.

- **Concurrency**  
  Test how the system handles multiple operations simultaneously.  
  *Example:* Checking for race conditions in a shared resource.

- **State Management**  
  Validate transitions and persistence of application states.  
  *Example:* Testing session state consistency across page reloads.

- **Error Handling**  
  Test how the system responds to unexpected inputs or situations.  
  *Example:* Verifying that invalid login attempts display appropriate error messages.

- **Configuration Management**  
  Ensure robust and flexible configuration without causing failures.  
  *Example:* Testing different combinations of environment variables.

- **Versioning**  
  Verify compatibility between different versions of APIs or libraries.  
  *Example:* Testing a new library version in an existing project.

- **Chaos Testing**  
  Introduce random failures to assess system robustness.  
  *Example:* Terminating a server instance to test failover mechanisms.

- **Business Logic Validation**  
  Ensure domain-specific rules and workflows function as required.  
  *Example:* Verifying that discounts are applied correctly during checkout.

- **Redundancy**  
  Test the replication of critical components for fault tolerance.  
  *Example:* Ensuring a database cluster remains operational after a node failure.

- **Deployment Verification**  
  Check the application’s availability and configuration after deployment.  
  *Example:* Testing a deployed app’s endpoint to verify accessibility.

- **Interoperability**  
  Validate seamless interaction with third-party tools or systems.  
  *Example:* Testing integration with a payment gateway.

- **Event Handling**  
  Test how the system produces, consumes, and reacts to events.  
  *Example:* Ensuring that a message queue processes events in the correct order.

- **Logging and Audit Trails**  
  Verify that logs capture critical operations and maintain an audit trail.  
  *Example:* Ensuring login attempts are logged with timestamps and user details.
