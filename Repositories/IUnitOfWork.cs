namespace Assignment1_PROG3340.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Employee> Employees { get; }
        IRepository<Product> Products { get; }

        int Complete();
    }
}
