using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trust.Cgc.Computer;

namespace Trust.Cgc.ComputerTests
{
    [TestClass]
    public class REngineTests
    {
        [TestMethod]
        public void TestExecution()
        {
            using (RFramework r = new RFramework())
            {

                string output;
                var result = r.Execute("output<-as.data.frame(c(1))", out output);

                Assert.AreEqual(1.0, result[0][0]);
            }
        }

        [TestMethod]
        public void TestOutput()
        {
            using (RFramework r = new RFramework())
            {

                string output;
                var result = r.Execute("c<-'test'", out output);

                Assert.AreEqual("test", output);
            }
        }

        /// <summary>
        /// Test that a bad library fails to execute
        /// Works but blows up RFramework, need to investigate this
        /// </summary>
        [TestMethod]
        [Ignore]
        public void TestBadLibrary()
        {
            using (RFramework r = new RFramework())
            {

                try
                {
                    r.LoadLibrary("tttt");
                }
                catch (RDotNet.EvaluationException)
                {
                    return;
                }


                Assert.Fail();
            }
        }


        /// <summary>
        /// Test that a good library does not throw an exception
        /// </summary>
        [TestMethod]
        public void TestExistingLibrary()
        {
            using (RFramework r = new RFramework())
            {

                r.LoadLibrary("ggplot2");

            }
        }

        /// <summary>
        /// Test hacky way to read dataframe as csv
        /// </summary>
        [TestMethod]
        public void TestDataFrameRead()
        {
            using (RFramework r = new RFramework())
            {
                string output;
                var result = r.Execute("output<-as.data.frame(c(1))", out output);

                Assert.AreEqual(1.0, result[0][0]);

                var dfCsv = r.GetVarAsCSV("output");

                Assert.AreEqual("\"\",\"c(1)\"\r\n\"1\",1\r\n", dfCsv);
            }
        }
    }
}
