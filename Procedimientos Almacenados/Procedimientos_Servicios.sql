CREATE PROCEDURE SP_InsertVehiculo
@llaves bit, @tarjeta bit, @poliza bit, @alarma bit, @placa nchar(9), @marca varchar(50), @modelo varchar(50), @color varchar(25),
@año int, @tipo varchar(20), @idGas int, @telefono varchar(9), @radio bit, @mascara_radio bit, @perilla_cal bit, @aire_ac bit,
@cont_alar bit, @pito bit, @esp_int bit, @esp_ext bit, @antena bit, @tapa_llanta bit, @emblema_lat bit, @emblema_post bit, @gato bit,
@llave_rueda bit,@herramientas bit,@kit_carretera bit,@tapa_gas bit,@encendedor bit,@tapa_liq_frenos bit,@tapa_fusibles bit,@alfombras bit,
@llanta_emergencia bit,@copa_llantas bit,@cable_corriente bit
AS
DECLARE @idCliente int, @idDocs int, @idCon int
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		IF NOT EXISTS(SELECT 1 FROM Vehiculos WHERE placa=@placa)
		BEGIN
			SET @idCliente = (SELECT id FROM Clientes WHERE telefono=@telefono)
			INSERT INTO Documentos(llave,tarjeta,poliza,alarma) VALUES(@llaves,@tarjeta,@poliza,@alarma)
			SET @idDocs = SCOPE_IDENTITY()
			INSERT INTO Condiciones(radio,mascara_radio,perilla_cal,aire_ac,cont_alar,pito,esp_int,esp_ext,antena,tapa_llanta,emblema_lat,emblema_post,gato,
			llave_rueda,herramientas,kit_carretera,tapa_gas,encendedor,tapa_liq_frenos,tapa_fusibles,alfombras,llanta_emergencia,copa_llantas,cable_corriente)
			VALUES(@radio,@mascara_radio,@perilla_cal,@aire_ac,@cont_alar,@pito,@esp_int,@esp_ext,@antena,@tapa_llanta,@emblema_lat,@emblema_post,@gato,
			@llave_rueda,@herramientas,@kit_carretera,@tapa_gas,@encendedor,@tapa_liq_frenos,@tapa_fusibles,@alfombras,@llanta_emergencia,
			@copa_llantas,@cable_corriente)
			SET @idCon = SCOPE_IDENTITY()
			INSERT INTO Vehiculos(placa,modelo,marca,color,año,tipo,id_gas,id_cliente,id_docs,id_con) VALUES(@placa,@modelo,@marca,@color,@año,@tipo,@idGas,@idCliente,@idDocs,@idCon)
		END
		ELSE
		BEGIN
			SELECT @idDocs = id_docs, @idCon = id_con FROM Vehiculos WHERE placa = @placa

			UPDATE Documentos SET llave=@llaves,tarjeta=@tarjeta,poliza=@poliza,alarma=@alarma WHERE id=@idDocs

			UPDATE Condiciones SET  radio=@radio, mascara_radio=@mascara_radio,perilla_cal=@perilla_cal,aire_ac=@aire_ac,cont_alar=@cont_alar,pito=@pito,
			esp_int=@esp_int,esp_ext=@esp_ext,antena=@antena,tapa_llanta=@tapa_llanta,emblema_lat=@emblema_lat,emblema_post=@emblema_post,gato=@gato,
			llave_rueda=@llave_rueda,herramientas=@herramientas,kit_carretera=@kit_carretera,tapa_gas=@tapa_gas,encendedor=@encendedor,tapa_liq_frenos=@tapa_liq_frenos,
			tapa_fusibles=@tapa_fusibles,alfombras=@alfombras,llanta_emergencia=@llanta_emergencia,copa_llantas=@copa_llantas,cable_corriente=@cable_corriente
			WHERE id = @idCon

			UPDATE Vehiculos SET modelo=@modelo,marca=@marca,color=@color,año=@año,tipo=@tipo,id_gas=@idGas,id_docs=@idDocs,id_con=@idCon WHERE placa=@placa
		END

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

CREATE PROCEDURE SP_InsertService
@gas_rec varchar(3), @distan_in int, @tipo_dis varchar(10),@pintura nvarchar(max),@receptor varchar(75),@mecanico varchar(75),
@encargado_vehi varchar(75),@cargo_en varchar(50),@comentarios varchar(500), @placa nchar(9), @idServicio int
AS
BEGIN
DECLARE @idVehiculo int, @fecha_in varchar(10)
	BEGIN TRY
		BEGIN TRANSACTION
			SET @idVehiculo = (SELECT id FROM Vehiculos WHERE placa = @placa)
			SET @fecha_in = (SELECT CONVERT(VARCHAR(10), GETDATE(), 103))
			IF @tipo_dis = 'Kilometros'
				BEGIN
					INSERT INTO Servicios(id_vehiculo,id_servicio,gas_recibido,estado,fecha_in,km_in,fecha_out,pintura,receptor,mecanico,encargado_vehi,cargo_en,comentarios,anulado)
					VALUES(@idVehiculo,@idServicio,@gas_rec,1,@fecha_in,@distan_in,@fecha_in,@pintura,@receptor,@mecanico,@encargado_vehi,@cargo_en,@comentarios,0)
				END
			ELSE IF(@tipo_dis = 'Millas')
				BEGIN
					INSERT INTO Servicios(id_vehiculo,id_servicio,gas_recibido,estado,fecha_in,mil_in,fecha_out,pintura,receptor,mecanico,encargado_vehi,cargo_en,comentarios,anulado)
					VALUES(@idVehiculo,@idServicio,@gas_rec,1,@fecha_in,@distan_in,@fecha_in,@pintura,@receptor,@mecanico,@encargado_vehi,@cargo_en,@comentarios,0)
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

CREATE PROCEDURE SP_IndexService
AS
BEGIN
SELECT s.id as 'ID', c.nombre as 'Nombre', v.marca + ' ' + v.modelo as 'Vehiculo', v.placa as 'Placa', s.fecha_in as 'Checkin',
ls.nombre as 'Servicio'
FROM Clientes c
INNER JOIN Vehiculos v
ON v.id_cliente = c.id
INNER JOIN Servicios s
ON s.id_vehiculo = v.id
INNER JOIN ListaServicios ls
ON s.id_servicio = ls.id
WHERE s.estado = 1 AND s.anulado = 0
END

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
GO

CREATE PROCEDURE SP_FillInfo
@placa nchar(8)
AS
BEGIN
	SELECT*FROM Vehiculos v
	INNER JOIN Documentos d
	ON d.id = v.id_docs
	INNER JOIN Condiciones c
	ON c.id = v.id_con
	INNER JOIN Clientes cl
	ON cl.id = v.id_cliente
	WHERE v.placa = @placa
END