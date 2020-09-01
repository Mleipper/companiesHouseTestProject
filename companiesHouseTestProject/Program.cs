using companiesHouseTestProject.CompaniesHouseAPI;
using companiesHouseTestProject.EDocumentsTest;
using System;
using System.Linq;

namespace companiesHouseTestProject
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Edocument test project");
            
            var companiesHouseApiClient = new CompaniesHouseAPIClient("API key");

            var eDocumentsClient = new EDocumentsTestClient(companiesHouseApiClient);

            var companies = await eDocumentsClient.Search("Edocuments");

            companies.ForEach(c => Console.WriteLine($"Company Name: {c.CompanyName}, Company Number: {c.CompanyNumber}"));

            var companyModel = companies.FirstOrDefault();

            if (companyModel is object)
            {
                var company = await eDocumentsClient.GetGivenCompany(companyModel.CompanyNumber);

                Console.WriteLine($"Company name: {company.CompanyName} company Number: {company.CompanyNumber} called found on company number.");
            }


            Console.ReadKey();
        }
    }
}
