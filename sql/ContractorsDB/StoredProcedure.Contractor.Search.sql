CREATE PROCEDURE [dbo].[StoredProcedure.Contractor.Search]
  @ContractorName NVARCHAR(1024) = NULL,
  @ContractorNIP NUMERIC(10, 0) = NULL
AS

SELECT
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
  FOR XML PATH ('ContractorAddress'), root ('ContractorsAddresses')) AS ContractorAddresses
FROM Contractors c
WHERE 
  (@ContractorName IS NOT NULL AND [c].[ContractorName] = @ContractorName)
  OR
  (@ContractorNIP IS NOT NULL AND [c].[ContractorNIP] = @ContractorNIP)

RETURN 0
