using System;
using Newtonsoft.Json.Linq;
using NLog;
using RestSharp;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Utilites.Helpers;

namespace TAF_TMS_C1onl.Tests.API
{
    public class ProjectsTest : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void GetProjectTest_1()
        {
            var request = new RestRequest("index.php?/api/v2/get_project/{project_id}")
                .AddUrlSegment("project_id", "1");
            var response = _apiClient.Execute(request);
            _logger.Info(response.Content.Normalize);

            var json = response.Content;

            //Perform desearilizatsia Json-string to object Jobject
            var jsonObject1 = JObject.Parse(json);

            var jsonObject2 = JsonHelper.FromJson(json);

            //Using JsonPath to get any value from object
            var value = jsonObject1.SelectToken("$.name");
            _logger.Info("jsonObject1 -> name: " + value);

            var value2 = jsonObject2.SelectToken("$.name");
            _logger.Info("jsonObject2 -> name: " + value2);
        }

        [Test]
        public void GetProjectTest_2()
        {
            var json = _projectService.GetProject("1").Content;

            //Perform desearilizatsia Json-string to object Jobject
            var jsonObject1 = JObject.Parse(json);

            var jsonObject2 = JsonHelper.FromJson(json);

            //Using JsonPath to get any value from object
            var value = jsonObject1.SelectToken("$.name");
            _logger.Info("jsonObject1 -> name: " + value);

            var value2 = jsonObject2.SelectToken("$.name");
            _logger.Info("jsonObject2 -> name: " + value2);
        }

        [Test]
        public void GetProjectTest_3()
        {
            var actualProject = _projectService.GetAsProject("1");
            _logger.Info("jsonObject2 -> name: " + actualProject.Name);
        }

        [Test]
        public void GetProjectTest_4()
        {
            var json = _projectService.GetProjectAsync("1").Result.Content;

            //Perform desearilizatsia Json-string to object Jobject
            var jsonObject1 = JObject.Parse(json);

            var jsonObject2 = JsonHelper.FromJson(json);

            //Using JsonPath to get any value from object
            var value = jsonObject1.SelectToken("$.name");
            _logger.Info("jsonObject1 -> name: " + value);

            var value2 = jsonObject2.SelectToken("$.name");
            _logger.Info("jsonObject2 -> name: " + value2);
        }

        [Test]
        public void GetProjectTest_5()
        {
            var actualProject = _projectService.GetAsProjectAsync("1");
            _logger.Info("jsonObject2 -> name: " + actualProject.Result.Name);
        }

        [Test]
        public void AddProjectTest_1()
        {
            var expectedProject = new Project();
            expectedProject.Name = "Test Project 2";
            expectedProject.Announcement = "Description Test 2Project";
            expectedProject.SuiteMode = 2;

            var actualProject = _projectService.AddProjectAsync(expectedProject);
            _logger.Info("ActualProject: " + actualProject.Result.ToString());

            Assert.AreEqual(expectedProject.Name, actualProject.Result.Name);
        }
    }
}

