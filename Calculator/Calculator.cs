using System;
using System.Collections.Generic;

namespace MyCalculator
{
    public class Calculator
    {
        public string Add(List<int> numbers)
        {
            int result = 0;

            foreach (int number in numbers)
            {
                result += number;
            }

            return result.ToString();
        }

        public string Substracted(List<int> numbers)
        {
            int result = numbers[0];

            for (int i = 1; i != numbers.Count; i++)
            {
                result -= numbers[i];
            }

            return result.ToString();
        }

        public string Multiply(List<int> numbers)
        {
            int result = numbers[0];

            for (int i = 1; i != numbers.Count; i++)
            {
                result *= numbers[i];
            }

            return result.ToString();
        }

        public string Divide(List<int> numbers)
        {
            try
            {
                float result = numbers[0];

                for (int i = 1; i != numbers.Count; i++)
                {
                    result /= numbers[i];
                }

                if (float.IsInfinity(result))
                {
                    return "Cannot divide by zero";
                }

                return result.ToString();
            }
            catch (DivideByZeroException)
            {
                return "Cannot divide by zero";
            }
        }

        public string ComputeFormula(List<int> inputNumbers, List<string> operators)
        {
            //10*2+5-4
            // result = 10*2
            // result = result+5
            // result = result-4

            string result = "";
            int left = inputNumbers[0];
            for (int i = 1; i != inputNumbers.Count; i++)
            {
                string ope = operators[i - 1];
                int right = inputNumbers[i];

                List<int> inputs = new List<int>()
                {
                    left, right
                };

                switch (ope)
                {
                    case "+":
                        result = Add(inputs);
                        break;

                    case "-":
                        result = Substracted(inputs);
                        break;

                    case "*":
                        result = Multiply(inputs);
                        break;

                    case "/":
                        result = Divide(inputs);
                        break;

                    default:
                        break;
                }

                left = int.Parse(result);
            }

            return result;
        }      
    }
}
