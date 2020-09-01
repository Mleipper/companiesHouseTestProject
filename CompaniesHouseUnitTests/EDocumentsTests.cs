using companiesHouseTestProject.CompaniesHouseAPI;
using companiesHouseTestProject.CompaniesHouseAPI.CompaniesHouseResponses;
using companiesHouseTestProject.EDocumentsTest;
using Moq;
using System.Collections.Generic;
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
        public void WhenPassAString_ShouldReturnListOfCompanyModels()
        {
            var company1 = new Companies()
            {
                Kind = "searchresults#company",
                Company_number = "04236508",
                Address_snippet = "75 Springfield Road, Chelmsford, Essex, CM2 6JB",
                Company_status = "active",
                Title = "EDOCUMENTS LIMITED"
            };

            var mocApiResponse = new CompaniesHouseSearchResponse()
            {
                Items_per_page = 100,
                Kind = "search#companies",
                Start_index = 0,
                Items = new List<Companies>()
                    {
                        company1
                    }
            };

            mocApiClient.Setup(s => s.PagedCompaniesSearch(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(mocApiResponse);

            var companies = subject.Search("EDOCUMENTS");
            mocApiClient.Verify(rd => rd.PagedCompaniesSearch(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        private EDocumentsTestClient CreateClient()
        {
            return new EDocumentsTestClient(mocApiClient.Object);
            
        }
    }
}
