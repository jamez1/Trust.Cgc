using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDotNet;

namespace Trust.Cgc.Computer
{
    public class RFramework:IDisposable
    {
        private string outputVar = "output";
        private string rootDir = @"C:/temp/";
        REngine engine;

        public RFramework()
        {

            engine = REngine.GetInstance();
            // REngine requires explicit initialization.
            // You can set some parameters.
            engine.Initialize();

        }

        public void LoadLibrary(string library)
        {
            engine.Evaluate("require('" + library + "')");
            engine.Evaluate("library('" + library + "')");
        }

        public DataFrame Execute(string script, out string console)
        {
            var result = engine.Evaluate(script);

            if (result != null)
            {
                string[] consoleOut = result.AsCharacter().ToArray();

                console = consoleOut[0];
            }
            else
                console = "";

            try
            {
                return engine.GetSymbol(outputVar).AsDataFrame();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void SetVar(string var, string val)
        {
            CharacterVector charVec = engine.CreateCharacterVector(new[] { val });

            engine.SetSymbol(var, charVec);
        }

        //ugly hack to read dataframe as csv
        public string GetVarAsCSV(string var)
        {
            var randomName = new Random().Next(1,1000000).ToString();
            var filename = Path.Combine(rootDir, randomName);

            engine.Evaluate("write.csv(file='"+ filename + "', x=" + var + ")");

            return File.ReadAllText(filename);
        }

        public void Dispose()
        {
            //engine.Dispose();
        }
    }
}
