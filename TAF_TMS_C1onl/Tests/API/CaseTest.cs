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
        protected Case expectedCaseForCreate = TestDataHelper.GetTestCase("CreateCase.json");
        protected Case expectedCaseForUpdate = TestDataHelper.GetTestCase("UpdateCase.json");

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void AddCaseTest()
        {
            var actualCase = _caseService.AddCase(expectedCaseForCreate.SectionId, expectedCaseForCreate);
            _logger.Info("Actual Case: " + actualCase.ToString());

            Assert.Multiple(() =>
            {
                Assert.That(actualCase.Title, Is.EqualTo(expectedCaseForCreate.Title));
                Assert.That(actualCase.SectionId, Is.EqualTo(expectedCaseForCreate.SectionId));
                Assert.That(actualCase.TemplateId, Is.EqualTo(expectedCaseForCreate.TemplateId));
                Assert.That(actualCase.TypeId, Is.EqualTo(expectedCaseForCreate.TypeId));
                Assert.That(actualCase.PriorityId, Is.EqualTo(expectedCaseForCreate.PriorityId));
                Assert.That(actualCase.Estimate, Is.EqualTo(expectedCaseForCreate.Estimate));
            });
        }

        [Test]
        public void GetCaseTest()
        {
            var expectedCase = _caseService.AddCase(expectedCaseForCreate.SectionId, expectedCaseForCreate);
            _logger.Info("Expected Added Case:\n " + expectedCase.ToString());

            var actualCase = _caseService.GetAsCase(expectedCase.Id);
            _logger.Info($"Actual Case:\n " + actualCase.ToString());

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

        //BAD REQUEST?!!
        //[Test]
        public void UpdateCaseTest()
        {
            var addedCase = _caseService.AddCase(expectedCaseForCreate.SectionId, expectedCaseForCreate);
            _logger.Info("Added Case Before UPDATE: " + addedCase.ToString());

            var actualCase = _caseService.UpdateCase(addedCase.Id, expectedCaseForUpdate);
            _logger.Info("Actual Case after UPDATE: " + actualCase.ToString());

            Assert.Multiple(() =>
            {
                Assert.That(actualCase.Id, Is.EqualTo(addedCase.Id));
                Assert.That(actualCase.Title, Is.EqualTo(expectedCaseForUpdate.Title));            
                Assert.That(actualCase.TypeId, Is.EqualTo(expectedCaseForUpdate.TypeId));
                Assert.That(actualCase.PriorityId, Is.EqualTo(expectedCaseForUpdate.PriorityId));
                Assert.That(actualCase.Estimate, Is.EqualTo(expectedCaseForUpdate.Estimate));
            });
        }

        [Test]
        public void DeleteCaseTest()
        {
            var addedCase = _caseService.AddCase(expectedCaseForCreate.SectionId, expectedCaseForCreate);
            _logger.Info("Added Case Before DELETION: " + addedCase.ToString());

            _caseService.DeleteCase(addedCase.Id);
            try
            {
               var actualCase = _caseService.GetAsCase(addedCase.Id);
               Assert.That(actualCase, Is.Null);
            }
            catch (HttpRequestException ex)
            {
                _logger.Info("Message: " + ex.Message);
                Assert.That(true);
            }
            catch (Exception ex)
            {
                _logger.Info("Message: " + ex.Message);
                Assert.That(false);
            }
        }
    }
}

