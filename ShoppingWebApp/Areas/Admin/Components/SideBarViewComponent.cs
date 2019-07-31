using Microsoft.AspNetCore.Mvc;
using ShoppingWebApp.Application.Interfaces;
using ShoppingWebApp.Application.ViewModels.System;
using ShoppingWebApp.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ShoppingWebApp.Utilities.Constants;

namespace ShoppingWebApp.Areas.Admin.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        IFunctionService _functionService;
        public SideBarViewComponent(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = (User as ClaimsPrincipal).GetSpecificClaim("Roles");
            List<FunctionViewModel> functions;
            if (roles.Split(";").Contains(Constants.AdminRole))
            {
                functions = await _functionService.GetAll();
            }
            else
            {
                functions = new List<FunctionViewModel>();
            }

            return View(functions);
        }
    }
}
