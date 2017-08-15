using DAO;
using DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Produtos.Controllers
{
    public class ListaProdutosController : ApiController
    {
        // GET api/<controller>
        public List<Produto> Get()
        {
            ProdutoDao _dao = new ProdutoDao();
            var produtos = _dao.GetProdutos();

            return produtos;
        }


    }
}