using companiesHouseTestProject.EDocumentsTestClient.EDocumentsModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace companiesHouseTestProject.EDocumentsTestClient
{
    public interface IEdocumentsTestClient
    {
        Task<List<CompanyModel>> Search(string Company_name);
        Task<CompanyModel> GetGivenCompany(int company_number);
        Task<List<string>> GetChanges(CompanyModel company_model);
    }
}
