CREATE DATABASE TemplateRedis;
GO

use TemplateRedis;

CREATE TABLE ClasseExemplos
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	CadastradoEm DATE NOT NULL,
    ArquivadaEm DATE, 
    Ativa BIT NOT NULL,
    Propriedade1 INT NOT NULL,
    Propriedade2 INT,
    Propriedade3 VARCHAR(50),
    Propriedade4 INT,
    Propriedade5 DATE,
    Propriedade6 DATE,
    Propriedade7 DATE,
    Propriedade8 BIT,
    Propriedade9 BIT,
    Propriedade10 VARCHAR(50),
    Propriedade11 VARCHAR(15) NOT NULL,
    Propriedade12 VARCHAR(50),
    Propriedade13 VARCHAR(50),
    Propriedade14 VARCHAR(50),
    Propriedade15 VARCHAR(50),
    Propriedade16 VARCHAR(50),
    Propriedade17 VARCHAR(50),
    Propriedade18 VARCHAR(50),
    Propriedade19 VARCHAR(50),
    Propriedade20 VARCHAR(50) NOT NULL,
    Propriedade21 SMALLMONEY NOT NULL DEFAULT(0),
    Propriedade22 VARCHAR(50),
    Propriedade23 INT NOT NULL

);

