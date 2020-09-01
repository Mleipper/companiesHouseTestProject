using companiesHouseTestProject.CompaniesHouseAPIClient.CompaniesHouseResponses;
using System.Threading.Tasks;

namespace companiesHouseTestProject.CompaniesHouseAPIClient
{
    public interface ICompaniesHouseApiClient
    {
        Task<CompaniesHouseSearchResponse> PagedCompaniesSearch(string searchString, int? pageNumber, int? itemsPerPage);
    }
}
