using companiesHouseTestProject.CompaniesHouseAPI.CompaniesHouseResponses;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Net;
using System.Threading.Tasks;

namespace companiesHouseTestProject.CompaniesHouseAPI
{
    class CompaniesHouseAPIClient : ICompaniesHouseApiClient
    {
        private readonly RestClient _client;
        public CompaniesHouseAPIClient(string apiKey)
        {
            _client = new RestClient("https://api.companieshouse.gov.uk/")
            {
                //according to documentation the api key goes in the userName section with blank password passed to API
                Authenticator = new HttpBasicAuthenticator(apiKey, "")
            };
            _client.UseNewtonsoftJson();
        }

        public async Task<CompaniesHouseSearchResponse> PagedCompaniesSearch(string searchString, int? pageNumber, int? itemsPerPage)
        {
            var startIndex = itemsPerPage * pageNumber;
            var request = new RestRequest("search/companies", DataFormat.Json);

            request.AddQueryParameter("q", searchString);
            if (itemsPerPage != null)
            {
                request.AddQueryParameter("items_per_page", itemsPerPage.ToString());
            }

            if (pageNumber != null)
            {
                request.AddQueryParameter("start_index", startIndex.ToString());
            }

            var response = await _client.ExecuteAsync<CompaniesHouseSearchResponse>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Http status did not return ok");
            }
            return response.Data;
        }
    }
}
