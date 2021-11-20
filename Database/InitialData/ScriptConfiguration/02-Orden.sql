DROP TABLE IF EXISTS #OrdenTemp

SELECT 
IdOrden, IdProducto, NombreProducto, PrecioProducto, CantidadProducto, Estado
INTO #OrdenTemp
FROM (
VALUES
(1, 2, 'Detergente liquido', 120.00, 2, 'Pendiente'),
(2, 4, 'Alcohol en gel', 135.00, 5, 'Cancelada'),
(3, 1, 'Jabon lava manos', 100.00, 7, 'Cancelada'),
(4, 7, 'Desinfectante', 250.00, 3, 'Pendiente'),
(5, 5, 'Suavizante', 140.25, 1, 'Cancelada'),
(6, 6, 'Cloro en polvo', 150.30, 8, 'Pendiente'),
(7, 3, 'Esponja lava platos', 20.00, 9, 'Cancelada')
)AS TEMP (IdOrden, IdProducto, NombreProducto, PrecioProducto, CantidadProducto, Estado)

----ACTUALIZAR DATOS---
UPDATE O SET
  O.IdProducto = TM.IdProducto,
  O.NombreProducto = TM.NombreProducto,
  O.PrecioProducto = TM.PrecioProducto,
  O.CantidadProducto = TM.CantidadProducto,
  O.Estado = TM.Estado
FROM dbo.Orden O
INNER JOIN #OrdenTemp TM
    ON O.IdOrden= TM.IdOrden

----INSERTAR DATOS---
SET IDENTITY_INSERT dbo.Orden ON
INSERT INTO dbo.Orden(
IdOrden, IdProducto, NombreProducto, PrecioProducto, CantidadProducto, Estado)
SELECT
IdOrden, IdProducto, NombreProducto, PrecioProducto, CantidadProducto, Estado
FROM #OrdenTemp
EXCEPT
SELECT
IdOrden, IdProducto, NombreProducto, PrecioProducto, CantidadProducto, Estado
FROM dbo.Orden
SET IDENTITY_INSERT dbo.Orden OFF
GO