   SCRIPT COMPLETO - BASE DE DATOS ProyectoFinal
   


-- TABLA: ROLES
CREATE TABLE dbo.tblRoles (
    IDRoles INT IDENTITY(1,1) PRIMARY KEY,
    NombreRol NVARCHAR(45),
    Pantalla NVARCHAR(45),
    TipoPermiso NVARCHAR(45),
    EstadoRol NVARCHAR(45)
);

INSERT INTO dbo.tblRoles (NombreRol, Pantalla, TipoPermiso, EstadoRol)
VALUES 
('Administrador', 'Dashboard', 'Completo', 'Activo'),
('Vendedor', 'Ventas', 'Limitado', 'Activo'),
('Contador', 'Reportes', 'Lectura', 'Activo');


-- TABLA: EMPLEADOS
CREATE TABLE dbo.tblEmpleados (
    IDEmpleado INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(45),
    Telefono NVARCHAR(20),
    Correo NVARCHAR(60),
    Cargo NVARCHAR(45),
    SalarioBase DECIMAL(10,2),
    FechaIngreso DATETIME
);

INSERT INTO dbo.tblEmpleados (Nombre, Telefono, Correo, Cargo, SalarioBase, FechaIngreso)
VALUES
('Juan Pérez', '502-5551-1111', 'juan.perez@empresa.com', 'Vendedor', 3500.00, '2023-03-15'),
('María López', '502-5552-2222', 'maria.lopez@empresa.com', 'Contadora', 4200.00, '2022-07-10'),
('Carlos García', '502-5553-3333', 'carlos.garcia@empresa.com', 'Gerente', 6000.00, '2021-01-05');



-- TABLA: SUCURSALES

CREATE TABLE dbo.tblSucursales (
    IDSucursal INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(45),
    Direccion NVARCHAR(100),
    Telefono NVARCHAR(20),
    Correo NVARCHAR(60),
    Estado NVARCHAR(45)
);

INSERT INTO dbo.tblSucursales (Nombre, Direccion, Telefono, Correo, Estado)
VALUES
('Sucursal Central', 'Zona 1, Ciudad de Guatemala', '502-2222-1000', 'central@empresa.com', 'Activo'),
('Sucursal Norte', 'Zona 16, Ciudad de Guatemala', '502-2222-2000', 'norte@empresa.com', 'Activo'),
('Sucursal Sur', 'Villa Nueva, Guatemala', '502-2222-3000', 'sur@empresa.com', 'Activo');


-- TABLA: USUARIOS
CREATE TABLE dbo.tblUsuarios (
    IDUsuarios INT IDENTITY(1,1) PRIMARY KEY,
    IDRoles INT FOREIGN KEY REFERENCES dbo.tblRoles(IDRoles),
    IDEmpleados INT FOREIGN KEY REFERENCES dbo.tblEmpleados(IDEmpleado),
    Nombre NVARCHAR(45),
    Clave NVARCHAR(45),
    Estado NVARCHAR(45)
);

INSERT INTO dbo.tblUsuarios (IDRoles, IDEmpleados, Nombre, Clave, Estado)
VALUES
(1, 3, 'admin', 'admin123', 'Activo'),
(2, 1, 'juanv', 'ventas2024', 'Activo'),
(3, 2, 'mariaC', 'conta2024', 'Activo');



-- TABLA: CLIENTES
CREATE TABLE dbo.tblClientes (
    IDClientes INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(45),
    NIT NVARCHAR(20),
    Telefono NVARCHAR(20),
    Direccion NVARCHAR(100),
    Correo NVARCHAR(60),
    Departamento NVARCHAR(45),
    TipoCliente NVARCHAR(45),
    Estado NVARCHAR(45)
);

