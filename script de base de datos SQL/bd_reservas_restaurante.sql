IF DB_ID('bd_reservas_restaurante') IS NOT NULL
BEGIN
    ALTER DATABASE bd_reservas_restaurante SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE bd_reservas_restaurante;
END
GO

CREATE DATABASE bd_reservas_restaurante;
GO

USE bd_reservas_restaurante;
GO

CREATE TABLE ubigeo (
    ubigeo_id INT IDENTITY(1,1) NOT NULL,
    departamento NVARCHAR(50) NOT NULL,
    provincia NVARCHAR(50) NOT NULL,
    distrito NVARCHAR(50) NOT NULL,
    CONSTRAINT pk_ubigeo PRIMARY KEY (ubigeo_id)
);
GO

CREATE TABLE cargos (
    cargo_id INT IDENTITY(1,1) NOT NULL,
    nombre_cargo NVARCHAR(50) NOT NULL,
    descripcion_cargo NVARCHAR(200) NULL,
    salario_base DECIMAL(10,2) NULL,
    fecha_creacion DATETIME NOT NULL CONSTRAINT df_cargos_fecha_creacion DEFAULT (GETDATE()),
    usuario_creacion NVARCHAR(50) NOT NULL CONSTRAINT df_cargos_usuario_creacion DEFAULT (SUSER_SNAME()),
    fecha_ult_modificacion DATETIME NULL,
    usuario_ult_modificacion NVARCHAR(50) NULL,
    estado INT NOT NULL CONSTRAINT df_cargos_estado DEFAULT (1),
    CONSTRAINT pk_cargos PRIMARY KEY (cargo_id),
    CONSTRAINT ck_cargos_estado CHECK (estado IN (0,1))
);
GO

CREATE TABLE zonas (
    zona_id INT IDENTITY(1,1) NOT NULL,
    nombre_zona NVARCHAR(50) NOT NULL,
    descripcion NVARCHAR(200) NULL,
    fecha_creacion DATETIME NOT NULL CONSTRAINT df_zonas_fecha_creacion DEFAULT (GETDATE()),
    usuario_creacion NVARCHAR(50) NOT NULL CONSTRAINT df_zonas_usuario_creacion DEFAULT (SUSER_SNAME()),
    fecha_ult_modificacion DATETIME NULL,
    usuario_ult_modificacion NVARCHAR(50) NULL,
    estado INT NOT NULL CONSTRAINT df_zonas_estado DEFAULT (1),
    CONSTRAINT pk_zonas PRIMARY KEY (zona_id),
    CONSTRAINT ck_zonas_estado CHECK (estado IN (0,1))
);
GO

CREATE TABLE turnos (
    turno_id INT IDENTITY(1,1) NOT NULL,
    nombre_turno NVARCHAR(50) NOT NULL,
    hora_inicio_turno TIME NOT NULL,
    hora_fin_turno TIME NOT NULL,
    fecha_creacion DATETIME NOT NULL CONSTRAINT df_turnos_fecha_creacion DEFAULT (GETDATE()),
    usuario_creacion NVARCHAR(50) NOT NULL CONSTRAINT df_turnos_usuario_creacion DEFAULT (SUSER_SNAME()),
    fecha_ult_modificacion DATETIME NULL,
    usuario_ult_modificacion NVARCHAR(50) NULL,
    estado INT NOT NULL CONSTRAINT df_turnos_estado DEFAULT (1),
    CONSTRAINT pk_turnos PRIMARY KEY (turno_id),
    CONSTRAINT ck_turnos_estado CHECK (estado IN (0,1))
);
GO

CREATE TABLE estados_reserva (
    estado_id INT IDENTITY(1,1) NOT NULL,
    nombre_estado NVARCHAR(50) NOT NULL,
    descripcion NVARCHAR(200) NULL,
    CONSTRAINT pk_estados_reserva PRIMARY KEY (estado_id)
);
GO

CREATE TABLE categorias (
    categoria_id INT IDENTITY(1,1) NOT NULL,
    nombre_categoria NVARCHAR(50) NOT NULL,
    descripcion NVARCHAR(200) NULL,
    fecha_creacion DATETIME NOT NULL CONSTRAINT df_categorias_fecha_creacion DEFAULT (GETDATE()),
    usuario_creacion NVARCHAR(50) NOT NULL CONSTRAINT df_categorias_usuario_creacion DEFAULT (SUSER_SNAME()),
    fecha_ult_modificacion DATETIME NULL,
    usuario_ult_modificacion NVARCHAR(50) NULL,
    estado INT NOT NULL CONSTRAINT df_categorias_estado DEFAULT (1),
    CONSTRAINT pk_categorias PRIMARY KEY (categoria_id),
    CONSTRAINT ck_categorias_estado CHECK (estado IN (0,1))
);
GO

CREATE TABLE clientes (
    cliente_id INT IDENTITY(1,1) NOT NULL,
    nombres NVARCHAR(50) NOT NULL,
    apellidos NVARCHAR(50) NOT NULL,
    telefono VARCHAR(15) NULL,
    correo NVARCHAR(100) NOT NULL,
    fecha_nacimiento DATE NOT NULL,
    sexo CHAR(1) NOT NULL,
    categoria_cliente VARCHAR(20) NOT NULL CONSTRAINT df_clientes_categoria_cliente DEFAULT ('Nuevo'),
    fecha_creacion DATETIME NOT NULL CONSTRAINT df_clientes_fecha_creacion DEFAULT (GETDATE()),
    usuario_creacion NVARCHAR(50) NOT NULL CONSTRAINT df_clientes_usuario_creacion DEFAULT (SUSER_SNAME()),
    fecha_ult_modificacion DATETIME NULL,
    usuario_ult_modificacion NVARCHAR(50) NULL,
    estado INT NOT NULL CONSTRAINT df_clientes_estado DEFAULT (1),
    CONSTRAINT pk_clientes PRIMARY KEY (cliente_id),
    CONSTRAINT uq_clientes_correo UNIQUE (correo),
    CONSTRAINT ck_clientes_sexo CHECK (sexo IN ('M','F')),
    CONSTRAINT ck_clientes_categoria_cliente CHECK (categoria_cliente IN ('Nuevo','Regular','Frecuente','VIP')),
    CONSTRAINT ck_clientes_estado CHECK (estado IN (0,1))
);
GO

