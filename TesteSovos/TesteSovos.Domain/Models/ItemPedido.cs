using Flunt.Validations;
using System;
using System.ComponentModel.DataAnnotations;
using TesteSovos.Domain.Base;

namespace TesteSovos.Domain.Models
{
    public class ItemPedido : ModelBase
    {
        #region construtor
        public ItemPedido()
        {

        }

        public ItemPedido(int quantidade, double preco, string descricao)
        {
            Quantidade = quantidade;
            Preco = preco;
            Descricao = descricao;
        }
        #endregion

        #region propriedades
        [Key]
        public int ItemPedidoId { get; set; }
        public int Quantidade { get; private set; }
        public Double Preco { get; private set; }
        public int PedidoId { get; private set; }
        public string Descricao { get; private set; }
        public virtual Pedido Pedido { get; set; }
        #endregion
        #region metodos
        public void DefinePedidoId(int id)
        {
            PedidoId = id;
        }
        #endregion

    }
}
