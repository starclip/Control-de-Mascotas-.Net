-- Persona de control.
INSERT INTO PER.PERSONA (
	CEDULA, 
	PRIMERNOMBRE, 
	SEGUNDONOMBRE, 
	PRIMERAPELLIDO, 
	SEGUNDOAPELLIDO, 
	FECHANACIMIENTO
)
VALUES (
	'0-0000-0000',
	'',
	'',
	'',
	'',
	CONVERT(DATETIME, '20000101')
)