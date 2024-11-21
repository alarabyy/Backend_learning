using Port.Models;

namespace Port.Controllers.Repositry
{
    public class RepositryOrder
    {
        private readonly ApplicationDbContext _context;

        public RepositryOrder(ApplicationDbContext context)
        {
            _context = context;
        }

        public RepositryOrder()
        {
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public void Delete(int id)
        {
            var order = GetById(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
        }

        public void Update(Order order )
        {
            _context.Orders.Update(order);
        }

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(s => s.OrderId == id);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
