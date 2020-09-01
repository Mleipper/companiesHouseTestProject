namespace companiesHouseTestProject.EDocumentsTest.EDocumentsModels
{
    public class CompanyModel
    {
        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        // company numbers can have leading zeros
        public string CompanyNumber { get; set; }

        public string CompanyStatus { get; set; }
    }
}
