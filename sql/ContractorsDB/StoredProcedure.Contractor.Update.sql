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

DECLARE @docHandle INT;
EXEC sp_xml_preparedocument @docHandle OUTPUT, @ContractorAddressesXML;

MERGE INTO ContractorsAddresses AS ca
USING (
    SELECT
      ContractorAddressId,
      ContractorAddressLine
    FROM OPENXML(@docHandle, N'/ContractorsAddresses/ContractorAddress')
      WITH (
      ContractorAddressId INT 'ContractorAddressId',
      ContractorAddressLine NVARCHAR(1024) 'ContractorAddressLine'   
    )
) AS caXml
ON ca.ContractorAddressId = caXml.ContractorAddressId
WHEN NOT MATCHED BY SOURCE AND ca.ContractorId = @ContractorId
    THEN DELETE
WHEN MATCHED THEN 
    UPDATE SET 
        ca.ContractorAddressLine = caXml.ContractorAddressLine        
WHEN NOT MATCHED THEN 
    INSERT (ContractorId, ContractorAddressLine)
    VALUES (@ContractorId, caXml.ContractorAddressLine);

EXEC sp_xml_removedocument @docHandle;

RETURN 0
