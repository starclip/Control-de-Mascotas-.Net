CREATE OR ALTER PROCEDURE [per].[ObtenerClientes]
	@Pagina INT,
	@TotalRegistros INT,
	@ColumnaOrdenamiento VARCHAR(100),
	@TipoOrdenamiento VARCHAR(5),
	@Nombre VARCHAR(255)
AS BEGIN

	SELECT 
		C.IDCLIENTE,
		P.CEDULA,
		P.PRIMERNOMBRE + ' ' + 
			(CASE WHEN P.SEGUNDONOMBRE IS NULL THEN '' ELSE P.SEGUNDONOMBRE + ' ' END) +
			P.PRIMERAPELLIDO + ' ' +
			P.SEGUNDOAPELLIDO AS NOMBRE,
		P.TELEFONO,
		P.CORREO,
		C.DIRECCION,
		(
			STUFF((SELECT ',' + M.NOMBRE
				FROM ANM.MASCOTA M
				WHERE M.IDCLIENTE = C.IDCLIENTE
				ORDER BY M.NOMBRE
				FOR XML PATH('')), 1,1, '')
		) AS MASCOTAS,
		C.CAMBIOS
	FROM PER.CLIENTE C
	INNER JOIN PER.PERSONA P
		ON C.IDPERSONA = P.IDPERSONA
	INNER JOIN SIS.CATALOGOVALOR CV
		ON C.IDESTADO = CV.IDCATALOGOVALOR
		AND CV.CODIGO = 'ACT'
	WHERE @Nombre = '' OR (
		@Nombre != '' AND (
			( UPPER(P.PRIMERNOMBRE) LIKE '%' + UPPER(@Nombre) + '%' ) OR
			( P.SEGUNDONOMBRE IS NOT NULL AND UPPER(P.SEGUNDONOMBRE) LIKE '%' + UPPER(@Nombre) + '%' ) OR
			( UPPER(P.PRIMERAPELLIDO) LIKE '%' + UPPER(@Nombre) + '%' ) OR
			( UPPER(P.SEGUNDOAPELLIDO) LIKE '%' + UPPER(@Nombre) + '%' )
		)
	)
	ORDER BY CASE WHEN @ColumnaOrdenamiento = 'Nombre' AND @TipoOrdenamiento = 'asc'
		THEN PRIMERNOMBRE END ASC,
	CASE WHEN @ColumnaOrdenamiento = 'Nombre' AND @TipoOrdenamiento = 'desc'
		THEN PRIMERNOMBRE END DESC,
	CASE WHEN @ColumnaOrdenamiento = 'Cedula' AND @TipoOrdenamiento = 'asc'
		THEN CEDULA END ASC,
	CASE WHEN @ColumnaOrdenamiento = 'Cedula' AND @TipoOrdenamiento = 'desc'
		THEN CEDULA END DESC,
	CASE WHEN @ColumnaOrdenamiento = 'Telefono' AND @TipoOrdenamiento = 'asc'
		THEN TELEFONO END ASC,
	CASE WHEN @ColumnaOrdenamiento = 'Telefono' AND @TipoOrdenamiento = 'desc'
		THEN TELEFONO END DESC,
	CASE WHEN @ColumnaOrdenamiento = 'Correo' AND @TipoOrdenamiento = 'asc'
		THEN CORREO END ASC,
	CASE WHEN @ColumnaOrdenamiento = 'Correo' AND @TipoOrdenamiento = 'desc'
		THEN CORREO END DESC,
	CASE WHEN @ColumnaOrdenamiento = 'Direccion' AND @TipoOrdenamiento = 'asc'
		THEN DIRECCION END ASC,
	CASE WHEN @ColumnaOrdenamiento = 'Direccion' AND @TipoOrdenamiento = 'desc'
		THEN DIRECCION END DESC
	OFFSET(@Pagina) * @TotalRegistros ROWS
		FETCH NEXT @TotalRegistros ROWS ONLY

	RETURN 1;
END