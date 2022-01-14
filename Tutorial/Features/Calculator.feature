Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](Tutorial/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Multiple two numbers
	Given the first number is 2
	And the second number is 3
	When the two numbers are multiply
	Then the result should be 6

Scenario Outline: Divide two numbers
	Given the first number is <number1>
	And the second number is <number2>
	When the two numbers are divided
	Then the result should be <result>
	Examples: 
	| number1 | number2 | result                |
	| 10      | 5       | 2                     |
	| 10      | 0       | Cannot divide by zero |

#Scenario with N numbers

Scenario: Add N numbers
	Given numbers are
	| Numbers |
	| 25      |
	| 2       |
	| 10      |
	When the numbers are added
	Then the result should be 37

	Scenario: Multiply N numbers
	Given numbers are
	| Numbers |
	| 25      |
	| 2       |
	| 10      |
	When the numbers are multiplied
	Then the result should be 500

Scenario: Divide N numbers
	Given numbers are
	| Numbers |
	| 25      |
	| 2       |
	| 10      |
	When the numbers are divided
	Then the result should be 1.25

Scenario: Sub N numbers
	Given numbers are
	| Numbers |
	| 25      |
	| 2       |
	| 10      |
	When the numbers are substracted
	Then the result should be 13

#formula

Scenario: Calculate formula with N numbers as inupts, without priotrity ex: 10*2+5-4 = 21
	Given formula
	| Operator | Numbers |
	|          | 10      |
	| *        | 2       |
	| +        | 5       |
	| -        | 4       |
	When formula is computed
	Then the result should be 21
