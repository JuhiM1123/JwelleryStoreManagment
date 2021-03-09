
### Welcome to Jwellery Store Application
### Features
Jwellery Store is a small estimation web application for a Jewelry store.

The application has the following abilities to cater the service:

1)Login screen for cutomers to login to the application

2)Home Screen with the following options for estimation:
a. Gold price
b. Weight of the item
c. Discount percentage (This option is visible to the customers as per their roles/ privilege , discount percentage can only be set by the Owner hence its an readonly field)

3)The application prints the estimation memo via the following options
a. Print on the screen (Shows estimation memo on the dialog box)
b. Print to a file (Downloads an pdf file with the estimation memo)
c. Print to a paper 


### Getting Started-Explanation of Structure
This application is divided in two parts :
1)JwelleryStoreServies
2)JwelleryStoreUI

### I)JwelleryStoreServices
JwelleryStoreServices is an application made in .NetCore 3.0 and EntityFramework Core 

- JwelleryStoreServices
     -  This project is an actual WEBAPI
	  
- JwelleryStore.Common
     -  This is the common library which is accessible by all the project present in JwelleryStoreServices solution

- JwelleryStore.Business
     -  This is the business library which contains applications business logic
     -  This library will connect to the Data access layer to perform all the CRUD operations 

- JwelleryStore.DAL
   -  This is the Data Access Layer which is used to connect and fetch data from the database.
   

- JwelleryStore.UnitTest
   -  This application contains all the required Unit Tests for the WEB API and JWT Authenticaion

### I)JwelleryStoreUI
Jwellery Store application is an UI application made in Angular

- JwelleryStoreUI
JwelleryStoreUI consumes the WEB Api made in JwelleryStoreServices in order to fecth the data from the application.

### Getting Started- Configuration
- JwelleryStoreServices
    - Open the solution file present in the JwelleryStore.API folder
    - Update the connection string of SQL server in the appsettings.json file key would be "JwelleryStoreSQL". By default it is connected to the localDB
    - Build the application
- JwelleryStoreUI
    - Open the folder  JwelleryStoreUI in VSCode
    - Open node package manager console and change the directory to the location of the project
    - Execute the following command
     	 - npm install
    	 - ng serve --o
	
### Getting Started- How to test
 
  -  You can run the test cases present in the "JwelleryStore.UnitTest"

### Getting Started- API URL Format

POST=> "/api/Account/Login" => This url will authenticate the User with the encrypted password and JWT Authentication and get the UserDetails

### Author
[Juhi Mehta](http://linkedin.com/in/juhi-menta-6b515b57/)



### End
