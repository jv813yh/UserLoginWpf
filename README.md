# I showed how to bind to a PasswordBox by creating a custom control. 

One of the most frustrating issues with the WPF PasswordBox is that the Password property is not a DependencyProperty. 
Therefore, view models can not bind to the Password property. 
However, this problem is solvable by creating a custom WPF control and setting up a custom Password DependencyProperty. 

In [https://github.com/jv813yh/UserLoginWpf/blob/master/UserLoginWpf/CreateLoginDbMVVVMDatabase.sql] you have script for create database and inserting a list of users.
You can use users for login. I have implemented only Authenticate(NetworkCredential credential) and GetByName(string name) functions. 
You can write CRUD functions, if you want.
I use the ADO.NET library for working with the database, I think it is suitable for such a small project.

In [https://github.com/jv813yh/UserLoginWpf/blob/master/UserLoginWpf/Repositories/RepositoryBase.cs] check the connection string to see if it matches yours.


