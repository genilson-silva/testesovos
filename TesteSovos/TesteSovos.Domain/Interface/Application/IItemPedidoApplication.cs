using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteSovos.Domain.DTO;

namespace TesteSovos.Domain.Interface.Application
{
    public interface IItemPedidoApplication
    {
        Task<bool> InserirItens(List<ItemPedidoPost> itens);
        Task<List<ItemPedidoGet>> ObterItens(int IdPedido);
    }
}
