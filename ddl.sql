
CREATE SEQUENCE public.vistas_cod_vista_seq;

CREATE TABLE public.vistas (
                cod_vista NUMERIC NOT NULL DEFAULT nextval('public.vistas_cod_vista_seq'),
                descripcion VARCHAR(50) NOT NULL,
                CONSTRAINT cod_vistas PRIMARY KEY (cod_vista)
);


ALTER SEQUENCE public.vistas_cod_vista_seq OWNED BY public.vistas.cod_vista;

CREATE SEQUENCE public.permisos_cod_permiso_seq;

CREATE TABLE public.permisos (
                cod_permiso NUMERIC NOT NULL DEFAULT nextval('public.permisos_cod_permiso_seq'),
                nombre VARCHAR(30) NOT NULL,
                descripcion VARCHAR(50) NOT NULL,
                vistas_cod_vista NUMERIC NOT NULL,
                CONSTRAINT cod_permiso PRIMARY KEY (cod_permiso)
);


ALTER SEQUENCE public.permisos_cod_permiso_seq OWNED BY public.permisos.cod_permiso;

CREATE SEQUENCE public.roles_cod_rol_seq;

CREATE TABLE public.roles (
                cod_rol NUMERIC NOT NULL DEFAULT nextval('public.roles_cod_rol_seq'),
                descripcion VARCHAR(30) NOT NULL,
                CONSTRAINT cod_rol PRIMARY KEY (cod_rol)
);


ALTER SEQUENCE public.roles_cod_rol_seq OWNED BY public.roles.cod_rol;

CREATE SEQUENCE public.permisos_roles_cod_permiso_rol_seq;

CREATE TABLE public.permisos_roles (
                cod_permiso_rol NUMERIC NOT NULL DEFAULT nextval('public.permisos_roles_cod_permiso_rol_seq'),
                cod_permiso NUMERIC NOT NULL,
                cod_rol NUMERIC NOT NULL,
                CONSTRAINT cod_permiso_rol PRIMARY KEY (cod_permiso_rol)
);


ALTER SEQUENCE public.permisos_roles_cod_permiso_rol_seq OWNED BY public.permisos_roles.cod_permiso_rol;

CREATE SEQUENCE public.compras_cab_cod_compra_cab_seq;

CREATE TABLE public.compras_cab (
                cod_compra_cab NUMERIC NOT NULL DEFAULT nextval('public.compras_cab_cod_compra_cab_seq'),
                fecha DATE NOT NULL,
                total NUMERIC NOT NULL,
                CONSTRAINT cod_compras_cab PRIMARY KEY (cod_compra_cab)
);


ALTER SEQUENCE public.compras_cab_cod_compra_cab_seq OWNED BY public.compras_cab.cod_compra_cab;

CREATE SEQUENCE public.clientes_cod_cliente_seq;

CREATE TABLE public.clientes (
                cod_cliente NUMERIC NOT NULL DEFAULT nextval('public.clientes_cod_cliente_seq'),
                nombre_usuario VARCHAR NOT NULL,
                nombre VARCHAR(50) NOT NULL,
                apellido VARCHAR(50) NOT NULL,
                nro_telefono NUMERIC,
                cuenta VARCHAR,
                correo VARCHAR,
                deuda BOOLEAN NOT NULL,
                CONSTRAINT cod_cliente PRIMARY KEY (cod_cliente)
);


ALTER SEQUENCE public.clientes_cod_cliente_seq OWNED BY public.clientes.cod_cliente;

CREATE SEQUENCE public.usuarios_cod_usuario_seq;

CREATE TABLE public.usuarios (
                cod_usuario NUMERIC NOT NULL DEFAULT nextval('public.usuarios_cod_usuario_seq'),
                cod_cliente NUMERIC NOT NULL,
                clave VARCHAR(150) NOT NULL,
                nombre_usuario VARCHAR NOT NULL,
                CONSTRAINT usuarios_pk PRIMARY KEY (cod_usuario)
);


ALTER SEQUENCE public.usuarios_cod_usuario_seq OWNED BY public.usuarios.cod_usuario;

