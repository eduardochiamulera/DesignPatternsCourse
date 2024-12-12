-- Remova as tabelas existentes antes de excluir o schema, se existirem
IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'design_patterns.room') AND type = 'U')
BEGIN
    DROP TABLE design_patterns.room;
END
GO

IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'design_patterns.booking') AND type = 'U')
BEGIN
    DROP TABLE design_patterns.booking;
END
GO

-- Remova o schema se ele existir
IF EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'design_patterns')
BEGIN
    DROP SCHEMA design_patterns;
END
GO

-- Criação do schema
CREATE SCHEMA design_patterns;
GO

-- Criação das tabelas
CREATE TABLE design_patterns.room (
    room_id INT,
    category VARCHAR(200),
    price DECIMAL(10, 2),
    status VARCHAR(200)
);
GO

CREATE TABLE design_patterns.booking (
    code VARCHAR(40),
    room_id INT,
    email VARCHAR(200),
    checkinDate DATETIME2,
    checkoutDate DATETIME2,
    duration INT,
    price DECIMAL(10, 2),
    status VARCHAR(200)
)

insert into design_patterns.room (room_id, category, price, status) values (1, 'suite', 500, 'available');
insert into design_patterns.room (room_id, category, price, status) values (2, 'suite', 500, 'available');
insert into design_patterns.room (room_id, category, price, status) values (3, 'standard', 300, 'available');
insert into design_patterns.room (room_id, category, price, status) values (4, 'standard', 300, 'maintenance');
insert into design_patterns.room (room_id, category, price, status) values (5, 'suite', 500, 'available');
insert into design_patterns.room (room_id, category, price, status) values (6, 'suite', 500, 'available');

insert into design_patterns.booking(code, room_id, email, checkinDate, checkoutDate, duration, price) values ('abc', 1, 'john.doe@gmail.com', '2021-03-10T10:00:00', '2021-03-12T10:00:00',2,1000);
insert into design_patterns.booking(code, room_id, email, checkinDate, checkoutDate, duration, price) values ('def', 2, 'john.doe@gmail.com', '2021-03-10T10:00:00', '2021-03-12T10:00:00',2,1000);