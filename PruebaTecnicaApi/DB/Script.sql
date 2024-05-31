CREATE DATABASE PruebaTecnica
USE PruebaTecnica

-- Crear tabla host
CREATE TABLE host (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NOT NULL,
    telefono NVARCHAR(20) NULL,
    RFC NVARCHAR(13) NULL,
    razon_social NVARCHAR(100) NULL,
    es_activo BIT NOT NULL
);

-- Crear tabla tipo_habitacion
CREATE TABLE tipo_habitacion (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    codigo NVARCHAR(20) NOT NULL,
    descripcion NVARCHAR(255) NULL,
    es_activo BIT NOT NULL
);

-- Crear tabla habitaciones
CREATE TABLE habitaciones (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(255) NULL,
    cantidad INT NOT NULL,
    precio DECIMAL(18, 2) NOT NULL,
    codigo NVARCHAR(20) NOT NULL,
    es_activo BIT NOT NULL,
    host_id INT NOT NULL,
    tipo_habitacion_id INT NOT NULL,
    FOREIGN KEY (host_id) REFERENCES host(id),
    FOREIGN KEY (tipo_habitacion_id) REFERENCES tipo_habitacion(id)
);
