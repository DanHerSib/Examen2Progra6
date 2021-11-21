using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Producto
{
    public class GridModel : PageModel
    {
        private readonly IProductoService ProductoService;
        public GridModel(IProductoService ProductoService)
        {
            this.ProductoService = ProductoService;
        }
        public IEnumerable<ProductoEntity> GridList { get; set; } = new List<ProductoEntity>();
        //Get method
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await ProductoService.Get();
                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        //Delete Method
        public async Task<IActionResult> OnDeleteEliminar(int id)
        {
            try
            {
                var result = await ProductoService.Delete(new() { IdProducto = id });
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }
}