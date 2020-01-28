using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDomain.Entities
{
    public class Usuario
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Campo nome é obrigatório!")]
        [Display(Name = "Nome")]
        public String Nome { get; set; }

        [Display(Name = "Sobrenome")]
        public String SobreNome { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        [Display(Name = "E-mail")]
        public String Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Column("Nascimento")]

        public DateTime Nascimento { get; set; }
        [Display(Name = "Dias Próximo Aniversário")]
        public int ProxAniv { get; set; }
    }
}
