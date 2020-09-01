using companiesHouseTestProject.EDocumentsTest.EDocumentsModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace companiesHouseTestProject.EDocumentsTest
{
    public interface IEdocumentsTestClient
    {
        Task<List<CompanyModel>> Search(string company_name);
        Task<CompanyModel> GetGivenCompany(string company_number);
        Task<List<string>> GetChanges(CompanyModel company_model);
    }
}
