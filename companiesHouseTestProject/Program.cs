using companiesHouseTestProject.CompaniesHouseAPI;
using System;

namespace companiesHouseTestProject
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var CompaniesHouseApiClient = new CompaniesHouseAPIClient("APIKEY here");

            var testData = await CompaniesHouseApiClient.PagedCompaniesSearch("Edocuments", 0, 100);

        }
    }
}
