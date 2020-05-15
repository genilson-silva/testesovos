using Flunt.Notifications;
using System;
using System.ComponentModel.DataAnnotations;

namespace TesteSovos.Domain.Base
{
    public class ModelBase //: Notifiable
    {        
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
