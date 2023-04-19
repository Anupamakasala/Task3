using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskSpecFlow.StepDefinitions
{
    [Binding]
    public class DummyStepDefinitions
    {
        [Given(@"I created to the dummy feature file")]
        public void GivenICreatedToTheDummyFeatureFile()
        {
            throw new PendingStepException();
        }

        [When(@"I tried to generate step definition")]
        public void WhenITriedToGenerateStepDefinition()
        {
            throw new PendingStepException();
        }

        [Then(@"I need to see the file under step definition")]
        public void ThenINeedToSeeTheFileUnderStepDefinition()
        {
            throw new PendingStepException();
        }
    }
}
