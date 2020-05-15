using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteSovos.Domain.DTO
{
    public class ItemPedidoPost : Notifiable, IValidatable
    {

        #region propriedades
        public int ItemPedidoId { get; set; }
        public int Quantidade { get; set; }
        public Double Preco { get; set; }
        public int PedidoId { get; set; }
        public string Descricao { get; set; }
        #endregion

        #region metodos
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Descricao, "Descricao", "Descricao não pode ser vazio")
                .AreEquals(Quantidade, 0, "Quantidade", "Quantidade deve ser maior que zero")
                .AreEquals(Preco, 0.0, "Preço", "Preço deve ser maior que zero")
            );
        }
        #endregion
    }

    public class ItemPedidoGet
    {

        #region propriedades
        public int ItemPedidoId { get; set; }
        public int Quantidade { get; set; }
        public Double Preco { get; set; }
        public int PedidoId { get; set; }
        #endregion

    }
}
