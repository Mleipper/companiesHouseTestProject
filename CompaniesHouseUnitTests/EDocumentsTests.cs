using companiesHouseTestProject.CompaniesHouseAPI;
using companiesHouseTestProject.EDocumentsTest;
using Moq;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace CompaniesHouseUnitTests
{
    public class EDocumentsTests
    {
        private readonly Mock<ICompaniesHouseApiClient> mocApiClient;

        private readonly IEDocumentsTestClient subject;

        public EDocumentsTests()
        {
            mocApiClient = new Mock<ICompaniesHouseApiClient>();
            subject = CreateClient();
            
        }


        [Fact]
        public void Test1()
        {

        }

        private EDocumentsTestClient CreateClient()
        {
            return new EDocumentsTestClient(mocApiClient.Object);
            
        }
    }
}
