using System.ComponentModel.DataAnnotations;

namespace ContractorsWebAPI.DTOs;

public class ContractorAddress
{
    public int ContractorAddressId { get; set;}
    public int ContractorId { get; set;}
    
    [Required]
    [MaxLength(1024)]
    public string ContractorAddressLine { get; set; } = string.Empty;     
} 