CREATE PROCEDURE SP_CreateFactura
@placa nchar(9), @tipoDoc varchar(50), @montoTotal decimal(5,2), @descripcion varchar(250)
AS
BEGIN
DECLARE @IdCliente int, @Count int, @Ref int, @IdVehiculo int
	BEGIN TRY
		BEGIN TRANSACTION
			IF EXISTS(SELECT id_cliente FROM Vehiculos WHERE placa = @placa)
				BEGIN
					SET @IdCliente = (SELECT id_cliente FROM Vehiculos WHERE placa = @placa)
					SET @IdVehiculo = (SELECT id FROM Vehiculos WHERE placa = @placa)
				END
			SET @Count = (SELECT COUNT(*) FROM Venta)
			IF(@Count = 0)
				BEGIN
					INSERT INTO Venta(id_usuario, tipo_doc, numero_doc, id_cliente, monto_total, descripcion) 
					VALUES(1,@tipoDoc,1000,@IdCliente,@montoTotal,@descripcion)
				END
			ELSE
				BEGIN
					SET @Ref = (SELECT TOP 1 numero_doc FROM Venta ORDER BY id_venta DESC)
					INSERT INTO Venta(id_usuario, tipo_doc, numero_doc, id_cliente, monto_total, descripcion) 
					VALUES(1,@tipoDoc,@Ref+1 ,@IdCliente,@montoTotal,@descripcion)
				END

			UPDATE Servicios SET estado = 0 WHERE id_vehiculo = @IdVehiculo AND estado = 1
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO
CREATE PROCEDURE SP_CreateFacturaDetail
@idProd int, @formaPago varchar(25), @cantidad int
AS
BEGIN
DECLARE @Precio decimal(5,2), @SubTotal decimal(5,2), @IdVenta int
	BEGIN TRY
		BEGIN TRANSACTION
			SET @Precio = (SELECT precio_venta FROM Productos WHERE id = @idProd)
			SET @SubTotal = @Precio * @cantidad
			SET @IdVenta = (SELECT IDENT_CURRENT('Venta'))
			INSERT INTO Detalle_Venta(id_producto,id_venta,precio_venta,cantidad,tipo_pago,subtotal)
			VALUES(@idProd,@IdVenta,@Precio,@cantidad,@formaPago,@SubTotal)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH
END
GO
