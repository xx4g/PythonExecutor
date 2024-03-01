using Python.Included;
using Python.Runtime;

namespace TorchNet
{
    using System.CodeDom.Compiler;
    using System.Text;
    using System.Threading.Tasks;
    using System;
    using global::PythonExecutor;

    public class Program
    {
        public static void Main(string[] args)
        {
            PythonExecutor pythonExecutor = new PythonExecutor(new[] { "transformers",  "torch" });
            pythonExecutor.Initialize().Wait();
            PythonScript script = new PythonScript();
                pythonExecutor.ExecuteScript(script.pythonScript);
      












            pythonExecutor.Shutdown();


#if NETFRAMEWORK
            Console.WriteLine("Hit any key to exit.");
            Console.ReadKey();
#endif
        }

     

    }
}
