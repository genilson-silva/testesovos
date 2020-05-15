using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteSovos.Domain.DTO;
using TesteSovos.Domain.Interface.Application;
using TesteSovos.Domain.Interface.Infrastructure;
using TesteSovos.Domain.Models;
using TesteSovos.Infrastructure;

namespace TesteSovos.Application
{
    public class PedidoApplication : IPedidoApplication
    {
        private readonly IRepositorioBase<Pedido> repositorioPedidos = new Repositorio<Pedido>();
        private readonly IRepositorioBase<Cliente> repositorioCliente = new Repositorio<Cliente>();

        public async Task<int> InserirPedido(PedidoPost pedido)
        {
            try
            {
                var exiteClienete = await repositorioCliente.BuscaQualquerParametro(x => x.ClienteId == pedido.ClienteId);
                if (exiteClienete != null)
                {
                    Pedido pedidoModel = new Pedido(pedido.Descricao);
                    pedidoModel.DefineClienteId(pedido.ClienteId);
                    pedidoModel.DataInclusao = DateTime.Now;
                    List<ItemPedido> itens = new List<ItemPedido>();
                    foreach (var item in pedido.Itens)
                    {
                        ItemPedido itemModel = new ItemPedido(item.Quantidade, item.Preco, item.Descricao);
                        itemModel.DefinePedidoId(pedidoModel.PedidoId);
                        itemModel.DataInclusao = DateTime.Now;
                        itens.Add(itemModel);
                    }
                    pedidoModel.Itens = itens;
                    var result = await repositorioPedidos.Inserir(pedidoModel);
                    return result.PedidoId;
                }
                else
                {
                    return 0;
                }
                
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }
    }
}
