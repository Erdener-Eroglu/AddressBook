namespace AddressBookEL.ViewModels
{
    public class ApiVM
    {
        public bool success { get; set; }
        public string status { get; set; }
        public string dataupdatedate { get; set; }
        public string pagecreatedate { get; set; }
        public List<PostalCodeApiViewModel> postakodu { get; set; }
    }
}
