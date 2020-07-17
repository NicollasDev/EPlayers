using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EPlayers.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace EPlayers.Controllers
{
    public class NoticiasController : Controller
    {
         Noticias noticiasModel = new Noticias();

       /// <summary>
       /// Aponta para a Index da minha View
       /// </summary>
       /// <returns>a própria View da Index</returns>
       public IActionResult Index()
        {
            ViewBag.Noticias = noticiasModel.ReadAll();
            return View();
        }

        /// <summary>
        ///  Cadastra Notícias
        /// </summary>
        /// <param name="form">Dados da notícias</param>
        /// <returns>Redireciona para Notícias </returns>
        public IActionResult Cadastrar(IFormCollection form)
        {
            Noticias noticias = new Noticias();
            noticias.IdNoticia = Int32.Parse( form["IdNoticia"]);
            noticias.Titulo = form["Titulo"];
            noticias.Texto = form["Texto"];

            // Upload da imagem
             var file    = form.Files[0];
             var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

            //pastaA , pastaB , pastaC , arquivo.pdf
             
           
            if(file != null)
            {
               
                if(!Directory.Exists(folder)){ //  Se não existir, Cria uma pasta para imagens 
                    Directory.CreateDirectory(folder); //Cria uma pasta para imagens 
                }

                //wwwroot/img/Equipe/arquivo.pdf
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                noticias.Imagem   = file.FileName;
            }
            else
            {
                noticias.Imagem   = "padrao.png";
            }
            // Fim - Upload Imagem

            noticiasModel.Create(noticias);

            return LocalRedirect("~/Noticias");
        }
         
        [Route("[controller]/{id}")]
        public IActionResult Excluir(int id)
        {
         noticiasModel.Delete(id);
         return LocalRedirect("~/Noticias");
        }
    }
}
