using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WF_App.Models.ViewModels;


namespace WF_App.Models.Stored_Procedures
{
    public class Productos : Controller
    {
        private readonly DbTalleresContext _context;

        public Productos(DbTalleresContext context)
        {
            _context = context;
        }
        public async Task InsertOrUpdateProduct(ProductosViewModel model)
        {
            try
            {
                var id = new SqlParameter("@id", model.Id ?? (object)DBNull.Value);
                var codigo = new SqlParameter("@codigo", model.Codigo ?? (object)DBNull.Value);
                var cantidad = new SqlParameter("@cantidad", model.Cantidad);
                var medida = new SqlParameter("@medida", model.Medida ?? (object)DBNull.Value);
                var biscosidad = new SqlParameter("@biscosidad", model.Biscosidad ?? (object)DBNull.Value);
                var precioVenta = new SqlParameter("@precio_venta", model.PrecioVenta);
                var modeloVehiculo = new SqlParameter("@modelo_vehiculo", model.ModeloVehiculo ?? (object)DBNull.Value);
                var idMarca = new SqlParameter("@id_marca", model.IdMarca ?? (object)DBNull.Value);
                var idCategoria = new SqlParameter("@id_categoria", model.IdCategoria ?? (object)DBNull.Value);
                var nombre = new SqlParameter("@nombre", model.Nombre ?? (object)DBNull.Value);

                await _context.Database.ExecuteSqlRawAsync("EXEC SP_InsertProducto @id, @codigo, @cantidad, @medida, @biscosidad, @precio_venta, @modelo_vehiculo, @id_marca, @id_categoria, @nombre",
                    id, codigo, cantidad, medida, biscosidad, precioVenta, modeloVehiculo, idMarca, idCategoria, nombre);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task DeleteProduct(int id)
        {
            try
            {
                var productId = new SqlParameter("@id", id);

                await _context.Database.ExecuteSqlRawAsync("EXEC SP_DeleteProducto @id", productId);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine(ex.ToString());
            }
        }

        public ProductosViewModel GetProductDetails(string codigo)
        {
            var model = new ProductosViewModel();
            try
            {
                using (SqlConnection con = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand("SP_FillProductInfo", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@codigo", codigo));

                        con.Open();
                        using (SqlDataReader sr = command.ExecuteReader())
                        {
                            while (sr.Read())
                            {
                                var producto = new ProductosViewModel
                                {
                                    Codigo = sr["codigo"].ToString().Trim(),
                                    Cantidad = Convert.ToInt16(sr["cantidad"]),
                                    PrecioVenta = Convert.ToDecimal(sr["precio_venta"]),
                                    ModeloVehiculo = sr["modelo_vehiculo"].ToString().Trim(),
                                    NombreMarca = sr["Marca"].ToString().Trim(),
                                    NombreCategoria = sr["Categoria"].ToString().Trim(),
                                    Nombre = sr["nombre"].ToString().Trim(),
                                    Medida = sr["medida"].ToString().Trim(),
                                    Biscosidad = sr["biscosidad"].ToString().Trim()
                                };

                                model = producto;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Manejo de errores
                Console.WriteLine(e.ToString());
            }
            return model;
        }

        public ProductosViewModel SP_SelectProductDetails(int id)
        {
            var model = new ProductosViewModel();
            using (SqlConnection con = new SqlConnection(_context.Database.GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand("SP_SelectProductDetails", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@idProducto", id));

                    con.Open();

                    using (SqlDataReader sr = command.ExecuteReader())
                    {
                        while (sr.Read())
                        {
                            var llenado = new ProductosViewModel
                            {
                                // Datos del producto
                                Codigo = sr["codigo"].ToString().Trim(),
                                Cantidad = Convert.ToInt16(sr["cantidad"]),
                                Medida = sr["medida"].ToString().Trim(),
                                Biscosidad = sr["biscosidad"].ToString().Trim(),
                                PrecioVenta = Convert.ToDecimal(sr["precio_venta"]),
                                ModeloVehiculo = sr["modelo_vehiculo"].ToString().Trim(),
                                Nombre = sr["ProductoNombre"].ToString().Trim(),

                                // Datos de la marca
                                MarcaNombre = sr["MarcaNombre"].ToString().Trim(),

                                // Datos de la categoría
                                CategoriaNombre = sr["CategoriaNombre"].ToString().Trim()
                            };

                            model = llenado;
                        }
                    }
                }
            }
            return model;
        }
    }
}