CREATE TABLE empleados (
    empleado_id INT IDENTITY(1,1) NOT NULL,
    nombres NVARCHAR(50) NOT NULL,
    apellidos NVARCHAR(50) NOT NULL,
    dni CHAR(8) NOT NULL,
    telefono VARCHAR(15) NULL,
    email NVARCHAR(100) NULL,
    fecha_contratacion DATE NOT NULL,
    cargo_id INT NOT NULL,
    foto VARBINARY(MAX) NULL,
    sexo CHAR(1) NOT NULL,
    fecha_nacimiento DATE NOT NULL,
    direccion NVARCHAR(150) NOT NULL,
    ubigeo_id INT NOT NULL,
    fecha_creacion DATETIME NOT NULL CONSTRAINT df_empleados_fecha_creacion DEFAULT (GETDATE()),
    usuario_creacion NVARCHAR(50) NOT NULL CONSTRAINT df_empleados_usuario_creacion DEFAULT (SUSER_SNAME()),
    fecha_ult_modificacion DATETIME NULL,
    usuario_ult_modificacion NVARCHAR(50) NULL,
    estado INT NOT NULL CONSTRAINT df_empleados_estado DEFAULT (1),
    CONSTRAINT pk_empleados PRIMARY KEY (empleado_id),
    CONSTRAINT uq_empleados_dni UNIQUE (dni),
    CONSTRAINT ck_empleados_dni CHECK (dni NOT LIKE '%[^0-9]%'),
    CONSTRAINT ck_empleados_sexo CHECK (sexo IN ('M','F')),
    CONSTRAINT ck_empleados_estado CHECK (estado IN (0,1)),
    CONSTRAINT fk_empleados_cargos FOREIGN KEY (cargo_id) REFERENCES cargos (cargo_id),
    CONSTRAINT fk_empleados_ubigeo FOREIGN KEY (ubigeo_id) REFERENCES ubigeo (ubigeo_id)
);
GO

CREATE TABLE mesas (
    mesa_id INT IDENTITY(1,1) NOT NULL,
    numero_mesa INT NOT NULL,
    capacidad INT NOT NULL,
    zona_id INT NOT NULL,
    estado_mesa VARCHAR(20) NOT NULL CONSTRAINT df_mesas_estado_mesa DEFAULT ('Disponible'),
    fecha_creacion DATETIME NOT NULL CONSTRAINT df_mesas_fecha_creacion DEFAULT (GETDATE()),
    usuario_creacion NVARCHAR(50) NOT NULL CONSTRAINT df_mesas_usuario_creacion DEFAULT (SUSER_SNAME()),
    fecha_ult_modificacion DATETIME NULL,
    usuario_ult_modificacion NVARCHAR(50) NULL,
    estado INT NOT NULL CONSTRAINT df_mesas_estado DEFAULT (1),
    CONSTRAINT pk_mesas PRIMARY KEY (mesa_id),
    CONSTRAINT ck_mesas_estado_mesa CHECK (estado_mesa IN ('Disponible','Reservada','Ocupada','Mantenimiento')),
    CONSTRAINT ck_mesas_estado CHECK (estado IN (0,1)),
    CONSTRAINT fk_mesas_zonas FOREIGN KEY (zona_id) REFERENCES zonas (zona_id)
);
GO

CREATE TABLE platos (
    plato_id INT IDENTITY(1,1) NOT NULL,
    nombre_plato NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(300) NULL,
    categoria_id INT NOT NULL,
    tiempo_preparacion_minutos INT NULL,
    disponible BIT NOT NULL CONSTRAINT df_platos_disponible DEFAULT (1),
    precio_referencial DECIMAL(8,2) NULL,
    foto VARBINARY(MAX) NULL,
    fecha_creacion DATETIME NOT NULL CONSTRAINT df_platos_fecha_creacion DEFAULT (GETDATE()),
    usuario_creacion NVARCHAR(50) NOT NULL CONSTRAINT df_platos_usuario_creacion DEFAULT (SUSER_SNAME()),
    fecha_ult_modificacion DATETIME NULL,
    usuario_ult_modificacion NVARCHAR(50) NULL,
    estado INT NOT NULL CONSTRAINT df_platos_estado DEFAULT (1),
    CONSTRAINT pk_platos PRIMARY KEY (plato_id),
    CONSTRAINT ck_platos_estado CHECK (estado IN (0,1)),
    CONSTRAINT fk_platos_categorias FOREIGN KEY (categoria_id) REFERENCES categorias (categoria_id)
);
GO

CREATE TABLE reservas (
    reserva_id INT IDENTITY(1,1) NOT NULL,
    cliente_id INT NOT NULL,
    fecha_reserva DATE NOT NULL,
    hora_reserva TIME NOT NULL,
    numero_personas INT NOT NULL,
    mesa_id INT NOT NULL,
    turno_id INT NOT NULL,
    estado_id INT NOT NULL,
    empleado_id INT NOT NULL,
    observaciones NVARCHAR(300) NULL,
    fecha_creacion DATETIME NOT NULL CONSTRAINT df_reservas_fecha_creacion DEFAULT (GETDATE()),
    usuario_creacion NVARCHAR(50) NOT NULL CONSTRAINT df_reservas_usuario_creacion DEFAULT (SUSER_SNAME()),
    fecha_ult_modificacion DATETIME NULL,
    usuario_ult_modificacion NVARCHAR(50) NULL,
    estado INT NOT NULL CONSTRAINT df_reservas_estado DEFAULT (1),
    CONSTRAINT pk_reservas PRIMARY KEY (reserva_id),
    CONSTRAINT ck_reservas_estado CHECK (estado IN (0,1)),
    CONSTRAINT fk_reservas_clientes FOREIGN KEY (cliente_id) REFERENCES clientes (cliente_id),
    CONSTRAINT fk_reservas_mesas FOREIGN KEY (mesa_id) REFERENCES mesas (mesa_id),
    CONSTRAINT fk_reservas_turnos FOREIGN KEY (turno_id) REFERENCES turnos (turno_id),
    CONSTRAINT fk_reservas_estados_reserva FOREIGN KEY (estado_id) REFERENCES estados_reserva (estado_id),
    CONSTRAINT fk_reservas_empleados FOREIGN KEY (empleado_id) REFERENCES empleados (empleado_id)
);
GO

CREATE UNIQUE INDEX uq_reservas_mesa_fecha_hora
ON reservas (mesa_id, fecha_reserva, hora_reserva)
WHERE estado = 1 AND estado_id <> 6 AND estado_id <> 7 AND estado_id <> 8 AND estado_id <> 19;
GO

CREATE TABLE pedidos (
    pedido_id INT IDENTITY(1,1) NOT NULL,
    fecha_pedido DATETIME NOT NULL CONSTRAINT df_pedidos_fecha_pedido DEFAULT (GETDATE()),
    reserva_id INT NOT NULL,
    fecha_creacion DATETIME NOT NULL CONSTRAINT df_pedidos_fecha_creacion DEFAULT (GETDATE()),
    usuario_creacion NVARCHAR(50) NOT NULL CONSTRAINT df_pedidos_usuario_creacion DEFAULT (SUSER_SNAME()),
    fecha_ult_modificacion DATETIME NULL,
    usuario_ult_modificacion NVARCHAR(50) NULL,
    estado INT NOT NULL CONSTRAINT df_pedidos_estado DEFAULT (1),
    CONSTRAINT pk_pedidos PRIMARY KEY (pedido_id),
    CONSTRAINT ck_pedidos_estado CHECK (estado IN (0,1)),
    CONSTRAINT fk_pedidos_reservas FOREIGN KEY (reserva_id) REFERENCES reservas (reserva_id)
);
GO

