namespace SignalRApi.DAL
{
    public enum ECity
    {
        Edirne=1,
        İstanbul=2,
        Antalya=3,
        Ankara=4,
        Bursa=5
    }

    public class Visitor
    {
        public int VisitorID { get; set; }

        public ECity City { get; set; }

        public int CityVisitCount { get; set; }

        public DateTime VisitDate { get; set; }
    }
}