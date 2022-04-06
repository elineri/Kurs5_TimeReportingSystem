# TimeReportingSystem

## INTRODUCTION
This is a school project to create a backend for a time reporting system. 

## TABLE OF CONTENTS
* [API-CALLS FOR PROJECT REQUIREMENTS](#API---CALLS-FOR-PROJECT-REQUIREMENTS)
* [USING THE PROGRAM](#USING-THE-PROGRAM)
* [ABOUT THE PROGRAM (VG)](#ABOUT-THE-PROGRAM-(VG))

## API-CALLS FOR PROJECT REQUIREMENTS
### 1. Get detailed information about a specific employee and their time reports
- https://localhost:44397/api/employees/time/1
- For another employee change 

### 2. Get all employees working with a specific project
- https://localhost:44397/api/projects/1/employees
- To get data for another project change the id in the URL (.../projects/[id]/employees)

### 3. Get the amount of hours a specific employee have worked a specific week
- https://localhost:44397/api/timereports/1/year=2022/week=9
- To get data for another employee, year or week edit the brackets in the URL (.../timereports/[id],year=[year]/week=[week])

### 4. Add, Update and Delete an Employee
- 
-
-

### 5. Add, Update and Delete a Project
-
-
-

### 6. Add, Update and Delete a Time report
-
-
-

## USING THE PROGRAM
This is only the backend of the time reporting system. Run the program and use the API-calls in your browser or in the Postman client.

## ABOUT THE PROGRAM (VG)
### Models
The requirement for this program was to have at least three models (Employee, Project and TimeReport). I have chosen to use the TimeReport model as a joining table for many to many relationships. 

### Methods/Interface

