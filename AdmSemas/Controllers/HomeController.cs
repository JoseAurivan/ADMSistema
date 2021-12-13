using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdmSemas.Models;
using AdmSemas.ViewModels;
using Microsoft.EntityFrameworkCore;
using AppContext = AdmSemas.Data.AppContext;

namespace AdmSemas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppContext _appContext;

        public HomeController(ILogger<HomeController> logger, AppContext appContext)
        {
            _logger = logger;
            _appContext = appContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Index(LoginTiViewModel loginTiViewModel)
        {
            if ((!ModelState.IsValid) || !(loginTiViewModel.Username.Equals(loginTiViewModel.TypedUser) 
                                           && loginTiViewModel.Password.Equals(loginTiViewModel.TypedPassword))) 
            {
                ModelState.AddModelError("Error", "Dados incorretos");
                return View(loginTiViewModel);
            }
            return View(nameof(Panel));
        }

        
        [Route("Home/{id:int}")]
        public IActionResult Delete(int id)
        {
            var user = _appContext.Users.Find(id);
            _appContext.Users.Remove(user);
            _appContext.SaveChanges();    
            return View(nameof(Panel));
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(UserCreateViewModel userCreateViewModel)
        {
            if (!ModelState.IsValid)
                return View(nameof(Criar));

            var user = userCreateViewModel.GetModel(userCreateViewModel.Cpf, userCreateViewModel.Nome,
                userCreateViewModel.Senha, userCreateViewModel.Email);
            _appContext.Users.Add(user);
            await _appContext.SaveChangesAsync();
            return View(nameof(Panel));
        }

        public async Task<IActionResult> Listar()
        {
            List<User> resultado = await _appContext.Users
                .ToListAsync();
            return View(resultado);
        }
        
        [Route("Home/Editar/{id:int}")]
        public async Task<IActionResult> Editar(int id)
        {
            var user = _appContext.Users.Find(id);
            return View(user);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditarConfirm(User user)
        {
            _appContext.Entry(user).State = EntityState.Modified;
            await _appContext.SaveChangesAsync();
            return View(nameof(Panel));
        }

        public IActionResult Panel()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}