ALTER PROCEDURE SP_IndexService
AS
BEGIN
SELECT s.id as 'ID', c.nombre as 'Nombre', v.marca + ' ' + v.modelo as 'Vehiculo', v.placa as 'Placa', s.fecha_in as 'Checkin'
FROM Clientes c
INNER JOIN Vehiculos v
ON v.id_cliente = c.id
INNER JOIN Servicios s
ON s.id_vehiculo = v.id
WHERE s.estado = 1
END