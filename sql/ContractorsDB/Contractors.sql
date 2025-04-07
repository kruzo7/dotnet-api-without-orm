CREATE TABLE [dbo].[Contractors]
(
  [ContractorId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [ContractorName] NVARCHAR(1024) NOT NULL INDEX IX_Contractors_ContractorName NONCLUSTERED,
  [ContractorNIP] NUMERIC(10, 0) NOT NULL INDEX IX_Contractors_ContractorNIP NONCLUSTERED,
  [ContractorREGON] NUMERIC(14, 0) NOT NULL
)
