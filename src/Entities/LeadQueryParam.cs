using LeadX.NET.Enum;

namespace LeadX.NET.Entities
{
    public class LeadQueryParam
    {
        public int Start { get; set; }

        public int Limit { get; set; }

        public string SortBy { get; set; }

        public SortingOrder SortOrder { get; set; }

        public string Filter { get; set; }

        public string StatusId { get; set; }

        public string SizeId { get; set; }

        public LeadQueryParam()
        {
            Start = 0;
            Limit = 10;
            SortOrder = SortingOrder.ASC;
        }
    }
}