CREATE SEQUENCE public.roles_usuarios_cod_rol_usuario_seq;

CREATE TABLE public.roles_usuarios (
                cod_rol_usuario NUMERIC NOT NULL DEFAULT nextval('public.roles_usuarios_cod_rol_usuario_seq'),
                cod_rol NUMERIC NOT NULL,
                cod_usuario NUMERIC NOT NULL,
                CONSTRAINT cod_rol_usuario PRIMARY KEY (cod_rol_usuario)
);


ALTER SEQUENCE public.roles_usuarios_cod_rol_usuario_seq OWNED BY public.roles_usuarios.cod_rol_usuario;

CREATE SEQUENCE public.ventas_cab_cod_venta_seq;

CREATE TABLE public.ventas_cab (
                cod_venta NUMERIC NOT NULL DEFAULT nextval('public.ventas_cab_cod_venta_seq'),
                cod_cliente NUMERIC NOT NULL,
                fecha DATE NOT NULL,
                total NUMERIC NOT NULL,
                condicion_venta BOOLEAN NOT NULL,
                CONSTRAINT cod_ventas_cab PRIMARY KEY (cod_venta)
);


ALTER SEQUENCE public.ventas_cab_cod_venta_seq OWNED BY public.ventas_cab.cod_venta;

CREATE SEQUENCE public.pagos_cod_pago_seq;

CREATE TABLE public.pagos (
                cod_pago NUMERIC NOT NULL DEFAULT nextval('public.pagos_cod_pago_seq'),
                cod_venta NUMERIC NOT NULL,
                fecha DATE NOT NULL,
                monto NUMERIC NOT NULL,
                CONSTRAINT cod_pago PRIMARY KEY (cod_pago)
);


ALTER SEQUENCE public.pagos_cod_pago_seq OWNED BY public.pagos.cod_pago;

CREATE SEQUENCE public.secciones_cod_seccion_seq;

CREATE TABLE public.secciones (
                cod_seccion NUMERIC NOT NULL DEFAULT nextval('public.secciones_cod_seccion_seq'),
                descripcion VARCHAR(60) NOT NULL,
                CONSTRAINT cod_seccion PRIMARY KEY (cod_seccion)
);


ALTER SEQUENCE public.secciones_cod_seccion_seq OWNED BY public.secciones.cod_seccion;

CREATE SEQUENCE public.colores_cod_color_seq;

CREATE TABLE public.colores (
                cod_color NUMERIC NOT NULL DEFAULT nextval('public.colores_cod_color_seq'),
                descripcion VARCHAR(200) NOT NULL,
                CONSTRAINT cod_color PRIMARY KEY (cod_color)
);


ALTER SEQUENCE public.colores_cod_color_seq OWNED BY public.colores.cod_color;

CREATE SEQUENCE public.marcas_cod_marca_seq;

CREATE TABLE public.marcas (
                cod_marca NUMERIC NOT NULL DEFAULT nextval('public.marcas_cod_marca_seq'),
                descripcion VARCHAR(200) NOT NULL,
                CONSTRAINT cod_marca PRIMARY KEY (cod_marca)
);


ALTER SEQUENCE public.marcas_cod_marca_seq OWNED BY public.marcas.cod_marca;

CREATE SEQUENCE public.grupos_cod_grupo_seq;

CREATE TABLE public.grupos (
                cod_grupo NUMERIC NOT NULL DEFAULT nextval('public.grupos_cod_grupo_seq'),
                descripcion VARCHAR(200) NOT NULL,
                CONSTRAINT cod_grupo PRIMARY KEY (cod_grupo)
);


ALTER SEQUENCE public.grupos_cod_grupo_seq OWNED BY public.grupos.cod_grupo;

CREATE SEQUENCE public.tamanhos_cod_tamanho_seq;

CREATE TABLE public.tamanhos (
                cod_tamanho NUMERIC NOT NULL DEFAULT nextval('public.tamanhos_cod_tamanho_seq'),
                descripcion VARCHAR(200) NOT NULL,
                CONSTRAINT cod_tamanhos PRIMARY KEY (cod_tamanho)
);


