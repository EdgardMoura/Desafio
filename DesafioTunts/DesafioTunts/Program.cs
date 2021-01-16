/*
 * set working google api/ google sheets.
 */
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace DesafioTunts
{
    class Program
    {
        // If modifying these scopes, delete your previously saved credentials

        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Desafio Tunts";



        static void Main(string[] args)
        {
            Console.WriteLine("Process start");

            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                //string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None
                    ).Result;
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define request parameters.
            String spreadsheetId = "14D5q1gu-NfV6ky23M7Nt0wZVymLedHkLikv3czovEoc";
            String range = "engenharia_de_software!C4:H27";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            // Prints the "Situação" and "Nota para Aprovação Final" of students in the spreadsheet:
            // https://docs.google.com/spreadsheets/d/14D5q1gu-NfV6ky23M7Nt0wZVymLedHkLikv3czovEoc/edit#gid=0
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                Console.WriteLine("Faltas, P1, P2, P3, Situacao, Nota para Aprovação Final");
                int rows = 4;
                foreach (var row in values)
                {
                    BusinessRules br = new BusinessRules();

                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", row[0], row[1], row[2], row[3], br.AbsencePercentage(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString()), br.Naf(br.CalculatesAverage(row[1].ToString(), row[2].ToString(), row[3].ToString()), br.AbsencePercentage(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString())));

                    //Update SpeedSheet Column "Situação".:
                    String rangeUpdate = "engenharia_de_software!G" + rows.ToString();  // update cell
                    ValueRange valueRange = new ValueRange();
                    valueRange.MajorDimension = "COLUMNS";//"ROWS";//COLUMNS

                    //Processing the values "Situação" field.
                    var oblist = new List<object>() { br.AbsencePercentage(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString()) };
                    valueRange.Values = new List<IList<object>> { oblist };

                    SpreadsheetsResource.ValuesResource.UpdateRequest update = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, rangeUpdate);
                    update.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
                    UpdateValuesResponse result = update.Execute();


                    //Update SpeedSheet Column "Nota para Aprovação Final":
                    String rangeUpdate2 = "engenharia_de_software!H" + rows.ToString();  // update cell 
                    ValueRange valueRange2 = new ValueRange();
                    valueRange2.MajorDimension = "COLUMNS";//"ROWS";//COLUMNS

                    //Processing the values "Nota para Aprovação Final" field.
                    var oblist2 = new List<object>() { br.Naf(br.CalculatesAverage(row[1].ToString(), row[2].ToString(), row[3].ToString()), br.AbsencePercentage(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString())) };
                    valueRange2.Values = new List<IList<object>> { oblist2 };

                    SpreadsheetsResource.ValuesResource.UpdateRequest update2 = service.Spreadsheets.Values.Update(valueRange2, spreadsheetId, rangeUpdate2);
                    update2.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
                    UpdateValuesResponse result2 = update2.Execute();
                    rows++;
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }

            Console.WriteLine("Process Completed, check the spreadsheet.");
            Console.WriteLine("Please close this window");
            Console.Read();
        }
    }
}
