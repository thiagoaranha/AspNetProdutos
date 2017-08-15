using DAO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ProdutoDao
    {
        private static readonly Context _context = new Context();

        public List<Produto> GetProdutos()
        {
            return _context.Produtos.ToList();
        }

        public Produto GetById(int id)
        {
            return _context.Produtos.SingleOrDefault(p => p.Id == id);
        }

        public Boolean Update(Produto produtoAlterado)
        {
            var produto = _context.Produtos.SingleOrDefault(p => p.Id == produtoAlterado.Id);

            if (produto != null)
            {
                produto.Nome = produtoAlterado.Nome;
                produto.Categoria = produtoAlterado.Categoria;
                produto.Preco = produtoAlterado.Preco;

                try
                {
                    _context.SaveChanges();
                    return true;
                }
                catch
                {
                    throw new Exception();
                }
            }

            return false;
            
        }

        public Boolean Delete(int id)
        {
            
            try
            {
                var produto = _context.Produtos.SingleOrDefault(p => p.Id == id);
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception();
            }
            

        }

        public Boolean Save(Produto produto)
        {
            try
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
