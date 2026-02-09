using TimeExchangePlatform.Models;

namespace TimeExchangePlatform.ViewModels
{
    public class MyAgreementViewModel
    {
        public int HoursBalanace { get; set; }
        public List<Agreement> Agreements { get; set; } = [];
    }
}
