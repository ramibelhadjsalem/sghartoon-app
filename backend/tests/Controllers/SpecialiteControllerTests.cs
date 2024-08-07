using System;
using System.Net;
using System.Net.Http.Json;
using API.Models;
using Xunit.Abstractions;

namespace tests.Controllers
{
	public class SpecialiteControllerTests : ControllerTestsBase<Specialite>
    {
		public SpecialiteControllerTests(ITestOutputHelper output) : base(output)
        {
        }

        protected override string BaseUrl => "/api/specialite";




        [Theory]
        [InlineData( HttpStatusCode.Created, HttpStatusCode.OK, HttpStatusCode.OK, HttpStatusCode.NoContent)]
        public async Task TestCRUDOperations(HttpStatusCode createStatusCode, HttpStatusCode getByIdStatusCode, HttpStatusCode getAllStatusCode, HttpStatusCode deleteStatusCode)
        {
           

            var specialite = new Specialite
            {
                Libelle = "Dyslexie",
                LibelleAR = "تونس",
                LibelleAN = "Tunisia"
            };

            // Create Specialite
            var createSpecialiteResponse = await CreateAsync(specialite);
            Assert.Equal(createStatusCode, createSpecialiteResponse.StatusCode);
            _output.WriteLine($"Create Specialite status code: {createSpecialiteResponse.StatusCode}");

            // Get Created Specialite by ID
            var createdSpecialite = await createSpecialiteResponse.Content.ReadFromJsonAsync<Specialite>();
            Assert.NotNull(createdSpecialite);
            var getSpecialiteByIdResponse = await GetByIdAsync(createdSpecialite.Id);
            Assert.Equal(getByIdStatusCode, getSpecialiteByIdResponse.StatusCode);
            _output.WriteLine($"Get Specialite by ID status code: {getSpecialiteByIdResponse.StatusCode}");

            // Get All Specialites
            var getAllSpecialitesResponse = await GetAllAsync();
            Assert.Equal(getAllStatusCode, getAllSpecialitesResponse.StatusCode);
            _output.WriteLine($"Get All Specialites status code: {getAllSpecialitesResponse.StatusCode}");

            // Delete Specialite
            var deleteSpecialiteResponse = await DeleteAsync(createdSpecialite.Id);
            Assert.Equal(deleteStatusCode, deleteSpecialiteResponse.StatusCode);
            _output.WriteLine($"Delete Specialite status code: {deleteSpecialiteResponse.StatusCode}");

        }
    }
}

