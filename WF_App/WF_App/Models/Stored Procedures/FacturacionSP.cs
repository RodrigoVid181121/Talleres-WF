using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WF_App.Models.ViewModels;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace WF_App.Models.Stored_Procedures
{
    public class FacturacionSP : Controller
    {
        private readonly DbTalleresContext _context;

        public FacturacionSP(DbTalleresContext context)
        {
            _context = context;
        }

        public async Task SP_CreateFactura(FacturacionViewModel model)
        {
            try
            {
                var Placa = new SqlParameter("@placa", model.Placa);
                var TipoDoc = new SqlParameter("@tipoDoc", model.TipoDoc);
                var MontoTot = new SqlParameter("@montoTotal", model.MontoTotal);
                var Descripcion = new SqlParameter("@descripcion", model.Descripcion);

                await _context.Database.ExecuteSqlRawAsync("EXEC SP_CreateFactura @placa, @tipoDoc, @montoTotal," +
                    "@descripcion",Placa,TipoDoc,MontoTot,Descripcion);
            }
            catch(Exception ex)
            {
                
            }
            finally
            {

            }
        }

        public async Task CreateDetailFactura(FacturacionViewModel model)
        {
            try
            {
                var IdProd = new SqlParameter("@idProd", model.IdProductos);
                var FormaPago = new SqlParameter("@formaPago", model.FormaPago);
                var Cantidad = new SqlParameter("@cantidad", model.Cantidad);

                await _context.Database.ExecuteSqlRawAsync("EXEC SP_CreateFacturaDetail @idProd, @formaPago, @cantidad",
                    IdProd, FormaPago, Cantidad);
            }
            catch(Exception ex)
            {
                
            }
            finally
            {

            }
            
        }
    }
}
