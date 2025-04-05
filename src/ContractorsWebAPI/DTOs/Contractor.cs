using System;

namespace ContractorsWebAPI.DTOs;

public class Contractor
{
    public int ContractorId { get; set; }
    public string ContractorName { get; set; } = string.Empty;
    public int ContractorNIP { get; set; }
    public int ContractorREGON { get; set; }
    public List<ContractorAddress> ContractorAddresses { get; set; } = new List<ContractorAddress>();
}