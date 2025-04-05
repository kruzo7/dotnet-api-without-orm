using ContractorsWebAPI.DTOs;
using Microsoft.Data.SqlClient;

namespace ContractorsWebAPI.DataBase;

public class ContractorRepository : IContractorRepository
{
    private readonly string _connectionString;
    public ContractorRepository(IContractorDBConnection connection)
    {
        _connectionString = connection.ConnectionString;   
    }
    public IEnumerable<Contractor> GetAll()
    {
        return new List<Contractor>();
    }
    public Contractor Get(int contractorId)
    {
        return new Contractor();
    }
    public void Add(Contractor contractor)
    {

    }
    public void Edit(Contractor contractor)
    {

    }
    public void Delete(int contractorId)
    {

    }
}