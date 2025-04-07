-- This file contains SQL statements that will be executed after the build script.
INSERT INTO  Contractors
    (ContractorName, ContractorNIP, ContractorREGON)
VALUES
    ('Kowalski', 1234567890, 12345678901234),
    ('Nowak', 2345678901, 23456789012345),
    ('Kwiatkowski', 3456789012, 34567890123456);

INSERT INTO  ContractorsAddresses
    (ContractorID, ContractorAddressLine)
VALUES
    (1, 'ul. Krakowska 12 02-123 Poznań'),
    (1, 'ul. Gdańska 45 02-123 Poznań'),
    (1, 'ul. Wrocławska 23 02-123 Poznań'),
    (2, 'ul. Poznańska 9 02-123 Poznań'),
    (2, 'ul. Łódzka 34 02-123 Poznań'),
    (2, 'ul. Szczecińska 18 02-123 Poznań'),
    (3, 'ul. Lublin 56 02-123 Poznań'),
    (3, 'ul. Bydgoska 5 02-123 Poznań'),
    (3, 'ul. Katowicka 38 02-123 Poznań');
           
