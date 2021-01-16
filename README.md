Methods and tools used to develop the application:
- We use Visual Studio 2017.
- .Net Framework 4.6.1.
- C # Programming Language
- Search the Google Sheet API Documentation on how to access and update a spreadsheet (developers.google.com).
- Enable the Google Sheet API for the project.
- Install the package to use the google sheet package (Google.Api.Sheets.v4).
- Configuration of the credentials file in the project, in this case we use the debug folder to store the credentials.json file.
- Implementation of Interaction with the spreadsheet.
- Implementation of business and processing rules in a separate class.
- Spreadsheet link available: Spreadsheet: https://docs.google.com/spreadsheets/d/1XvWJcRLj2WAeXO3ULQ_GxGm9---3SZkjMbGcXMJtt70/edit?usp=sharing
- Copy made, configured as the Spreadsheet publishes: https://docs.google.com/spreadsheets/d/14D5q1gu-NfV6ky23M7Nt0wZVymLedHkLikv3czovEoc/edit#gid=0

Auxiliary documentation:
 - The methods were commented to facilitate the understanding of the system.

Overview:
 - The system is divided into two classes, one for interacting with Google Sheets (reading and updating), where during reading,
 the methods that are available in the business rules class are executed, processing each cell to be updated.
 - Used good notation practices to name methods and classes.
 - The application requirements respected the proposed rules of the Tunts challenge.


To run the application:
- GitHub link https://github.com/EdgardMoura/Desafio
- Use the Desafio Tunts.exe executable file available in the path: \ DesafioTunts \ DesafioTunts \ bin \ Debug \
- Click on the spreadsheet to check the result https://docs.google.com/spreadsheets/d/14D5q1gu-NfV6ky23M7Nt0wZVymLedHkLikv3czovEoc/edit#gid=0
(can also be seen during execution).


Considerations:
- There is a limit on daily requests when using the Google API, as it does not use a paid license type.
