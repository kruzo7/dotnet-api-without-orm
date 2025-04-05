CREATE TABLE [dbo].[Contractors]
(
  [ContractorId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [ContractorName] NVARCHAR(1024) NOT NULL,
  [ContractorNIP] NUMERIC(10, 0) NOT NULL,
  [ContractorREGON] NUMERIC(14, 0) NOT NULL
)
