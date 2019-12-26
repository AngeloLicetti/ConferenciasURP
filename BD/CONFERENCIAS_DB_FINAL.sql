/*CREA LA BASE DE DATOS [db_conferencias] Y SUS TABLAS*/
USE [master]
GO
DROP DATABASE IF EXISTS [db_conferencias]
GO
CREATE DATABASE [db_conferencias]
GO
USE [db_conferencias]
GO

CREATE TABLE [dbo].[EXPOSITOR](
	Dni CHAR(8) PRIMARY KEY NOT NULL,
	Nombres VARCHAR(30) NOT NULL,
	Apellidos VARCHAR(30) NOT NULL,
	Titulado BIT NOT NULL,
	Especialidad VARCHAR(60),
	Empresa VARCHAR(60)
)
GO

CREATE TABLE [dbo].[FACULTAD](
	Codigo CHAR(12) PRIMARY KEY,
	Nombre VARCHAR(60) NOT NULL,
)
GO

CREATE TABLE [dbo].[ESCUELA](
	Codigo CHAR(12) PRIMARY KEY,
	Nombre VARCHAR(60) NOT NULL,
	Codigo_Facultad CHAR(12) NOT NULL,
	FOREIGN KEY (Codigo_Facultad) REFERENCES FACULTAD(Codigo) ON DELETE CASCADE
)
GO

CREATE TABLE [dbo].[CONFERENCIA](
	Codigo INT NOT NULL PRIMARY KEY IDENTITY,
	Semestre CHAR(6) NOT NULL,
	Fecha_Inicio DATETIME NOT NULL,
	Fecha_Fin DATETIME NOT NULL,
	Lugar VARCHAR(60) NOT NULL,
	Tema VARCHAR(60) NOT NULL,
	Peso INT NOT NULL,
	Dni_Expositor CHAR(8),
	Codigo_Escuela CHAR(12),
	FOREIGN KEY (Dni_Expositor) REFERENCES EXPOSITOR(Dni) ON DELETE SET NULL,
	FOREIGN KEY (Codigo_Escuela) REFERENCES ESCUELA(Codigo) ON DELETE SET NULL
)
GO

CREATE TABLE [dbo].[ALUMNO](
	Codigo CHAR(9) PRIMARY KEY,
	Nombres VARCHAR(30) NOT NULL,
	Apellidos VARCHAR(30) NOT NULL,
	Codigo_Escuela CHAR(12),
	FOREIGN KEY (Codigo_Escuela) REFERENCES ESCUELA(Codigo) ON DELETE SET NULL
)
GO

CREATE TABLE [dbo].[ASISTENCIA](
	Codigo_Conferencia INT NOT NULL,
	Codigo_Alumno CHAR(9) NOT NULL,
	Hora_Entrada DATETIME NOT NULL,
	PRIMARY KEY(Codigo_Conferencia, Codigo_Alumno),
	FOREIGN KEY (Codigo_Conferencia) REFERENCES CONFERENCIA(Codigo) ON DELETE CASCADE,
	FOREIGN KEY (Codigo_Alumno) REFERENCES ALUMNO(Codigo) ON DELETE CASCADE
)
GO

CREATE TABLE [dbo].[USUARIO](
	Usuario VARCHAR(30) PRIMARY KEY,
	Contrasena VARCHAR(30) NOT NULL
)
GO

/*CREA STORED PROCEDURES PARA INSERTAR*/
CREATE PROCEDURE [sp_insertar_Expositor]
	@Dni CHAR(8),
	@Nombres VARCHAR(30),
	@Apellidos VARCHAR(30),
	@Titulado BIT,
	@Especialidad VARCHAR(60),
	@Empresa VARCHAR(60)
AS
BEGIN
	INSERT INTO EXPOSITOR(Dni, Nombres, Apellidos, Titulado, Especialidad, Empresa) VALUES(@Dni, @Nombres, @Apellidos, @Titulado, @Especialidad, @Empresa)
END
GO

CREATE PROCEDURE [sp_insertar_Facultad]
	@Codigo CHAR(12),
	@Nombre VARCHAR(60)
