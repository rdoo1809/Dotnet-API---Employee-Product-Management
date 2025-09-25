using Assignment1_PROG3340.Data;
using Assignment1_PROG3340.Repositories;

namespace Assignment1_PROG3340.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public IRepository<Employee> Employees { get; set; }
        public IRepository<Product> Products { get; set; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Employees = new EmployeeRepository<Employee>(_appDbContext);
            Products = new ProductRepository<Product>(_appDbContext);
        }
        
        public int Complete()
        {
            return _appDbContext.SaveChanges();
        }
    }
}
