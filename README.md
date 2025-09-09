# OrangeHRM

### Selected application
https://opensource-demo.orangehrmlive.com/  


### Scope and objectives
**Scope:**  
Authentication: login.  
PIM module: employee creation and deletion.  
Admin module: user creation and deletion.  


**Objectives:**  
Validate critical flows (positive and negative).  
Reduce risk of regressions.  


### Test approach
**Automated:** 
Login, create/delete employees, create/delete users.  

### Test environment
Framework: .NET + NUnit + Selenium WebDriver. 


### Critical test cases (10)
1. Valid login
2. Invalid login (wrong username)
3. Invalid login (wrong password)
4. Create new employee
5. Create new user
6. Delete user
7. Delete employee


### Tech stack
Language: **C#**  
Framework: **NUnit**  
Automation: **Selenium WebDriver**  
Pattern: **Page Object Model (POM)**  
Data generation: **DataGenerator** (random strings/passwords) 


### Automated flows
**Login**  
validLogin: valid credentials → dashboard.  
invalidUserLogin: wrong username → "Invalid credentials".  
invalidPasswordLogin: wrong password → "Invalid credentials".  

**PIM (Employee Management)**  
createNewEmployee: create employee → redirect to **Personal Details**.  
deleteEmployee: create and then delete employee → "Successfully Deleted".  

**Admin (User Management)**  
createNewUser: create user for an existing employee → "Successfully Saved".  
deleteUser: create user, delete it, and delete the associated employee.   
