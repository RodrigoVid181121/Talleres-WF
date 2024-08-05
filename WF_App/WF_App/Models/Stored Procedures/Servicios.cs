using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WF_App.Models.ViewModels;

namespace WF_App.Models.Stored_Procedures
{
    public class Servicios : Controller
    {
        private readonly DbTalleresContext _context;

        public Servicios(DbTalleresContext context)
        {
            _context = context;
        }

        public async Task InsertClientSP(ServiciosViewModel model)
        {
            try
            {
                var nombre = new SqlParameter("@nombre", model.Nombre);
                var tel = new SqlParameter("@telefono", model.Celular);

                await _context.Database.ExecuteSqlRawAsync("EXEC SP_InsertClient @nombre, @telefono", nombre, tel);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

        }

        public async Task VehiculoSP(ServiciosViewModel model)
        {
            try
            {
                var Llaves = new SqlParameter("@llaves", model.Llaves);
                var Tarjeta = new SqlParameter("@tarjeta", model.Tarjeta);
                var Poliza = new SqlParameter("@poliza", model.Poliza);
                var Alarma = new SqlParameter("@alarma", model.Control_Alarma);
                var Placa = new SqlParameter("@placa", model.Placa);
                var Marca = new SqlParameter("@marca", model.Marca);
                var Modelo = new SqlParameter("@modelo", model.Modelo);
                var Color = new SqlParameter("@color", model.Color);
                var Año = new SqlParameter("@año", model.Año);
                var Tipo = new SqlParameter("@tipo", model.Tipo);
                var IdGas = new SqlParameter("@idGas", model.Combustible);
                var Telefono = new SqlParameter("@telefono", model.Celular);
                var Radio = new SqlParameter("@radio", model.Radio);
                var MascRadio = new SqlParameter("@mascara_radio", model.MascRad);
                var Perilla = new SqlParameter("@perilla_cal", model.PerillaCal);
                var Ac = new SqlParameter("@aire_ac", model.AC);
                var ContAl = new SqlParameter("@cont_alar", model.ControlAlarma);
                var Pito = new SqlParameter("@pito", model.Pito);
                var EspInt = new SqlParameter("@esp_int", model.EspejoIn);
                var EspExt = new SqlParameter("@esp_ext", model.EspejoExt);
                var Antena = new SqlParameter("@antena", model.Antena);
                var TapaLlanta = new SqlParameter("@tapa_llanta", model.TapaLlanta);
                var EmbLat = new SqlParameter("@emblema_lat", model.EmbLat);
                var EmbPost = new SqlParameter("@emblema_post", model.EmbPost);
                var Gato = new SqlParameter("@gato", model.Gato);
                var LlaveRueda = new SqlParameter("@llave_rueda", model.LlaveRuedas);
                var Herramientas = new SqlParameter("@herramientas", model.Herramientas);
                var KitCarretera = new SqlParameter("@kit_carretera", model.KitCarretera);
                var TapaGas = new SqlParameter("@tapa_gas", model.TapaGas);
                var Encendedor = new SqlParameter("@encendedor", model.Encendedor);
                var Tapafrenos = new SqlParameter("@tapa_liq_frenos", model.TapaLiqFrenos);
                var TapaFus = new SqlParameter("@tapa_fusibles", model.TapaFusibles);
                var Alfombras = new SqlParameter("@alfombras", model.Alfombras);
                var LlantaEmer = new SqlParameter("@llanta_emergencia", model.LlantaEmergencia);
                var CopaLlantas = new SqlParameter("@copa_llantas", model.CopaLlanta);
                var CableCorr = new SqlParameter("@cable_corriente", model.CableCorriente);

                await _context.Database.ExecuteSqlRawAsync("EXEC SP_InsertVehiculo @llaves, @tarjeta, @poliza, @alarma, @placa, @marca," +
                    "@modelo, @color, @año, @tipo,@idGas, @telefono, @radio , @mascara_radio, @perilla_cal, @aire_ac," +
                    "@cont_alar, @pito, @esp_int, @esp_ext, @antena, @tapa_llanta, @emblema_lat,@emblema_post, @gato,@llave_rueda," +
                    "@herramientas,@kit_carretera,@tapa_gas,@encendedor,@tapa_liq_frenos,@tapa_fusibles,@alfombras," +
                    "@llanta_emergencia,@copa_llantas,@cable_corriente", Llaves, Tarjeta, Poliza, Alarma, Placa, Marca, Modelo, Color, Año,
                    Tipo, IdGas, Telefono, Radio, MascRadio, Perilla, Ac, ContAl, Pito, EspInt, EspExt, Antena, TapaLlanta, EmbLat, EmbPost,
                    Gato, LlaveRueda, Herramientas, KitCarretera, TapaGas, Encendedor, Tapafrenos, TapaFus, Alfombras, LlantaEmer, CopaLlantas,
                    CableCorr);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        public async Task ServiciosSP(ServiciosViewModel model)
        {
            try
            {
                var GasRec = new SqlParameter("@gas_rec", model.CantGas);
                var DistIn = new SqlParameter("@distan_in", model.KilIn);
                var TipoDis = new SqlParameter("@tipo_dis", model.Distancia);
                var Imagen = new SqlParameter("@pintura", model.Imagen);
                var Receptor = new SqlParameter("@receptor", model.Receptor);
                var Mecanico = new SqlParameter("@mecanico", model.Mecanico);
                var Encargado = new SqlParameter("@encargado_vehi", model.Encargado);
                var Cargo = new SqlParameter("@cargo_en", model.Cargo);
                var Comentarios = new SqlParameter("@comentarios", model.Comentarios);
                var Placa = new SqlParameter("@placa", model.Placa);
                var IdSer = new SqlParameter("@idServicio", model.IdServicio);

                await _context.Database.ExecuteSqlRawAsync("EXEC SP_InsertService @gas_rec, @distan_in, @tipo_dis,@pintura,@receptor," +
                    "@mecanico,@encargado_vehi,@cargo_en,@comentarios,@placa,@idServicio", GasRec, DistIn, TipoDis, Imagen, Receptor, Mecanico, Encargado,
                    Cargo, Comentarios, Placa, IdSer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {

            }

        }

        public List<IndexServiceViewModel> IndexSelect()
        {
            var IndexViewModel = new List<IndexServiceViewModel>();

            using (SqlConnection con = new SqlConnection(_context.Database.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_IndexService", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    using (SqlDataReader sr = command.ExecuteReader())
                    {
                        while (sr.Read())
                        {
                            var viewModel = new IndexServiceViewModel
                            {
                                ID_Servicio = Convert.ToInt32(sr["ID"]),
                                NombreCliente = sr["Nombre"].ToString(),
                                Vehiculo = sr["Vehiculo"].ToString(),
                                Placa = sr["Placa"].ToString(),
                                FechaIn = sr["Checkin"].ToString(),
                                Servicio = sr["Servicio"].ToString()
                            };
                            IndexViewModel.Add(viewModel);
                        }
                    }
                    con.Close();
                }
            }

            return IndexViewModel;
        }

        public ServiciosViewModel SP_SelectAllService(int id)
        {
            var model = new ServiciosViewModel();
            int millaje = 0;
            using (SqlConnection con = new SqlConnection(_context.Database.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_SelectAllService", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@idServicio", id));

                    con.Open();

                    using (SqlDataReader sr = command.ExecuteReader())
                    {
                        while (sr.Read())
                        {
                            if (!DBNull.Value.Equals(sr["km_in"]))
                            {
                                millaje = Convert.ToInt32(sr["km_in"]);
                            }
                            else if (!DBNull.Value.Equals(sr["mil_in"]))
                            {
                                millaje = Convert.ToInt32(sr["mil_in"]);
                            }
                            var llenado = new ServiciosViewModel
                            {
                                Action = "Finalizar",
                                //Datos del cliente
                                Nombre = sr["nombre"].ToString().Trim(),
                                Celular = sr["telefono"].ToString().Trim(),
                                Cargo = sr["cargo_en"].ToString().Trim(),
                                Encargado = sr["encargado_vehi"].ToString().Trim(),
                                //Datos del servicio
                                Receptor = sr["receptor"].ToString().Trim(),
                                Mecanico = sr["mecanico"].ToString().Trim(),
                                CantGas = sr["gas_recibido"].ToString().Trim(),
                                KilIn = millaje,
                                Comentarios = sr["comentarios"].ToString().Trim(),
                                Imagen = sr["pintura"].ToString().Trim(),
                                //Datos del vehiculo
                                Placa = sr["placa"].ToString().Trim(),
                                Marca = sr["marca"].ToString().Trim(),
                                Modelo = sr["modelo"].ToString().Trim(),
                                Color = sr["color"].ToString().Trim(),
                                Año = Convert.ToInt32(sr["año"]),
                                Tipo = sr["tipo"].ToString().Trim(),
                                Combustible = Convert.ToInt32(sr["id_gas"]),
                                Llaves = Convert.ToInt32(sr["llave"]),
                                Tarjeta = Convert.ToInt32(sr["tarjeta"]),
                                Poliza = Convert.ToInt32(sr["poliza"]),
                                Control_Alarma = Convert.ToInt32(sr["alarma"]),
                                Radio = Convert.ToInt32(sr["radio"]),
                                MascRad = Convert.ToInt32(sr["mascara_radio"]),
                                PerillaCal = Convert.ToInt32(sr["perilla_cal"]),
                                AC = Convert.ToInt32(sr["aire_ac"]),
                                ControlAlarma = Convert.ToInt32(sr["cont_alar"]),
                                Pito = Convert.ToInt32(sr["pito"]),
                                EspejoIn = Convert.ToInt32(sr["esp_int"]),
                                EspejoExt = Convert.ToInt32(sr["esp_ext"]),
                                Antena = Convert.ToInt32(sr["antena"]),
                                TapaLlanta = Convert.ToInt32(sr["tapa_llanta"]),
                                EmbLat = Convert.ToInt32(sr["emblema_lat"]),
                                EmbPost = Convert.ToInt32(sr["emblema_post"]),
                                Gato = Convert.ToInt32(sr["gato"]),
                                LlaveRuedas = Convert.ToInt32(sr["llave_rueda"]),
                                Herramientas = Convert.ToInt32(sr["herramientas"]),
                                KitCarretera = Convert.ToInt32(sr["kit_carretera"]),
                                TapaGas = Convert.ToInt32(sr["tapa_gas"]),
                                Encendedor = Convert.ToInt32(sr["encendedor"]),
                                TapaLiqFrenos = Convert.ToInt32(sr["tapa_liq_frenos"]),
                                TapaFusibles = Convert.ToInt32(sr["tapa_fusibles"]),
                                Alfombras = Convert.ToInt32(sr["alfombras"]),
                                LlantaEmergencia = Convert.ToInt32(sr["llanta_emergencia"]),
                                CopaLlanta = Convert.ToInt32(sr["copa_llantas"]),
                                CableCorriente = Convert.ToInt32(sr["cable_corriente"])
                            };

                            model = llenado;
                        }
                    }
                }
            }
            return model;
        }

        public async Task SP_FinalService(ServiciosViewModel model, int distOut)
        {
            try
            {
                await VehiculoSP(model);
                var Placa = new SqlParameter("@placa", model.Placa);
                var DistOut = new SqlParameter("@distan_out", distOut);

                await _context.Database.ExecuteSqlRawAsync("EXEC SP_FinaleService @placa, @distan_out", Placa, DistOut);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        public ServiciosViewModel SP_FillInfo(string placa)
        {
            var model = new ServiciosViewModel();
            try
            {
                using (SqlConnection con = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand("SP_FillInfo", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@placa", placa));

                        con.Open();

                        using (SqlDataReader sr = command.ExecuteReader())
                        {
                            while (sr.Read())
                            {
                                var llenado = new ServiciosViewModel
                                {
                                    Action = "Create",
                                    //Datos del cliente
                                    Nombre = sr["nombre"].ToString().Trim(),
                                    Celular = sr["telefono"].ToString().Trim(),
                                    //Datos del vehiculo
                                    Placa = sr["placa"].ToString().Trim(),
                                    Marca = sr["marca"].ToString().Trim(),
                                    Modelo = sr["modelo"].ToString().Trim(),
                                    Color = sr["color"].ToString().Trim(),
                                    Año = Convert.ToInt32(sr["año"]),
                                    Tipo = sr["tipo"].ToString().Trim(),
                                    Combustible = Convert.ToInt32(sr["id_gas"]),
                                    Llaves = Convert.ToInt32(sr["llave"]),
                                    Tarjeta = Convert.ToInt32(sr["tarjeta"]),
                                    Poliza = Convert.ToInt32(sr["poliza"]),
                                    Control_Alarma = Convert.ToInt32(sr["alarma"]),
                                    Radio = Convert.ToInt32(sr["radio"]),
                                    MascRad = Convert.ToInt32(sr["mascara_radio"]),
                                    PerillaCal = Convert.ToInt32(sr["perilla_cal"]),
                                    AC = Convert.ToInt32(sr["aire_ac"]),
                                    ControlAlarma = Convert.ToInt32(sr["cont_alar"]),
                                    Pito = Convert.ToInt32(sr["pito"]),
                                    EspejoIn = Convert.ToInt32(sr["esp_int"]),
                                    EspejoExt = Convert.ToInt32(sr["esp_ext"]),
                                    Antena = Convert.ToInt32(sr["antena"]),
                                    TapaLlanta = Convert.ToInt32(sr["tapa_llanta"]),
                                    EmbLat = Convert.ToInt32(sr["emblema_lat"]),
                                    EmbPost = Convert.ToInt32(sr["emblema_post"]),
                                    Gato = Convert.ToInt32(sr["gato"]),
                                    LlaveRuedas = Convert.ToInt32(sr["llave_rueda"]),
                                    Herramientas = Convert.ToInt32(sr["herramientas"]),
                                    KitCarretera = Convert.ToInt32(sr["kit_carretera"]),
                                    TapaGas = Convert.ToInt32(sr["tapa_gas"]),
                                    Encendedor = Convert.ToInt32(sr["encendedor"]),
                                    TapaLiqFrenos = Convert.ToInt32(sr["tapa_liq_frenos"]),
                                    TapaFusibles = Convert.ToInt32(sr["tapa_fusibles"]),
                                    Alfombras = Convert.ToInt32(sr["alfombras"]),
                                    LlantaEmergencia = Convert.ToInt32(sr["llanta_emergencia"]),
                                    CopaLlanta = Convert.ToInt32(sr["copa_llantas"]),
                                    CableCorriente = Convert.ToInt32(sr["cable_corriente"])
                                };

                                model = llenado;
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {

            }
            finally
            {

            }
            return model;
        }
    }
}
