using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Contrato
{
    public class GridModel : PageModel
    {
        private readonly IContratoService contratoService;

        public GridModel(IContratoService contratoService)
        {
            this.contratoService = contratoService;
        }

        public IEnumerable<ContratoEntity> GridList { get; set; } = new List<ContratoEntity>();

        public async Task<IActionResult> OnGet()
        {

            try
            {
                GridList = await contratoService.Get();
             

                return Page();

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<IActionResult> OnDeleteEliminar(int id)
        {

            try
            {
                var result = await contratoService.Delete(new() { IdContrato = id });

                return new JsonResult(result);


            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }

        }









    }
}
