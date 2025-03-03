# Web App with JWT Authentication and Role-Based Access Control

## Overview

This web application implements JWT (JSON Web Token) authentication and role-based access control. The application restricts access to certain endpoints based on user roles.

## Challenge #2

### Objective

Implement JWT Auth and at least 2 different User Roles in the app. 

### Restricted Endpoints

The following endpoints are restricted to users with the **Admin** role:

- `POST /api/QuizRecords/createrecord`
- `DELETE /api/QuizRecords/{recordId}`

### Authorization

The application uses the `[Authorize(Role="Admin")]` attribute to ensure that only users with the Admin role can access these endpoints.

## User Accounts

### Admin Account

- **Username**: admin
- **Password**: test

### User Account

- **Username**: Henry
- **Password**: test

## Testing with Postman

Postman tests have been created for the restricted endpoints to confirm that the application returns the correct status codes when accessed with an Admin account.

- **Expected Status Codes**:
  - `POST /api/QuizRecords/createrecord`: Should return `201 Created` when accessed with an Admin account.
  - `DELETE /api/QuizRecords/{recordId}`: Should return `200 OK` when accessed with an Admin account.

### Postman Documentation

You can find the Postman documentation and testing details at the following link:

https://dev.azure.com/erniegh/ERNI-EPM-University/_backlogs/backlog/ERNI-EPM-University%20Team/Epics?workitem=166665 
