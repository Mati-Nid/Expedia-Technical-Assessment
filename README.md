# Expedia - Assessment Task

This is an ASP.Net core project on Hotel deals developed for Expedia's technical assignment.

## Getting Started

These instructions will guide you through the process of deploying the 'Hotel deals' website to IIS.
Supported operating system is windows 7 and later.

### Prerequisites
-	Enable the IIS Management Console and World Wide Web Services:
```
Navigate to Control Panel > Programs > Programs and Features > Turn Windows features on or off (left side of the screen).

Open the Internet Information Services node. Open the Web Management Tools node.

Check the box for IIS Management Console.

Check the box for World Wide Web Services.

Accept the default features for World Wide Web Services or customize the IIS features.

If the IIS installation requires a restart, restart the system.
```
-	Install the .NET Core Hosting Bundle on the hosting system:
```
The bundle installs the .NET Core Runtime, .NET Core Library, and the ASP.NET Core Module. The module creates the reverse proxy between IIS and the Kestrel server.

Navigate to the * [.NET All Downloads page]( https://www.microsoft.com/net/download/all)  .

Select the latest non-preview .NET Core runtime from the list (.NET Core > Runtime > .NET Core Runtime x.y.z).
On the .NET Core runtime download page under Windows, select the Hosting Bundle Installer link to download the .NET Core Hosting Bundle.
Important! If the Hosting Bundle is installed before IIS, the bundle installation must be repaired. Run the Hosting Bundle installer again after installing IIS.

To prevent the installer from installing x86 packages on an x64 OS, run the installer from an administrator command prompt with the switch OPT_NO_X86=1.

Restart the system or execute net stop was /y followed by net start w3svc from a command prompt. Restarting IIS picks up a change to the system PATH made by the installer.
```

### Creating the IIS site

```
On the hosting system, create a folder to contain the app's published folders and files.

On visual studio, after cloning the code, right click on the project and select Publish. Select to folder, specify folder location and press publish.

In IIS Manager, Under the server's node, select Application Pools.

Right-click the site's app pool and select Basic Settings from the contextual menu.

In the Edit Application Pool window, set the .NET CLR version to No Managed Code.

Right click the site, select Add Application, fill in Alias and Physical path and press OK.

```
Now you can browse the Hotel deals site on http://localhost/<Alias> to verify the deployment process.
  
## Author

* **Matilda Abuabdou** - *Initial work*
