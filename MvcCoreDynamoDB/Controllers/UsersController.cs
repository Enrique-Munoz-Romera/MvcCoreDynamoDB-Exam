using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCoreDynamoDB.Helpers;
using MvcCoreDynamoDB.Models;
using MvcCoreDynamoDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreDynamoDB.Controllers
{
    public class UsersController : Controller
    {
        private ServiceDynamoDb ServiceDynamoDb;
        private UploadHelper uploadhelper;

        public UsersController(ServiceDynamoDb service,UploadHelper uploadhelper) { this.ServiceDynamoDb = service; this.uploadhelper = uploadhelper; }

        public async Task<IActionResult> Index()
        {
            return View(await this.ServiceDynamoDb.GetUsers());
        }

        public async Task<IActionResult> Details(string idUsers)
        {
            return View(await this.ServiceDynamoDb.GetUser(idUsers));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user, string foto, IFormFile file)
        {
            if(foto != null)
            {
                String path =
                await this.uploadhelper.UploadFileAsync(file, Folders.Images);
                user.imagen = new Imagenes();
                user.imagen.url = path;
            }
            await this.ServiceDynamoDb.CreateUser(user);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string idUsers)
        {
            return View(await this.ServiceDynamoDb.GetUser(idUsers));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            await this.ServiceDynamoDb.UpdateUser(user);
            return RedirectToAction("Details",new{idUsers = user.idUsers});
        }

        public async Task<IActionResult> Delete(string idUsers)
        {
            await this.ServiceDynamoDb.DeleteUser(idUsers);
            return RedirectToAction("Index");
        }
    }
}
