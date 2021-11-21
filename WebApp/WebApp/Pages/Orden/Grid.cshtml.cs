using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WBL;

namespace WebApp.Pages.Orden
{
    public class GridModel : PageModel
    {

        private readonly IOrdenService ordenService;

        public GridModel(IOrdenService ordenService)
        {
            this.ordenService = ordenService;
        }

        public IEnumerable<OrdenEntity> GridList { get; set; } = new List<OrdenEntity>();
        //Get method
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await ordenService.Get();
                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        //Delete method
        public async Task<IActionResult> OnGetEliminar(int id)
        {
            try
            {
                var result = await ordenService.Delete(new() { IdOrden = id });
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }
}



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