CREATE TABLE detalle_pedido (
    detalle_pedido_id INT IDENTITY(1,1) NOT NULL,
    pedido_id INT NOT NULL,
    plato_id INT NOT NULL,
    cantidad INT NOT NULL,
    CONSTRAINT pk_detalle_pedido PRIMARY KEY (detalle_pedido_id),
    CONSTRAINT uq_detalle_pedido_pedido_plato UNIQUE (pedido_id, plato_id),
    CONSTRAINT ck_detalle_pedido_cantidad CHECK (cantidad > 0),
    CONSTRAINT fk_detalle_pedido_pedidos FOREIGN KEY (pedido_id) REFERENCES pedidos (pedido_id),
    CONSTRAINT fk_detalle_pedido_platos FOREIGN KEY (plato_id) REFERENCES platos (plato_id)
);
GO

INSERT INTO ubigeo (departamento, provincia, distrito) VALUES
(N'Lima', N'Lima', N'Cercado de Lima'),
(N'Lima', N'Lima', N'Miraflores'),
(N'Lima', N'Lima', N'San Isidro'),
(N'Lima', N'Lima', N'Santiago de Surco'),
(N'Lima', N'Lima', N'La Molina'),
(N'Lima', N'Lima', N'San Borja'),
(N'Lima', N'Lima', N'Barranco'),
(N'Lima', N'Lima', N'Jesús María'),
(N'Lima', N'Lima', N'Lince'),
(N'Lima', N'Lima', N'Magdalena del Mar'),
(N'Lima', N'Lima', N'Pueblo Libre'),
(N'Lima', N'Lima', N'San Miguel'),
(N'Lima', N'Lima', N'Surquillo'),
(N'Lima', N'Lima', N'Chorrillos'),
(N'Lima', N'Lima', N'Los Olivos'),
(N'Lima', N'Lima', N'Ate'),
(N'Callao', N'Callao', N'Callao'),
(N'Arequipa', N'Arequipa', N'Arequipa'),
(N'Cusco', N'Cusco', N'Cusco'),
(N'La Libertad', N'Trujillo', N'Trujillo');
GO

INSERT INTO cargos (nombre_cargo, descripcion_cargo, salario_base) VALUES
(N'Administrador General', N'Responsable de la gestión general del restaurante', 4500.00),
(N'Gerente de Turno', N'Supervisa las operaciones durante su turno', 3200.00),
(N'Chef Ejecutivo', N'Encargado de la cocina y creación de menús', 3800.00),
(N'Sous Chef', N'Asistente directo del chef ejecutivo', 3000.00),
(N'Chef Pastelero', N'Encargado de postres y repostería', 2800.00),
(N'Jefe de Cocina Fría', N'Responsable de entradas y ensaladas', 2500.00),
(N'Parrillero', N'Encargado de la parrilla y carnes', 2400.00),
(N'Cocinero', N'Preparación de platos del menú', 2200.00),
(N'Ayudante de Cocina', N'Apoyo en preparación de alimentos', 1500.00),
(N'Steward', N'Encargado de limpieza de cocina y utensilios', 1300.00),
(N'Mesero', N'Atención directa a comensales', 1600.00),
(N'Mesero Senior', N'Mesero con mayor experiencia y responsabilidades', 1900.00),
(N'Anfitrión', N'Recibe y ubica a los comensales', 1700.00),
(N'Recepcionista', N'Gestiona el ingreso y reservas en el local', 1700.00),
(N'Bartender', N'Preparación de bebidas y cócteles', 2000.00),
(N'Barista', N'Preparación de café y bebidas calientes', 1700.00),
(N'Sommelier', N'Experto en maridaje de vinos', 2600.00),
(N'Supervisor de Salón', N'Supervisa el servicio en el salón', 2300.00),
(N'Encargado de Reservas', N'Gestiona la agenda de reservas', 1900.00),
(N'Personal de Limpieza', N'Mantenimiento y limpieza general', 1300.00);
GO

INSERT INTO zonas (nombre_zona, descripcion) VALUES
(N'Salón Principal', N'Área central climatizada del restaurante'),
(N'Terraza Norte', N'Terraza al aire libre con vista al jardín'),
(N'Terraza Sur', N'Terraza al aire libre con vista a la calle'),
(N'Salón VIP', N'Espacio exclusivo para eventos privados'),
(N'Barra Central', N'Zona de barra con asientos altos'),
(N'Zona Familiar', N'Espacio amplio ideal para familias'),
(N'Jardín Interior', N'Área verde dentro del local'),
(N'Salón de Eventos', N'Espacio para banquetes y celebraciones'),
(N'Balcón Vista Ciudad', N'Balcón con vista panorámica'),
(N'Comedor Privado 1', N'Sala privada para reuniones'),
(N'Comedor Privado 2', N'Sala privada para reuniones pequeñas'),
(N'Zona de Bar', N'Área cercana a la barra de tragos'),
(N'Salón Ejecutivo', N'Espacio para almuerzos de negocios'),
(N'Terraza Techada', N'Terraza cubierta para todo clima'),
(N'Zona Lounge', N'Espacio de estilo lounge con sofás'),
(N'Salón de Banquetes', N'Salón amplio para grandes grupos'),
(N'Área Acústica', N'Zona con música en vivo los fines de semana'),
(N'Zona Mirador', N'Espacio elevado con vista panorámica'),
(N'Patio Central', N'Patio interno decorado'),
(N'Sala de Degustación', N'Espacio para catas y eventos especiales');
GO

INSERT INTO turnos (nombre_turno, hora_inicio_turno, hora_fin_turno) VALUES
(N'Desayuno Entre Semana', '07:00', '10:00'),
(N'Desayuno Fin de Semana', '07:30', '11:00'),
(N'Brunch Sábado', '10:00', '13:00'),
(N'Brunch Domingo', '10:00', '13:00'),
(N'Almuerzo Entre Semana', '12:00', '15:30'),
(N'Almuerzo Fin de Semana', '12:30', '16:00'),
(N'Media Tarde', '15:30', '18:00'),
(N'Happy Hour', '17:00', '19:00'),
(N'Cena Entre Semana', '19:00', '23:00'),
(N'Cena Viernes', '19:00', '23:30'),
(N'Cena Sábado', '19:00', '23:59'),
(N'Cena Domingo', '18:30', '22:30'),
(N'Turno Nocturno Extendido', '23:00', '01:00'),
(N'Turno Corporativo', '12:00', '14:30'),
(N'Turno Familiar Domingo', '13:00', '16:00'),
(N'Turno de Eventos Privados', '18:00', '23:00'),
(N'Turno de Banquetes', '12:00', '17:00'),
(N'Café de la Tarde', '15:00', '17:30'),
(N'Turno de Cierre', '22:00', '00:30'),
(N'Turno Especial Feriados', '11:00', '22:00');
GO

