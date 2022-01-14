using FluentAssertions;
using MyCalculator;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Tutorial.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        private int _input1;
        private int _input2;

        private List<int> _inputNumbers;
        private List<string> _operators;

        private string _result;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _inputNumbers = new List<int>();
            _operators = new List<string>();
        }

        #region first and second

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            this._input1 = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            this._input2 = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            Calculator target = new Calculator();
            this._result = target.Add(new List<int>() { this._input1, this._input2 });
        }

        [When(@"the two numbers are multiply")]
        public void WhenTheTwoNumbersAreMultiply()
        {
            Calculator target = new Calculator();
            this._result = target.Multiply(new List<int> { this._input1, this._input2 });
        }

        [When(@"the two numbers are divided")]
        public void WhenTheTwoNumbersAreDivided()
        {
            Calculator target = new Calculator();
            this._result = target.Divide(new List<int> { this._input1, this._input2 });
        }

        #endregion

        [Given(@"numbers are")]
        public void GivenNumbersAre(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                int value = int.Parse(row["Numbers"]);
                this._inputNumbers.Add(value);
            }
        }

        [When(@"the numbers are added")]
        public void WhenTheNumbersAreAdded()
        {
            Calculator target = new Calculator();
            this._result = target.Add(this._inputNumbers);
        }

        [When(@"the numbers are multiplied")]
        public void WhenTheNumbersAreMultiplied()
        {
            Calculator target = new Calculator();
            this._result = target.Multiply(this._inputNumbers);
        }

        [When(@"the numbers are divided")]
        public void WhenTheNumbersAreDivided()
        {
            Calculator target = new Calculator();
            this._result = target.Divide(this._inputNumbers);
        }

        [When(@"the numbers are substracted")]
        public void WhenTheNumbersAreSubstracted()
        {
            Calculator target = new Calculator();
            this._result = target.Substracted(this._inputNumbers);
        }

        [Given(@"formula")]
        public void GivenFormula(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                string ope = row["Operator"];
                if (!string.IsNullOrWhiteSpace(ope))
                {
                    _operators.Add(ope);
                }

                int value = int.Parse(row["Numbers"]);
                this._inputNumbers.Add(value);
            }
        }

        [When(@"formula is computed")]
        public void WhenFormulaIsComputed()
        {
            Calculator target = new Calculator();
            this._result = target.ComputeFormula(_inputNumbers, _operators);
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(string result)
        {
            this._result.Should().Be(result);
        }
    }
}
