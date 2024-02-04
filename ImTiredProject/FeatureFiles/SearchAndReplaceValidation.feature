Feature: SearchAndReplaceValidation

Checking the correctness of text search and replacement

@SearchAndReplaceValidation
Scenario: SearchAndReplaceValidation
	Given app is open
	When clear document
		And fill in the document with '<text>'
		And open find form
		And paste the text '<anotherText>' and click next
	Then the message with text should appear - 'failSearchMessage'
	When paste the text '<text>' and click next
		Then the message with text should appear - 'goodSearchMessage'
	When go to replacement tab
		And fill the search field with text '<text>'
		And fill the replace field with text '<anotherText>'
		And click replace all button
	Then the message with text should appear - 'goodReplaceMessage'
	When close find form
	Then is the document fill in '<anotherText>'
	When press the back button
	Then is the document fill in '<text>'
	When open find form
		And go to replacement tab
		And activate Match case checkbox
		And fill the search field with text '<text>', but without a capital letter at the beginning
		And fill the replace field with text '<anotherText>'
		And click replace all button
	Then the message with text should appear - 'badReplaceMessage'
	When deactivate Match case checkbox
		
Examples: 
| text               | anotherText | findErrorText                 | goodReplaceText | badReplaceText |
| Aboba abra kadabra | Humburger   | Не удается найти текст |                 |                |
