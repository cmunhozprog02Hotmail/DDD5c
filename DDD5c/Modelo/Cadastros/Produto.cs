using Modelo.Tabelas;
using System;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Cadastros
{
    public class Produto
    {
        [Display (Name = "ID")]
        public long? ProdutoId { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Nome { get; set; }

        [Display(Name = "Data de Cadastro")]
        [Required(ErrorMessage = "Informe a data de cadastro do produto")]
        public DateTime? DataCadastro { get; set; }

        [Display(Name = "Categoria")]
        public long? CategoriaId { get; set; }

        [Display(Name = "Fabricante")]
        public long? FabricanteId { get; set; }

        public Categoria Categoria { get; set; }
        public Fabricante Fabricante { get; set; }
    }
}