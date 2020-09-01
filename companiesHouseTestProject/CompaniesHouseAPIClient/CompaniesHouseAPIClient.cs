using companiesHouseTestProject.CompaniesHouseAPIClient.CompaniesHouseResponses;
using System;
using System.Threading.Tasks;

namespace companiesHouseTestProject.CompaniesHouseAPIClient
{
    class CompaniesHouseAPIClient : ICompaniesHouseApiClient
    {
        public Task<CompaniesHouseSearchResponse> PagedCompaniesSearch(string searchString, int? pageNumber, int? itemsPerPage)
        {
            throw new NotImplementedException();
        }
    }
}
