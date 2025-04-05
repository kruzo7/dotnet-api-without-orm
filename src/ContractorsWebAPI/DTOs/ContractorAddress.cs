using System;

namespace ContractorsWebAPI.DTOs;

public class ContractorAddress
{
    public int ContractorAddressId { get; set;}
    public int ContractorID { get; set;}
    public string ContractorAddressLine { get; set; } = string.Empty;     
} 