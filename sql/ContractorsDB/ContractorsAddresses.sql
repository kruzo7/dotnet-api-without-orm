CREATE TABLE [dbo].[ContractorsAddresses]
(
  [ContractorAddresseId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [ContractorID] INT NOT NULL,
  [ContractorAddresseLine] NVARCHAR(1024) NOT NULL,

  CONSTRAINT FK_ContractorsAddresses_Contractors FOREIGN KEY (ContractorID)
        REFERENCES Contractors (ContractorID)        
)
