using companiesHouseTestProject.EDocumentsTestClient.EDocumentsModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace companiesHouseTestProject.EDocumentsTestClient
{
    public class EDocumentsTestClient : IEdocumentsTestClient
    {
        public Task<List<string>> GetChanges(CompanyModel company_model)
        {
            throw new System.NotImplementedException();
        }

        public Task<CompanyModel> GetGivenCompany(int company_number)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<CompanyModel>> Search(string Company_name)
        {
            throw new System.NotImplementedException();
        }
    }
}