INSERT INTO estados_reserva (nombre_estado, descripcion) VALUES
(N'Pendiente', N'La reserva fue creada pero no ha sido confirmada'),
(N'Confirmada', N'La reserva ha sido confirmada por el restaurante'),
(N'En Espera', N'El comensal está en lista de espera por disponibilidad'),
(N'Reprogramada', N'La reserva fue movida a otra fecha u hora'),
(N'Completada', N'El servicio de la reserva fue brindado con éxito'),
(N'Cancelada', N'La reserva fue cancelada por el solicitante'),
(N'Cancelada por el Restaurante', N'El restaurante canceló la reserva'),
(N'No Show', N'El comensal no se presentó a la reserva'),
(N'En Proceso', N'La mesa está siendo preparada para la reserva'),
(N'Rechazada', N'La solicitud de reserva fue rechazada'),
(N'Vencida', N'La reserva no fue confirmada a tiempo'),
(N'Modificada', N'Se realizaron cambios en los datos de la reserva'),
(N'Bloqueada', N'La mesa fue bloqueada temporalmente para la reserva'),
(N'Pre-Reserva', N'Reserva preliminar sujeta a confirmación'),
(N'Reserva VIP Confirmada', N'Reserva especial confirmada para comensal VIP'),
(N'Reserva Grupal Pendiente', N'Reserva de grupo grande en validación'),
(N'Reserva Corporativa Confirmada', N'Reserva confirmada para evento empresarial'),
(N'Reserva de Evento Confirmada', N'Reserva confirmada para evento especial'),
(N'Anulada por el Solicitante', N'El solicitante anuló la reserva antes de confirmarla'),
(N'Reserva Especial Confirmada', N'Reserva confirmada con requerimientos especiales');
GO

INSERT INTO categorias (nombre_categoria, descripcion) VALUES
(N'Entradas', N'Platos para iniciar la comida'),
(N'Sopas', N'Sopas y cremas calientes'),
(N'Ensaladas', N'Preparaciones frías con vegetales'),
(N'Platos Fuertes', N'Platos principales del menú'),
(N'Carnes', N'Preparaciones a base de carnes rojas'),
(N'Pescados y Mariscos', N'Preparaciones a base de productos marinos'),
(N'Pastas', N'Preparaciones a base de pasta'),
(N'Arroces', N'Preparaciones a base de arroz'),
(N'Postres', N'Opciones dulces para cerrar la comida'),
(N'Bebidas Frías', N'Bebidas refrescantes sin alcohol'),
(N'Bebidas Calientes', N'Café, té e infusiones'),
(N'Bebidas sin Alcohol', N'Opciones no alcohólicas variadas'),
(N'Coctelería', N'Bebidas preparadas con licor'),
(N'Vinos', N'Selección de vinos de la casa'),
(N'Cervezas Artesanales', N'Selección de cervezas artesanales'),
(N'Menú Infantil', N'Opciones especiales para niños'),
(N'Guarniciones', N'Acompañamientos para platos principales'),
(N'Panadería y Repostería', N'Panes y productos horneados'),
(N'Aperitivos', N'Opciones para compartir'),
(N'Especialidades de la Casa', N'Platos exclusivos e insignia del restaurante');
GO

INSERT INTO clientes (nombres, apellidos, telefono, correo, fecha_nacimiento, sexo) VALUES
(N'Rosa Elena', N'Bautista', '987001122', N'rosa.bautista@gmail.com', '1988-03-14', 'F'),
(N'Luis Fernando', N'Alva', '987002233', N'luis.alva@gmail.com', '1985-07-22', 'M'),
(N'Carmen Rosa', N'Díaz', '987003344', N'carmen.diaz@gmail.com', '1979-11-05', 'F'),
(N'Jorge Luis', N'Pardo', '987004455', N'jorge.pardo@gmail.com', '1990-01-30', 'M'),
(N'María José', N'Rivas', '987005566', N'maria.rivas@gmail.com', '1993-09-18', 'F'),
(N'Pedro Antonio', N'Ruiz', '987006677', N'pedro.ruiz@gmail.com', '1982-06-09', 'M'),
(N'Lucía Fernanda', N'Soto', '987007788', N'lucia.soto@gmail.com', '1995-12-02', 'F'),
(N'Andrés Felipe', N'Cruz', '987008899', N'andres.cruz@gmail.com', '1987-04-27', 'M'),
(N'Rosa María', N'Guevara', '987009900', N'rosa.guevara@gmail.com', '1976-08-16', 'F'),
(N'Diego Armando', N'León', '987010011', N'diego.leon@gmail.com', '1991-02-11', 'M'),
(N'Valeria Nicole', N'Paz', '987011122', N'valeria.paz@gmail.com', '1998-10-25', 'F'),
(N'Ricardo José', N'Vidal', '987012233', N'ricardo.vidal@gmail.com', '1984-05-07', 'M'),
(N'Gabriela Alexandra', N'Ríos', '987013344', N'gabriela.rios@gmail.com', '1992-03-21', 'F'),
(N'Sebastián Andrés', N'Cano', '987014455', N'sebastian.cano@gmail.com', '1989-09-03', 'M'),
(N'Camila Sofía', N'Mendoza', '987015566', N'camila.mendoza@gmail.com', '1996-01-19', 'F'),
(N'Alonso Rafael', N'Bravo', '987016677', N'alonso.bravo@gmail.com', '1983-12-12', 'M'),
(N'Daniela Isabel', N'Prado', '987017788', N'daniela.prado@gmail.com', '1994-07-08', 'F'),
(N'Javier Eduardo', N'Nolasco', '987018899', N'javier.nolasco@gmail.com', '1980-10-31', 'M'),
(N'Sofía Valentina', N'Chumpitaz', '987019900', N'sofia.chumpitaz@gmail.com', '1999-04-15', 'F'),
(N'Fabricio Alonso', N'Terán', '987020011', N'fabricio.teran@gmail.com', '1986-11-28', 'M');
GO

