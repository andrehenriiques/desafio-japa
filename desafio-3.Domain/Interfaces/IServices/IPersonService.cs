using desafio_3.Domain.Models;

namespace desafio_3.Domain.Interfaces.IServices;

public interface IPersonService
{
    public List<Person> GetAll();
}