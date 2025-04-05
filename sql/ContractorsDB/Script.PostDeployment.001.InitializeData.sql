-- This file contains SQL statements that will be executed after the build script.
INSERT INTO  Contractors
    (ContractorName, ContractorNIP, ContractorREGON)
VALUES
    ('Kowalski', 1234567890, 12345678901234);


INSERT INTO  ContractorsAddresses
    (ContractorID, ContractorAddresseLine)
VALUES
    (1, 'ul. Warszawska 1');    
