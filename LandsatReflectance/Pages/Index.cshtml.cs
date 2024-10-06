using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Python.Runtime;

namespace LandsatReflectance.Pages
{
    public class IndexModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

       

        public static void Initialize()
        {
            Runtime.PythonDLL = @"C:\Users\rorem\AppData\Local\Programs\Python\Python311\python311.dll";
            Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", Runtime.PythonDLL);
            PythonEngine.Initialize();
        }

        public IActionResult OnPostHandleJSCall([FromBody] dynamic data)
        {
            string jsValue = data.someValue;
            string responseMessage = $"Received: {jsValue}";
            RunPythonCode("NASA_SpaceApps", jsValue);

            return new JsonResult(new { message = responseMessage });
        }

        public static void RunPythonCode(string scriptName, string Data)
        {
            var TOKEN = "eyJjaWQiOjI3Mjk2OTgzLCJzIjoiMTcyODE1MjE4NCIsInIiOjczNiwicCI6WyJ1c2VyIl19";

            Initialize();
            using (Py.GIL())
            {
                var pythonScript = Py.Import(scriptName);
                var message = new PyString(Data);
                var feedback = pythonScript.InvokeMethod("landsatSceneLEVEL2", new PyObject[] {message});
            }
        }








    }
}
