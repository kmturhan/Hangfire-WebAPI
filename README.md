# Hangfire
In web applications need tasks to work continuously at certain times but web applications work on requests. So we can't start a task without triggering. We can do it with Hangfire.

# Hangfire-WebAPI
I developed a simple web application to try Hangfire.

# Installation
* Hangfire needs a database.
* You need to change the **ConnectionString** field in the **appsettings.json** file for the database connection.

![image](https://github.com/kmturhan/Hangfire-WebAPI/assets/22748839/8ddf77e0-01bc-4d32-9022-b3a4d450309c)

# Types of Operation
* Fire & Forget : Only works once. <br />Endpoint : /welcome
* Delayed : Only works once and works after a certain period of time. <br />Endpoint : /discount
* Recurring : Works and repeats between certain time intervals. <br />Endpoint : /databaseupdate
* Continuations : Works after the work of another job. <br />Endpoint : /confirm

# ScreenShot

![image](https://github.com/kmturhan/Hangfire-WebAPI/assets/22748839/a20bc4be-4998-4379-a56b-1ed7cbdc51b7)


# Useful Links
https://crontab.cronhub.io

https://crontab.guru
# Sources
https://www.borakasmer.com/net-6-0-uzerinde-hangfire-implementasyonu

https://www.youtube.com/watch?v=6WS_iT5vNv8
