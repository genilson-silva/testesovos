using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteSovos.Domain.DTO;
using TesteSovos.Domain.Interface.Application;

namespace TesteSovos.Application
{
    public class ItemPedidoApplication : IItemPedidoApplication
    {
        public Task<bool> InserirItens(List<ItemPedidoPost> itens)
        {
            throw new NotImplementedException();
        }

        public Task<List<ItemPedidoGet>> ObterItens(int IdPedido)
        {
            throw new NotImplementedException();
        }
    }
}
