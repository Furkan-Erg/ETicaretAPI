using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Customer : BaseEntity
    {
        string Name { get; set; }
        string Surname { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string Phone { get; set; }
        string Address { get; set; }
        
    }
}