INSERT INTO empleados (nombres, apellidos, dni, telefono, email, fecha_contratacion, cargo_id, sexo, fecha_nacimiento, direccion, ubigeo_id, estado) VALUES
(N'Carlos', N'Ramírez Soto', '45678912', '987654321', 'carlos.ramirez@restaurante.com', '2021-03-15', 1, 'M', '1980-04-12', N'Av. Arequipa 1520', 2, 1),
(N'María', N'Fernández López', '44567823', '987654322', 'maria.fernandez@restaurante.com', '2021-05-10', 2, 'F', '1985-09-03', N'Calle Los Pinos 245', 3, 1),
(N'Jorge', N'Salazar Quispe', '43678234', '987654323', 'jorge.salazar@restaurante.com', '2020-01-20', 3, 'M', '1978-11-21', N'Jr. Cusco 780', 1, 1),
(N'Lucía', N'Torres Mendoza', '42789345', '987654324', 'lucia.torres@restaurante.com', '2020-06-01', 4, 'F', '1990-02-14', N'Av. Primavera 1050', 4, 1),
(N'Andrés', N'Vargas Rojas', '41890456', '987654325', 'andres.vargas@restaurante.com', '2022-02-14', 5, 'M', '1992-07-30', N'Calle Las Flores 132', 5, 1),
(N'Patricia', N'Chávez Díaz', '40901567', '987654326', 'patricia.chavez@restaurante.com', '2021-08-23', 6, 'F', '1987-05-18', N'Av. Javier Prado 2200', 6, 1),
(N'Miguel Ángel', N'Rosales', '40012678', '987654327', 'miguel.rosales@restaurante.com', '2019-11-05', 7, 'M', '1983-12-09', N'Jr. Domeyer 310', 7, 1),
(N'Rosa Elena', N'Huamán', '39123789', '987654328', 'rosa.huaman@restaurante.com', '2022-07-19', 8, 'F', '1995-03-27', N'Av. Brasil 1890', 8, 1),
(N'Fernando', N'Castillo Peña', '38234890', '987654329', 'fernando.castillo@restaurante.com', '2023-01-10', 9, 'M', '1998-08-15', N'Calle Las Begonias 415', 3, 1),
(N'Karina', N'Ibáñez Ríos', '37345901', '987654330', 'karina.ibanez@restaurante.com', '2022-09-02', 10, 'F', '1993-10-06', N'Av. Petit Thouars 960', 9, 1),
(N'Diego', N'Alonso Paredes', '36456012', '987654331', 'diego.paredes@restaurante.com', '2021-04-18', 11, 'M', '1991-01-25', N'Av. La Marina 2310', 12, 1),
(N'Valeria', N'Nuñez Campos', '35567123', '987654332', 'valeria.nunez@restaurante.com', '2020-10-30', 12, 'F', '1989-06-11', N'Jr. Junín 560', 11, 1),
(N'Ricardo', N'Espinoza Luna', '34678234', '987654333', 'ricardo.espinoza@restaurante.com', '2023-03-25', 13, 'M', '1996-04-02', N'Av. Angamos 1475', 13, 1),
(N'Gabriela', N'Flores Medina', '33789345', '987654334', 'gabriela.flores@restaurante.com', '2022-12-01', 14, 'F', '1994-09-19', N'Av. Huaylas 830', 14, 1),
(N'Sebastián', N'Morales Vega', '32890456', '987654335', 'sebastian.morales@restaurante.com', '2021-01-15', 15, 'M', '1990-12-30', N'Av. Universitaria 1620', 15, 1),
(N'Camila', N'Herrera Silva', '31901567', '987654336', 'camila.herrera@restaurante.com', '2023-05-20', 16, 'F', '1997-05-08', N'Av. Nicolás Ayllón 3400', 16, 1),
(N'Alonso', N'Guzmán Reyes', '30012678', '987654337', 'alonso.guzman@restaurante.com', '2020-08-12', 17, 'M', '1986-03-16', N'Av. Sáenz Peña 725', 17, 1),
(N'Daniela', N'Cárdenas Ortiz', '29123789', '987654338', 'daniela.cardenas@restaurante.com', '2019-06-07', 18, 'F', '1984-11-04', N'Calle Mercaderes 340', 18, 1),
(N'Javier', N'Ponce Aguilar', '28234890', '987654339', 'javier.ponce@restaurante.com', '2022-04-28', 19, 'M', '1988-07-22', N'Av. El Sol 612', 19, 0),
(N'Sofía', N'Romero Tapia', '27345901', '987654340', 'sofia.romero@restaurante.com', '2023-08-14', 20, 'F', '1999-02-10', N'Jr. Pizarro 455', 20, 1);
GO

INSERT INTO mesas (numero_mesa, capacidad, zona_id, estado_mesa) VALUES
(1, 4, 1, 'Disponible'),
(2, 4, 1, 'Disponible'),
(3, 2, 2, 'Disponible'),
(4, 6, 2, 'Reservada'),
(5, 2, 3, 'Disponible'),
(6, 6, 3, 'Disponible'),
(7, 8, 4, 'Reservada'),
(8, 4, 4, 'Disponible'),
(9, 2, 5, 'Disponible'),
(10, 4, 6, 'Disponible'),
(11, 8, 6, 'Mantenimiento'),
(12, 4, 7, 'Disponible'),
(13, 10, 8, 'Disponible'),
(14, 2, 9, 'Disponible'),
(15, 6, 10, 'Reservada'),
(16, 4, 11, 'Disponible'),
(17, 6, 12, 'Disponible'),
(18, 4, 13, 'Disponible'),
(19, 2, 14, 'Disponible'),
(20, 8, 15, 'Disponible');
GO

INSERT INTO platos (nombre_plato, descripcion, categoria_id, tiempo_preparacion_minutos, disponible, precio_referencial) VALUES
(N'Causa Limeña', N'Entrada tradicional a base de papa amarilla y ají', 1, 15, 1, 18.00),
(N'Crema de Zapallo', N'Sopa cremosa de zapallo con especias', 2, 20, 1, 16.00),
(N'Ensalada Mediterránea', N'Mix de vegetales frescos con queso feta', 3, 10, 1, 20.00),
(N'Lomo Saltado', N'Plato fuerte a base de carne salteada con papas', 4, 25, 1, 32.00),
(N'Ají de Gallina', N'Plato tradicional peruano a base de pollo', 4, 25, 1, 28.00),
(N'Bife a la Parrilla', N'Corte de carne a la parrilla con guarnición', 5, 30, 1, 45.00),
(N'Ceviche Mixto', N'Pescado y mariscos frescos marinados en limón', 6, 20, 1, 38.00),
(N'Tallarines Verdes', N'Pasta con salsa de albahaca y queso', 7, 20, 1, 26.00),
(N'Arroz con Mariscos', N'Arroz al estilo criollo con mariscos', 8, 30, 1, 36.00),
(N'Suspiro a la Limeña', N'Postre tradicional a base de manjar blanco', 9, 15, 1, 14.00),
(N'Limonada Frozen', N'Bebida fría a base de limón', 10, 5, 1, 10.00),
(N'Café Americano', N'Bebida caliente preparada con café filtrado', 11, 5, 1, 8.00),
(N'Agua Mineral', N'Agua sin gas embotellada', 12, 2, 1, 6.00),
(N'Pisco Sour', N'Coctel tradicional peruano a base de pisco', 13, 8, 1, 22.00),
(N'Copa de Vino Tinto', N'Copa de vino tinto de la casa', 14, 3, 1, 24.00),
(N'Cerveza Artesanal IPA', N'Cerveza artesanal tipo IPA', 15, 3, 1, 18.00),
(N'Nuggets de Pollo Infantil', N'Plato infantil con nuggets y papas', 16, 15, 1, 16.00),
(N'Papas al Hilo', N'Guarnición de papas fritas finas', 17, 10, 1, 12.00),
(N'Pan Artesanal de la Casa', N'Pan horneado diariamente en casa', 18, 5, 1, 8.00),
(N'Tabla de Piqueos', N'Aperitivo variado para compartir', 19, 15, 1, 40.00);
GO

