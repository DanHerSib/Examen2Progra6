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
