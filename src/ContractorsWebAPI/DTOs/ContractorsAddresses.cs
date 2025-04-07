using System.Xml.Serialization;

namespace ContractorsWebAPI.DTOs;

[XmlRoot("ContractorsAddresses")]
public class ContractorsAddresses
{
    [XmlElement("ContractorAddress")]
    public List<ContractorAddress> ContractorsAddressess { get; set; }

}