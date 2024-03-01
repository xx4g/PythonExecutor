# PythonExecutor

The PythonExecutor class is a C# utility designed to facilitate the execution of Python scripts and functions directly from C#. It is particularly useful for .NET applications that require the integration of Python libraries or scripts. This class simplifies the process of setting up Python, installing required packages, and executing Python code, providing a seamless bridge between the .NET and Python ecosystems.

Features

Python Installation: Automates the installation of Python within the .NET application's environment, ensuring that the Python runtime is available for script execution.
Library Management: Supports the installation of required Python libraries via pip, making it easy to manage dependencies directly from C#.

Python Script Execution: Allows for the execution of Python scripts, enabling the integration of Python codebases or snippets within a .NET application.
Function Invocation: Facilitates the direct invocation of Python functions from C#, with support for passing arguments and receiving return values, offering a high degree of interoperability between C# and Python.

Initialization Check: Ensures that Python and all required libraries are properly initialized before any script or function is executed, preventing runtime errors due to uninitialized components.
Safe Shutdown: Provides a mechanism to correctly shut down the Python engine, ensuring that resources are properly released and that the application can clean up the Python environment upon termination.
Usage

Initialization

Before executing any Python script or function, the PythonExecutor must be initialized with the list of Python libraries your application requires. Initialization involves setting up Python, installing pip (if not already available), and installing the specified libraries.

var libraries = new List<string> { "numpy", "torch" }; // Example libraries
var pythonExecutor = new PythonExecutor(libraries);
await pythonExecutor.Initialize();

Executing Python Scripts
To execute a Python script, simply call the ExecuteScript method with your Python code as a string argument.

pythonExecutor.ExecuteScript("print('Hello from Python')");
Invoking Python Functions
To invoke a Python function, use the ExecuteFunction method, specifying the module name, function name, and any arguments required by the function.

dynamic result = pythonExecutor.ExecuteFunction("math", "sqrt", 16);
Console.WriteLine(result); // Outputs: 4
Shutdown
Once you are done executing Python code, it is recommended to shut down the Python engine to release resources properly.

pythonExecutor.Shutdown();

Requirements

.NET compatible development environment (e.g., Visual Studio)
Python.Included package for embedding Python
Python.Runtime for interacting with the Python runtime
Conclusion
The PythonExecutor class offers a convenient way to integrate Python's powerful ecosystem into .NET applications, making it an invaluable tool for projects that benefit from the capabilities of both languages.




