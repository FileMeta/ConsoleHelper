# ConsoleHelper
A CodeBit class to make console applications more friendly.
## About ConsoleHelper
On windows, a console application can be run from a command-line console or directly from Windows Explorer. When run from a command line, its output will be visible in the host console even after the application exists. When run from Windows Explorer, or when debugging from Visual Studio the console closes when the app exits and the user may not have time to see the output.

The ConsoleHelper class includes a method for determining whether an application is the sole console owner. This lets the application determine whether to linger (becaue it's the only app on the console) or exit (because it was run from a command-line in an existing console). The class also includes a method to conditionally prompt the user and wait for a key before exiting - but only if the application is the sole console owner.

ConsoleHelper also includes a method to bring the console to the front.

## About CodeBit
A CodeBit is a way to share common code that's lighter weight than [NuGet](http://nuget.org). CodeBits are contained in one source code file. A structured comment at the beginning of the file indicates where to find the master copy so that automated tools can retrieve and update CodeBits to the latest version. For more information see [http://FileMeta.org/CodeBit.html](http://FileMeta.org/CodeBit.html).

In this case, the CodeBit is the ConsoleHelper.cs file. It is intended to be reused in other applications.

## About the Project
This project includes the ConsoleHelper.cs CodeBit and unit test code to make sure the class functions correctly. It was created in Visual Studio Express 2015 for Windows Desktop.