INSERT INTO reservas (cliente_id, fecha_reserva, hora_reserva, numero_personas, mesa_id, turno_id, estado_id, empleado_id, observaciones) VALUES
(1, '2026-09-15', '13:00', 4, 1, 5, 5, 14, N'Cliente frecuente'),
(2, '2026-09-16', '20:00', 2, 3, 9, 8, 19, N'No llegó a la hora indicada'),
(1, '2026-09-18', '12:30', 6, 13, 5, 5, 14, N'Celebración de cumpleaños'),
(3, '2026-09-19', '20:00', 8, 20, 16, 6, 19, N'Cancelada por cambio de planes'),
(4, '2026-09-21', '10:30', 3, 14, 2, 2, 14, NULL),
(5, '2026-09-21', '19:00', 2, 9, 9, 1, 19, N'Pendiente de confirmar asistencia'),
(1, '2026-09-22', '13:30', 5, 6, 5, 3, 14, N'En lista de espera por mesa preferida'),
(2, '2026-09-22', '21:00', 4, 17, 11, 2, 19, N'Aniversario de bodas'),
(6, '2026-09-23', '12:00', 10, 13, 14, 17, 14, N'Almuerzo corporativo'),
(4, '2026-09-23', '19:30', 2, 5, 9, 1, 19, NULL),
(1, '2026-09-24', '13:00', 4, 8, 5, 2, 14, NULL),
(7, '2026-09-24', '20:30', 6, 20, 16, 18, 19, N'Reserva de evento especial'),
(8, '2026-09-25', '10:00', 4, 14, 2, 4, 14, N'Cambio de horario solicitado'),
(3, '2026-09-19', '19:00', 2, 9, 9, 8, 19, N'Cliente no se presentó'),
(9, '2026-09-26', '12:30', 8, 13, 5, 2, 14, NULL),
(10, '2026-09-17', '20:00', 2, 3, 9, 6, 19, N'Reserva cancelada por el cliente'),
(1, '2026-09-27', '13:00', 5, 6, 5, 1, 14, NULL),
(6, '2026-09-27', '19:30', 4, 1, 9, 2, 19, NULL),
(2, '2026-09-28', '12:00', 3, 5, 2, 3, 14, NULL),
(11, '2026-09-30', '21:00', 12, 20, 16, 15, 19, N'Reserva VIP para evento empresarial');
GO

INSERT INTO pedidos (fecha_pedido, reserva_id) VALUES
('2026-09-15 13:10', 1),
('2026-09-15 14:00', 1),
('2026-09-18 12:45', 3),
('2026-09-18 13:30', 3),
('2026-09-21 10:45', 5),
('2026-09-21 19:15', 6),
('2026-09-22 13:45', 7),
('2026-09-22 21:15', 8),
('2026-09-23 12:15', 9),
('2026-09-23 13:00', 9),
('2026-09-23 19:45', 10),
('2026-09-24 13:15', 11),
('2026-09-24 20:45', 12),
('2026-09-25 10:15', 13),
('2026-09-26 12:45', 15),
('2026-09-27 13:15', 17),
('2026-09-27 19:45', 18),
('2026-09-28 12:15', 19),
('2026-09-30 21:15', 20),
('2026-09-30 22:30', 20);
GO

INSERT INTO detalle_pedido (pedido_id, plato_id, cantidad) VALUES
(1, 1, 2),
(1, 4, 2),
(2, 11, 2),
(3, 6, 3),
(3, 7, 2),
(4, 14, 4),
(5, 12, 2),
(5, 19, 1),
(6, 5, 2),
(7, 8, 3),
(8, 15, 2),
(8, 3, 1),
(9, 9, 4),
(9, 10, 4),
(10, 2, 2),
(10, 13, 2),
(11, 16, 3),
(12, 4, 2),
(13, 14, 2),
(13, 18, 1),
(14, 12, 2),
(15, 20, 3),
(15, 15, 3),
(16, 7, 2),
(17, 1, 2),
(17, 6, 2),
(18, 9, 3),
(19, 20, 4),
(19, 14, 6),
(20, 10, 6),
(20, 12, 6);
GO

CREATE VIEW vw_zonas_capacidad
AS
SELECT
    z.zona_id,
    z.nombre_zona,
    z.descripcion,
    COUNT(m.mesa_id) AS total_mesas,
    ISNULL(SUM(m.capacidad), 0) AS capacidad_total
FROM zonas z
LEFT JOIN mesas m ON m.zona_id = z.zona_id AND m.estado = 1
WHERE z.estado = 1
GROUP BY z.zona_id, z.nombre_zona, z.descripcion;
GO

CREATE VIEW vw_reservas_detalle
AS
SELECT
    r.reserva_id,
    r.fecha_reserva,
    r.hora_reserva,
    r.numero_personas,
    c.cliente_id,
    c.nombres + ' ' + c.apellidos AS cliente,
    c.telefono AS telefono_cliente,
    c.correo AS correo_cliente,
    c.categoria_cliente,
    m.numero_mesa,
    z.nombre_zona,
    t.nombre_turno,
    es.nombre_estado,
    e.nombres + ' ' + e.apellidos AS registrado_por,
    r.observaciones
FROM reservas r
INNER JOIN clientes c ON r.cliente_id = c.cliente_id
INNER JOIN mesas m ON r.mesa_id = m.mesa_id
INNER JOIN zonas z ON m.zona_id = z.zona_id
INNER JOIN turnos t ON r.turno_id = t.turno_id
INNER JOIN estados_reserva es ON r.estado_id = es.estado_id
INNER JOIN empleados e ON r.empleado_id = e.empleado_id
WHERE r.estado = 1;
GO

CREATE VIEW vw_empleados_detalle
AS
SELECT
    e.empleado_id,
    e.nombres,
    e.apellidos,
    e.dni,
    e.sexo,
    e.fecha_nacimiento,
    DATEDIFF(YEAR, e.fecha_nacimiento, GETDATE()) AS edad,
    e.telefono,
    e.email,
    e.direccion,
    u.departamento,
    u.provincia,
    u.distrito,
    c.nombre_cargo,
    c.salario_base,
    e.fecha_contratacion
FROM empleados e
INNER JOIN cargos c ON e.cargo_id = c.cargo_id
INNER JOIN ubigeo u ON e.ubigeo_id = u.ubigeo_id
WHERE e.estado = 1;
GO

CREATE VIEW vw_clientes_resumen
AS
SELECT
    c.cliente_id,
    c.nombres,
    c.apellidos,
    c.telefono,
    c.correo,
    c.fecha_nacimiento,
    c.sexo,
    c.categoria_cliente,
    COUNT(r.reserva_id) AS total_reservas
FROM clientes c
LEFT JOIN reservas r ON r.cliente_id = c.cliente_id AND r.estado = 1
WHERE c.estado = 1
GROUP BY c.cliente_id, c.nombres, c.apellidos, c.telefono, c.correo, c.fecha_nacimiento, c.sexo, c.categoria_cliente;
GO

CREATE VIEW vw_pedidos_detalle
AS
SELECT
    p.pedido_id,
    p.fecha_pedido,
    r.reserva_id,
    c.nombres + ' ' + c.apellidos AS cliente,
    pl.nombre_plato,
    ca.nombre_categoria,
    d.cantidad,
    pl.precio_referencial,
    d.cantidad * pl.precio_referencial AS subtotal_referencial
FROM pedidos p
INNER JOIN reservas r ON p.reserva_id = r.reserva_id
INNER JOIN clientes c ON r.cliente_id = c.cliente_id
INNER JOIN detalle_pedido d ON d.pedido_id = p.pedido_id
INNER JOIN platos pl ON d.plato_id = pl.plato_id
INNER JOIN categorias ca ON pl.categoria_id = ca.categoria_id
WHERE p.estado = 1;
GO

CREATE VIEW vw_menu_platos
AS
SELECT
    pl.plato_id,
    pl.nombre_plato,
    pl.descripcion,
    ca.nombre_categoria,
    pl.tiempo_preparacion_minutos,
    pl.precio_referencial,
    pl.disponible,
    pl.foto
FROM platos pl
INNER JOIN categorias ca ON pl.categoria_id = ca.categoria_id
WHERE pl.estado = 1;
GO

