CREATE PROCEDURE SP_InsertService
@gas_rec varchar(3), @estado bit, @fecha_in date, @distan_in float, @distan_out float, @tipo_dis varchar(3), @fecha_out date,
@pintura image,@receptor varchar(75),@mecanico varchar(75),@encargado_vehi varchar(75),@cargo_en varchar(50),@comentarios varchar(500)
AS
BEGIN
DECLARE @idVehiculo int
	BEGIN TRY
		BEGIN TRANSACTION
			SET @idVehiculo = (SELECT IDENT_CURRENT('Vehiculos'))
			IF(@tipo_dis = 'km')
				BEGIN
					INSERT INTO Servicios(id_vehiculo,gas_recibido,estado,fecha_in,km_in,fecha_out,km_out,pintura,receptor,mecanico,encargado_vehi,cargo_en,comentarios)
					VALUES(@idVehiculo,@gas_rec,@estado,@fecha_in,@distan_in,@fecha_out,@distan_out,@pintura,@receptor,@mecanico,@encargado_vehi,@cargo_en,@comentarios)
				END
			ELSE
				BEGIN
					INSERT INTO Servicios(id_vehiculo,gas_recibido,estado,fecha_in,mil_in,fecha_out,mil_out,pintura,receptor,mecanico,encargado_vehi,cargo_en,comentarios)
					VALUES(@idVehiculo,@gas_rec,@estado,@fecha_in,@distan_in,@fecha_out,@distan_out,@pintura,@receptor,@mecanico,@encargado_vehi,@cargo_en,@comentarios)
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