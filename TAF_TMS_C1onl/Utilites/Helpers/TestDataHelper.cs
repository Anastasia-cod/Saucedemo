using System.Reflection;
using System.Text.Json;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.Utilites.Helpers;

public class TestDataHelper
{
    public static Project GetTestProject(string fileName)
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData" 
                                    + Path.DirectorySeparatorChar + fileName);

        return JsonHelper.FromJson(json).ToObject<Project>();
    }

    //public static Case GetTestCase(string fileName)
    //{
    //    var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    //    var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
    //                                + Path.DirectorySeparatorChar + fileName);

    //    return JsonHelper.FromJson(json).ToObject<Case>();
    //}

    public static Case GetTestCase(string fileName)
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(Path.Combine(basePath, "TestData", fileName));

        return JsonSerializer.Deserialize<Case>(json);
    }
}
