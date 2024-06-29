CREATE PROCEDURE SP_SelectAllService
@idServicio int
AS
BEGIN
SELECT*FROM Servicios s
INNER JOIN Vehiculos v
ON v.id = s.id_vehiculo
INNER JOIN Documentos d
ON d.id = v.id_docs
INNER JOIN Condiciones c
ON c.id = v.id_con
INNER JOIN Clientes cl
ON cl.id = v.id_cliente
WHERE s.id = @idServicio
END