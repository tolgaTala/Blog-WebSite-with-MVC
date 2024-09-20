using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.ComponentModel.DataAnnotations;
using System.Data;
using YoutubeBlog.Entity.Dtos.Categories;
using YoutubeBlog.Entity.Dtos.Roles;
using YoutubeBlog.Entity.Dtos.Users;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Services.Conrete;
using YoutubeBlog.Web.Consts;
using YoutubeBlog.Web.ResultMessages;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoleController : Controller
    {
        private readonly IMapper mapper;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IValidator<AppRole> validator;
        private readonly IToastNotification toastNotification;

        public RoleController(IMapper mapper, RoleManager<AppRole> roleManager,IValidator<AppRole> validator, IToastNotification toastNotification)
        {
            this.mapper = mapper;
            this.roleManager = roleManager;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            var roles =  roleManager.Roles.ToList();
            var map = mapper.Map<List<RoleDto>>(roles);
            return View(map);
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public async Task<IActionResult> Add(RoleAddDto roleAddDto)
        {
            var map = mapper.Map<AppRole>(roleAddDto);
            var validation = await validator.ValidateAsync(map);
            if (ModelState.IsValid)
            {
                map.NormalizedName = roleAddDto.Name.ToUpper();
                map.ConcurrencyStamp = Guid.NewGuid().ToString();
                var result = await roleManager.CreateAsync(map);
                if (result.Succeeded)
                {
                    toastNotification.AddSuccessToastMessage(Messages.Role.Add(roleAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Index", "Role", new { Area = "Admin" });
                }
                else
                {
                    result.AddToIdentityModelState(ModelState);
                    validation.AddToModelState(ModelState);
                    return View();
                }
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public async Task<IActionResult> Update(Guid roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId.ToString());
            var map = mapper.Map<RoleUpdateDto>(role);
            return View(map);
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}")]
        public async Task<IActionResult> Update(RoleUpdateDto roleUpdateDto)
        {
            var map = mapper.Map<AppRole>(roleUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await roleManager.UpdateAsync(map);
                toastNotification.AddSuccessToastMessage(Messages.Role.Update(map.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Role", new { Area = "Admin" });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                return View();
            }
        }
        public async Task<IActionResult> Delete(Guid roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId.ToString());
            var result = await roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                toastNotification.AddSuccessToastMessage(Messages.Role.Delete(role.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Role", new { Area = "Admin" });
            }
            else
            {
                result.AddToIdentityModelState(ModelState);
            }
            return NotFound();
        }
    }
}
