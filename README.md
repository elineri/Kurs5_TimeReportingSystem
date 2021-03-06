# TimeReportingSystem

## INTRODUCTION
This is a school project to create a backend for a time reporting system. 

## TABLE OF CONTENTS
* [USING THE PROGRAM](#USING-THE-PROGRAM)
* [ABOUT THE PROGRAM](#ABOUT-THE-PROGRAM)
* [API-CALLS FOR PROJECT REQUIREMENTS](#API-CALLS-FOR-PROJECT-REQUIREMENTS)

## USING THE PROGRAM
This is only the backend of the time reporting system. Run the program and run the API-calls in your browser or in the Postman client.

## ABOUT THE PROGRAM
The time reporting system has been created with two projects (ClassLibrary and REST-API) in the same solution. A database has been build with Entity Framework

### ARCHITECTURE

#### Models
The requirement for this program was to have at least three models (Employee, Project and TimeReport) for the database. I have chosen to use the TimeReport model as a joining table for many to many relationships. A time report will be connected to an employee and a project, and this will be connected to aditional information like number of worked hours, date and note for time reports so I think it's a good idea using the TimeReport model as a joining table. I haven't added any more models other than what was required but depending on the project/company that uses the time reporting system more tables could be added if necessary and connected to the TimeReports table.

Validation has been added for some properties. Range/Length for names, phone numbers and note for time report. There's also a limit how many hours you can report per day (24 hours). Worked hours is currently an int property but this could be changed to decimal depending on if the employees should be able to report half hours as well. 

#### Interface
I have chosen to use one interface for all classes. All classes use five base methods (GetAll, GetSingle, Add, Update and Delete) and then there are three class specific methods (EmployeeReportedTime, ProjectEmployees, EmployeeReportedTimeWeek). Instead of creating more interfaces I have chosen just to not implement the class specific methods in the classes where it's not needed to keep the program more readable and simple. If this was a bigger program it might be a good idea to create more interfaces or if the classes didn't share as many methods as they do in this program.

### CHOICE OF TECHNICAL METHODS

#### EmployeeReportedTime
- This method is implemented in the EmployeeRepo class. It takes an int id as input, includes TimeReports table and returns detailed information about the employee with matching id and all the connected time reports from the TimeReports table.

- I have chosen to use the Include method to get connected TimeReport entities instead of a mulitple Query join to get the data grouped better. For example if you had more than one employee it would be grouped by employees and then their time reports in a sub group.

#### ProjectEmployees
- This method is implemented in the Project class. It takes an id as input and then checks if there is a project with matching id. If the id exists then it includes the TimeReports and Employees table and returns all employees who has reported time on the project id. 

- In this method I have chosen to use Include and ThenInclude methods to get information from all tables/models since the connection from project to employee is in the join table TimeReports. Here you should probably use automapper to exclude for example the TimeReports List in Employees since this is unnecessary information. You could probably use query syntax here and only return a List of employees but I want to inlcude information about the project as well. If you don't want to return information about the project then the method could be implemented in the TimeReportRepo class where it checks for projectId and then includes the Employee table to get information about the employees.

#### EmployeeReportedTimeWeek
- This method is implemented in the TimeReportRepo class. It takes three integers (id, year and week number) as input. First it checks if there is an employee with the id in the system. If true it will call on the method GetFirstDayOfWeek, it will return the first day of the week (Monday) for selected year and week. The saved variable will be used to get time reports for the selected week where the employeeId is the same as the input id. The method EmployeeReportedTimeWeek will then return an integer of total hours the employee has worked that week. 

- I have chosen to use Query syntax to get all the time reports for the selected week and employee id. You should probably use the Include method here if information about the employee or time reports should be returned, but since it works and I only want to return an integer I have chosen to keep the Query syntax.

![TimeReportingSystem - Page 1 (2)](https://user-images.githubusercontent.com/91311233/162448745-e75a74f4-44db-426b-88c7-0c8239f33057.png)

## API CALLS FOR PROJECT REQUIREMENTS
### 1. Get detailed information about a specific employee and their time reports
- https://localhost:44397/api/employees/time/1
- For another employee change id in the URL (.../employees/time/[id])

### 2. Get all employees working with a specific project
- https://localhost:44397/api/projects/4/employees
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
"startDate": "2020-05-13"
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
    "startDate": "2020-05-13",
    "endDate": null
}

#### DELETE [DELETE]
- https://localhost:44397/api/employees/7

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
        "date": "2022-04-08",
        "workedHours": 8,
        "note": "Bug fixing"    }
#### UPDATE [PUT]
- https://localhost:44397/api/timereports/30
- In Postman go to Body and select raw and JSON
- {    "timeReportId": 30,
    "employeeId": 1,
    "projectId": 1,
    "date": "2022-04-08",
    "workedHours": 8,
    "note": "Bug fixing and maintenance"}
#### DELETE [DELETE]
- https://localhost:44397/api/timereports/29



