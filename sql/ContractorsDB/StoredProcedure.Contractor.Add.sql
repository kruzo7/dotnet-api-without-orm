CREATE PROCEDURE [dbo].[StoredProcedure.Contractor.Add]
  @ContractorName NVARCHAR(1024),
  @ContractorNIP NUMERIC(10, 0),
  @ContractorREGON NUMERIC(14, 0)
AS
INSERT INTO [dbo].[Contractors]
  (ContractorName, ContractorNIP, ContractorREGON)
VALUES
  (@ContractorName, @ContractorNIP, @ContractorREGON);

  
RETURN 0
