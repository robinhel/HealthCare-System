# HealthCare System
Healthcare System is a journal system that runs in the terminal and has been developed in C#.
The purpose of our project is to create a simple system where users can log in and perform different actions depending on their role (doctor, patient, admin).
The idea was to mimic a real system, such as 1177, as a source of inspiration.


## Patient
- Log in or create an account
- Book appointments with doctors
- View personal schedule
- Cancel appointments
- View medical records

## Doktor
- Handle booking requests
- View schedule
- Create and edit patient records
- View all patient records

## Admin
- Add or remove doctors
- Manage user permissions
- Create appointments directly
- Manage and save healthcare locations


## File Management
To make sure information is saved, we created a file management system where user data and different locations are stored in CSV files.
This way, the information does not disappear when the program is closed.
Currently, the system uses:
- Users.csv to store users
- Locations.csv to store locations
- In the future, we plan to add Journals.csv to store journals.

### How to run

1 - Git clone git@github.com:robinhel/HealthCare-System.git

2 - Type: dotnet run - in terminal

3 - Login in as a user:
* Admin: username: a-1 ,password: a 
* Doctor: username: d-1 ,password: a 
* Patient: username: p-1 ,password: a 

4 - Follow to Menu

## Group Members
This project was created by:

- Robin
- Tameem
- Filiph
- Nicklas
- Calle

