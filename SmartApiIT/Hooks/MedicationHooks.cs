using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using SmartMed.Dtos;
using System.Text;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace SmartApiIT.Hooks
{
    [Binding]
    public sealed class MedicationHooks
    {
        private ScenarioContext _scenarioContext;
        private MedicationRequestDto medication = new MedicationRequestDto("Ibuprofeno", 3);
        public MedicationHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void AddHttpClient()
        {
            var application = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>{builder.UseTestServer();});
            var client = application.CreateClient();
            _scenarioContext.Add("httpClient", client);
        }

        [BeforeScenario("delete")]
        public void CreateMedicationBeforeDelete()
        {
            var content = JsonSerializer.Serialize<MedicationRequestDto>(medication);
            var data = new StringContent(content, Encoding.UTF8, "application/json");

            var client = _scenarioContext.Get<HttpClient>("httpClient");
            var task = client.PostAsync("/Medications", data);

            var response = task.GetAwaiter().GetResult();

            var responseContent = response.Content.ReadAsStringAsync().Result;
            var responseMedication = JsonSerializer.Deserialize<MedicationResponseDto>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            Assert.True(responseMedication?.IsValid);

            _scenarioContext.Add("testMedication", responseMedication);
        }

        [AfterScenario("create")]
        public void AfterScenario()
        {
            var client = _scenarioContext.Get<HttpClient>("httpClient");
            var createdMedication = _scenarioContext.Get<MedicationResponseDto>("responseMedication");
            var task = client.DeleteAsync($"/Medications/{createdMedication.UniqueId}");
            var response = task.GetAwaiter().GetResult();
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var responseMedication = JsonSerializer.Deserialize<MedicationResponseDto>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            Assert.True(responseMedication?.IsValid);
        }
    }
}