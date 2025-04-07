CREATE PROCEDURE [dbo].[StoredProcedure.Contractor.Get]
  @ContractorId int
AS
SELECT TOP 1
  c.ContractorId,
  c.ContractorName,
  c.ContractorNIP,
  c.ContractorREGON,
  (Select
    ContractorAddressId,
    ContractorId,
    ContractorAddressLine
  FROM ContractorsAddresses
  WHERE ContractorId = c.ContractorId
  FOR XML AUTO)
FROM Contractors c
WHERE [c].[ContractorId] = @ContractorId

RETURN 0
