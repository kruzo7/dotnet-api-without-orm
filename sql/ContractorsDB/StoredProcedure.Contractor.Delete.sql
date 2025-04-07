CREATE PROCEDURE [dbo].[StoredProcedure.Contractor.Delete]
  @ContractorId int
AS
DELETE FROM [dbo].[ContractorsAddresses]
  WHERE ContractorId = @ContractorId

DELETE FROM [dbo].[Contractors]
  WHERE ContractorId = @ContractorId
RETURN 0
