# Requirements

## Assumptions
	- There will be only one version of the document and changes will be tracked using the versioning feature of the MS Word.
	- Permissions 
## Development Phase I
	- Define liquid based xml template to generate xml string to create the word document.
	- Define the data model to be used in the template.
	- Generate byte array of the word document from the template and data model.
	- Save the byte array to a file for testing purposes. The byte array will be sent to the content service to be saved in the blob store.
	- Extract the user input data from the filled word document and return as list of key value pairs.
	- Generate word document using the extracted data (user input data) and the liquid based xml template
	- Structure of the data model remains the same but the data will be different to generate different word documents.
	- 


## Development Phase II