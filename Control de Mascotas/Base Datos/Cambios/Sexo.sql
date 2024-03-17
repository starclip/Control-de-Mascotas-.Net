-- Se crea el cat�logo de sexos.
SET IDENTITY_INSERT SIS.CATALOGO ON;

IF NOT EXISTS (
	SELECT 1
	FROM SIS.CATALOGO
	WHERE CODIGO = 'SEXO'
)
BEGIN
	INSERT INTO SIS.CATALOGO (IDCATALOGO, CODIGO, NOMBRE)
	VALUES (10001, 'SEXO', 'Sexo')
END

SET IDENTITY_INSERT SIS.CATALOGO OFF;

-- Se crean los valores de catalogo valor.
SET IDENTITY_INSERT SIS.CATALOGOVALOR ON;

INSERT INTO SIS.CATALOGOVALOR (IDCATALOGOVALOR, IDCATALOGO, CODIGO, NOMBRE)
VALUES  (10001000, 10001, 'M', 'Masculino'),
		(10001001, 10001, 'F', 'Femenino'),
		(10001002, 10001, 'I', 'Indefinido')

SET IDENTITY_INSERT SIS.CATALOGOVALOR OFF;