ALTER SEQUENCE public.tamanhos_cod_tamanho_seq OWNED BY public.tamanhos.cod_tamanho;

CREATE SEQUENCE public.productos_cod_producto_seq;

CREATE TABLE public.productos (
                cod_producto NUMERIC NOT NULL DEFAULT nextval('public.productos_cod_producto_seq'),
                nombre VARCHAR(30) NOT NULL,
                descripcion VARCHAR(200) NOT NULL,
                existencia BOOLEAN NOT NULL,
                costo_promedio NUMERIC NOT NULL,
                vencimiento BOOLEAN NOT NULL,
                fecha_vencimiento TIMESTAMP,
                codigo_barra NUMERIC,
                cantidad NUMERIC(38) NOT NULL,
                cod_color NUMERIC NOT NULL,
                precio NUMERIC NOT NULL,
                cod_marca NUMERIC NOT NULL,
                cod_tamanho NUMERIC NOT NULL,
                CONSTRAINT cod_producto PRIMARY KEY (cod_producto)
);


ALTER SEQUENCE public.productos_cod_producto_seq OWNED BY public.productos.cod_producto;

CREATE SEQUENCE public.compras_det_cod_compra_cab_seq;

CREATE SEQUENCE public.compras_det_cod_detalle_seq;

CREATE TABLE public.compras_det (
                cod_compra_cab NUMERIC NOT NULL DEFAULT nextval('public.compras_det_cod_compra_cab_seq'),
                cod_detalle NUMERIC NOT NULL DEFAULT nextval('public.compras_det_cod_detalle_seq'),
                costo NUMERIC NOT NULL,
                cantidad NUMERIC NOT NULL,
                cod_producto NUMERIC NOT NULL,
                CONSTRAINT cod_compra_det PRIMARY KEY (cod_compra_cab, cod_detalle)
);


ALTER SEQUENCE public.compras_det_cod_compra_cab_seq OWNED BY public.compras_det.cod_compra_cab;

ALTER SEQUENCE public.compras_det_cod_detalle_seq OWNED BY public.compras_det.cod_detalle;

CREATE SEQUENCE public.inventario_cod_inventario_seq;

CREATE TABLE public.inventario (
                cod_inventario NUMERIC NOT NULL DEFAULT nextval('public.inventario_cod_inventario_seq'),
                cod_producto NUMERIC NOT NULL,
                cantidad_sistema NUMERIC NOT NULL,
                descripcion VARCHAR(150) NOT NULL,
                cantidad_fisica NUMERIC NOT NULL,
                CONSTRAINT cod_inventario PRIMARY KEY (cod_inventario)
);


ALTER SEQUENCE public.inventario_cod_inventario_seq OWNED BY public.inventario.cod_inventario;

CREATE TABLE public.ventas_det (
                cod_producto NUMERIC NOT NULL,
                cod_venta NUMERIC NOT NULL,
                precio NUMERIC NOT NULL,
                cantidad NUMERIC NOT NULL,
                CONSTRAINT cod_ventas_det PRIMARY KEY (cod_producto, cod_venta)
);


CREATE TABLE public.secciones_productos (
                cod_seccion_producto NUMERIC NOT NULL,
                cod_producto NUMERIC NOT NULL,
                cod_seccion NUMERIC NOT NULL,
                CONSTRAINT cod_seccion_producto PRIMARY KEY (cod_seccion_producto)
);


CREATE SEQUENCE public.grupos_productos_cod_grupo_producto_seq;

CREATE TABLE public.grupos_productos (
                cod_grupo_producto NUMERIC NOT NULL DEFAULT nextval('public.grupos_productos_cod_grupo_producto_seq'),
                cod_producto NUMERIC NOT NULL,
                cod_grupo NUMERIC NOT NULL,
                CONSTRAINT cod_grupo_producto PRIMARY KEY (cod_grupo_producto)
);


ALTER SEQUENCE public.grupos_productos_cod_grupo_producto_seq OWNED BY public.grupos_productos.cod_grupo_producto;

