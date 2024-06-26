CREATE OR ALTER PROCEDURE [per].[ValidarCedula]
	@CEDULA VARCHAR(50)
AS BEGIN

	-- Valida si la persona existe en el sistema.
	IF EXISTS(
		SELECT 1
		FROM PER.PERSONA P
		WHERE CEDULA = @CEDULA
	)
		SELECT CONVERT(BIT, 1) AS Valido;
	ELSE
		SELECT CONVERT(BIT, 0) AS Valido;

	RETURN 1;
END