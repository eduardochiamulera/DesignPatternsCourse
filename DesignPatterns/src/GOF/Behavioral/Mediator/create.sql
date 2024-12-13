-- Remova as tabelas existentes antes de excluir o schema, se existirem
IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'mediator.grade') AND type = 'U')
BEGIN
    DROP TABLE mediator.grade;
END
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'mediator.average') AND type = 'U')
BEGIN
    DROP TABLE mediator.average;
END
GO

-- Remova o schema se ele existir
IF EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'mediator')
BEGIN
    DROP SCHEMA mediator;
END
GO

-- Criação do schema
CREATE SCHEMA mediator;
GO

-- Criação das tabelas
CREATE TABLE mediator.grade (
    studentId BIGINT,
    exam VARCHAR(200),
    value float
);
GO

CREATE TABLE mediator.average (
     studentId BIGINT,
     value float
)