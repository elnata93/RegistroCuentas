create database Cuentas;
use Cuentas;

Create table Cuentas(CuentaId int identity(1,1),
Descripcion nvarchar(100), Balance Float);

select * from Cuentas;

drop table Cuentas;