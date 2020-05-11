# MyOrgHelper
Small tool to help in attending meetings, sending status from confluence and git bucket track and merge.

There are two main part of solution, 
1. DailyWebService (My Primary use) which is a web service which uses the WindowsAzureActiveDirectoryBearerAuthentication.
2. A basic Winform (For testing) which contains all the functionalities.

The whole application is divided into 3 parts.
A. Meeting: To query the Calender and launch Zoom /Skype meetings.
B. Status: To get the Weekly Status or to run custom JQL. Here the status is on confluence page. The app reads the confluence and send email to manager for the tasks worked on. It can be modified for other source.
C. Stash: It is my favourite. In this we can check pull requests created by us. Check overall status. Can automate the task to merge the pull request.
