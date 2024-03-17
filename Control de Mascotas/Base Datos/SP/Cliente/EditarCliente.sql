CREATE OR ALTER PROCEDURE [per].[EditarCliente]
	@IdCliente BIGINT,
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

	DECLARE @ESTADO BIT = CONVERT(BIT, 0);

	DECLARE @IdPersona BIGINT = (
		SELECT P.IdPersona
		FROM PER.PERSONA P
		INNER JOIN PER.CLIENTE C
			ON P.IDPERSONA = C.IDPERSONA
			AND C.IDCLIENTE = @IdCliente
	);

	-- Actualizo los datos de la persona.
	UPDATE PER.PERSONA 
	SET 
		TELEFONO = @Telefono, 
		CORREO = @Correo
	WHERE IDPERSONA = @IdPersona

	-- Si se actualizo los datos de la persona.
	IF (@@ROWCOUNT > 0)
		SET @ESTADO = CONVERT(BIT, 1)

	-- Actualizo los datos del cliente.
	UPDATE PER.CLIENTE
	SET 
		IDDISTRITO = @Distrito,
		DIRECCION = @DireccionExacta,
		FECHAMODIFICACION = GETDATE(),
		IDPERSONAMODIFICACION = @IdVeterinarioActual
	WHERE IDCLIENTE = @IdCliente

	-- Si se actualizo los datos del cliente.
	IF (@@ROWCOUNT > 0)
		SET @ESTADO = CONVERT(BIT, 1)

	SELECT @ESTADO AS ESTADO;

	RETURN 1;
END