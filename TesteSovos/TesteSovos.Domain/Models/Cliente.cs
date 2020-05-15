using Flunt.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TesteSovos.Domain.Base;

namespace TesteSovos.Domain.Models
{
    public class Cliente : ModelBase
    {

        #region construtor
        public Cliente()
        {

        }

        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
        #endregion

        #region propriedades
        [Key]
        public int ClienteId { get; set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        #endregion
    }
}
