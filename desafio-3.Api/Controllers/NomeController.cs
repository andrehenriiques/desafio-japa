using desafio_3.Domain.Interfaces.IServices;
using desafio_3.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace desafio_3.Controllers;

[Route("api/[controller]")]
[ApiController] 
public class NomeController : ControllerBase
{
    private readonly IPersonService _personService;

    public NomeController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public List<Person> ListNames()
    {
        return _personService.GetAll();
    }
}