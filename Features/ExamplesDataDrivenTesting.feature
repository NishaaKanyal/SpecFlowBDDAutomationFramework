Feature: Examples Data Driven Testing

Google search for Selenium

@ExamplesDataDrivenTesting
Scenario Outline: Searching for Selenium in google
	Given Open the Browser
	When Enter the URL
	Then Search with <searchKey>
	Examples:
	| searchKey              |
	| selenium tutorials     |
	| Specflow BDD Framework |




	





