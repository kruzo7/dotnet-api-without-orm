using System.ComponentModel.DataAnnotations;

namespace ContractorsWebAPI.DTOs;

public class Contractor
{
    public int ContractorId { get; set; }
    
    [Required]
    [MaxLength(1024)]
    public string ContractorName { get; set; } = string.Empty;
    public decimal ContractorNIP { get; set; }
    public decimal ContractorREGON { get; set; }
    public List<ContractorAddress> ContractorAddresses { get; set; } = new List<ContractorAddress>();
}