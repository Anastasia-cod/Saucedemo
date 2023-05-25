using System;
using System.Reflection;
using Core.Models;

namespace Core.Utilities.Helpers
{
    public class TestDataHelper
    {
        public static Project GetTestProject(string FileName)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
                                        + Path.DirectorySeparatorChar + FileName);
            return JsonHelper.FromJson(json).ToObject<Project>();
        }
    }
}

