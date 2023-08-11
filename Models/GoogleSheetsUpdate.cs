using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace ReloadingDB.Models
{
    public class GoogleSheetsUpdate
    {
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "GoogleSheetsUpdate";
        static readonly string SpreadsheetId = "1cexN4tKkWKfDum5mdqF-UiqlGH3LSPzboLJum5lJhkg";
        static SheetsService service;

        public static void Init()
        {
            GoogleCredential credential;

            // Put your credentials json file in the root of the solution and make sure copy to output dir property is set to always copy 
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }

            // Create Google Sheets API service.
            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });
        }

        public static void UpdateCells()
        {
            var range = "Ballistics!B12";

            var valueRange = new ValueRange();

            // Setting Cell Value...
            var oblist = new List<object>() { 3000 };

            valueRange.Values = new List<IList<object>> { oblist };

            // Performing Update Operation...
            var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, range);

            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;

            var appendReponse = updateRequest.Execute();
        }
    }
}

