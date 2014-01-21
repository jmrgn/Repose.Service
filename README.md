Repose.Service
==============

A lightweight way to host Rackspace's Repose, a reverse proxy meant to implement and standardize cross-cutting API tasks like authentication and rate limiting (more info here: http://www.openrepose.org/)

#####
Installation instructions:

1) Extract an instance of the Repose Package to the desired run location
2) Edit the settings in configuration/Repose.config to the correct settings
3) build.bat
4) Copy the build output to the desired service installation location
5) open up a command line

To run the service from the command line:
6) Repose.Service.exe run 

To install the service from the command line:
6b) Repose.Service.exe install
Note: This service uses top shelf for easy installation and testing. Please refer to the following documentation for additional information and instructions: http://docs.topshelf-project.com/en/latest/overview/commandline.html