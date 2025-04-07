CREATE TABLE [dbo].[ContractorsAddresses]
(
  [ContractorAddressId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [ContractorId] INT NOT NULL,
  [ContractorAddressLine] NVARCHAR(1024) NOT NULL,

  CONSTRAINT FK_ContractorsAddresses_Contractors FOREIGN KEY (ContractorId)
        REFERENCES Contractors (ContractorId)
)
