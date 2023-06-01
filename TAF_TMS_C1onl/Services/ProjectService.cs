﻿using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using TAF_TMS_C1onl.Clients;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Utilites.Configuration;
using TAF_TMS_C1onl.Utilites.Helpers;

namespace TAF_TMS_C1onl.Services
{
    public class ProjectService : BaseService
    {
        public static readonly string GET_PROJECT = "index.php?/api/v2/get_project/{project_id}";

        public ProjectService(ApiClient apiClient) : base(apiClient)
        {

        }

        public RestResponse GetProject(string projectId)
        {
            var request = new RestRequest(GET_PROJECT)
                .AddUrlSegment("project_id", projectId);

            return _apiClient.Execute(request);
        }

        public Project GetAsProject(string projectId)
        {
            var request = new RestRequest(Endpoints.GET_PROJECT)
                .AddUrlSegment("project_id", projectId);

            return _apiClient.Execute<Project>(request);
        }

        public Task<RestResponse> GetProjectAsync(string projectId)
        {
            var request = new RestRequest(GET_PROJECT)
                .AddUrlSegment("project_id", projectId);

            return _apiClient.ExecuteAsync(request);
        }

        public Task<Project> GetAsProjectAsync(string projectId)
        {
            var request = new RestRequest(GET_PROJECT)
                .AddUrlSegment("project_id", projectId);

            return _apiClient.ExecuteAsync<Project>(request);
        }

        //public List<Project> GetProjects(string projectId)
        //{
        //    var request = new RestRequest("index.php?/api/v2/get_projects");
        //    var response = _apiClient.Execute(request);
        //    var json = JObject.Parse(response.Content).SelectToken("$.projects");
        //    return JsonHelper.FromJson(json);
        //}

        public Task<Project> AddProjectAsync(Project project)
        {
            var request = new RestRequest("index.php?/api/v2/add_project", Method.Post)
                .AddHeader("Content-Type", "application/json")
                .AddBody(project);

            return _apiClient.ExecuteAsync<Project>(request);
        }

        public RestResponse UpdateProject(string projectId, Project project)
        {
            return null;
        }

        public RestResponse DeleteProject(string projectId)
        {
            return null;
        }
    }
}

