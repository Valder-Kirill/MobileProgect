Feature: WorkingWithMultipleTabs

Working with multiple tabs

@WorkingWithMultipleTabs
Scenario: WorkingWithMultipleTabs
	When open '2' documents
	Then '3' documents are open
	When fill in all documents with text '<text>'
	Then all documents are filled with '<text>'
		And all documents have default names
	When open find form
		And go to replacement tab
		And fill the search field with text '<text>'
		And fill the replace field with text '<anotherText>'
		And click replace in all documents button
		And press ok in confirm button
		And close find form
	Then all documents are filled with '<anotherText>'
	When go to document numer '1'
		And press the back button
	Then is the document fill in '<text>'
	When go to document numer '2'
	Then is the document fill in '<anotherText>'
	When go to document numer '3'
	Then is the document fill in '<anotherText>'
	When go to document numer '3'
		And close curent document
		And select dont save in close document notification
	Then '2' documents are open
	When click close all document
		And select dont save in close document notification
	Then '1' documents are open
		And is the document fill in ''

	Examples: 
| text				 | anotherText |
| Aboba abra kadabra | Humburger   |