AS
BEGIN
	INSERT INTO FACULTAD(Codigo, Nombre) VALUES(@Codigo, @Nombre)
END
GO

CREATE PROCEDURE [sp_insertar_Escuela]
	@Codigo CHAR(12),
	@Nombre VARCHAR(60),
	@Codigo_Facultad CHAR(12)
AS
BEGIN
	INSERT INTO ESCUELA(Codigo, Nombre, Codigo_Facultad) VALUES(@Codigo, @Nombre, @Codigo_Facultad)
END
GO

CREATE PROCEDURE [sp_insertar_Conferencia]
	@Semestre CHAR(6),
	@Fecha_Inicio DATETIME,
	@Fecha_Fin DATETIME,
	@Lugar VARCHAR(60),
	@Tema VARCHAR(60),
	@Peso INT,
	@Dni_Expositor CHAR(8),
	@Codigo_Escuela CHAR(12)
AS
BEGIN
	INSERT INTO CONFERENCIA(Semestre, Fecha_Inicio, Fecha_Fin, Lugar, Tema, Peso, Dni_Expositor, Codigo_Escuela) VALUES(@Semestre, @Fecha_Inicio, @Fecha_Fin, @Lugar, @Tema, @Peso, @Dni_Expositor, @Codigo_Escuela)
END
GO

CREATE PROCEDURE [sp_insertar_Alumno]
	@Codigo CHAR(9),
	@Nombres VARCHAR(30),
	@Apellidos VARCHAR(30),
	@Codigo_Escuela CHAR(12)
AS
BEGIN
	INSERT INTO ALUMNO(Codigo, Nombres, Apellidos, Codigo_Escuela) VALUES(@Codigo, @Nombres, @Apellidos, @Codigo_Escuela)
END
GO

CREATE PROCEDURE [sp_insertar_Asistencia]
	@Codigo_Conferencia INT,
	@Codigo_Alumno CHAR(9),
	@Hora_Entrada DATETIME
AS
BEGIN
	INSERT INTO ASISTENCIA(Codigo_Conferencia, Codigo_Alumno, Hora_Entrada) VALUES(@Codigo_Conferencia, @Codigo_Alumno, @Hora_Entrada)
END
GO

CREATE PROCEDURE [sp_insertar_Usuario]
	@Usuario VARCHAR(30),
	@Contrasena VARCHAR(30)
AS
BEGIN
	INSERT INTO USUARIO(Usuario, Contrasena) VALUES(@Usuario, @Contrasena)
END
GO

/*CREA STORED PROCEDURES PARA ACTUALIZAR*/
CREATE PROCEDURE [sp_actuzalizar_Expositor]
	@Dni CHAR(8),
	@Nombres VARCHAR(30),
	@Apellidos VARCHAR(30),
	@Titulado BIT,
	@Especialidad VARCHAR(60),
	@Empresa VARCHAR(60)
AS
BEGIN
	UPDATE EXPOSITOR
	SET
		Nombres = @Nombres,
		Apellidos = @Apellidos,
		Titulado = @Titulado,
		Especialidad = @Especialidad,
		Empresa = @Empresa
	WHERE Dni = @Dni
END
GO

CREATE PROCEDURE [sp_actualizar_Facultad]
	@Codigo CHAR(12),
	@Nombre VARCHAR(60)
AS
BEGIN
	UPDATE FACULTAD
	SET
	Nombre = @Nombre
		
	WHERE Codigo = @Codigo
END
GO


CREATE PROCEDURE [sp_actualizar_Escuela]
	@Codigo CHAR(12),
	@Nombre VARCHAR(60),
	@Codigo_Facultad CHAR(12)
AS
BEGIN
	UPDATE ESCUELA
	SET Codigo_Facultad = @Codigo_Facultad,
	    Nombre = @Nombre
	    
	WHERE Codigo = @Codigo
END
GO