CREATE TABLE public.imagenes (
                cod_producto NUMERIC NOT NULL,
                cod_imagen NUMERIC NOT NULL,
                imagen BYTEA NOT NULL,
                CONSTRAINT cod_imagen PRIMARY KEY (cod_producto, cod_imagen)
);


ALTER TABLE public.permisos ADD CONSTRAINT vistas_permisos_fk1
FOREIGN KEY (vistas_cod_vista)
REFERENCES public.vistas (cod_vista)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.permisos_roles ADD CONSTRAINT permisos_permisos_roles_fk
FOREIGN KEY (cod_permiso)
REFERENCES public.permisos (cod_permiso)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.permisos_roles ADD CONSTRAINT roles_permisos_roles_fk
FOREIGN KEY (cod_rol)
REFERENCES public.roles (cod_rol)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.roles_usuarios ADD CONSTRAINT roles_roles_usuarios_fk
FOREIGN KEY (cod_rol)
REFERENCES public.roles (cod_rol)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.compras_det ADD CONSTRAINT compras_cab_compras_det_fk
FOREIGN KEY (cod_compra_cab)
REFERENCES public.compras_cab (cod_compra_cab)
ON DELETE NO ACTION
ON UPDATE CASCADE
NOT DEFERRABLE;

ALTER TABLE public.ventas_cab ADD CONSTRAINT clientes_ventas_cab_fk
FOREIGN KEY (cod_cliente)
REFERENCES public.clientes (cod_cliente)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.usuarios ADD CONSTRAINT clientes_usuarios_fk
FOREIGN KEY (cod_cliente)
REFERENCES public.clientes (cod_cliente)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.roles_usuarios ADD CONSTRAINT usuarios_roles_usuarios_fk
FOREIGN KEY (cod_usuario)
REFERENCES public.usuarios (cod_usuario)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.pagos ADD CONSTRAINT ventas_cab_pagos_fk
FOREIGN KEY (cod_venta)
REFERENCES public.ventas_cab (cod_venta)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.ventas_det ADD CONSTRAINT ventas_cab_ventas_det_fk
FOREIGN KEY (cod_venta)
REFERENCES public.ventas_cab (cod_venta)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.secciones_productos ADD CONSTRAINT secciones_secciones_productos_fk
FOREIGN KEY (cod_seccion)
REFERENCES public.secciones (cod_seccion)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.productos ADD CONSTRAINT colores_productos_fk
FOREIGN KEY (cod_color)
REFERENCES public.colores (cod_color)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.productos ADD CONSTRAINT marcas_productos_fk
FOREIGN KEY (cod_marca)
REFERENCES public.marcas (cod_marca)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.grupos_productos ADD CONSTRAINT grupos_grupos_productos_fk
FOREIGN KEY (cod_grupo)
REFERENCES public.grupos (cod_grupo)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.productos ADD CONSTRAINT tamanhos_productos_fk
FOREIGN KEY (cod_tamanho)
REFERENCES public.tamanhos (cod_tamanho)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.grupos_productos ADD CONSTRAINT productos_grupos_productos_fk
FOREIGN KEY (cod_producto)
REFERENCES public.productos (cod_producto)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.imagenes ADD CONSTRAINT productos_imagenes_fk
FOREIGN KEY (cod_producto)
REFERENCES public.productos (cod_producto)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.secciones_productos ADD CONSTRAINT productos_secciones_productos_fk
FOREIGN KEY (cod_producto)
REFERENCES public.productos (cod_producto)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.ventas_det ADD CONSTRAINT productos_ventas_det_fk
FOREIGN KEY (cod_producto)
REFERENCES public.productos (cod_producto)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.inventario ADD CONSTRAINT productos_inventario_fk
FOREIGN KEY (cod_producto)
REFERENCES public.productos (cod_producto)
ON DELETE NO ACTION
ON UPDATE NO ACTION
NOT DEFERRABLE;

ALTER TABLE public.compras_det ADD CONSTRAINT productos_compras_det_fk
FOREIGN KEY (cod_producto)
REFERENCES public.productos (cod_producto)
ON DELETE NO ACTION
ON UPDATE CASCADE
NOT DEFERRABLE;