CREATE PROCEDURE usp_actualizar_categoria_cliente
    @cliente_id INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE c
    SET categoria_cliente = CASE
            WHEN x.total >= 6 THEN 'VIP'
            WHEN x.total >= 4 THEN 'Frecuente'
            WHEN x.total >= 2 THEN 'Regular'
            ELSE 'Nuevo'
        END
    FROM clientes c
    OUTER APPLY (
        SELECT COUNT(*) AS total
        FROM reservas r
        WHERE r.cliente_id = c.cliente_id AND r.estado = 1
    ) x
    WHERE @cliente_id IS NULL OR c.cliente_id = @cliente_id;
END
GO

CREATE PROCEDURE usp_insertar_cliente
    @nombres NVARCHAR(50),
    @apellidos NVARCHAR(50),
    @telefono VARCHAR(15) = NULL,
    @correo NVARCHAR(100),
    @fecha_nacimiento DATE,
    @sexo CHAR(1),
    @usuario NVARCHAR(50),
    @nuevo_cliente_id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM clientes WHERE correo = @correo)
        THROW 50001, N'Ya existe un cliente registrado con ese correo.', 1;

    INSERT INTO clientes
        (nombres, apellidos, telefono, correo, fecha_nacimiento, sexo, usuario_creacion)
    VALUES
        (@nombres, @apellidos, @telefono, @correo, @fecha_nacimiento, @sexo, @usuario);

    SET @nuevo_cliente_id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE usp_actualizar_cliente
    @cliente_id INT,
    @nombres NVARCHAR(50),
    @apellidos NVARCHAR(50),
    @telefono VARCHAR(15) = NULL,
    @correo NVARCHAR(100),
    @fecha_nacimiento DATE,
    @sexo CHAR(1),
    @usuario NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clientes WHERE cliente_id = @cliente_id AND estado = 1)
        THROW 50002, N'El cliente indicado no existe.', 1;

    IF EXISTS (SELECT 1 FROM clientes WHERE correo = @correo AND cliente_id <> @cliente_id)
        THROW 50001, N'Ya existe otro cliente registrado con ese correo.', 1;

    UPDATE clientes
    SET nombres = @nombres,
        apellidos = @apellidos,
        telefono = @telefono,
        correo = @correo,
        fecha_nacimiento = @fecha_nacimiento,
        sexo = @sexo,
        fecha_ult_modificacion = GETDATE(),
        usuario_ult_modificacion = @usuario
    WHERE cliente_id = @cliente_id;
END
GO

CREATE PROCEDURE usp_eliminar_cliente
    @cliente_id INT,
    @usuario NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM clientes WHERE cliente_id = @cliente_id AND estado = 1)
        THROW 50002, N'El cliente indicado no existe.', 1;

    UPDATE clientes
    SET estado = 0,
        fecha_ult_modificacion = GETDATE(),
        usuario_ult_modificacion = @usuario
    WHERE cliente_id = @cliente_id;
END
GO

CREATE PROCEDURE usp_consultar_clientes
    @cliente_id INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        cliente_id,
        nombres,
        apellidos,
        telefono,
        correo,
        fecha_nacimiento,
        sexo,
        categoria_cliente
    FROM clientes
    WHERE estado = 1
      AND (@cliente_id IS NULL OR cliente_id = @cliente_id)
    ORDER BY apellidos, nombres;
END
GO

CREATE PROCEDURE usp_insertar_empleado
    @nombres NVARCHAR(50),
    @apellidos NVARCHAR(50),
    @dni CHAR(8),
    @telefono VARCHAR(15) = NULL,
    @email NVARCHAR(100) = NULL,
    @fecha_contratacion DATE,
    @cargo_id INT,
    @foto VARBINARY(MAX) = NULL,
    @sexo CHAR(1),
    @fecha_nacimiento DATE,
    @direccion NVARCHAR(150),
    @ubigeo_id INT,
    @usuario NVARCHAR(50),
    @nuevo_empleado_id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM empleados WHERE dni = @dni)
        THROW 50003, N'Ya existe un empleado registrado con ese DNI.', 1;

    INSERT INTO empleados
        (nombres, apellidos, dni, telefono, email, fecha_contratacion, cargo_id,
         foto, sexo, fecha_nacimiento, direccion, ubigeo_id, usuario_creacion)
    VALUES
        (@nombres, @apellidos, @dni, @telefono, @email, @fecha_contratacion, @cargo_id,
         @foto, @sexo, @fecha_nacimiento, @direccion, @ubigeo_id, @usuario);

    SET @nuevo_empleado_id = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE usp_actualizar_empleado
    @empleado_id INT,
    @nombres NVARCHAR(50),
    @apellidos NVARCHAR(50),
    @dni CHAR(8),
    @telefono VARCHAR(15) = NULL,
    @email NVARCHAR(100) = NULL,
    @fecha_contratacion DATE,
    @cargo_id INT,
    @foto VARBINARY(MAX) = NULL,
    @sexo CHAR(1),
    @fecha_nacimiento DATE,
    @direccion NVARCHAR(150),
    @ubigeo_id INT,
    @usuario NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM empleados WHERE empleado_id = @empleado_id AND estado = 1)
        THROW 50004, N'El empleado indicado no existe.', 1;

    IF EXISTS (SELECT 1 FROM empleados WHERE dni = @dni AND empleado_id <> @empleado_id)
        THROW 50003, N'Ya existe otro empleado registrado con ese DNI.', 1;

    UPDATE empleados
    SET nombres = @nombres,
        apellidos = @apellidos,
        dni = @dni,
        telefono = @telefono,
        email = @email,
        fecha_contratacion = @fecha_contratacion,
        cargo_id = @cargo_id,
        foto = ISNULL(@foto, foto),
        sexo = @sexo,
        fecha_nacimiento = @fecha_nacimiento,
        direccion = @direccion,
        ubigeo_id = @ubigeo_id,
        fecha_ult_modificacion = GETDATE(),
        usuario_ult_modificacion = @usuario
    WHERE empleado_id = @empleado_id;
END
GO

CREATE PROCEDURE usp_eliminar_empleado
    @empleado_id INT,
    @usuario NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM empleados WHERE empleado_id = @empleado_id AND estado = 1)
        THROW 50004, N'El empleado indicado no existe.', 1;

    UPDATE empleados
    SET estado = 0,
        fecha_ult_modificacion = GETDATE(),
        usuario_ult_modificacion = @usuario
    WHERE empleado_id = @empleado_id;
END
GO

CREATE PROCEDURE usp_consultar_empleados
    @empleado_id INT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        e.empleado_id,
        e.nombres,
        e.apellidos,
        e.dni,
        e.telefono,
        e.email,
        e.fecha_contratacion,
        c.nombre_cargo,
        e.foto,
        e.sexo,
        e.fecha_nacimiento,
        e.direccion,
        u.departamento,
        u.provincia,
        u.distrito
    FROM empleados e
    INNER JOIN cargos c ON e.cargo_id = c.cargo_id
    INNER JOIN ubigeo u ON e.ubigeo_id = u.ubigeo_id
    WHERE e.estado = 1
      AND (@empleado_id IS NULL OR e.empleado_id = @empleado_id)
    ORDER BY e.apellidos, e.nombres;
