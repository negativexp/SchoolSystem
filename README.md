# School system
Basic school system using WPF and MVVM architecture.
# Features
## MongoDB
School system only works with MongoDB and it needs 3 collections...
 - Class collection
 - Teacher collection
 - Student collection
You can find the database settings under `System`. All IDs are generated automatically.
# Objects
## Classes
A class contains...
 - Class name
 - Grade
 - Root teacher
 - Dictionary of students (IDs and names)
## Teachers
A teacher contains...
 - Full name
 - Birthday
 - Phone number
 - Degree
 - Salary
## Students
A student contains...
 - Full name
 - Birthday
 - Phone number
 - Mothers name
 - Fathers name
# Known bugs
| Bug name         | description      |
| ---------------- | ---------------- |
| UI list bug | If there are only two objects in one of the collections, the second one only shows when the page is loaded or third object is created and disappears when refreshed or new third object is created. |
