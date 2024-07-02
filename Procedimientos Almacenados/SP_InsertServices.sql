CREATE PROCEDURE SP_InsertService
@gas_rec varchar(3), @distan_in int, @tipo_dis varchar(10),@pintura nvarchar(max),@receptor varchar(75),@mecanico varchar(75),
@encargado_vehi varchar(75),@cargo_en varchar(50),@comentarios varchar(500), @placa nchar(9)
AS
BEGIN
DECLARE @idVehiculo int, @fecha_in varchar(10)
	BEGIN TRY
		BEGIN TRANSACTION
			SET @idVehiculo = (SELECT id FROM Vehiculos WHERE placa = @placa)
			SET @fecha_in = (SELECT CONVERT(VARCHAR(10), GETDATE(), 103))
			IF @tipo_dis = 'Kilometros'
				BEGIN
					INSERT INTO Servicios(id_vehiculo,gas_recibido,estado,fecha_in,km_in,fecha_out,pintura,receptor,mecanico,encargado_vehi,cargo_en,comentarios)
					VALUES(@idVehiculo,@gas_rec,1,@fecha_in,@distan_in,@fecha_in,@pintura,@receptor,@mecanico,@encargado_vehi,@cargo_en,@comentarios)
				END
			ELSE IF(@tipo_dis = 'Millas')
				BEGIN
					INSERT INTO Servicios(id_vehiculo,gas_recibido,estado,fecha_in,mil_in,fecha_out,pintura,receptor,mecanico,encargado_vehi,cargo_en,comentarios)
					VALUES(@idVehiculo,@gas_rec,1,@fecha_in,@distan_in,@fecha_in,@pintura,@receptor,@mecanico,@encargado_vehi,@cargo_en,@comentarios)
				END
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
		-- Manejo de errores
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
SELECT*FROM Servicios