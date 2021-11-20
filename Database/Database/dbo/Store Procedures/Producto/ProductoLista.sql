CREATE PROCEDURE [dbo].[ProductoLista]
AS
	BEGIN
	SET NOCOUNT ON
	SELECT
	 IdProducto,
	 NombreProducto,
	 PrecioProducto
	FROM dbo.Producto
END