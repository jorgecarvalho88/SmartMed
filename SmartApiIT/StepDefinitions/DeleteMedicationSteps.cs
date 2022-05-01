using SmartMed.Dtos;
using System;
using TechTalk.SpecFlow;

namespace SmartApiIT.StepDefinitions
{
    [Binding]
    public class DeleteMedicationSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public DeleteMedicationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I submit a DELETE request (.*)")]
        public void WhenISubmitADELETERequest(string url)
        {
            var client = _scenarioContext.Get<HttpClient>("httpClient");
            var createdMedication = _scenarioContext.Get<MedicationResponseDto>("testMedication");
            var response = client.DeleteAsync($"{url}/{createdMedication.UniqueId}");

            _scenarioContext.Add("responseTask", response);
        }
    }
}
