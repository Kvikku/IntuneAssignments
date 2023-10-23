# Intune Assignments

# Overview

This application aims to solve one big issue I've had with Microsoft Intune for a long time - how to efficiently deploy a large amount of applications and profiles/policies to one or more groups with just a few clicks.

Usually with process involves a lot of manual work and mouse clicks, which in turn increases the probability for human error.

And before you ask - No, we don't talk about policy sets in Intune to solve this. Shh!

# About the author

I am a system administrator working primarly with Microsoft 365 services, such as Microsoft Intune and Microsoft 365 Defender. I have a bachelor's degree within system and network administration, and several infrastructure related IT certifications.

When it comes to the art of software development I am entirely self taught with no formal education. As such, the experienced developers among you will probably discover ineffecient, subpar and non optimized code. If that is the case, feel free to provide constructive criticism and feedback. I am always interested in learning more!




# Prerequisites
![](https://img.shields.io/badge/START%20HERE-red)


There are some requirements and prerequisites you will need to take care of before using the application.

## 1 - Azure tenant

You will need access to an Azure tenant.


## 2 - App registration


You will need to create an App Registration in your Azure tenant. 

This application will be granted the necessary permissions to complete the deployments in Microsoft Intune.

Authentication is handled through the use of Client ID and Client Secret (Other authentication methods will be implemented in the future).

The application should look something like this:

- Name - Intune Assignments
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




# How to use
![](https://img.shields.io/badge/How_to-_use-blue)

## First run

When launching the application the first time you will have to enter the following info from your tenant and app registration:

- Tenant ID
- Client ID
- Client Secret



## Application deployment

## Profile deployment

# Planned features

## Functionality
![](https://img.shields.io/badge/Upcoming-Stuff-green)

- Handle All Users and All Devices virtual groups
- Assignment options
    - End user notifications
    - Deadline
    - Availability
- Bulk delete
    - Assignments
    - Policies
    - Applications

## Security related

- Authentication with work account login
- Logging to log file
- Verify API permissions when authenticating


## Community feature requests

If you have other feature request, please post or comment in the discussion tab, and explain to the best of your abilities the desired feature. I appreciate a challenge!

# Acknowledgments
![](https://img.shields.io/badge/Thanks-green)
- ChatGPT and Copilot Chat
- Reddit
- Stack overflow
