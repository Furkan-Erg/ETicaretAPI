using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Domain.Entities
{
    public class Customer : BaseEntity //class base entityden inherit ediliyo
    {
        public ICollection<Order> Orders { get; set; } //bir customer birden fazla siparişi olabilir. bunun içinde ICollection kullanılır.
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}