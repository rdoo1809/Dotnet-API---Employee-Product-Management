using Assignment1_PROG3340.Data;
using Microsoft.EntityFrameworkCore;

namespace Assignment1_PROG3340.Repositories;

public class ProductRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }
    
    public IEnumerable<TEntity> GetAll() => _dbSet.ToList();

    public TEntity? GetById(int id) => _dbSet.Find(id);

    public void Add(TEntity model) => _dbSet.Add(model);

    public void Update(TEntity model) => _dbSet.Update(model);

    public void Delete(TEntity model) => _dbSet.Remove(model);
}