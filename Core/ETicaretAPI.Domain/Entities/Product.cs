using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Product : BaseEntity //Product isimli class base entityden inherit ediliyo
    {
        public string Name { get; set; } //product ın name propertysi

        public long Price { get; set; } //product ın price propertysi
        public int Stock { get; set; } //product ın stock propertysi

        public ICollection<Order> Orders { get; set; } //bir product birden fazla order da bulunabilir bu yüzden ICollection ile mantıksal yapı kurulur.
    }
}