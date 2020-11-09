using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace CsharpTemplate.Hooks
{
    [Binding]
    public class ExtentRportHooks
    {
        private readonly FeatureContext _featureContext;
        private static ExtentTest featureName;
        private static ExtentTest Scenario;
        private static AventStack.ExtentReports.ExtentReports extent;
        private FeatureContext featureContext;
        private readonly ScenarioContext _scenarioContext;



        public ExtentRportHooks(FeatureContext featureContext, ScenarioContext scenariocontext)
        {
            _scenarioContext = scenariocontext;
            _featureContext = featureContext;
        }



        [BeforeScenario(Order = -1)]
        public void TestSetUp()
        {
            Scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }



        [BeforeTestRun(Order = -1)]
        public static void InitializeReport()
        {
            string file = "ExtentReport.html";
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
            var htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);
        }



        [AfterTestRun(Order = -1)]
        public static void TearDownReport()
        {
            extent.Flush();
        }



        [BeforeFeature]
        public static void BeforeFeatureRun(FeatureContext feaureContext)
        {
            featureName = extent.CreateTest<Feature>(feaureContext.FeatureInfo.Title);
        }



        [AfterStep]
        public void InsertReports()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    Scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "When")
                {
                    Scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "Then")
                {
                    Scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "And")
                {
                    Scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                }
            }
            else if (_scenarioContext.TestError != null)



            {
                if (stepType == "Given")
                {
                    Scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message + _scenarioContext.TestError.StackTrace);
                }
                else if (stepType == "When")
                {
                    Scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message + _scenarioContext.TestError.StackTrace);
                }
                else if (stepType == "Then")
                {
                    Scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message + _scenarioContext.TestError.StackTrace);
                }



                else if (stepType == "And")
                {
                    Scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(_scenarioContext.TestError.Message + _scenarioContext.TestError.StackTrace);
                }
            }
        }
    }
}
