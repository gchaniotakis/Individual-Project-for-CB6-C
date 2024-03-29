Definition

You are required to build a console application where you will be asked to read various inputs from the keyboard.
This application is not defined in terms of what it is but it is defined as to what it is expected to be doing in principal.
These inputs will be used as login details and as various actions to give the ability to the users of the system to interact with each other.
The interaction between the users is solely defined by you so you can decide,

• What kind of information you would like your users to interchange

• How often this information has or must be exchanged

• The role that each user has within the application

The output of the various subsystems will be displayed to the screen and it will be written to simple text files.
The following description of the logical units of the application is given to have a guideline to what it should be expected as minimum requirements.

A. Logical Units of the application:

1. Main application
2. Login Screen
3. Application’s menus
4. Database’s access
5. Files’ access

B. Deliverables

1. You need to produce at least five classes. Each class must contain the code needed as this is described in part A. 

2. The system’s menu should have the option to login a user with super admin privileges (username: admin, password: admin) 

3. The super admin must have the option to create, view, delete and update the users of the system 

4. The super admin must have the option to assign a role to each created user

5. Each role has different responsibilities to the application. The responsibilities are:


      A. View the transacted data between the users
  
      B. View and Edit  the transacted data between the users
  
      C. View, Edit and Delete the transacted data between the users 
  
  
6. Each user must be able to interact with any other user in terms of sending any data that you decided as if it was an email message. This data must contain any text limited to 250 characters. Every message containing this data must be stored to the database along with the following information:

      A. Date of submission
  
      B. Sender
  
      C. Receiver
  
      D. Message Data
  
  
  The marks are assigned as follows:
  
  1. Structure of the message as described above 
  2. Ability to send a message 
  3. Ability to receive a message 
  4. Store to database 
  
7. All the messages between the users must be stored in files so that all the transacted messages exist in these files and each file has the same contents as described in 6. 
Specifically, the allocated marks for this section is as follows:

  1. File creation 
  2. Message storage 
  3. Follow the structure as above on 6
  4. Ability to append to the same file
