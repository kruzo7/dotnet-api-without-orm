using ContractorsWebAPI.DataBase;
using ContractorsWebAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ContractorsWebAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ContractorController : ControllerBase
{
    private readonly ILogger<ContractorController> _logger;
    private readonly IContractorRepository _contractorRepository;

    public ContractorController(ILogger<ContractorController> logger, IContractorRepository contractorRepository)
    {
        _logger = logger;
        _contractorRepository = contractorRepository;
    }

    [HttpGet]
    public IEnumerable<Contractor> GetAll()
    {
        return _contractorRepository.GetAll();
    }

    [HttpGet("{id}")]
    public Contractor Get(int id)
    {
        return _contractorRepository.Get(id);
    }

    [HttpPost]
    public void Add(Contractor contractor)
    {
        _contractorRepository.Add(contractor);
    }

    [HttpPut]
    public void Edit(Contractor contractor)
    {
        _contractorRepository.Edit(contractor);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _contractorRepository.Delete(id);
    }
}
