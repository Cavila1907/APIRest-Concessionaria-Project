using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICarro.Data.Dtos
{
    public class ReadCarroDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do veículo é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O fabricante do veículo é obrigatório")]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "A cor do veículo é obrigatória")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "A verificação do modelo do motor do veículo é obrigatória")]
        public bool Automatico { get; set; }

        [Range(15000, 30000, ErrorMessage = "O valor minímo é R$15.000 e o valor máximo é R$30.000")]
        public double Valor { get; set; }
    }
}
