namespace ContractorsWebAPI.DataBase;

public class ContractorDBConnection : IContractorDBConnection
{
    public string ConnectionString { get; set; } = string.Empty;

    public ContractorDBConnection(string connectionString)
    {
        ConnectionString = connectionString;
    }
}