CREATE PROCEDURE [sp_actualizar_Conferencia]
	@Codigo INT,
	@Semestre CHAR(6),
	@Fecha_Inicio DATETIME,
	@Fecha_Fin DATETIME,
	@Lugar VARCHAR(60),
	@Tema VARCHAR(60),
	@Peso INT,
	@Dni_Expositor CHAR(8),
	@Codigo_Escuela CHAR(12)
AS
BEGIN
	UPDATE CONFERENCIA
		   
	SET Semestre = @Semestre,
	    Fecha_Inicio = @Fecha_Inicio,
		Fecha_Fin = @Fecha_Fin,
		Lugar = @Lugar,
		Tema = @Tema,
        Peso = @Peso,
		Dni_Expositor = @Dni_Expositor,
		Codigo_Escuela = @Codigo_Escuela
	
	WHERE Codigo = @Codigo
END
GO

CREATE PROCEDURE [sp_actualizar_Alumno]
	@Codigo CHAR(9),
	@Nombres VARCHAR(30),
	@Apellidos VARCHAR(30),
	@Codigo_Escuela CHAR(12)
AS
BEGIN
	UPDATE ALUMNO
	SET Nombres = @Nombres,
	Apellidos = @Apellidos,
	Codigo_Escuela = @Codigo_Escuela
		
	WHERE Codigo = @Codigo
END
GO

CREATE PROCEDURE [sp_actualizar_Asistencia]
	@Codigo_Conferencia INT,
	@Codigo_Alumno CHAR(9),
	@Hora_Entrada DATETIME
AS
BEGIN
	UPDATE ASISTENCIA
	SET Hora_Entrada = @Hora_Entrada
		
	WHERE (Codigo_Alumno = @Codigo_Alumno) AND (Codigo_Conferencia = @Codigo_Conferencia)
END
GO

/*CREA STORED PROCEDURES PARA ELIMINAR*/
CREATE PROCEDURE [sp_eliminar_Expositor]
	@Dni CHAR(8)
AS
BEGIN
	DELETE EXPOSITOR WHERE Dni = @Dni
END
GO

CREATE PROCEDURE [sp_eliminar_Facultad]
	@Codigo CHAR(12)
AS
BEGIN
	DELETE FACULTAD WHERE Codigo = @Codigo 
END
GO

CREATE PROCEDURE [sp_eliminar_Escuela]
		@Codigo char(12)
AS
BEGIN
	DELETE ESCUELA WHERE Codigo = @Codigo 
END
GO

CREATE PROCEDURE [sp_eliminar_Conferencia]
	@Codigo int
AS
BEGIN
	DELETE CONFERENCIA WHERE codigo = @Codigo 
END
GO

CREATE PROCEDURE [sp_eliminar_Alumno]
	@Codigo char(9)
AS
BEGIN
	DELETE ALUMNO WHERE codigo = @Codigo 
END
GO

CREATE PROCEDURE [sp_eliminar_Asistencia]
	@Codigo_Conferencia INT,
	@Codigo_Alumno CHAR(9)
AS
BEGIN
	DELETE ASISTENCIA WHERE (Codigo_Alumno = @Codigo_Alumno) AND (Codigo_Conferencia = @Codigo_Conferencia)
END
GO

/*CREA STORED PROCEDURES PARA OBTENER LOS DATOS DE CADA TABLA POR SU LLAVE PRIMARIA*/
CREATE PROCEDURE [sp_getExpositorByDni]
	@Dni CHAR(8)
AS
BEGIN
	SELECT * FROM EXPOSITOR WHERE Dni = @Dni
END
GO

CREATE PROCEDURE [sp_getFacultadByCodigo]
	@Codigo CHAR(12)
AS
BEGIN
	SELECT * FROM FACULTAD WHERE Codigo = @Codigo 
END
GO

CREATE PROCEDURE [sp_getEscuelaByCodigo]
		@Codigo char(12)
AS
BEGIN
	SELECT * FROM ESCUELA WHERE Codigo = @Codigo 
END
GO

CREATE PROCEDURE [sp_getConferenciaByCodigo]
	@Codigo int
