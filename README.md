# TimeReportingSystem

## INTRODUCTION
This is a school project to create a backend for a time reporting system. A database has been created with Entity Framework and a repository pattern has been used. REST API

## TABLE OF CONTENTS
* [USING THE PROGRAM](#USING-THE-PROGRAM)
* [ABOUT THE PROGRAM (VG)](#ABOUT-THE-PROGRAM)
* [API-CALLS FOR PROJECT REQUIREMENTS](#API-CALLS-FOR-PROJECT-REQUIREMENTS)

## USING THE PROGRAM
This is only the backend of the time reporting system. Run the program and run the API-calls in your browser or in the Postman client.

## ABOUT THE PROGRAM
### Models
The requirement for this program was to have at least three models (Employee, Project and TimeReport) for the database. I have chosen to use the TimeReport model as a joining table for many to many relationships. You will have worked hours, date and note in the time reports and this should all be connected to an employee and which project this is connected to. So using the TimeReport model as a joining table fits perfectly i think. I haven't added any more models other than what was required but depending on the project/company that uses the time reporting system more tables could be added if necessary and connected to the TimeReport model.

Properties requirements and limitation. !TODO!

### Interface
I have chosen to use one interface for all classes. All classes use five base methods (GetAll, GetSingle, Add, Update and Delete) and then there are three class specific methods (EmployeeReportedTime, ProjectEmployees, EmployeeReportedTimeWeek). Instead of creating more interfaces I have chosen just to not implement the class specific methods in the classes where it's not needed to keep the program more readable and simple. If this was a bigger program it might be a good idea to create more interfaces.

## API CALLS FOR PROJECT REQUIREMENTS
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



