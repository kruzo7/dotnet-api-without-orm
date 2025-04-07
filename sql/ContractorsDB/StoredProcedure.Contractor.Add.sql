CREATE PROCEDURE [dbo].[StoredProcedure.Contractor.Add]
  @ContractorName NVARCHAR(1024),
  @ContractorNIP NUMERIC(10, 0),
  @ContractorREGON NUMERIC(14, 0),
  @ContractorAddressesXML XML
AS
INSERT INTO [dbo].[Contractors]
  (ContractorName, ContractorNIP, ContractorREGON)
VALUES
  (@ContractorName, @ContractorNIP, @ContractorREGON);

DECLARE @contractorId int;
SET @contractorId = SCOPE_IDENTITY();

DECLARE @docHandle int;
EXEC sp_xml_preparedocument @docHandle OUTPUT, @ContractorAddressesXML;

INSERT INTO ContractorsAddresses
  (ContractorId, ContractorAddressLine)
SELECT @contractorId, ContractorAddressLine
FROM OPENXML(@docHandle, N'/ContractorsAddresses/ContractorAddress')
  WITH (
    ContractorAddressLine NVARCHAR(1024) 'ContractorAddressLine'
  );

EXEC sp_xml_removedocument @docHandle;

RETURN 0
