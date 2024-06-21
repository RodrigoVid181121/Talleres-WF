CREATE PROCEDURE SP_InsertVehiculo
@llaves bit, @tarjeta bit, @poliza bit, @alarma bit, @placa nchar(9), @marca varchar(50), @modelo varchar(50), @color varchar(25),
@año tinyint, @tipo varchar(20), @idGas int, @telefono varchar(9), @radio bit, @mascara_radio bit, @perilla_cal bit, @aire_ac bit,
@cont_alar bit, @pito bit, @esp_int bit, @esp_ext bit, @antena bit, @tapa_llanta bit, @emblema_lat bit, @emblema_post bit, @gato bit,
@llave_rueda bit,@herramientas bit,@kit_carretera bit,@tapa_gas bit,@encendedor bit,@tapa_liq_frenos bit,@tapa_fusibles bit,@alfombras bit,
@llanta_emergencia bit,@copa_llantas bit,@cable_corriente bit
AS
DECLARE @idCliente int, @idDocs int, @idCon int
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
		IF NOT EXISTS(SELECT*FROM Vehiculos WHERE placa=@placa)
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