﻿using companiesHouseTestProject.CompaniesHouseAPI;
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

        public Task<List<string>> GetChanges(CompanyModel company_model)
        {
            throw new System.NotImplementedException();
        }

        public Task<CompanyModel> GetGivenCompany(int company_number)
        {
            throw new System.NotImplementedException();
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
            //foreach (var company in companiesHouseData.Items)
            //{
            //    var companyModel = CreateCompanyModel(company);

            //    companies.Add(companyModel);
            //}
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
                CompanyNumber = long.Parse(company.Company_number)
            };
        }
    }
}