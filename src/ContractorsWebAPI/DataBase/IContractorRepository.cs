using ContractorsWebAPI.DTOs;

namespace ContractorsWebAPI.DataBase;

public interface IContractorRepository
{
    public IEnumerable<Contractor> GetAll();
    public IEnumerable<Contractor> Search(string contractorName, int? contractorNIP);
    public Contractor Get(int contractorId);
    public void Add(Contractor contractor);
    public void Edit(Contractor contractor);
    public void Delete(int contractorId);
}