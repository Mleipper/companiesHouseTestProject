using companiesHouseTestProject.CompaniesHouseAPI.CompaniesHouseResponses;
using System.Threading.Tasks;

namespace companiesHouseTestProject.CompaniesHouseAPI
{
    public interface ICompaniesHouseApiClient
    {
        Task<CompaniesHouseSearchResponse> PagedCompaniesSearch(string searchString, int? pageNumber, int? itemsPerPage);
    }
}
