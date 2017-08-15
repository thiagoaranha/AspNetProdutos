using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Entities
{
    public class Produto
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        [Display(Name = "Data de cadastro")]
        public DateTime DataDeCadastro { get; set; }

        [Required(ErrorMessage = "Nome do produto obrigatório")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Categoria do produto obrigatória")]
        public String Categoria { get; set; }

        [DisplayFormat(DataFormatString = "{0:F}")]
        [Display(Name = "Preço")]
        [Required(ErrorMessage = "Preço do produto obrigatório")]
        public Double Preco { get; set; }

    }
}
