Feature: FillInTheDocument

checking the filling of documents

@FillInTheDocument
Scenario: FillInTheDocument
	When clear document
		And fill in the document with '<text>'
	Then is the document fill in '<text>'
	When select all the text
		And press scissors
	Then is the document fill in ''
	When click on the insert button
	Then is the document fill in '<text>'
	When fill in the document with '<text>'
	Then is the document fill in '<text><text>'
	When press the back button
	Then is the document fill in '<text>'
	When press the forward button
	Then is the document fill in '<text><text>'
	When select all the text
		And click copy button
		And clear document
	Then is the document fill in ''
	When click on the record button
	Then the stop Recording button has become active
	When click on the insert button
	Then is the document fill in '<text><text>'
	When click on the stop recording button
	Then the play button has become active
	When click on the play button
	Then is the document fill in '<text><text><text><text>'
	When press the multiple run button and run 2 times
	Then is the document fill in '<text><text><text><text><text><text><text><text>'

Examples: 
| text				 |
| Aboba abra kadabra |