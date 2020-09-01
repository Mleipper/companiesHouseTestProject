using System.Collections.Generic;

namespace companiesHouseTestProject.CompaniesHouseAPIClient.CompaniesHouseResponses
{
    public class CompaniesHouseSearchResponse
    {
        public int Start_index { get; set; }
        public int Total_results { get; set; }
        public int Page_number { get; set; }
        public int Items_per_page { get; set; }
        public List<Items> Items { get; set; }
        public string Kind { get; set; }

        public CompaniesHouseSearchResponse()
        {
            Items = new List<Items>();
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

    public class Items
    {
        public string Company_number { get; set; }
        public string Description { get; set; }
        public string Snippet { get; set; }
        public string Title { get; set; }
        public string Company_status { get; set; }
        public Matches Matches { get; set; }
        public string Kind { get; set; }
        public string[] Description_identifier { get; set; }
        public string Company_type { get; set; }
        public string Date_of_creation { get; set; }
        public string Address_snippet { get; set; }
        public Links Links { get; set; }
        public Address Address { get; set; }

        public Items()
        {

        }
    }

    public class Matches
    {
        public int[] Title { get; set; }
        public int?[] Snippet { get; set; }

        public Matches()
        {
        }
    }

    public class Links
    {
        public string Self { get; set; }

        public Links()
        {
        }
    }

    public class Address
    {
        public string Locality { get; set; }
        public string Premises { get; set; }
        public string Country { get; set; }
        public string Postal_code { get; set; }
        public string Address_line_1 { get; set; }

        public string Address_line_2 { get; set; }
        public Address()
        {

        }
    }
}
