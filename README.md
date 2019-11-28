Assumptions/Instructions
========================
Main solution has been structed as below:

Core
 - Interfaces
      - All Interface can be placed here. In this case IExtractData is the one interface that's being implemented by both XML and JSON extracts.
 - Constants
      - All application level file-paths have been defined here. In this case XML file, XSD file, JSON file and JSON schema file paths have been placed here.
 - Logging
      - Entire application level static error messages have been placed here. These messages have been referred through out the application.
 - Models
      - Application specific models have been defined here. In our case it is Output model which is the same model returned by both XML and JSON extracts.
 - Modules
      - Two main modules to extract the data have been defined here. 
 - Schemas
      - Both XSD and JSON schema files have been defined here.
      
 All the provided source files have been placed under FeedData folder.
 
 Unit Test
 
 Two Unit tests each for XML and JSON files have been written. One is a valid test case and the other is an incorrect schema validation.
