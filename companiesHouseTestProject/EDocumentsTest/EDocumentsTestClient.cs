using companiesHouseTestProject.CompaniesHouseAPI;
using companiesHouseTestProject.CompaniesHouseAPI.CompaniesHouseResponses;
using companiesHouseTestProject.EDocumentsTest.EDocumentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace companiesHouseTestProject.EDocumentsTest

{
    public class EDocumentsTestClient : IEdocumentsTestClient
    {
        private readonly ICompaniesHouseApiClient _apiClient;
        public EDocumentsTestClient(ICompaniesHouseApiClient companiesHouseApiClient)
        {
            _apiClient = companiesHouseApiClient;
        }

        public async Task<List<string>> GetChanges(CompanyModel company_model)
        {
            var company = await GetGivenCompany(company_model.CompanyNumber);
            List<string> changes = new List<string>();

            if (!company.CompanyName.Equals(company_model.CompanyName))
            {
                changes.Add($"Company name has changed from: {company_model.CompanyName} to {company.CompanyName}");

                company_model.CompanyName = company.CompanyName;
            }

            if (!company.CompanyAddress.Equals(company_model.CompanyAddress))
            {
                changes.Add($"Company Address has changed from: {company_model.CompanyAddress} to {company.CompanyAddress}");
                company_model.CompanyAddress = company.CompanyAddress;
            }

            return changes;
        }

        public async Task<CompanyModel> GetGivenCompany(string company_number)
        {
            try
            {
                var response = await _apiClient.PagedCompaniesSearch(company_number, null, null);

                if (response is null || !response.Items.Any())
                {
                    return default;
                }

                var companyData = response.Items.Where(m => m.Company_number == company_number)
                    .FirstOrDefault();

                if (companyData is object)
                {
                    return CreateCompanyModel(companyData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occured while in method {nameof(GetGivenCompany)} details: {ex.Message}");
            }

            return default;
        }

        public async Task<List<CompanyModel>> Search(string company_name)
        {
            var itemsPerPage = 100;
            var pageNumber = 0;
            var hasNextPage = true;
            List<CompanyModel> companies = new List<CompanyModel>();

            while (hasNextPage)
            {
                try
                {
                    var response = await _apiClient.PagedCompaniesSearch(company_name, pageNumber, itemsPerPage);

                    if (response is null || !response.Items.Any())
                    {
                        break;
                    }

                    hasNextPage = response.HasNextPage();

                    ProcessResponse(companies, response);

                    pageNumber++;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"The following exception occured while retriving data for page: {pageNumber} message reads as {e.Message}");
                    hasNextPage = false;
                }
            }
            return companies;
        }

        private void ProcessResponse(List<CompanyModel> companies, CompaniesHouseSearchResponse companiesHouseData)
        {
            var companiesToAdd = companiesHouseData.Items
                .Select(c => CreateCompanyModel(c));

            companies.AddRange(companiesToAdd);
        }

        private CompanyModel CreateCompanyModel(Items company)
        {
            return new CompanyModel()
            {
                CompanyAddress = company.Address_snippet,
                CompanyName = company.Title,
                CompanyNumber = company.Company_number
            };
        }
    }
}
