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

        public void Init()
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
        
        public void UpdateCells(List<IList<object>> updateList)
        {
            var range = "Ballistics!B12";

            var valueRange = new ValueRange();

            // Setting Cell Value...
            valueRange.Values = updateList;

            // Performing Update Operation...
            var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, range);

            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;

            var appendReponse = updateRequest.Execute();
        }
    }
}

