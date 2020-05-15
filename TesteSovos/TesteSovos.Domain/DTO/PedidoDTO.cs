using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteSovos.Domain.DTO
{
    public class PedidoPost : Notifiable, IValidatable
    {
        #region construtor
        public PedidoPost()
        {
            Itens = new List<ItemPedidoPost>();
        }
        #endregion

        #region propriedades
        public int PedidoId { get; set; }
        public string Descricao { get; set; }
        public int ClienteId { get; set; }
        public List<ItemPedidoPost> Itens { get; set; }
        #endregion

        #region metodos
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Descricao, "Descrição", "Descrição deve ser preenchida")
            );
        }
        #endregion
    }

    public class PedidoGet
    {
        #region propriedades
        public int PedidoId { get; set; }
        public string Descricao { get; set; }
        public int ClienteId { get; set; }
        #endregion

    }
}
