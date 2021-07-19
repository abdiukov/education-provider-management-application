#  Education provider management application

A fully responsive application that is used to manage a complex database. The idea of this application is to manage an education provider with multiple campuses, over 100 students, 12 courses, and 50 units.  The user is able to manage student payments, manage student outcomes, manage teachers, manage courses, manage students, manage units.

Initially, this was a small assessment I needed to do for my college. Later on, I developed the application even further to sharpen my skills.

Right now, the application has over 10,000 lines of code, and 31 windows/forms. The application contains 47 stored procedures, and uses stored procedures only.

This application :

- has a multi-level access system. There are two users, with different levels of access.
- is built upon the MVC model.
- is connected to my personal Microsoft Azure database. 
- contains a navigation bar at the top, which remembers every page you visited and allows you to go back.
- allows the user to right-click on any datagrid to select which columns they wish to hide.
- uses generic methods, when possible.

## How to set up:

1. Start the application.
2. Log in as either a manager or a teacher. The Manager has access to all features, whereas the Teacher can only view information and cannot edit/delete/add new information.
    - Username - "manager". Password - "M1password" 
    - Username - "teacher". Password - "T1password"

## Credits

- The application icon - > https://github.com/Remix-Design/remixicon. Apache-2.0 Licence.