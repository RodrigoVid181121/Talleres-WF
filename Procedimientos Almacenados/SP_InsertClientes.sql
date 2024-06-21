CREATE PROCEDURE SP_InsertClient
@nombre varchar(75), @telefono varchar(9)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
			IF NOT EXISTS(SELECT id from Clientes WHERE telefono=@telefono)
			INSERT INTO Clientes(nombre,telefono) VALUES(@nombre,@telefono)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
        ROLLBACK TRANSACTION;
        -- Manejo de errores
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH;
END