END
GO

CREATE PROCEDURE usp_insertar_reserva
    @cliente_id INT,
    @fecha_reserva DATE,
    @hora_reserva TIME,
    @numero_personas INT,
    @mesa_id INT,
    @turno_id INT,
    @estado_id INT,
    @empleado_id INT,
    @observaciones NVARCHAR(300) = NULL,
    @usuario NVARCHAR(50),
    @nueva_reserva_id INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        IF NOT EXISTS (SELECT 1 FROM clientes WHERE cliente_id = @cliente_id AND estado = 1)
            THROW 50002, N'El cliente indicado no existe.', 1;

        IF @estado_id NOT IN (6, 7, 8, 19)
           AND EXISTS (
                SELECT 1
                FROM reservas WITH (UPDLOCK, HOLDLOCK)
                WHERE mesa_id = @mesa_id
                  AND fecha_reserva = @fecha_reserva
                  AND hora_reserva = @hora_reserva
                  AND estado = 1
                  AND estado_id NOT IN (6, 7, 8, 19)
           )
            THROW 50010, N'La mesa ya está reservada por otro cliente para esa fecha y hora.', 1;

        INSERT INTO reservas
            (cliente_id, fecha_reserva, hora_reserva, numero_personas, mesa_id,
             turno_id, estado_id, empleado_id, observaciones, usuario_creacion)
        VALUES
            (@cliente_id, @fecha_reserva, @hora_reserva, @numero_personas, @mesa_id,
             @turno_id, @estado_id, @empleado_id, @observaciones, @usuario);

        SET @nueva_reserva_id = SCOPE_IDENTITY();

        COMMIT TRANSACTION;

        EXEC usp_actualizar_categoria_cliente @cliente_id = @cliente_id;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE usp_actualizar_reserva
    @reserva_id INT,
    @cliente_id INT,
    @fecha_reserva DATE,
    @hora_reserva TIME,
    @numero_personas INT,
    @mesa_id INT,
    @turno_id INT,
    @estado_id INT,
    @empleado_id INT,
    @observaciones NVARCHAR(300) = NULL,
    @usuario NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @cliente_anterior INT;

    BEGIN TRY
        BEGIN TRANSACTION;

        SELECT @cliente_anterior = cliente_id
        FROM reservas
        WHERE reserva_id = @reserva_id AND estado = 1;

        IF @cliente_anterior IS NULL
            THROW 50011, N'La reserva indicada no existe.', 1;

        IF NOT EXISTS (SELECT 1 FROM clientes WHERE cliente_id = @cliente_id AND estado = 1)
            THROW 50002, N'El cliente indicado no existe.', 1;

        IF @estado_id NOT IN (6, 7, 8, 19)
           AND EXISTS (
                SELECT 1
                FROM reservas WITH (UPDLOCK, HOLDLOCK)
                WHERE mesa_id = @mesa_id
                  AND fecha_reserva = @fecha_reserva
                  AND hora_reserva = @hora_reserva
                  AND estado = 1
                  AND estado_id NOT IN (6, 7, 8, 19)
                  AND reserva_id <> @reserva_id
           )
            THROW 50010, N'La mesa ya está reservada por otro cliente para esa fecha y hora.', 1;

        UPDATE reservas
        SET cliente_id = @cliente_id,
            fecha_reserva = @fecha_reserva,
            hora_reserva = @hora_reserva,
            numero_personas = @numero_personas,
            mesa_id = @mesa_id,
            turno_id = @turno_id,
            estado_id = @estado_id,
            empleado_id = @empleado_id,
            observaciones = @observaciones,
            fecha_ult_modificacion = GETDATE(),
            usuario_ult_modificacion = @usuario
        WHERE reserva_id = @reserva_id;

        COMMIT TRANSACTION;

        EXEC usp_actualizar_categoria_cliente @cliente_id = @cliente_id;
        EXEC usp_actualizar_categoria_cliente @cliente_id = @cliente_anterior;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

CREATE PROCEDURE usp_actualizar_estado_reserva
    @reserva_id INT,
    @nuevo_estado_id INT,
    @usuario NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM reservas WHERE reserva_id = @reserva_id AND estado = 1)
    BEGIN
        RAISERROR(N'La reserva indicada no existe.', 16, 1);
        RETURN;
    END

    UPDATE reservas
    SET estado_id = @nuevo_estado_id,
        fecha_ult_modificacion = GETDATE(),
        usuario_ult_modificacion = @usuario
    WHERE reserva_id = @reserva_id;
END
GO

CREATE PROCEDURE usp_eliminar_reserva
    @reserva_id INT,
    @usuario NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @cliente_id INT;

    SELECT @cliente_id = cliente_id
    FROM reservas
    WHERE reserva_id = @reserva_id AND estado = 1;

    IF @cliente_id IS NULL
    BEGIN
        RAISERROR(N'La reserva indicada no existe.', 16, 1);
        RETURN;
    END

    UPDATE reservas
    SET estado = 0,
        fecha_ult_modificacion = GETDATE(),
        usuario_ult_modificacion = @usuario
    WHERE reserva_id = @reserva_id;

    EXEC usp_actualizar_categoria_cliente @cliente_id = @cliente_id;
END
GO

CREATE PROCEDURE usp_obtener_reservas_por_fecha
    @fecha_reserva DATE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        r.reserva_id,
        c.nombres + ' ' + c.apellidos AS cliente,
        c.telefono AS telefono_cliente,
        r.hora_reserva,
        r.numero_personas,
        m.numero_mesa,
        z.nombre_zona,
        t.nombre_turno,
        e.nombre_estado,
        emp.nombres + ' ' + emp.apellidos AS registrado_por,
        r.observaciones
    FROM reservas r
    INNER JOIN clientes c ON r.cliente_id = c.cliente_id
    INNER JOIN mesas m ON r.mesa_id = m.mesa_id
    INNER JOIN zonas z ON m.zona_id = z.zona_id
    INNER JOIN turnos t ON r.turno_id = t.turno_id
    INNER JOIN estados_reserva e ON r.estado_id = e.estado_id
    INNER JOIN empleados emp ON r.empleado_id = emp.empleado_id
    WHERE r.fecha_reserva = @fecha_reserva
      AND r.estado = 1
    ORDER BY r.hora_reserva;
END
GO

CREATE PROCEDURE usp_obtener_mesas_disponibles
    @fecha_reserva DATE,
    @turno_id INT,
    @numero_personas INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        m.mesa_id,
        m.numero_mesa,
        m.capacidad,
        z.nombre_zona
    FROM mesas m
    INNER JOIN zonas z ON m.zona_id = z.zona_id
    WHERE m.capacidad >= @numero_personas
      AND m.estado = 1
      AND m.estado_mesa <> 'Mantenimiento'
      AND NOT EXISTS (
            SELECT 1
            FROM reservas r
            WHERE r.mesa_id = m.mesa_id
              AND r.fecha_reserva = @fecha_reserva
              AND r.turno_id = @turno_id
              AND r.estado = 1
              AND r.estado_id NOT IN (6, 7, 8, 19)
      )
    ORDER BY m.capacidad ASC;
END
GO

EXEC usp_actualizar_categoria_cliente;
GO
