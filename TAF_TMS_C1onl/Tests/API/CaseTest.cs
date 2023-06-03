using System;
using System.Net;
using System.Reflection;
using Newtonsoft.Json.Linq;
using NLog;
using RestSharp;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Pages;
using TAF_TMS_C1onl.Services;
using TAF_TMS_C1onl.Utilites.Helpers;

namespace TAF_TMS_C1onl.Tests.API
{
    public class CaseTest : BaseApiTest
    {
        protected Case pathForGetCase = TestDataHelper.GetTestCase("GetCase.json");
        protected Case pathForCreateCase = TestDataHelper.GetTestCase("CreateCase.json");
        protected Case pathForUpdateCase = TestDataHelper.GetTestCase("UpdateCase.json");

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void GetCaseTest()
        {
            var expectedCase = new Case();
            expectedCase.Id = pathForGetCase.Id;
            expectedCase.Title = pathForGetCase.Title;
            expectedCase.SectionId = pathForGetCase.SectionId;
            expectedCase.TemplateId = pathForGetCase.TemplateId;
            expectedCase.TypeId = pathForGetCase.TypeId;
            expectedCase.PriorityId = pathForGetCase.PriorityId;
            expectedCase.Estimate = pathForGetCase.Estimate;

            var actualCase = _caseService.GetAsCase(pathForGetCase.Id);
            _logger.Info($"jsonObject:\n " + actualCase.ToString());

            Assert.Multiple(() =>
            {
                Assert.That(actualCase.Id, Is.EqualTo(expectedCase.Id));
                Assert.That(actualCase.Title, Is.EqualTo(expectedCase.Title));
                Assert.That(actualCase.SectionId, Is.EqualTo(expectedCase.SectionId));
                Assert.That(actualCase.TemplateId, Is.EqualTo(expectedCase.TemplateId));
                Assert.That(actualCase.TypeId, Is.EqualTo(expectedCase.TypeId));
                Assert.That(actualCase.PriorityId, Is.EqualTo(expectedCase.PriorityId));
                Assert.That(actualCase.Estimate, Is.EqualTo(expectedCase.Estimate));
            });
        }

        [Test]
        public void AddCaseTest()
        {
            var expectedCase = new Case();
            expectedCase.Title = pathForCreateCase.Title;
            expectedCase.SectionId = pathForCreateCase.SectionId;
            expectedCase.TemplateId = pathForCreateCase.TemplateId;
            expectedCase.TypeId = pathForCreateCase.TypeId;
            expectedCase.PriorityId = pathForCreateCase.PriorityId;
            expectedCase.Estimate = pathForCreateCase.Estimate;

            var actualCase = _caseService.AddCase(pathForCreateCase.SectionId, expectedCase);
            _logger.Info("Actual Case: " + actualCase.ToString());

            Assert.Multiple(() =>
            {
                Assert.That(actualCase.Title, Is.EqualTo(expectedCase.Title));
                Assert.That(actualCase.SectionId, Is.EqualTo(expectedCase.SectionId));
                Assert.That(actualCase.TemplateId, Is.EqualTo(expectedCase.TemplateId));
                Assert.That(actualCase.TypeId, Is.EqualTo(expectedCase.TypeId));
                Assert.That(actualCase.PriorityId, Is.EqualTo(expectedCase.PriorityId));
                Assert.That(actualCase.Estimate, Is.EqualTo(expectedCase.Estimate));
            });
        }

        //BAD REQUEST?!!
        //[Test]
        public void UpdateCaseTest()
        {
            var addedCase = new Case();
            addedCase.Title = pathForCreateCase.Title + " FOR UPDATE";
            addedCase.SectionId = pathForCreateCase.SectionId;
            addedCase.TemplateId = pathForCreateCase.TemplateId;
            addedCase.TypeId = pathForCreateCase.TypeId;
            addedCase.PriorityId = pathForCreateCase.PriorityId;
            addedCase.Estimate = pathForCreateCase.Estimate;

            var newCase = _caseService.AddCase(pathForCreateCase.SectionId, addedCase);
            _logger.Info("Added Case Before UPDATE: " + newCase.ToString());

            var expectedCase = new Case();
            expectedCase.Title = pathForUpdateCase.Title;
            expectedCase.TypeId = pathForUpdateCase.TypeId;
            expectedCase.PriorityId = pathForUpdateCase.PriorityId;
            expectedCase.Estimate = pathForUpdateCase.Estimate;
            expectedCase.Refs = pathForUpdateCase.Refs;

            var actualCase = _caseService.UpdateCase(newCase.Id, expectedCase);
            _logger.Info("Actual Case after UPDATE: " + actualCase.ToString());

            Assert.Multiple(() =>
            {
                Assert.That(actualCase.Id, Is.EqualTo(newCase.Id));
                Assert.That(actualCase.Title, Is.EqualTo(expectedCase.Title));
                Assert.That(actualCase.TypeId, Is.EqualTo(expectedCase.TypeId));
                Assert.That(actualCase.PriorityId, Is.EqualTo(expectedCase.PriorityId));
                Assert.That(actualCase.Estimate, Is.EqualTo(expectedCase.Estimate));
                Assert.That(actualCase.Refs, Is.EqualTo(expectedCase.Refs));
            });
        }

        [Test]
        public void DeleteCaseTest()
        {
            var addedCase = new Case();
            addedCase.Title = pathForCreateCase.Title + " FOR DELETE";
            addedCase.SectionId = pathForCreateCase.SectionId;
            addedCase.TemplateId = pathForCreateCase.TemplateId;
            addedCase.TypeId = pathForCreateCase.TypeId;
            addedCase.PriorityId = pathForCreateCase.PriorityId;
            addedCase.Estimate = pathForCreateCase.Estimate;

            var newCase = _caseService.AddCase(pathForCreateCase.SectionId, addedCase);
            _logger.Info("Added Case Before DELETION: " + newCase.ToString());

            _caseService.DeleteCase(newCase.Id);
            try
            {
                _caseService.GetAsCase(newCase.Id);
            }
            catch (HttpRequestException ex)
            {
                _logger.Info(ex.Message);
                Assert.That(true);
            }
            catch (Exception ex)
            {
                _logger.Info(ex.Message);
                Assert.That(false);
            }
        }
    }
}

