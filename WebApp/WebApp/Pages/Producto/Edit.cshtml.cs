using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using WBL;

namespace WebApp.Pages.Producto
{
    public class EditModel : PageModel
    {
        private readonly IProductoService productoService;
        public EditModel(IProductoService productoService)
        {
            this.productoService = productoService;
        }

        [BindProperty]
        [FromBody]

        public ProductoEntity Entity { get; set; } = new ProductoEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await productoService.GetById(new() { IdProducto = id });
                }
                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();
                if (Entity.IdProducto.HasValue)
                {
                    result = await productoService.Update(Entity);
                }
                else
                {
                    result = await productoService.Create(Entity);
                }
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }
}
