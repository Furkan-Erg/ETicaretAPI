using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities.Common
{
    public class BaseEntity //standart olarak entitylerin base sınıfı olması gerekir.Bu sınıfın içinde bütün entitylerin kullanacağı değerler coderepeat olmasın diye tutulur
    
    {
        public Guid Id { get; set; } //productın Guid id'si

        public DateTime CreatedDate { get; set; } //productın oluşturulma tarihi
    }
}
