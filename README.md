# TimeReportingSystem

## INTRODUCTION
This is a school project to create a backend for a time reporting system.

## TABLE OF CONTENTS
* [USING THE PROGRAM](#USING-THE-PROGRAM)
* [ABOUT THE PROGRAM (VG)](#ABOUT-THE-PROGRAM)
* [API-CALLS FOR PROJECT REQUIREMENTS](#API-CALLS-FOR-PROJECT-REQUIREMENTS)

## USING THE PROGRAM
This is only the backend of the time reporting system. Run the program and run the API-calls in your browser or in the Postman client.

## ABOUT THE PROGRAM
The time reporting system has been created with two projects (ClassLibrary and REST-API) in the same solution. A database has been build with Entity Framework

### Models
The requirement for this program was to have at least three models (Employee, Project and TimeReport) for the database. I have chosen to use the TimeReport model as a joining table for many to many relationships. You will have worked hours, date and note in the time reports and this should all be connected to an employee and which project this is connected to. So using the TimeReport model as a joining table fits perfectly. I haven't added any more models other than what was required but depending on the project/company that uses the time reporting system more tables could be added if necessary and connected to the TimeReports table.

Properties validation has been added for some properties. Range/Length for names, phone numbers and note for time report. There's also a limit how many hours you can report per day (24 hours). Worked hours is currently an int property but this could be changed to decimal depending on if the employees should be able to report half hours as well. 

### Interface
I have chosen to use one interface for all classes. All classes use five base methods (GetAll, GetSingle, Add, Update and Delete) and then there are three class specific methods (EmployeeReportedTime, ProjectEmployees, EmployeeReportedTimeWeek). Instead of creating more interfaces I have chosen just to not implement the class specific methods in the classes where it's not needed to keep the program more readable and simple. If this was a bigger program it might be a good idea to create more interfaces or if the classes didn't share as many methods as they do in this program.

### Methods/Controllers
#### All three classes implements the following methods
- GetAll
- GetSingle
- Add
- Update
- Delete

#### EmployeeReportedTime
- This method is implemented in the EmployeeRepo class. It takes an id as input, includes TimeReports table and returns detailed information about the employee with matching id and all the connected time reports from the TimeReports table.

#### ProjectEmployees
- This method is implemented in the ProjectRepo class. It takes an id as input and then checks if there is a project with matching id. If the id exists then it includes the TimeReports and Employees table and returns all employees who has reported time on the project id. 

#### EmployeeReportedTimeWeek
- This method is implemented in the TimeReportRepo class. It takes an id, year and week number as input. First it checks if there is an employee with the id in the system. If true it will call on the method GetFirstDayOfWeek, it will return the first day of the week (Monday) for selected year and week. The saved variable will be used to get time reports for the selected week where the employeeId is the same as the input id. The method EmployeeReportedTimeWeek will then return an integer of total hours the employee has worked that week. 

![TimeReportingSystem - Page 1 (2)](https://user-images.githubusercontent.com/91311233/162448745-e75a74f4-44db-426b-88c7-0c8239f33057.png)

## API CALLS FOR PROJECT REQUIREMENTS
### 1. Get detailed information about a specific employee and their time reports
- https://localhost:44397/api/employees/time/1
- For another employee change 

### 2. Get all employees working with a specific project
- https://localhost:44397/api/projects/2/employees
- To get data for another project change the id in the URL (.../projects/[id]/employees)

### 3. Get the amount of hours a specific employee have worked a specific week
- https://localhost:44397/api/timereports/1/year=2022/week=9
- To get data for another employee, year or week edit the brackets in the URL (.../timereports/[id],year=[year]/week=[week])

### 4. Add, Update and Delete an Employee
#### Add [POST]
- https://localhost:44397/api/employees
- In Postman go to Body and select raw and JSON
- {    "firstName": "Firstname", 
"lastName": "LastName",
"phoneNumber": "0700000000",
"email": "f.lastname@company.com",
"role": "Role",
"startDate": "2020-05-13T00:00:00"
 }
 
#### UPDATE [PUT]
- https://localhost:44397/api/employees/9
- In Postman go to Body and select raw and JSON
- {    "employeeId": 9,
    "firstName": "Oskar",
    "lastName": "Oskarsson",
    "phoneNumber": "0701231876",
    "email": "o.oskarsson@company.com",
    "role": "Frontend developer",
    "startDate": "2020-05-13T00:00:00",
    "endDate": null
}

#### DELETE [DELETE]
https://localhost:44397/api/employees/7

### 5. Add, Update and Delete a Project
#### ADD [POST]
- https://localhost:44397/api/projects
- In Postman go to Body and select raw and JSON
- {        "projectName": "World of Warcraft2"}
#### UPDATE [PUT]
- https://localhost:44397/api/projects/8
- In Postman go to Body and select raw and JSON
- {        "projectId": 8,        "projectName": "Hogwarts Harry Potter"    }
#### DELETE [DELETE]
- https://localhost:44397/api/projects/8

### 6. Add, Update and Delete a Time report
#### ADD [POST]
- https://localhost:44397/api/timereports
- In Postman go to Body and select raw and JSON
- {     "employeeId": 1,
        "projectId": 1,
        "date": "2022-04-08T00:00:00",
        "workedHours": 8,
        "note": "Bug fixing"    }
#### UPDATE [PUT]
- https://localhost:44397/api/timereports/30
- In Postman go to Body and select raw and JSON
- {    "timeReportId": 30,
    "employeeId": 1,
    "projectId": 1,
    "date": "2022-04-08T00:00:00",
    "workedHours": 8,
    "note": "Bug fixing and maintenance"}
#### DELETE [DELETE]
- https://localhost:44397/api/timereports/29



