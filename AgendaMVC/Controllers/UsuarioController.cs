using AgendaDataBaseSQL.Repositories;
using AgendaDomain.Entities;
using AgendaDomain.Interfaces.Repositories;
using AgendaDomain.Services;
using AgendaMVC.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AgendaMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private IRepositoryUsuario _repositoryUsuario;
        private ICalculaDiasAniversario _diasAniversario;
                
        public UsuarioController()
        {
            _repositoryUsuario = new RepositoryUsuario();
            _diasAniversario = new GestaoDiasAniversario();
        }

        public UsuarioController(IRepositoryUsuario repositoryUsuario, 
                                ICalculaDiasAniversario diasAniversario)
        {            
            _repositoryUsuario = repositoryUsuario;
            _diasAniversario = diasAniversario;            
        }
        // GET: Usuario
        public ActionResult Index(String termo, Usuario usuario)
        {
            //var _usuarioVM = Mapper.Map<IEnumerable<Usuario>, 
            //IEnumerable <UsuarioViewModel>>(_repositoryUsuario.GetAll(nome));

            //var usuarioViewModel = Mapper.Map<List<Usuario>, 
            //    List<UsuarioViewModel>>(_repositoryUsuario.GetAll(nome));            

            var lista = _repositoryUsuario.GetAll(termo);           

            List<String> aux = new List<String>();            

            for (int i = 0; i < lista.Count; i++)
            {
                var data = lista[i].Nascimento;
                usuario.ProxAniv = _diasAniversario.CacularDiasAniversario(data);

                lista[i].ProxAniv = usuario.ProxAniv;

                if (lista[i].Nome != null)
                {
                    if (lista[i].ProxAniv == 0)
                    {
                        aux.Add(lista[i].Nome);
                    }
                }

            }

            aux.Sort();
            ViewBag.List = aux;

            if (aux.Count == 0)
            {
                ViewBag.Message = "Nenhum aniversariante no dia!";
            }            

            return View(lista.OrderBy(u => u.ProxAniv));
        }

        // GET: Usuario/Details/5
        public ActionResult Details(long? id, Usuario usuario)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            usuario = _repositoryUsuario.GetById(id);
            var retorno = _diasAniversario.CacularDiasAniversario(usuario.Nascimento);
            usuario.ProxAniv = retorno;

            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositoryUsuario.Save(usuario);
                }
                return RedirectToAction("Index");
            }
            catch (DataException /*dataEx*/)
            {
                ModelState.AddModelError("", "Erro ao tentar salvar! " +
                                         "Entre em contato com o administrador do sistema!");
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var usuario = _repositoryUsuario.GetById(id);
            
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositoryUsuario.Update(usuario);
                }
                return RedirectToAction("Index");
            }
            catch (DataException /*dataEx*/)
            {
                ModelState.AddModelError("", "Erro ao tentar Editar! " +
                                         "Entre em contato com o administrador do sistema!");
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var usuario = _repositoryUsuario.GetById(id);
            var retorno = _diasAniversario.CacularDiasAniversario(usuario.Nascimento);
            usuario.ProxAniv = retorno;

            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Usuario usuario)
        {
            try
            {
                usuario = _repositoryUsuario.GetById(usuario.Id);

                if (usuario != null)
                {
                    var result = _repositoryUsuario.Remove(usuario.Id);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                }
                else
                {
                    return HttpNotFound();
                }
                
            }
            catch (DataException /*dataEx*/)
            {
                ModelState.AddModelError("", "Erro ao tentar Excluir! " +
                                         "Entre em contato com o administrador do sistema!");
            }
            return View(usuario);
        }
    }
}
