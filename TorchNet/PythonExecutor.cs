using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Included;
using Python.Runtime;

namespace TorchNet
{
    public class PythonExecutor
    {
        private bool _initialized;
        private readonly IEnumerable<string> _libraries;

        public PythonExecutor(IEnumerable<string> libraries)
        {
            _libraries = libraries ?? throw new ArgumentNullException(nameof(libraries));
            _initialized = false;
        }

        public async Task Initialize()
        {
            if (!_initialized)
            {
                // Install Python and required libraries
                Installer.InstallPath = System.IO.Path.GetFullPath(".");
                Installer.LogMessage += Console.WriteLine;

                await Installer.SetupPython();
                await Installer.TryInstallPip();

                foreach (var lib in _libraries)
                {
                    await Installer.PipInstallModule(lib);
                }

                // Initialize Python engine
                PythonEngine.Initialize();
                //Console.Clear();
                _initialized = true;
            }
        }

        public void ExecuteScript(string pythonScript)
        {
            if (!_initialized)
            {
                throw new InvalidOperationException("Python engine has not been initialized.");
            }

            PythonEngine.Exec(pythonScript);
        }

        public dynamic ExecuteFunction(string moduleName, string functionName, params object[] args)
        {
            if (!_initialized)
            {
                throw new InvalidOperationException("Python engine has not been initialized.");
            }

            using (Py.GIL())
            {
                dynamic module = Py.Import(moduleName);
                dynamic function = module.GetAttr(functionName);
                return function(args);
            }
        }

        public void Shutdown()
        {
            if (_initialized)
            {
                PythonEngine.Shutdown();
                _initialized = false;
            }
        }
    }
}