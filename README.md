# MyOrgHelper
Small tool to help in attending meetings, sending status from confluence and git bucket track and merge, auto merge and send notification via WirePusher.
<br />
**Note**: WirePusher needs to be installed on mobile device to get the notification.
<br />
There are two main part of solution
1. **DailyWebService** (My Primary use) which is a web service which uses the WindowsAzureActiveDirectoryBearerAuthentication.
2. **Winform Application** (For testing) which contains all the functionalities.
<br />
The whole application is divided into 3 parts. <br />
1. **Meeting**: To query the Calender and launch Zoom /Skype meetings. <br />
2. **Status**: To get the Weekly Status or to run custom JQL. Here the status is on confluence page. The app reads the confluence and send email to manager for the tasks worked on. It can be modified for other source. <br />
3. **Stash**: It is my favourite. In this we can check pull requests created by us. Check overall status. Can automate the task to merge the pull request. <br /><br />

**Changes Required**: <br />
To run the application, In Web.config & App.config values needs to be filled which are described in **"## ##"**. <br />
Example: Jira & Stash base URI, App & Tenant Code for EWS etc.
