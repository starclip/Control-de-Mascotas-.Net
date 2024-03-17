CREATE OR ALTER PROCEDURE [sis].[ObtenerDatos]
	@Parametro1 VARCHAR(MAX),
	@Parametro2 INT,
	@Parametro3 BIT,
	@Parametro4 BIGINT
AS BEGIN

	SELECT 
		'Parametro 1' AS ParametroRetorno,
		152 AS SegundoRetorno,
		CONVERT(BIT, 0) AS TercerRetorno,
		15000000000 AS CuartoRetorno

	RETURN 1;
END