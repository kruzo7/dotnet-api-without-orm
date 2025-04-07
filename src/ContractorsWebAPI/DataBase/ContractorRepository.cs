using System.Data;
using System.Xml.Serialization;
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

    public IEnumerable<Contractor> Search(string? contractorName, decimal? contractorNIP)
    {
        var contractors = new List<Contractor>();

        using (var connection = new SqlConnection(_connectionString))
        {
            using (var command = new SqlCommand("[dbo].[StoredProcedure.Contractor.Search]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ContractorName", contractorName));
                command.Parameters.Add(new SqlParameter("@ContractorNIP", contractorNIP));

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var contractor = new Contractor
                        {
                            ContractorId = reader.GetFieldValue<int>("ContractorId"),
                            ContractorName = reader.GetFieldValue<string>("ContractorName"),
                            ContractorNIP = reader.GetFieldValue<decimal>("ContractorNIP"),
                            ContractorREGON = reader.GetFieldValue<decimal>("ContractorREGON"),
                            ContractorAddresses = DeserializeContractorAddresses(reader.GetFieldValue<string>("ContractorAddresses"))
                        };

                        contractors.Add(contractor);
                    }
                }
            }
        }

        return contractors;
    }

    public Contractor Get(int contractorId)
    {
        var contractor = new Contractor();

        using (var connection = new SqlConnection(_connectionString))
        {
            using (var command = new SqlCommand("[dbo].[StoredProcedure.Contractor.Get]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ContractorId", contractorId));

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contractor = new Contractor
                        {
                            ContractorId = reader.GetFieldValue<int>("ContractorId"),
                            ContractorName = reader.GetFieldValue<string>("ContractorName"),
                            ContractorNIP = reader.GetFieldValue<decimal>("ContractorNIP"),
                            ContractorREGON = reader.GetFieldValue<decimal>("ContractorREGON"),
                            ContractorAddresses = DeserializeContractorAddresses(reader.GetFieldValue<string>("ContractorAddresses"))
                        };
                    }
                }
            }
        }

        return contractor;
    }
    public void Add(Contractor contractor)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            using (var command = new SqlCommand("[dbo].[StoredProcedure.Contractor.Add]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ContractorName", contractor.ContractorName));
                command.Parameters.Add(new SqlParameter("@ContractorNIP", contractor.ContractorNIP));
                command.Parameters.Add(new SqlParameter("@ContractorREGON", contractor.ContractorREGON));
                command.Parameters.Add(new SqlParameter("@ContractorAddressesXML", SerializeContractorAddresses(contractor)));

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
    public void Edit(Contractor contractor)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            using (var command = new SqlCommand("[dbo].[StoredProcedure.Contractor.Update]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ContractorId", contractor.ContractorId));
                command.Parameters.Add(new SqlParameter("@ContractorName", contractor.ContractorName));
                command.Parameters.Add(new SqlParameter("@ContractorNIP", contractor.ContractorNIP));
                command.Parameters.Add(new SqlParameter("@ContractorREGON", contractor.ContractorREGON));
                command.Parameters.Add(new SqlParameter("@ContractorAddressesXML", SerializeContractorAddresses(contractor)));
                
                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
    public void Delete(int contractorId)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            using (var command = new SqlCommand("[dbo].[StoredProcedure.Contractor.Delete]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@ContractorId", contractorId));

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

    }

    private List<ContractorAddress> DeserializeContractorAddresses(string xmlData)
    {
        var contractorAddresses = new ContractorsAddresses();
        XmlSerializer serializer = new XmlSerializer(typeof(ContractorsAddresses));

        using (StringReader reader = new StringReader(xmlData))
        {
            contractorAddresses = (ContractorsAddresses)serializer.Deserialize(reader);
        }

        return contractorAddresses.ContractorsAddressess;
    }

    private string SerializeContractorAddresses(Contractor contractor)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ContractorsAddresses));

        using (var stringWriter = new StringWriter())
        {
            using (var xmlWriter = new System.Xml.XmlTextWriter(stringWriter) { Formatting = System.Xml.Formatting.Indented })
            {
                serializer.Serialize(xmlWriter, new ContractorsAddresses() { ContractorsAddressess = contractor.ContractorAddresses });
                return stringWriter.ToString();
            }
        }
    }
}