AS
BEGIN
	SELECT * FROM CONFERENCIA WHERE codigo = @Codigo 
END
GO

CREATE PROCEDURE [sp_getAlumnoByCodigo]
	@Codigo char(9)
AS
BEGIN
	SELECT * FROM ALUMNO WHERE codigo = @Codigo 
END
GO

CREATE PROCEDURE [sp_getAsistenciaByConferenciaAlumno]
	@Codigo_Conferencia INT,
	@Codigo_Alumno CHAR(9)
AS
BEGIN
	SELECT * FROM ASISTENCIA WHERE (Codigo_Alumno = @Codigo_Alumno) AND (Codigo_Conferencia = @Codigo_Conferencia)
END
GO

CREATE PROCEDURE [sp_getUsuarioByUsuarioContrasena]
@Usuario VARCHAR(30),
@Contrasena VARCHAR(30)
AS
BEGIN
	SELECT * FROM USUARIO WHERE (Usuario = @Usuario) AND (ContraseNa = @Contrasena)
END
GO

/*CREA STORED PROCEDURES PARA LLENAR DATOS EN LAS TABLAS*/
CREATE PROCEDURE [sp_llenar_Expositor]
AS
BEGIN
	EXEC sp_insertar_Expositor @Dni = '69225197', @Nombres = 'Luis', @Apellidos = 'Valverde Farfan', @Titulado = 1, @Especialidad = 'Machine Learning', @Empresa = 'Amazon'
	EXEC sp_insertar_Expositor @Dni = '48731848', @Nombres = 'Pedro', @Apellidos = 'Carpio Fernandez', @Titulado = 1, @Especialidad = 'Desarrollo de videojuegos', @Empresa = 'Coditetec'
	EXEC sp_insertar_Expositor @Dni = '84482197', @Nombres = 'Juana', @Apellidos = 'Campos Aguilar', @Titulado = 1, @Especialidad = 'Marketing digital', @Empresa = 'Businesses Everywhere'
	EXEC sp_insertar_Expositor @Dni = '54481872', @Nombres = 'Francisco', @Apellidos = 'Colombo Ramirez', @Titulado = 0, @Especialidad = 'Internet of things', @Empresa = 'Internet of Everything'
	EXEC sp_insertar_Expositor @Dni = '75146319', @Nombres = 'Armando', @Apellidos = 'Paredes Fuertes', @Titulado = 0, @Especialidad = 'Big data', @Empresa = 'IBM'
END
GO

CREATE PROCEDURE [sp_llenar_Facultad]
AS
BEGIN
	EXEC sp_insertar_Facultad @Codigo = 'FI', @Nombre = 'Facultad de Ingeniería'
	EXEC sp_insertar_Facultad @Codigo = 'FAU', @Nombre = 'Facultad de Arquitectura y Urbanismo'
	EXEC sp_insertar_Facultad @Codigo = 'FCB', @Nombre = 'Facultad de Ciencias Biológicas'
	EXEC sp_insertar_Facultad @Codigo = 'FHLM', @Nombre = 'Facultad de Humanidades y Lenguas Modernas'
	EXEC sp_insertar_Facultad @Codigo = 'FDCP', @Nombre = 'Facultad de Derecho y Ciencia Política'
	EXEC sp_insertar_Facultad @Codigo = 'FP', @Nombre = 'Facultad de Psicología'
	EXEC sp_insertar_Facultad @Codigo = 'FMH', @Nombre = 'Facultad de Medicina Humana'
	EXEC sp_insertar_Facultad @Codigo = 'FACEE', @Nombre = 'Facultad de Ciencias Económicas y Empresariales'
END
GO


