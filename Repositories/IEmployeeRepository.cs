namespace Assignment1_PROG3340.Repositories;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAll();
    Task<Employee?> GetById(int id);
    Task Add(Employee employee);
    void Update(Employee employee);
    void Delete(Employee employee);
}