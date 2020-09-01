namespace companiesHouseTestProject.CompaniesHouseAPI.CompaniesHouseResponses
{
    public class Companies
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

        public Companies()
        {

        }
    }
}
