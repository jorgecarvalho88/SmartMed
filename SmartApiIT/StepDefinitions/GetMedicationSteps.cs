using System;
using TechTalk.SpecFlow;

namespace SmartApiIT.StepDefinitions
{
    [Binding]
    public class GetMedicationSteps
    {
        private readonly ScenarioContext _scenarioContext;
        public GetMedicationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I submit a GET request (.*)")]
        public void WhenISubmitAGETRequest(string url)
        {
            var client = _scenarioContext.Get<HttpClient>("httpClient");
            var response = client.GetAsync(url);

            _scenarioContext.Add("responseTask", response);
        }

        [Then(@"I receive a response")]
        public void ThenIReceiveAResponse()
        {
            var task = _scenarioContext.Get<Task<HttpResponseMessage>>("responseTask");
            var response = task.GetAwaiter().GetResult();
            _scenarioContext.Add("response", response);
        }

        [Then(@"the http response status is (.*)")]
        public void ThenTheHttpResponseStatusIs(string status)
        {
            var response = _scenarioContext.Get<HttpResponseMessage>("response");
            Assert.Equal(status, response.StatusCode.ToString());
        }
    }
}
