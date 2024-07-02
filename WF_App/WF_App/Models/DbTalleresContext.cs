using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WF_App.Models.ViewModels;

namespace WF_App.Models;

public partial class DbTalleresContext : DbContext
{
    public DbTalleresContext()
    {
    }

    public DbTalleresContext(DbContextOptions<DbTalleresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Condicione> Condiciones { get; set; }

    public virtual DbSet<Contabilidad> Contabilidads { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Ga> Gas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-CG3R77P;Database=DB_Talleres;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__cargos__D3C09EC5542B83A4");

            entity.ToTable("cargos");

            entity.Property(e => e.IdCargo).HasColumnName("id_cargo");
            entity.Property(e => e.NombreCargo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre_cargo");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3213E83FAC0421C1");

            entity.HasIndex(e => e.Telefono, "UQ__Clientes__2A16D945700775BD").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK__Compra__C4BAA604422F21CE");

            entity.ToTable("Compra");

            entity.Property(e => e.IdCompra).HasColumnName("id_compra");
            entity.Property(e => e.FechaCompra)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_compra");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.MontoTot)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("monto_tot");
            entity.Property(e => e.NumeroDoc).HasColumnName("numero_doc");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_doc");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__Compra__id_prove__5DCAEF64");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Compra__id_usuar__5CD6CB2B");
        });

        modelBuilder.Entity<Condicione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Condicio__3213E83F33485F8F");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AireAc).HasColumnName("aire_ac");
            entity.Property(e => e.Alfombras).HasColumnName("alfombras");
            entity.Property(e => e.Antena).HasColumnName("antena");
            entity.Property(e => e.CableCorriente).HasColumnName("cable_corriente");
            entity.Property(e => e.ContAlar).HasColumnName("cont_alar");
            entity.Property(e => e.CopaLlantas).HasColumnName("copa_llantas");
            entity.Property(e => e.EmblemaLat).HasColumnName("emblema_lat");
            entity.Property(e => e.EmblemaPost).HasColumnName("emblema_post");
            entity.Property(e => e.Encendedor).HasColumnName("encendedor");
            entity.Property(e => e.EspExt).HasColumnName("esp_ext");
            entity.Property(e => e.EspInt).HasColumnName("esp_int");
            entity.Property(e => e.Gato).HasColumnName("gato");
            entity.Property(e => e.Herramientas).HasColumnName("herramientas");
            entity.Property(e => e.KitCarretera).HasColumnName("kit_carretera");
            entity.Property(e => e.LlantaEmergencia).HasColumnName("llanta_emergencia");
            entity.Property(e => e.LlaveRueda).HasColumnName("llave_rueda");
            entity.Property(e => e.MascaraRadio).HasColumnName("mascara_radio");
            entity.Property(e => e.PerillaCal).HasColumnName("perilla_cal");
            entity.Property(e => e.Pito).HasColumnName("pito");
            entity.Property(e => e.Radio).HasColumnName("radio");
            entity.Property(e => e.TapaFusibles).HasColumnName("tapa_fusibles");
            entity.Property(e => e.TapaGas).HasColumnName("tapa_gas");
            entity.Property(e => e.TapaLiqFrenos).HasColumnName("tapa_liq_frenos");
            entity.Property(e => e.TapaLlanta).HasColumnName("tapa_llanta");
        });

        modelBuilder.Entity<Contabilidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contabil__3213E83FED5CC22A");

            entity.ToTable("Contabilidad");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Balance)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("balance");
            entity.Property(e => e.Concepto)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("concepto");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("tipo_pago");
            entity.Property(e => e.TipoTrans)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_trans");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCompra).HasName("PK__Detalle___BD16E2794D8F770A");

            entity.ToTable("Detalle_Compra");

            entity.Property(e => e.IdDetalleCompra).HasColumnName("id_detalle_compra");
            entity.Property(e => e.FechaCompra)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_compra");
            entity.Property(e => e.IdCompra).HasColumnName("id_compra");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("metodo_pago");
            entity.Property(e => e.PrecioCompra)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("precio_compra");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("precio_venta");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdCompra)
                .HasConstraintName("FK__Detalle_C__id_co__619B8048");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Detalle_C__id_pr__628FA481");
        });

        modelBuilder.Entity<DetalleVentum>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__Detalle___4F1332DE723AA80E");

            entity.ToTable("Detalle_Venta");

            entity.Property(e => e.IdDetalle).HasColumnName("id_detalle");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.NumeroRef).HasColumnName("numero_ref");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("precio_venta");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("tipo_pago");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Detalle_V__id_pr__59063A47");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK__Detalle_V__id_ve__5812160E");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3213E83F8EDB5C70");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alarma).HasColumnName("alarma");
            entity.Property(e => e.Llave).HasColumnName("llave");
            entity.Property(e => e.Poliza).HasColumnName("poliza");
            entity.Property(e => e.Tarjeta).HasColumnName("tarjeta");
        });

        modelBuilder.Entity<Ga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Gas__3213E83F7B7C5D09");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3213E83FE7ECBC35");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Codigo)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("codigo");
            entity.Property(e => e.ModeloVehiculo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo_vehiculo");
            entity.Property(e => e.PrecioCosto)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("precio_costo");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("precio_venta");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__8D3DFE2875784096");

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.CodigoProveedor)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("codigo_proveedor");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreProveedor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_proveedor");
            entity.Property(e => e.Telefono)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Servicio__3213E83F069CC912");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CargoEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cargo_en");
            entity.Property(e => e.Comentarios)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("comentarios");
            entity.Property(e => e.EncargadoVehi)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("encargado_vehi");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaIn)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fecha_in");
            entity.Property(e => e.FechaOut)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fecha_out");
            entity.Property(e => e.GasRecibido)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("gas_recibido");
            entity.Property(e => e.IdVehiculo).HasColumnName("id_vehiculo");
            entity.Property(e => e.KmIn).HasColumnName("km_in");
            entity.Property(e => e.KmOut).HasColumnName("km_out");
            entity.Property(e => e.Mecanico)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("mecanico");
            entity.Property(e => e.MilIn).HasColumnName("mil_in");
            entity.Property(e => e.MilOut).HasColumnName("mil_out");
            entity.Property(e => e.Pintura).HasColumnName("pintura");
            entity.Property(e => e.Receptor)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("receptor");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdVehiculo)
                .HasConstraintName("FK__Servicios__id_ve__4E88ABD4");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__4E3E04ADEDE87026");

            entity.HasIndex(e => e.Codigo, "UQ__Usuarios__40F9A2066D2278B1").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Codigo)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("codigo");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.IdCargo).HasColumnName("id_cargo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Salario)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("salario");

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdCargo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Usuarios__id_car__3A81B327");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vehiculo__3213E83F024AAA5E");

            entity.HasIndex(e => e.Placa, "UQ__Vehiculo__0C05742598B77EDC").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Año).HasColumnName("año");
            entity.Property(e => e.Color)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdCon).HasColumnName("id_con");
            entity.Property(e => e.IdDocs).HasColumnName("id_docs");
            entity.Property(e => e.IdGas).HasColumnName("id_gas");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo");
            entity.Property(e => e.Placa)
                .HasMaxLength(9)
                .IsFixedLength()
                .HasColumnName("placa");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Vehiculos__id_cl__49C3F6B7");

            entity.HasOne(d => d.IdConNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdCon)
                .HasConstraintName("FK__Vehiculos__id_co__4BAC3F29");

            entity.HasOne(d => d.IdDocsNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdDocs)
                .HasConstraintName("FK__Vehiculos__id_do__4AB81AF0");

            entity.HasOne(d => d.IdGasNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdGas)
                .HasConstraintName("FK__Vehiculos__id_ga__48CFD27E");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Venta__459533BF5B2FA7DF");

            entity.Property(e => e.IdVenta).HasColumnName("id_venta");
            entity.Property(e => e.Descuento).HasColumnName("descuento");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.MontoCambio)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("monto_cambio");
            entity.Property(e => e.MontoTotal)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("monto_total");
            entity.Property(e => e.NumeroDoc).HasColumnName("numero_doc");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_doc");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Venta__id_client__5441852A");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Venta__id_usuari__534D60F1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public async Task InsertClientSP(ServiciosViewModel model)
    {
        try
        {
            var nombre = new SqlParameter("@nombre", model.Nombre);
            var tel = new SqlParameter("@telefono", model.Celular);

            await Database.ExecuteSqlRawAsync("EXEC SP_InsertClient @nombre, @telefono", nombre, tel);
        }
        catch(Exception ex)
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

            await Database.ExecuteSqlRawAsync("EXEC SP_InsertVehiculo @llaves, @tarjeta, @poliza, @alarma, @placa, @marca," +
                "@modelo, @color, @año, @tipo,@idGas, @telefono, @radio , @mascara_radio, @perilla_cal, @aire_ac," +
                "@cont_alar, @pito, @esp_int, @esp_ext, @antena, @tapa_llanta, @emblema_lat,@emblema_post, @gato,@llave_rueda," +
                "@herramientas,@kit_carretera,@tapa_gas,@encendedor,@tapa_liq_frenos,@tapa_fusibles,@alfombras," +
                "@llanta_emergencia,@copa_llantas,@cable_corriente", Llaves, Tarjeta, Poliza, Alarma, Placa, Marca, Modelo, Color, Año,
                Tipo, IdGas, Telefono, Radio, MascRadio, Perilla, Ac, ContAl, Pito, EspInt, EspExt, Antena, TapaLlanta, EmbLat, EmbPost,
                Gato, LlaveRueda, Herramientas, KitCarretera, TapaGas, Encendedor, Tapafrenos, TapaFus, Alfombras, LlantaEmer, CopaLlantas,
                CableCorr);
        }
        catch(Exception ex)
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

            await Database.ExecuteSqlRawAsync("EXEC SP_InsertService @gas_rec, @distan_in, @tipo_dis,@pintura,@receptor," +
                "@mecanico,@encargado_vehi,@cargo_en,@comentarios,@placa", GasRec, DistIn, TipoDis, Imagen, Receptor, Mecanico, Encargado,
                Cargo, Comentarios,Placa);
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

        using(SqlConnection con = new SqlConnection(Database.GetConnectionString()))
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
                            FechaIn = sr["Checkin"].ToString()
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
        using (SqlConnection con = new SqlConnection(Database.GetConnectionString()))
        {
            using (SqlCommand command = new SqlCommand("SP_SelectAllService",con))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@idServicio", id));

                con.Open();

                using (SqlDataReader sr = command.ExecuteReader())
                {
                    while (sr.Read())
                    {
                        if(!DBNull.Value.Equals(sr["km_in"]))
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

    public async Task SP_FinalService(ServiciosViewModel model,int distOut)
    {
        try
        {
           await VehiculoSP(model);
            var Placa = new SqlParameter("@placa", model.Placa);
            var DistOut = new SqlParameter("@distan_out", distOut);

            await Database.ExecuteSqlRawAsync("EXEC SP_FinaleService @placa, @distan_out", Placa, DistOut);
        }
        catch(Exception ex)
        {

        }
        finally
        {

        }
    }
}
