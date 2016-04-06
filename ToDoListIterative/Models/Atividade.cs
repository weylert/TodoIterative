using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListIterative.Models
{
    [Table("Atividades")]
    public class Atividade
    {
        /// <summary>
        /// Chave da Atividade
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Título da Atividade
        /// </summary>
        [Required(ErrorMessage = "Campo Título é obrigatório"),
            MaxLength(250, ErrorMessage = "Tamanho máximo para o campo Título é 250"),
            MinLength(1, ErrorMessage = "Tamanho minimo para o campo Título é '")]
        public String Titulo { get; set; }

        /// <summary>
        /// Status da Atividade
        /// </summary>
        [Column("Status")]
        public bool StatusConclusao { get; set; }
    }
}
