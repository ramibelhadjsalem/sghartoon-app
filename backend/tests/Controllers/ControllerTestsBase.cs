using System;
using System.Net.Http.Json;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit.Abstractions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;

namespace tests.Controllers
{
	public abstract class ControllerTestsBase<T> : IClassFixture<WebApplicationFactory<Program>>
    {

        protected readonly HttpClient _client;
        protected readonly ITestOutputHelper _output;
        public ControllerTestsBase(ITestOutputHelper output )
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _client = webAppFactory.CreateDefaultClient();
            _output = output;
        }
        protected abstract string BaseUrl { get; }



        protected async Task<HttpResponseMessage> CreateAsync(T entity)
        {
            try
            {
                var response = await _client.PostAsJsonAsync(BaseUrl, entity);
                LogResponse("Create", response);
                return response;
            }
            catch (Exception ex)
            {
                _output.WriteLine($"Failed to create entity: {ex.Message}");
                return null;
            }
        }

        protected async Task<HttpResponseMessage> GetByIdAsync(string id)
        {
            try
            {
                var response = await _client.GetAsync($"{BaseUrl}/{id}");
                LogResponse("Get by ID", response);
                return response;
            }
            catch (Exception ex)
            {
                _output.WriteLine($"Failed to get entity by ID: {ex.Message}");
                return null;
            }
        }

        protected async Task<HttpResponseMessage> GetAllAsync()
        {
            try
            {
                var response = await _client.GetAsync(BaseUrl);
                LogResponse("Get all", response);
                return response;
            }
            catch (Exception ex)
            {
                _output.WriteLine($"Failed to get all entities: {ex.Message}");
                return null;
            }
        }

        protected async Task<HttpResponseMessage> DeleteAsync(string id)
        {
            try
            {
                var response = await _client.DeleteAsync($"{BaseUrl}/{id}");
                LogResponse("Delete", response);
                return response;
            }
            catch (Exception ex)
            {
                _output.WriteLine($"Failed to delete entity: {ex.Message}");
                return null;
            }
        }

        protected void LogResponse(string operation, HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                _output.WriteLine($"{operation} operation succeeded. Status code: {response.StatusCode}");
            }
            else
            {
                _output.WriteLine($"{operation} operation failed. Status code: {response.StatusCode}");
            }
        }
        protected async Task<HttpResponseMessage> UpdateAsync(T entity)
        {
            try
            {
                var response = await _client.PutAsJsonAsync(BaseUrl, entity);
                LogResponse("Update", response);
                return response;
            }
            catch (Exception ex)
            {
                _output.WriteLine($"Failed to update entity: {ex.Message}");
                return null;
            }
        }
    }
}

