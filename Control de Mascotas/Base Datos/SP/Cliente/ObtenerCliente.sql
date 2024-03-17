CREATE OR ALTER PROCEDURE [per].[ObtenerCliente]
	@IDCLIENTE BIGINT
AS BEGIN

	SELECT 
		C.IDCLIENTE,
		P.CEDULA,
		P.PRIMERNOMBRE,
		P.SEGUNDONOMBRE,
		P.PRIMERAPELLIDO,
		P.SEGUNDOAPELLIDO,
		CONVERT(VARCHAR(100), P.FECHANACIMIENTO, 103) AS FECHANACIMIENTO,
		P.TELEFONO,
		C.IDSEXO AS SEXO,
		P.CORREO,
		C.DIRECCION,
		C.IDDISTRITO AS DISTRITO,
		CN.IDCANTON AS CANTON,
		PR.IDPROVINCIA AS PROVINCIA,
		C.CAMBIOS
	FROM PER.CLIENTE C
	INNER JOIN PER.PERSONA P
		ON C.IDPERSONA = P.IDPERSONA
	INNER JOIN SIS.CATALOGOVALOR CV
		ON C.IDESTADO = CV.IDCATALOGOVALOR
		AND CV.CODIGO = 'ACT'
	INNER JOIN CFG.DISTRITO D
		ON C.IDDISTRITO = D.IDDISTRITO
	INNER JOIN CFG.CANTON CN
		ON D.IDCANTON = CN.IDCANTON
	INNER JOIN CFG.PROVINCIA PR
		ON CN.IDPROVINCIA = PR.IDPROVINCIA
	WHERE C.IDCLIENTE = @IDCLIENTE

	RETURN 1;
END