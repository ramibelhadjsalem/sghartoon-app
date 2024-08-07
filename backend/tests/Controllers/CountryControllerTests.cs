using System;
using System.Net;
using System.Net.Http.Json;
using API.Models;
using Xunit.Abstractions;

namespace tests.Controllers
{
    public class CountryControllerTests : ControllerTestsBase<Country>
    {
        public CountryControllerTests(ITestOutputHelper output) : base(output)
        {
        }

        protected override string BaseUrl => "/api/country";

        [Fact]
        public void Test1()
        {

        }
        [Theory]
        [InlineData(HttpStatusCode.Created, HttpStatusCode.OK, HttpStatusCode.OK, HttpStatusCode.NoContent)]
        public async Task TestCRUDOperations(HttpStatusCode createStatusCode, HttpStatusCode getByIdStatusCode, HttpStatusCode getAllStatusCode, HttpStatusCode deleteStatusCode)
        {


            var newCountry = new Country
            {
                Libelle = "Test Country",
                LibelleAR = "Test Country AR",
                LibelleAN = "Test Country AN",
                PhoneCode = "+123",
                AvatarsCulture = "Culture Name",
                PhoneLength = 10,
                FlagImage = Guid.NewGuid()
            };

            var createResponse = await CreateAsync(newCountry);
            Assert.Equal(createStatusCode, createResponse.StatusCode);

            var createdCountry = await createResponse.Content.ReadFromJsonAsync<Country>();
            Assert.NotNull(createdCountry);
            _output.WriteLine($"Created Country ID: {createdCountry.Id}");

            var getResponse = await GetByIdAsync(createdCountry.Id);
            Assert.Equal(getByIdStatusCode, getResponse.StatusCode);

            if (getResponse.StatusCode == HttpStatusCode.OK)
            {
                var countryWithId = await getResponse.Content.ReadFromJsonAsync<Country>();
                Assert.NotNull(countryWithId);
                _output.WriteLine($"Country Retrieved by ID: {countryWithId.Id}");
            }

            var getAllResponse = await GetAllAsync();
            Assert.Equal(getAllStatusCode, getAllResponse.StatusCode);

            if (getAllStatusCode == HttpStatusCode.OK)
            {
                var countryList = await getAllResponse.Content.ReadFromJsonAsync<List<Country>>();
                Assert.NotNull(countryList);
                Assert.NotEmpty(countryList);
            }

            var deleteResponse = await DeleteAsync(createdCountry.Id);
            Assert.Equal(deleteStatusCode, deleteResponse.StatusCode);

            _output.WriteLine($"Deleted Country with ID: {createdCountry.Id}");

        }
    }
}

