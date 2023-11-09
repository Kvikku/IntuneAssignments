# Intune Assignments

# Overview

This application aims to solve one big issue I've had with Microsoft Intune for a long time - how to efficiently deploy a large amount of applications and profiles/policies to one or more groups with just a few clicks.

Usually this process involves a lot of manual work and mouse clicks, which in turn increases the probability for human error.

And before you ask - No, we don't talk about policy sets in Intune to solve this. Shh!


__NOTE - This application is a work in progress. Errors, crashes and unexpected behaviour can occur__



# Prerequisites
![](https://img.shields.io/badge/START%20HERE-red)


There are some requirements and prerequisites you will need to take care of before using the application. 

Please read through this section carefully.

## 1 - Azure tenant

You will need access to an Azure tenant.


## 2 - App registration


You will need to create an App Registration in your Azure tenant. 

This application will be granted the necessary permissions to complete the deployments in Microsoft Intune.

Authentication is handled through the use of Client ID and Client Secret (Other authentication methods will be implemented in the future).

The application should look something like this:

- Name - Intune Bulk Assignments (or whatever you want)
- Supported account types - Accounts in this organization only
- Return URL - Mobile and desktop clients - use the default provided in the GUI
    - https://login.microsoftonline.com/common/oauth2/nativeclient
    - msal48751b13-c91e-4132-b21a-dc763721f4d4://auth
    - https://login.live.com/oauth20_desktop.srf

## 3 - API Permissions

The app registration requires the following permissions as type Application (not Delegated).

- DeviceManagementApps.ReadWrite.All
- DeviceManagementConfiguration.ReadWrite.All
- DeviceManagementManagedDevices.ReadWrite.All
- DeviceManagementServiceConfig.ReadWrite.All

These permissions are needed to both read and write in the Intune environment.


## 4 - Authentication

### Client secret

You will need to create a client secret to authenticate the desktop app to Microsoft Graph via this app registration.


### User based authentication

- This is a work in progress. Check back later

## 5 -.NET Desktop runtime

You will need to install .NET Desktop runtime 6.0 on your device. 

This can be downloaded here:

https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-6.0.24-windows-x64-installer?cid=getdotnetcore




# How to use
![](https://img.shields.io/badge/How_to-_use-blue)

## First run

Download the latest release version to your device, unzip, and navigate to "bin\Debug\net6.0-windows10.0.22621.0", and launch "IntuneAssignments.exe".

- (Alternatively you can just clone the repository and run the application, but you may encounter more bugs from work in progress code).


When launching the application the first time you will have to enter the following info from your tenant and app registration:

- Tenant ID
- Client ID
- Client Secret

Click the Wrench icon in the menu on the left side, enter your authentication info and click OK to save. 

The app will now verify if what you entered is correct. 
Status can be seen the lower left side.

## Help guides

There is a help guide throughout the application, represented with a book icon in the left menu. Use it for a quick tour of each page.


## Application deployment

Application deployment is done on the home page (House icon)

1. First you find and double click the application(s) that you want to deploy. This will move them to the check list
2. Then you do the same for the group(s) you want to deploy to.
3. Then you select the intent for the deployment
4. Finally you click "Prepare deployment", double check that it is what you intended and click "Deploy"

## Profile deployment

Profile deployment is done on the profile page (Gear icon)

1. First you find and highlight the profile(s) that you want to deploy.
2. Then you do the same for the group(s) you want to deploy to
3. Finally you click "Prepare deployment", double check that it is what you intended and click "Deploy"


## Manage assignments

Managing existing assignments is done on the assignment page (Magnifying glass icon)

_NOTE - This currently only supports assignments for applications_

1. First you find and double click the application you want to manage assignments for
2. If the applications have existing assignments they will appear in the list to the right
3. You can now delete assignments individually or in bulk


# Planned features

## Functionality
![](https://img.shields.io/badge/Upcoming-Stuff-orange)


- Assignment options
    - Filters
    - End user notifications
    - Deadline
    - Availability
- Bulk delete
    - Assignments
    - Policies
    - Applications
- Handle the description property
  

## Security related

- Authentication with work account login
- Logging to log file
- Verify API permissions when authenticating




## Completed features

![](https://img.shields.io/badge/Completed-Stuff-green)

- All Users and All Devices for application deployment
- All Users and All Devices for policy deployment

## Community feature requests

If you have other feature request, please post or comment in the discussion tab, and explain to the best of your abilities the desired feature. I appreciate a challenge!

# Acknowledgments
![](https://img.shields.io/badge/Thanks-green)
- ChatGPT and Copilot Chat
- Reddit
- Stack overflow


# About the author

I am a system administrator working primarly with Microsoft 365 services, such as Microsoft Intune and Microsoft 365 Defender. I have a bachelor's degree within system and network administration, and several infrastructure related IT certifications.

When it comes to the art of software development I am entirely self taught with no formal education. As such, the experienced developers among you will probably discover ineffecient, subpar and non optimized code. If that is the case, feel free to provide constructive criticism and feedback. I am always interested in learning more!