INSERT INTO dbo.tblClientes (Nombre, NIT, Telefono, Direccion, Correo, Departamento, TipoCliente, Estado)
VALUES
('Luis Blanco', 'CF', '502-7771-1111', 'Mixco, Guatemala', 'luis@cliente.com', 'Guatemala', 'Frecuente', 'Activo'),
('Ana Morales', '789456-2', '502-7772-2222', 'Villa Nueva, Guatemala', 'ana@cliente.com', 'Guatemala', 'Ocasional', 'Activo'),
('Pedro Ramírez', '456789-3', '502-7773-3333', 'Antigua Guatemala', 'pedro@cliente.com', 'Sacatepéquez', 'Nuevo', 'Activo');



-- TABLA: VENTAS

CREATE TABLE dbo.tblVentas (
    IDVentas INT IDENTITY(1,1) PRIMARY KEY,
    IDUsuarios INT FOREIGN KEY REFERENCES dbo.tblUsuarios(IDUsuarios),
    IDClientes INT FOREIGN KEY REFERENCES dbo.tblClientes(IDClientes),
    IDSucursal INT FOREIGN KEY REFERENCES dbo.tblSucursales(IDSucursal),
    FechaVenta DATETIME,
    TotalVenta DECIMAL(10,2),
    Estado NVARCHAR(45)
);

INSERT INTO dbo.tblVentas (IDUsuarios, IDClientes, IDSucursal, FechaVenta, TotalVenta, Estado)
VALUES
(2, 1, 1, '2025-01-15', 1200.50, 'Pagado'),
(2, 2, 2, '2025-02-10', 850.00, 'Pendiente'),
(3, 3, 3, '2025-03-12', 430.75, 'Anulado');



-- TABLA: DETALLE VENTA
CREATE TABLE dbo.tblDetalleVenta (
    IDDetalleVenta INT IDENTITY(1,1) PRIMARY KEY,
    IDVentas INT FOREIGN KEY REFERENCES dbo.tblVentas(IDVentas),
    Cantidad INT,
    PrecioUnitario DECIMAL(10,2),
    Descuento DECIMAL(5,2),
    Impuesto DECIMAL(5,2),
    Total DECIMAL(10,2),
    Estado NVARCHAR(45)
);

INSERT INTO dbo.tblDetalleVenta (IDVentas, Cantidad, PrecioUnitario, Descuento, Impuesto, Total, Estado)
VALUES
(1, 2, 500.00, 0, 60.00, 1060.00, 'Activo'),
(2, 1, 850.00, 0, 102.00, 952.00, 'Activo'),
(3, 3, 120.00, 10.00, 43.00, 393.00, 'Anulado');




-- TABLA: INVENTARIO
CREATE TABLE dbo.tblInventario (
    IDInventario INT IDENTITY(1,1) PRIMARY KEY,
    Cantidad INT,
    UltimaFechaActualizacion DATETIME,
    Estado NVARCHAR(45)
);

INSERT INTO dbo.tblInventario (Cantidad, UltimaFechaActualizacion, Estado)
VALUES
(50, '2025-01-01', 'Disponible'),
(100, '2025-01-20', 'Disponible'),
(10, '2025-03-10', 'Bajo stock');




-- TABLA: PROVEEDOR
CREATE TABLE dbo.tblProveedor (
    IDProveedor INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(45),
    Telefono NVARCHAR(20),
    Correo NVARCHAR(60),
    Direccion NVARCHAR(100),
    Estado NVARCHAR(45)
);

INSERT INTO dbo.tblProveedor (Nombre, Telefono, Correo, Direccion, Estado)
VALUES
('Distribuidora Maya', '502-6601-1111', 'contacto@maya.com', 'Zona 4, Guatemala', 'Activo'),
('TecnoExpress', '502-6602-2222', 'ventas@tecnoexpress.com', 'Zona 9, Guatemala', 'Activo'),
('MegaProveeduría', '502-6603-3333', 'info@megapro.com', 'Mixco, Guatemala', 'Activo');



