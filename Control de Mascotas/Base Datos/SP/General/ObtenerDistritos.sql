CREATE OR ALTER PROCEDURE [cfg].[ObtenerDistritos]
	@IDCANTON BIGINT
AS BEGIN

	SELECT 
		IDDISTRITO,
		IDCANTON,
		CODIGO,
		NOMBRE
	FROM CFG.DISTRITO
	WHERE IDCANTON = @IDCANTON

	RETURN 1;
END