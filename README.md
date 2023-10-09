# Intune Assignments

# Overview

This application aims to solve one big issue I've had with Microsoft Intune for a long time - how to efficiently deploy a large amount of applications and profiles/policies to one or more groups with just a few clicks.

Usually with process involves a lot of manual work and mouse clicks, which in turn increases the probability for human error.

And before you ask - No, we don't talk about policy sets in Intune to solve this. Shh!

# About the author

I am a system administrator working primarly with Microsoft 365 services, such as Microsoft Intune and Microsoft 365 Defender. I have a bachelor's degree within system and network administration, and several infrastructure related IT certifications.

When it comes to the art of software development I am entirely self taught with no formal education. As such, the experienced developers among you will probably discover ineffecient, subpar and non optimized code. If that is the case, feel free to provide constructive criticism and feedback. I am always interested in learning more!


# How to use

## Prerequisite

There are some requirements and prerequisites you will need to take care of:

- Azure tenant with permissions to create an App Registration

You will need an Azure tenant with an App registration. This application will be granted the necessary permissions to complete the deployments in Microsoft Intune.
Authentication is handled through the use of Client ID and Client Secret (Other authentication methods will be implemented in the future).

- Name (your choice)
- Accounts in this organization only
- Return URL - Mobile and desktop clients - use the default provided in the GUI
    - https://login.microsoftonline.com/common/oauth2/nativeclient
    - msal48751b13-c91e-4132-b21a-dc763721f4d4://auth
    - https://login.live.com/oauth20_desktop.srf


# How to use

## Application deployment

## Profile deployment

# Acknowledgments

- ChatGPT <3 
