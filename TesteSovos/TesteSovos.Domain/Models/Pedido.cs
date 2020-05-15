using Flunt.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TesteSovos.Domain.Base;

namespace TesteSovos.Domain.Models
{
    public class Pedido : ModelBase
    {
        #region construtor
        public Pedido()
        {

        }

        public Pedido(string descricao)
        {
            Descricao = descricao;
        }
        #endregion

        #region propriedades
        [Key]
        public int PedidoId { get; set; }
        public string Descricao { get; private set; }
        public int ClienteId { get; private set; }
        public virtual ICollection<ItemPedido> Itens { get; set; }
        public virtual Cliente Cliente { get; set; }
        #endregion

        #region metodos
        public void DefineClienteId(int id)
        {
            ClienteId = id;
        }
        #endregion
    }
}
