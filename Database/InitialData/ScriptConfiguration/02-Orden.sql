DROP TABLE IF EXISTS #OrdenTemp

SELECT 
IdOrden, IdProducto, CantidadProducto, Estado
INTO #OrdenTemp
FROM (
VALUES
(1, 2, 2, 'Pendiente'),
(2, 4, 5, 'Cancelada'),
(3, 1, 7, 'Cancelada'),
(4, 7, 3, 'Pendiente'),
(5, 5, 1, 'Cancelada'),
(6, 6, 8, 'Pendiente'),
(7, 3, 9, 'Cancelada')
)AS TEMP (IdOrden, IdProducto, CantidadProducto, Estado)

----ACTUALIZAR DATOS---
UPDATE O SET
  O.IdProducto = TM.IdProducto,
  O.CantidadProducto = TM.CantidadProducto,
  O.Estado = TM.Estado
FROM dbo.Orden O
INNER JOIN #OrdenTemp TM
    ON O.IdOrden= TM.IdOrden

----INSERTAR DATOS---
SET IDENTITY_INSERT dbo.Orden ON
INSERT INTO dbo.Orden(
IdOrden, IdProducto, CantidadProducto, Estado)
SELECT
IdOrden, IdProducto, CantidadProducto, Estado
FROM #OrdenTemp
EXCEPT
SELECT
IdOrden, IdProducto, CantidadProducto, Estado
FROM dbo.Orden
SET IDENTITY_INSERT dbo.Orden OFF
GO