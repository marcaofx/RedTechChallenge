using RedTechnologies.Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedTechnologies.App.ViewModel
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public OrderType Type { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
    }
}
