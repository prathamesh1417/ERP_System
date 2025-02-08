using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.Extensions
{
    public static class ControllerExtensions
    {
        // Renders a view or partial view to a string.
        public static async Task<string> RenderViewAsync<TModel>(this Controller controller, string viewName, TModel model, bool partial = false)
        {
            controller.ViewData.Model = model;
            using (var writer = new StringWriter())
            {
                IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult;
                if (partial)
                {
                    // For partial views, we can use FindView.
                    viewResult = viewEngine.FindView(controller.ControllerContext, viewName, false);
                }
                else
                {
                    viewResult = viewEngine.GetView("", viewName, false);
                }

                if (!viewResult.Success)
                {
                    throw new FileNotFoundException("View cannot be found.");
                }

                ViewContext viewContext = new ViewContext(
                    controller.ControllerContext,
                    viewResult.View,
                    controller.ViewData,
                    controller.TempData,
                    writer,
                    new HtmlHelperOptions()
                );
                await viewResult.View.RenderAsync(viewContext);
                return writer.GetStringBuilder().ToString();
            }
        }
        }
}
