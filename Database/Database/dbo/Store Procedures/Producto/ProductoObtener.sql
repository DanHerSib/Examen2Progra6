CREATE PROCEDURE [dbo].[ProductoObtener]
      @IdContrato int= NULL
AS BEGIN
  SET NOCOUNT ON

  SELECT 
     C.IdContrato,
	 C.TipoContrato,
	 C.FechaInicio,
	 C.FechaFin,
     
     E.IdEmpleado,
     E.Identificacion

    FROM Contrato C
    INNER JOIN Empleado E
       ON E.IdEmpleado= C.IdEmpleado
    WHERE
    (@IdContrato IS NULL OR IdContrato=@IdContrato)

END