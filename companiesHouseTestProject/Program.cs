using companiesHouseTestProject.CompaniesHouseAPI;
using companiesHouseTestProject.EDocumentsTest;
using System;

namespace companiesHouseTestProject
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var companiesHouseApiClient = new CompaniesHouseAPIClient("API KEY");

            var eDocumentsClient = new EDocumentsTestClient(companiesHouseApiClient);

            var testData = await eDocumentsClient.Search("Edocuments");
        }
    }
}
