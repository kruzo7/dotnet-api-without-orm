CREATE PROCEDURE [dbo].[StoredProcedure.Contractor.Update]
  @ContractorId INT,
  @ContractorName NVARCHAR(1024),
  @ContractorNIP NUMERIC(10, 0),
  @ContractorREGON NUMERIC(14, 0),
  @ContractorAddressesXML XML
AS

UPDATE [dbo].[Contractors]
    SET 
    ContractorName = @ContractorName, 
    ContractorNIP = @ContractorNIP,
    ContractorREGON = @ContractorREGON  
   WHERE ContractorId = @ContractorId;



RETURN 0
