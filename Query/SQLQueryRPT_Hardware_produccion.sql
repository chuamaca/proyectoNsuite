create proc RPT_Hardware_produccion
as
select count(seriehw) as hardwareprod from DetalleOrden
where estadodetalleorden=1
go










select * from DetalleOrden
go



select * from Usuario
go
