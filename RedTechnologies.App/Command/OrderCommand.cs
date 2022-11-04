using RedTechnologies.Repository.Enums;

namespace RedTechnologies.App.Command
{
    public class OrderCommand
    {
        public OrderType Type { get; set; }
        public string CustomerName { get; set; }
        public string CreatedByUserName { get; set; }
    }
}
