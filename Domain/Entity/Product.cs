using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductType { get; set; }
        public int Price { get; set; }
        public int userId { get; set; }

        public string? UserName { get; set; }

        

    }
}