CREATE PROCEDURE [sp_llenar_Escuela]
AS
BEGIN
	EXEC sp_insertar_Escuela 'ING_INF', 'Escuela de Ingeniería Informática','FI'
	EXEC sp_insertar_Escuela 'ING_CIV', 'Escuela de Ingeniería Civil','FI'
	EXEC sp_insertar_Escuela 'ING_IND', 'Escuela de Ingeniería Industrial','FI'
	EXEC sp_insertar_Escuela 'ING_MEC', 'Escuela de Ingeniería Mecatrónica','FI'
	EXEC sp_insertar_Escuela 'ING_ELE', 'Escuela de Ingeniería Electrónica','FI'
	
	EXEC sp_insertar_Escuela 'ARQ', 'Escuela de Arquitectura','FAU'
	
	EXEC sp_insertar_Escuela 'ECO', 'Escuela de Economía','FACEE'
	EXEC sp_insertar_Escuela 'ADM_NEG_GLO', 'Escuela de Administración de Negocios Globales','FACEE'
	EXEC sp_insertar_Escuela 'MAR_ADM_COM', 'Escuela de Marketing Global y Administración Comercial','FACEE'
	EXEC sp_insertar_Escuela 'TUR_HOT_GAS', 'Escuela de Turismo, Hotelería y Gastronomía','FACEE'
	EXEC sp_insertar_Escuela 'ADM_GER', 'Escuela de Administración y Gerencia','FACEE'
	EXEC sp_insertar_Escuela 'CON_FIN', 'Escuela de Contabilidad y Finanzas','FACEE'
	
	EXEC sp_insertar_Escuela 'BIO', 'Escuela de Biología','FCB'
	EXEC sp_insertar_Escuela 'MED_VET', 'Escuela de Medicina Veterinaria','FCB'
	
	EXEC sp_insertar_Escuela 'TRA_INT', 'Escuela de Traducción e Interpretación','FHLM'

	EXEC sp_insertar_Escuela 'MED_HUM', 'Escuela de Medicina Humana','FMH'
	EXEC sp_insertar_Escuela 'RES_MED', 'Escuela de Residentado Médico','FMH'

	EXEC sp_insertar_Escuela 'DER', 'Escuela de Derecho','FDCP'

	EXEC sp_insertar_Escuela 'PSI', 'Escuela de Psicología','FP'
	EXEC sp_insertar_Escuela 'EDU', 'Escuela de Educación','FP'
	END
GO


CREATE PROCEDURE [sp_llenar_Conferencia]
AS
BEGIN
	EXEC sp_insertar_Conferencia '2019-1', '2019-06-11 20:30', '2019-06-11 21:30', 'Auditorio Ollantaytambo', 'Chatbots', 1, '84482197', 'ING_INF'
	EXEC sp_insertar_Conferencia '2019-1', '2019-20-06 19:00', '2019-20-06 20:00', 'Auditorio Ollantaytambo', 'Análisis predictivo de datos cuantitativos usando Machine Learning', 1, '69225197', 'ING_INF'
	EXEC sp_insertar_Conferencia '2019-1', '2019-16-07 20:30', '2019-16-07 21:30', 'Auditorio Ollantaytambo', 'Cómo hacer crecer tu marca personal a través de Youtube', 1, '84482197', 'ING_INF'
	EXEC sp_insertar_Conferencia '2019-1', '2019-18-07 18:00', '2019-18-07 20:00', 'Auditorio Ollantaytambo', 'Cómo crear un videojuego usando Unity', 2, '48731848', 'ING_INF'
	EXEC sp_insertar_Conferencia '2019-1', '2019-18-07 20:00', '2019-18-07 22:00', 'Auditorio Ollantaytambo', 'La importancia del Big Data en el siglo 21', 2, '75146319', 'ING_INF'
	EXEC sp_insertar_Conferencia '2019-1', '2019-23-07 18:00', '2019-23-07 19:00', 'Auditorio Ollantaytambo', 'Chatbots', 1, '69225197', 'ING_INF'

	/*EXEC sp_insertar_Conferencia '2019-1', '2019-06-20 19:00', '2019-06-20 20:00', 'Auditorio Ollantaytambo', 'Análisis predictivo de datos cuantitativos usando Machine Learning', 1, '69225197', 'ING_INF'
	EXEC sp_insertar_Conferencia '2019-1', '2019-07-16 20:30', '2019-07-16 21:30', 'Auditorio Ollantaytambo', 'Cómo hacer crecer tu marca personal a través de Youtube', 1, '84482197', 'ING_INF'
	EXEC sp_insertar_Conferencia '2019-1', '2019-07-18 18:00', '2019-07-18 20:00', 'Auditorio Ollantaytambo', 'Cómo crear un videojuego usando Unity', 2, '48731848', 'ING_INF'
	EXEC sp_insertar_Conferencia '2019-1', '2019-07-18 20:00', '2019-07-18 22:00', 'Auditorio Ollantaytambo', 'La importancia del Big Data en el siglo 21', 2, '75146319', 'ING_INF'
	EXEC sp_insertar_Conferencia '2019-1', '2019-07-23 18:00', '2019-07-23 19:00', 'Auditorio Ollantaytambo', 'Chatbots', 1, '69225197', 'ING_INF'*/

