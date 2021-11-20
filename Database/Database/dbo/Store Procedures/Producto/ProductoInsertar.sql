CREATE PROCEDURE [dbo].[ProductoInsertar]
	@IdEmpleado int,
	@TipoContrato varchar(50),
	@FechaInicio Datetime,
	@FechaFin Datetime

AS BEGIN
SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

    BEGIN TRY
	
	INSERT INTO acc.Contrato
	(IdEmpleado,
	 TipoContrato,
	 FechaInicio,
	 FechaFin
	)
	VALUES
	(
	@IdEmpleado,
	@TipoContrato,
	@FechaInicio,
	@FechaFin

	)

  COMMIT TRANSACTION TRASA
  SELECT 0 AS CodeError, '' AS MsgError

  END TRY

  BEGIN CATCH

   SELECT 
         ERROR_NUMBER() AS CodeError,
		 ERROR_MESSAGE() AS MsgError
   
   ROLLBACK TRANSACTION TRASA

   END CATCH

 END