using System;
using Newtonsoft.Json.Linq;
using NLog;
using RestSharp;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Pages;
using TAF_TMS_C1onl.Utilites.Helpers;

namespace TAF_TMS_C1onl.Tests.API
{
    public class CaseTest : BaseApiTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void GetCaseTest()
        {
            var expectedCase = new Case();
            expectedCase.Id = 2;
            expectedCase.Title = "Anastasiya Test Case";
            expectedCase.SectionId = 1;
            expectedCase.TemplateId = 1;
            expectedCase.TypeId = 7;
            expectedCase.CustomPreconds = "Test preconditions";
            expectedCase.CustomSteps = "Test steps";
            expectedCase.CustomExpected = "Test expected result";

            var actualCase = _caseService.GetAsCase(2);
            _logger.Info("jsonObject -> id: " + actualCase.Id);
            _logger.Info("jsonObject -> title: " + actualCase.Title);
            _logger.Info("jsonObject -> section id: " + actualCase.SectionId);
            _logger.Info("jsonObject -> template id: " + actualCase.TemplateId);
            _logger.Info("jsonObject -> type id: " + actualCase.TypeId);
            _logger.Info("jsonObject -> custom preconds: " + actualCase.CustomPreconds);
            _logger.Info("jsonObject -> custom steps: " + actualCase.CustomSteps);
            _logger.Info("jsonObject -> custom expected: " + actualCase.CustomExpected);

            Assert.Multiple(() =>
            {
                Assert.That(actualCase.Id, Is.EqualTo(expectedCase.Id));
                Assert.That(actualCase.Title, Is.EqualTo(expectedCase.Title));
                Assert.That(actualCase.SectionId, Is.EqualTo(expectedCase.SectionId));
                Assert.That(actualCase.TemplateId, Is.EqualTo(expectedCase.TemplateId));
                Assert.That(actualCase.TypeId, Is.EqualTo(expectedCase.TypeId));
                Assert.That(actualCase.CustomPreconds, Is.EqualTo(expectedCase.CustomPreconds));
                Assert.That(actualCase.CustomSteps, Is.EqualTo(expectedCase.CustomSteps));
                Assert.That(actualCase.CustomExpected, Is.EqualTo(expectedCase.CustomExpected));
            });
        }

        [Test]
        public void AddCaseTest()
        {
            var expectedCase = new Case();
            expectedCase.Title = "Anastasiya Test Case 2 - Add new Case";
            expectedCase.SectionId = 1;
            expectedCase.TemplateId = 1;
            expectedCase.TypeId = 6;
            expectedCase.PriorityId = 2;
            expectedCase.Estimate = "4h";
            expectedCase.Refs = "test refs";

            var actualCase = _caseService.AddCase(expectedCase.SectionId, expectedCase);
            _logger.Info("Actual Case: " + actualCase.ToString());

            Assert.Multiple(() =>
            {
                Assert.That(actualCase.Title, Is.EqualTo(expectedCase.Title));
                Assert.That(actualCase.SectionId, Is.EqualTo(expectedCase.SectionId));
                Assert.That(actualCase.TemplateId, Is.EqualTo(expectedCase.TemplateId));
                Assert.That(actualCase.TypeId, Is.EqualTo(expectedCase.TypeId));
                Assert.That(actualCase.PriorityId, Is.EqualTo(expectedCase.PriorityId));
                Assert.That(actualCase.Estimate, Is.EqualTo(expectedCase.Estimate));
                Assert.That(actualCase.Refs, Is.EqualTo(expectedCase.Refs));
            });
        }

        [Test]
        public void UpdateCaseTest()
        {
            var expectedCase = new Case();
            expectedCase.Id = 4;
            expectedCase.Title = "Anastasiya Test Case 2 - Update Test Case";
            expectedCase.TypeId = 3;
            expectedCase.PriorityId = 1;
            expectedCase.Estimate = "9h";
            expectedCase.Refs = "test refs update";

            var actualCase = _caseService.UpdateCase(expectedCase.Id, expectedCase);
            _logger.Info("id: " + actualCase.Id);
            _logger.Info("Actual Case: " + actualCase.ToString());

            Assert.Multiple(() =>
            {
                Assert.That(actualCase.Id, Is.EqualTo(expectedCase.Id));
                Assert.That(actualCase.Title, Is.EqualTo(expectedCase.Title));
                Assert.That(actualCase.TypeId, Is.EqualTo(expectedCase.TypeId));
                Assert.That(actualCase.PriorityId, Is.EqualTo(expectedCase.PriorityId));
                Assert.That(actualCase.Estimate, Is.EqualTo(expectedCase.Estimate));
                Assert.That(actualCase.Refs, Is.EqualTo(expectedCase.Refs));
            });
        }

        //NEED TO FIX
        [Test]
        public void DeleteCaseTest()
        {
            var expectedCase = new Case();
            expectedCase.Id = 10;
            
            var actualCase = _caseService.DeleteCase(expectedCase.Id, expectedCase);

            Assert.Multiple(() =>
            {
                Assert.That(actualCase.Id, Is.EqualTo(expectedCase.Id));
            });
        }
    }
}