END
GO

CREATE PROCEDURE [sp_llenar_Alumno]
AS
BEGIN
	EXEC sp_insertar_Alumno '201710401', 'Maciel Daphne', 'Gonzales Salazar', 'ING_INF'
	EXEC sp_insertar_Alumno '201710402', 'Angelo Giovanni', 'Licetti León', 'ING_INF'
	EXEC sp_insertar_Alumno '201710403', 'José Smith', 'Caldas Reyes', 'ING_INF'
	EXEC sp_insertar_Alumno '201710404', 'Daniel Javier', 'Almanza Acosta', 'ING_INF'
	EXEC sp_insertar_Alumno '201710405', 'Carlos Arturo', 'Lau Loo', 'ING_INF'
	EXEC sp_insertar_Alumno '201710406', 'Melissa Melany', 'Mora Yarasca', 'ING_INF'
	EXEC sp_insertar_Alumno '201710407', 'Fernando Iván', 'Espinoza Pachecho', 'ING_INF'
	EXEC sp_insertar_Alumno '201710408', 'Melannie Jannet', 'Lizarraga Viera', 'ING_INF'
	EXEC sp_insertar_Alumno '201710409', 'Victor Enrique', 'Cortez Villagomez', 'ING_INF'
	EXEC sp_insertar_Alumno '201710410', 'Jairo Daniel', 'Melendez Alvarado', 'ING_INF'
	EXEC sp_insertar_Alumno '201710202', 'Luis Ricardo', 'Sanchez Vega', 'ADM_NEG_GLO'
	
END
GO


CREATE PROCEDURE [sp_llenar_Asistencia]
AS
BEGIN
	EXEC sp_insertar_Asistencia 1, '201710402', '2019-06-11 20:30'
	EXEC sp_insertar_Asistencia 1, '201710407', '2019-06-11 20:33'
	EXEC sp_insertar_Asistencia 1, '201710202', '2019-06-11 20:35'
	EXEC sp_insertar_Asistencia 1, '201710410', '2019-06-11 20:36'
	EXEC sp_insertar_Asistencia 1, '201710404', '2019-06-11 20:36'
	EXEC sp_insertar_Asistencia 1, '201710409', '2019-06-11 20:37'
	EXEC sp_insertar_Asistencia 1, '201710401', '2019-06-11 20:40'
	
END
GO

CREATE PROCEDURE [sp_llenar_Usuario]
AS
BEGIN
	EXEC sp_insertar_Usuario 'admin', '123'
	EXEC sp_insertar_Usuario 'angelo', '123'
	EXEC sp_insertar_Usuario 'luis', '123'
	EXEC sp_insertar_Usuario 'bryan', '123'
END
GO

/*CREA STORED PROCEDURES PARA LISTAR*/
CREATE PROCEDURE [sp_listar_Expositor]
AS
BEGIN
	SELECT * FROM EXPOSITOR
END
GO

CREATE PROCEDURE [sp_listar_Facultad]
AS
BEGIN
	SELECT * FROM FACULTAD
END
GO

CREATE PROCEDURE [sp_listar_Escuela]
AS
BEGIN
	SELECT * FROM ESCUELA
END
GO

