# IdlePrevention
Prevent Windows idle detection with a small C# system tray application

# Purpose
You may, for some reason, want to prevent Windows 10 (or previous versions) from locking the screen or going into sleep mode.

In Windows 10 especially it is difficult to prevent screen auto-locking by changing a user setting.

This system tray application lets you click to enable/disable and will prevent the system from detecting idle by notifying the operating system that the application is busy.  This is the same technique used to prevent idle for full screen video applications.

# Status
This is an initial prototype.  It appears to work well on Windows 10.  I will do additional cleanup and add features (prevent idle for X time) later.