-- TABLA: MATERIALES
CREATE TABLE dbo.tblMateriales (
    IDMateriales INT IDENTITY(1,1) PRIMARY KEY,
    IDProveedor INT FOREIGN KEY REFERENCES dbo.tblProveedor(IDProveedor),
    IDDetalleVenta INT FOREIGN KEY REFERENCES dbo.tblDetalleVenta(IDDetalleVenta),
    IDInventario INT FOREIGN KEY REFERENCES dbo.tblInventario(IDInventario),
    IDBarra NVARCHAR(45),
    Nombre NVARCHAR(45),
    Precio DECIMAL(12,2),
    Stock INT,
    Categoria NVARCHAR(45),
    Descripcion NVARCHAR(100),
    Estado NVARCHAR(45)
);

INSERT INTO dbo.tblMateriales (IDProveedor, IDDetalleVenta, IDInventario, IDBarra, Nombre, Precio, Stock, Categoria, Descripcion, Estado)
VALUES
(1, 1, 1, 'A001', 'Laptop HP 14"', 4500.00, 15, 'Tecnología', 'Laptop de oficina', 'Activo'),
(2, 2, 2, 'A002', 'Mouse Inalámbrico Logitech', 150.00, 50, 'Accesorios', 'Mouse óptico sin cable', 'Activo'),
(3, 3, 3, 'A003', 'Monitor Samsung 24"', 1200.00, 8, 'Pantallas', 'Full HD', 'Activo');



-- TABLA: ENVIOS
CREATE TABLE dbo.tblEnvios (
    IDEnvios INT IDENTITY(1,1) PRIMARY KEY,
    IDVentas INT FOREIGN KEY REFERENCES dbo.tblVentas(IDVentas),
    FechaEnvio DATETIME,
    Direccion NVARCHAR(100),
    Vehiculo NVARCHAR(45),
    Costo DECIMAL(10,2),
    Estado NVARCHAR(45)
);

INSERT INTO dbo.tblEnvios (IDVentas, FechaEnvio, Direccion, Vehiculo, Costo, Estado)
VALUES
(1, '2025-01-16', 'Zona 1, Guatemala', 'Pickup Toyota', 50.00, 'Entregado'),
(2, '2025-02-12', 'Villa Nueva', 'Motocicleta', 25.00, 'Pendiente'),
(3, '2025-03-13', 'Antigua Guatemala', 'Camión pequeño', 80.00, 'Cancelado');



-- TABLA: PAGOS CLIENTE
CREATE TABLE dbo.tblPagosCliente (
    IDPagosCliente INT IDENTITY(1,1) PRIMARY KEY,
    IDVentas INT FOREIGN KEY REFERENCES dbo.tblVentas(IDVentas),
    Fecha DATETIME,
    Monto DECIMAL(12,2),
    MetodoPago NVARCHAR(45),
    Estado NVARCHAR(45)
);

INSERT INTO dbo.tblPagosCliente (IDVentas, Fecha, Monto, MetodoPago, Estado)
VALUES
(1, '2025-01-16', 1200.50, 'Tarjeta', 'Confirmado'),
(2, '2025-02-11', 850.00, 'Efectivo', 'Pendiente'),
(3, '2025-03-12', 430.75, 'Transferencia', 'Anulado');




-- TABLA: PAGO PROVEEDOR
CREATE TABLE dbo.tblPagoProveedor (
    IDPagoProveedor INT IDENTITY(1,1) PRIMARY KEY,
    IDProveedor INT FOREIGN KEY REFERENCES dbo.tblProveedor(IDProveedor),
    Fecha DATETIME,
    Monto DECIMAL(12,2),
    MetodoPago NVARCHAR(45),
    Estado NVARCHAR(45)
);

INSERT INTO dbo.tblPagoProveedor (IDProveedor, Fecha, Monto, MetodoPago, Estado)
VALUES
(1, '2025-01-20', 5000.00, 'Transferencia', 'Pagado'),
(2, '2025-02-18', 3200.00, 'Cheque', 'Pendiente'),
(3, '2025-03-05', 2800.00, 'Efectivo', 'Pagado');


