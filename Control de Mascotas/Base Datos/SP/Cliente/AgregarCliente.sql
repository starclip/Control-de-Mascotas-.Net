CREATE OR ALTER PROCEDURE [per].[AgregarCliente]
	@PrimerNombre VARCHAR(255),
	@SegundoNombre VARCHAR(255) NULL,
	@PrimerApellido VARCHAR(255),
	@SegundoApellido VARCHAR(255),
	@Cedula VARCHAR(50),
	@FechaNacimiento DATETIME,
	@Telefono VARCHAR(50) NULL,
	@Sexo BIGINT,
	@Correo VARCHAR(255) NULL,
	@Distrito BIGINT,
	@DireccionExacta VARCHAR(255) NULL,
	@IdVeterinarioActual BIGINT
AS BEGIN

	DECLARE @IdNuevaPersona BIGINT;
	DECLARE @IdNuevoCliente BIGINT;
	DECLARE @IdEstadoNuevo BIGINT = (
		SELECT CV.IDCATALOGOVALOR
		FROM SIS.CATALOGOVALOR CV
		INNER JOIN SIS.CATALOGO C
			ON CV.IDCATALOGO = C.IDCATALOGO
			AND C.CODIGO = 'ESTADOSCLIENTE'
			AND CV.CODIGO = 'ACT'
	);

	-- Realizo la inserción de la nueva persona en el sistema.
	INSERT INTO PER.PERSONA (
		CEDULA,
		PRIMERNOMBRE,
		SEGUNDONOMBRE,
		PRIMERAPELLIDO,
		SEGUNDOAPELLIDO,
		FECHANACIMIENTO,
		TELEFONO,
		CORREO
	)
	VALUES (
		@Cedula,
		@PrimerNombre,
		@SegundoNombre,
		@PrimerApellido,
		@SegundoApellido,
		@FechaNacimiento,
		@Telefono,
		@Correo
	);

	-- Obtengo el id de la nueva persona.
	SELECT @IdNuevaPersona = SCOPE_IDENTITY();

	-- Realizo la inserción del nuevo cliente en el sistema.
	INSERT INTO PER.CLIENTE (
		IDPERSONA,
		IDDISTRITO,
		IDESTADO,
		IDSEXO,
		DIRECCION,
		IDPERSONACREACION,
		IDPERSONAMODIFICACION,
		FECHACREACION,
		FECHAMODIFICACION
	)
	VALUES (
		@IdNuevaPersona,
		@Distrito,
		@IdEstadoNuevo,
		@Sexo,
		@DireccionExacta,
		@IdVeterinarioActual,
		@IdVeterinarioActual,
		GETDATE(),
		GETDATE()
	);

	-- Obtengo el id del nuevo cliente.
	SELECT @IdNuevoCliente = SCOPE_IDENTITY();

	-- Retorno el nuevo Id del nuevo cliente creado.
	SELECT @IdNuevoCliente AS IdCliente;

	RETURN 1;
END