using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        //update-database -Migration "InitDb"
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    USE Bicycles;

                    INSERT INTO SupplierTypes (SupplierTypeName) VALUES 
                    ('Производитель'),
                    ('Дистрибьютор'),
                    ('Оптовик'),
                    ('Розничный продавец'),
                    ('Импортер'),
                    ('Экспортер'),
                    ('Онлайн поставщик'),
                    ('Местный поставщик'),
                    ('Эксклюзивный поставщик'),
                    ('Общий поставщик');

                    INSERT INTO Suppliers (SupplierName, ContactInfo, Address, SupplierTypeId) VALUES 
                    ('Поставщик1', 'contact1@example.com', 'Адрес1', 1),
                    ('Поставщик2', 'contact2@example.com', 'Адрес2', 2),
                    ('Поставщик3', 'contact3@example.com', 'Адрес3', 3),
                    ('Поставщик4', 'contact4@example.com', 'Адрес4', 4),
                    ('Поставщик5', 'contact5@example.com', 'Адрес5', 5),
                    ('Поставщик6', 'contact6@example.com', 'Адрес6', 6),
                    ('Поставщик7', 'contact7@example.com', 'Адрес7', 7),
                    ('Поставщик8', 'contact8@example.com', 'Адрес8', 8),
                    ('Поставщик9', 'contact9@example.com', 'Адрес9', 9),
                    ('Поставщик10', 'contact10@example.com', 'Адрес10', 10);

                    INSERT INTO Parts (PartName, PartDescription, SupplierId) VALUES 
                    ('Колесо', 'Переднее колесо', 1),
                    ('Сиденье', 'Удобное сиденье', 2),
                    ('Руль', 'Стандартный руль', 3),
                    ('Педаль', 'Педаль для горного велосипеда', 4),
                    ('Цепь', 'Прочная цепь', 5),
                    ('Тормоз', 'Дисковый тормоз', 6),
                    ('Передача', '12-скоростная передача', 7),
                    ('Рама', 'Алюминиевая рама', 8),
                    ('Шина', 'Всепроходная шина', 9),
                    ('Спица', 'Нержавеющая спица', 10);

                    INSERT INTO Bicycles (ModelName) VALUES 
                    ('Горный велосипед X100'),
                    ('Шоссейный велосипед R200'),
                    ('Гибридный велосипед H300'),
                    ('Электровелосипед E400'),
                    ('Складной велосипед F500'),
                    ('Круизер C600'),
                    ('Туринговый велосипед T700'),
                    ('Городской велосипед CB800'),
                    ('Велосипед BMX B900'),
                    ('Детский велосипед K1000');

                    INSERT INTO PartOrders (OrderDate, ExpectedDeliveryDate, BicycleId, CountOfBicycles) VALUES 
                    ('2024-01-01', '2024-01-10', 1, 50),
                    ('2024-01-02', '2024-01-11', 2, 40),
                    ('2024-01-03', '2024-01-12', 3, 30),
                    ('2024-01-04', '2024-01-13', 4, 20),
                    ('2024-01-05', '2024-01-14', 5, 10),
                    ('2024-01-06', '2024-01-15', 6, 15),
                    ('2024-01-07', '2024-01-16', 7, 25),
                    ('2024-01-08', '2024-01-17', 8, 35),
                    ('2024-01-09', '2024-01-18', 9, 45),
                    ('2024-01-10', '2024-01-19', 10, 55);

                    INSERT INTO PartBicycles (PartId, BicycleId, QuantityRequired) VALUES 
                    (1, 1, 2),
                    (2, 2, 1),
                    (3, 3, 1),
                    (4, 4, 2),
                    (5, 5, 1),
                    (6, 6, 2),
                    (7, 7, 1),
                    (8, 8, 1),
                    (9, 9, 2),
                    (10, 10, 1);

            ");
    }

    
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    USE Bicycles;

                    DELETE FROM PartOrders;

                    DELETE FROM PartBicycles;

                    DELETE FROM Bicycles;

                    DELETE FROM Parts;

                    DELETE FROM Suppliers;

                    DELETE FROM SupplierTypes;

                    DBCC CHECKIDENT ('PartOrders', RESEED, 0);
                    DBCC CHECKIDENT ('PartBicycles', RESEED, 0);
                    DBCC CHECKIDENT ('Bicycles', RESEED, 0);
                    DBCC CHECKIDENT ('Parts', RESEED, 0);
                    DBCC CHECKIDENT ('Suppliers', RESEED, 0);
                    DBCC CHECKIDENT ('SupplierTypes', RESEED, 0);

            ");
        }
    }
}
