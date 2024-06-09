using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            entity.HasKey(e => e.IdCargo).HasName("PK__cargos__D3C09EC59A866BEE");

            entity.ToTable("cargos");

            entity.Property(e => e.IdCargo).HasColumnName("id_cargo");
            entity.Property(e => e.NombreCargo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre_cargo");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3213E83F9850131C");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("direccion");
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
            entity.HasKey(e => e.IdCompra).HasName("PK__Compra__C4BAA60424933729");

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
                .HasConstraintName("FK__Compra__id_prove__5EBF139D");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Compra__id_usuar__5DCAEF64");
        });

        modelBuilder.Entity<Condicione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Condicio__3213E83FB4BC8A97");

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
            entity.HasKey(e => e.Id).HasName("PK__Contabil__3213E83F0ACF0905");

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
            entity.HasKey(e => e.IdDetalleCompra).HasName("PK__Detalle___BD16E2799530FC1C");

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
                .HasConstraintName("FK__Detalle_C__id_co__628FA481");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__Detalle_C__id_pr__6383C8BA");
        });

        modelBuilder.Entity<DetalleVentum>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__Detalle___4F1332DEF1A4AABC");

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
                .HasConstraintName("FK__Detalle_V__id_pr__59FA5E80");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK__Detalle_V__id_ve__59063A47");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3213E83FC412C5A8");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alarma).HasColumnName("alarma");
            entity.Property(e => e.Llave).HasColumnName("llave");
            entity.Property(e => e.Poliza).HasColumnName("poliza");
            entity.Property(e => e.Tarjeta).HasColumnName("tarjeta");
        });

        modelBuilder.Entity<Ga>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Gas__3213E83FA342EBE4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3213E83FB6D8CD12");

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
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__8D3DFE28F845BC6C");

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
            entity.HasKey(e => e.Id).HasName("PK__Servicio__3213E83FF9055BF2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comentarios)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("comentarios");
            entity.Property(e => e.FechaIn).HasColumnName("fecha_in");
            entity.Property(e => e.FechaOut).HasColumnName("fecha_out");
            entity.Property(e => e.GasRecibido)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("gas_recibido");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdCon).HasColumnName("id_con");
            entity.Property(e => e.IdDocs).HasColumnName("id_docs");
            entity.Property(e => e.IdVehiculo).HasColumnName("id_vehiculo");
            entity.Property(e => e.KmIn).HasColumnName("km_in");
            entity.Property(e => e.KmOut).HasColumnName("km_out");
            entity.Property(e => e.MilIn).HasColumnName("mil_in");
            entity.Property(e => e.MilOut).HasColumnName("mil_out");
            entity.Property(e => e.Pintura)
                .HasColumnType("image")
                .HasColumnName("pintura");
            entity.Property(e => e.Receptor)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("receptor");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Servicios__id_cl__44FF419A");

            entity.HasOne(d => d.IdConNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdCon)
                .HasConstraintName("FK__Servicios__id_co__46E78A0C");

            entity.HasOne(d => d.IdDocsNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdDocs)
                .HasConstraintName("FK__Servicios__id_do__45F365D3");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdVehiculo)
                .HasConstraintName("FK__Servicios__id_ve__440B1D61");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__4E3E04AD87CC33DA");

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
                .HasConstraintName("FK__Usuarios__id_car__4F7CD00D");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vehiculo__3213E83F0373D5CF");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Año).HasColumnName("año");
            entity.Property(e => e.Color)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
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
            entity.Property(e => e.Receptor)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("receptor");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Vehiculos__id_cl__3E52440B");

            entity.HasOne(d => d.IdDocsNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdDocs)
                .HasConstraintName("FK__Vehiculos__id_do__3F466844");

            entity.HasOne(d => d.IdGasNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.IdGas)
                .HasConstraintName("FK__Vehiculos__id_ga__3D5E1FD2");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Venta__459533BFB5B1A15F");

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
                .HasConstraintName("FK__Venta__id_client__5535A963");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Venta__id_usuari__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
