# NanaProject
A pet hotel management that have CRUD for pet, food and account, with a simple authenticator during the login, and other function to support the website, 
The project was made with just one person and this project is a result of a few week working at Nashtech

The following funtion inside the website:

-Coding:
    + Code First Database
    + Dependency Injection
    + User Identity
    + etc (basic mvc)

-Basic Page:
HomePage: First thing first when you enter the website there'll be a home page that everyone can access which so some information to user
AboutPage: Not yet
ContactPage: Not yet

-Login:
the login page that user can access in the navbar that lead user to login page which need an account to access main function of the web site. login will need email and password to logged in.

-Register:
the register page link is in the login page for people who doesn't have an account. the account to be registration that need email, password and password confirm

-Manage Account: only scaffold

-For Member: member@gmail.com || Test@123
    +AdoptPage: this page for the member to view all the pet that are adopted by the store, so the member they also can view detailly of each pet and eventually there'll be search bar to search specific pet
    +SupplyPage: this page provide member to see total of supply that the store have for pet, which follow up with view detail of supply and searching function

-For Staff: staff@gmail.com || Test@123
    +AdoptPage: this page is also like the adopted page for member but it have some function that only staff of the store have like Creating Pet, Modify Pet and Delete Pet
    +SupplyPage: same as the supply page for member but with function are Create Supply, Modify Supply and Delete Supply

-For Admin: admin@gmail.com || Test@123
    +AdoptPage: this page is also like the adopted page for member but it have some function that only staff of the store have like Creating Pet, Modify Pet and Delete Pet
    +SupplyPage: same as the supply page for member but with function are Create Supply, Modify Supply and Delete Supply
    +Category: the category page is only for admin to access, this is for the category of the supply in the store so admin can CRUD and search the supply, this page will used for the future function like sorting follow the category (you should create category first before create supply)
    +SpeciesPage: like the food page that this page is for the future function like sorting, so currently we have CRUD and search function for the species for pet (Create first before add pet to the list)
    +AccountPage: the account page is for account management that only can Update and Delete the exist account. but sadly no changing role of each account yet.
