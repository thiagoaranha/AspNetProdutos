using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using DAO.Entities;

namespace Produtos.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoDao _dao = new ProdutoDao();

        public ActionResult Index(int? pagina, string filtroAtual, string busca)
        {
            var produtos = _dao.GetProdutos();

            if (busca != null)
            {
                pagina = 1;
            }
            else
            {
                busca = filtroAtual;
            }

            if (!String.IsNullOrEmpty(busca))
            {
                produtos = produtos.Where(s => s.Nome.ToLower().Contains(busca.ToLower())).ToList();
            }

            var itensPorPagina = 10;
            var numeroDaPagina = (pagina ?? 1);
            return View(produtos.ToPagedList(numeroDaPagina, itensPorPagina));
        }

        public ActionResult Edit(int id)
        {
            var produto = _dao.GetById(id);

            if (produto != null)
            {
                return View("Edit", produto);
            }

            return View("Index");
        }

        public ActionResult Update(Produto produtoAlterado)
        {

            if (ModelState.IsValid)
            {

                if (_dao.Update(produtoAlterado))
                {
                    TempData["message"] = "Produto alterado com sucesso.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["message"] = "Nao for possivel alterar o Produto.";
                    return View("Edit", produtoAlterado);
                }

            }
            return View("Edit", produtoAlterado);
        }

        public ActionResult Delete(int id)
        {

            if (_dao.Delete(id))
            {
                TempData["message"] = "Produto excluido com sucesso.";
                return RedirectToAction("Index");
            }

            TempData["message"] = "Nao foi possivel excluir, produto nao encontrado.";
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            return View("Add");
        }

        public ActionResult Save(Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.DataDeCadastro = DateTime.Now;

                if (_dao.Save(produto))
                {
                    TempData["message"] = "Produto inserido com sucesso.";
                    return RedirectToAction("Index");
                }

            }

            return View("Add");
        }

    }
}