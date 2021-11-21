using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WBL;

namespace WebApp.Pages.Producto
{
    public class GridModel : PageModel
    {
        private readonly IProductoService productoService;
        public GridModel(IProductoService ProductoService)
        {
            this.productoService = ProductoService;
        }
        public IEnumerable<ProductoEntity> GridList { get; set; } = new List<ProductoEntity>();
        //Get method
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await productoService.Get();
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
                var result = await productoService.Delete(new() { IdProducto = id });
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }
}