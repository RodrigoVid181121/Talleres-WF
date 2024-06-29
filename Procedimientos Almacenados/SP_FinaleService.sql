CREATE PROCEDURE SP_FinaleService
@placa nchar(9), @distan_out int
AS
BEGIN
DECLARE @idVehiculo int, @fecha_out varchar(10), @idService int
	BEGIN TRY
		BEGIN TRANSACTION
			SET @idVehiculo = (SELECT id FROM Vehiculos WHERE placa = @placa)
			SET @fecha_out = (SELECT CONVERT(VARCHAR(10), GETDATE(), 103))		
			SET @idService = (SELECT id FROM Servicios WHERE id_vehiculo=@idVehiculo AND estado=1)

			UPDATE Servicios SET fecha_out=@fecha_out, km_out=@distan_out, estado=0 WHERE id=@idService
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