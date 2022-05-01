using SmartMed.Dtos;
using System;
using System.Text;
using System.Text.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SmartApiIT.StepDefinitions
{
    [Binding]
    public class AddMedicationSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public AddMedicationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I submit a POST request (.*)")]
        public void WhenISubmitAPOSTRequest(string url, Table table)
        {
            var newMedication = table.CreateInstance<MedicationRequestDto>();
            var content = JsonSerializer.Serialize<MedicationRequestDto>(newMedication);
            var data = new StringContent(content, Encoding.UTF8, "application/json");

            var client = _scenarioContext.Get<HttpClient>("httpClient");
            var response = client.PostAsync(url, data);

            _scenarioContext.Add("responseTask", response);
        }

        [Then(@"the response content is valid")]
        public void ThenTheResponseContentIsValid()
        {
            var response = _scenarioContext.Get<HttpResponseMessage>("response");
            var responseContent = response.Content.ReadAsStringAsync().Result;
            var responseMedication = JsonSerializer.Deserialize<MedicationResponseDto>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            _scenarioContext.Add("responseMedication", responseMedication);

            Assert.NotNull(responseMedication);
            Assert.True(responseMedication?.IsValid);
        }
    }
}
