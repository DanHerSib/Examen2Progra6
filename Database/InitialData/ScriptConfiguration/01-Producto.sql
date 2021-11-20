DROP TABLE IF EXISTS #ProductoTemp

SELECT 
IdProducto, NombreProducto, PrecioProducto INTO #ProductoTemp
FROM (
VALUES
(1, 'Jabon lava manos', 100.00),
(2, 'Detergente liquido', 120.00),
(3, 'Esponja lava platos', 20.00),
(4, 'Alcohol en gel', 135.00),
(5, 'Suavizante', 140.25),
(6, 'Cloro en polvo', 150.30),
(7, 'Desinfectante', 250.00)
)AS TEMP (IdProducto, NombreProducto, PrecioProducto)

----ACTUALIZAR DATOS---
UPDATE P SET
  P.NombreProducto = TM.NombreProducto,
  P.PrecioProducto = TM.PrecioProducto
FROM dbo.Producto P
INNER JOIN #ProductoTemp TM
    ON P.IdProducto = TM.IdProducto

----INSERTAR DATOS---
SET IDENTITY_INSERT dbo.Producto ON
INSERT INTO dbo.Producto(
IdProducto, NombreProducto, PrecioProducto)
SELECT
IdProducto, NombreProducto, PrecioProducto
FROM #ProductoTemp

EXCEPT
SELECT
IdProducto, NombreProducto, PrecioProducto
FROM dbo.Producto

SET IDENTITY_INSERT dbo.Producto OFF
GO