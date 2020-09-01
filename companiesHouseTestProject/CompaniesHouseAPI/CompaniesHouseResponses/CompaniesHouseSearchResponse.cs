using System.Collections.Generic;

namespace companiesHouseTestProject.CompaniesHouseAPI.CompaniesHouseResponses
{
    public class CompaniesHouseSearchResponse
    {
        public int Start_index { get; set; }
        public int Total_results { get; set; }
        public int Page_number { get; set; }
        public int Items_per_page { get; set; }
        public List<Companies> Items { get; set; }
        public string Kind { get; set; }

        public CompaniesHouseSearchResponse()
        {
            Items = new List<Companies>();
        }

        public bool HasNextPage()
        {
            return Total_results > TotalItemsOnPreviousPages();
        }

        private int TotalItemsOnPreviousPages()
        {
            return Page_number * Items_per_page;
        }
    }
}
