using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Domain.Entities
{
    public class Order : BaseEntity //class base entityden inherit ediliyo
    {
        public Guid CustomerId { get; set; } //customerın id'si order-customer relationship için gerekli
        public string Address { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; } //bir orderın içinde birden fazla product bulunabilir bu yüzden ICollection ile mantıksal yapı kurulur.

        public Customer Customer { get; set; } //bir orderın içinde bir customer bulunabilir bu yüzden Customer classından bir customer nesnesi alınır.
    }
}