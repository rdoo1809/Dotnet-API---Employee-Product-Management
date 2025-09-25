namespace Assignment1_PROG3340.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product?> GetById(int id);
    Task Add(Product product);
    void Update(Product product);
    void Delete(Product product);   
}