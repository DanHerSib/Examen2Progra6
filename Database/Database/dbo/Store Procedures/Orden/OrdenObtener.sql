CREATE PROCEDURE [dbo].[OrdenObtener]
      @IdOrden int = NULL
AS BEGIN
  SET NOCOUNT ON
  SELECT 
     O.IdOrden,
     O.CantidadProducto,
     O.Estado,
     /*Tabla Producto*/
     P.IdProducto,
     P.NombreProducto,
     P.PrecioProducto
    FROM dbo.Orden O
    INNER JOIN Producto P
       ON O.IdProducto = P.IdProducto
    WHERE
    (@IdOrden IS NULL OR IdOrden = @IdOrden)
END