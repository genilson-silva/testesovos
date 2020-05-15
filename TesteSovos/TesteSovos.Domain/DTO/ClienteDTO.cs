using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TesteSovos.Domain.DTO
{
    public class ClientePost : Notifiable, IValidatable
    {
        
        #region propriedades
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        #endregion

        #region metodos
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome, "Nome", "Nome deve ser preenchido")
                .IsEmailOrEmpty(Email, "E-mail", "E-mail deve ser preenchido corretamente")
            );
        }
        #endregion
    }

    public class ClienteGet
    {
        #region construtor
        public ClienteGet()
        {
            Pedidos = new List<PedidoGet>();
        }
        #endregion

        #region propriedades
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<PedidoGet> Pedidos { get; set; }
        #endregion

    }
}