CREATE PROCEDURE [sp_listar_Conferencia]
AS
BEGIN
	SELECT * FROM CONFERENCIA
END
GO

CREATE PROCEDURE [sp_listar_Alumno]
AS
BEGIN
	SELECT * FROM ALUMNO
END
GO

CREATE PROCEDURE [sp_listar_Asistencia]
AS
BEGIN
	SELECT * FROM ASISTENCIA
END
GO

CREATE PROCEDURE [sp_listar_Usuario]
AS
BEGIN
	SELECT * FROM USUARIO
END
GO

--Crea otros sp útiles para el proyecto:

--Crea reporte de los asistentes a una conferencia determinada:
CREATE PROCEDURE [sp_ReporteByCodigoConferencia]
@CodigoConferencia INT
AS
BEGIN
	SELECT CONCAT(ALUMNO.Apellidos, ',', ALUMNO.Nombres) AS Alumno, ESCUELA.Nombre AS ESCUELA, ALUMNO.Codigo, ASISTENCIA.Hora_Entrada
	FROM ALUMNO
	INNER JOIN ASISTENCIA ON ALUMNO.Codigo = ASISTENCIA.Codigo_Alumno
	INNER JOIN ESCUELA ON ALUMNO.Codigo_Escuela = ESCUELA.Codigo
	WHERE ASISTENCIA.Codigo_Conferencia = @CodigoConferencia
END
GO

--Crea reporte de los asistentes pertenecientes a una escuela determinada a una conferencia determinada:
CREATE PROCEDURE [sp_ReporteByConferenciaAndEscuela]
@CodigoConferencia INT,
@CodigoEscuela CHAR(12)
AS
BEGIN
	SELECT CONCAT(ALUMNO.Apellidos, ',', ALUMNO.Nombres) AS Alumno, ESCUELA.Nombre AS ESCUELA, ALUMNO.Codigo, ASISTENCIA.Hora_Entrada 
	FROM ALUMNO
	INNER JOIN ASISTENCIA ON ALUMNO.Codigo = ASISTENCIA.Codigo_Alumno 
	INNER JOIN ESCUELA ON ALUMNO.Codigo_Escuela = ESCUELA.Codigo
	WHERE ASISTENCIA.Codigo_Conferencia = @CodigoConferencia AND ALUMNO.Codigo_Escuela = @CodigoEscuela
END
GO

/*EJECUTA STORED PROCEDURES PARA LLENAR DATOS EN LAS TABLAS*/
EXEC [sp_llenar_Expositor]
GO
EXEC [sp_llenar_Facultad]
GO
EXEC [sp_llenar_Escuela]
GO
EXEC [sp_llenar_Conferencia]
GO
EXEC [sp_llenar_Alumno]
GO
EXEC [sp_llenar_Asistencia]
GO
EXEC [sp_llenar_Usuario]
GO

/*EJECUTA STORED PROCEDURES PARA LISTAR*/
EXEC [sp_listar_Expositor]
GO
EXEC [sp_listar_Facultad]
GO
EXEC [sp_listar_Escuela]
GO
EXEC [sp_listar_Conferencia]
GO
EXEC [sp_listar_Alumno]
GO
EXEC [sp_listar_Asistencia]
GO
EXEC [sp_listar_Usuario]
GO

/*PROC PARA DATASET2*/
CREATE PROCEDURE [sp_datos_conferencia_seleccionada]
@COD_CONF AS INT
AS
BEGIN
SELECT CONFERENCIA.CODIGO, CONFERENCIA.TEMA, CONFERENCIA.Semestre, 
CONCAT (EXPOSITOR.Nombres,' ',EXPOSITOR.Apellidos) AS DATOS_EXPOSITOR FROM CONFERENCIA INNER JOIN EXPOSITOR ON 
CONFERENCIA.Dni_Expositor= EXPOSITOR.Dni WHERE CONFERENCIA.Codigo = @COD_CONF 

END
/*
EXEC [sp.datos_conferencia_seleccionada] 8
EXEC sp_ReporteByCodigoConferencia 8*/