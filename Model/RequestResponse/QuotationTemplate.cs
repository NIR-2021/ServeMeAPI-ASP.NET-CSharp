namespace ServeMe_M2.Model.RequestResponse
{
    public class QuotationTemplate : ServiceModel
    {
        public float tax { get; set; }
        public float total{ get; set; }
        public float commission { get; set; }

        public float vendor_profit { get; set; }
    }
}
