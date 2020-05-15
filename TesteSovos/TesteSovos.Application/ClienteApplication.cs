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
    public class ClienteApplication : IClienteApplication
    {
        private readonly IRepositorioBase<Cliente> repositorio = new Repositorio<Cliente>();
        private readonly IRepositorioBase<Pedido> repositorioPedidos = new Repositorio<Pedido>();


        public async Task<int> InserirCliente(ClientePost cliente)
        {
            try
            {
                Cliente clieneteModel = new Cliente(cliente.Nome, cliente.Email);
                clieneteModel.DataInclusao = DateTime.Now;
                clieneteModel = await repositorio.Inserir(clieneteModel);
                return clieneteModel.ClienteId;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ClienteGet> ObterCliente(int IdCliente)
        {
            try
            {
                var result = await repositorio.BuscaQualquerParametro(x => x.ClienteId == IdCliente);
                if (result != null)
                {
                    var pedidos = await repositorioPedidos.BuscaTodosQualquerParametro(x => x.ClienteId == IdCliente);
                    ClienteGet cliente = new ClienteGet();
                    cliente.ClienteId = result.ClienteId;
                    cliente.Nome = result.Nome;
                    cliente.Email = result.Email;
                    if (pedidos != null)
                    {
                        foreach (var item in pedidos)
                        {
                            PedidoGet novoPedido = new PedidoGet()
                            {
                                ClienteId = item.ClienteId,
                                Descricao = item.Descricao,
                                PedidoId = item.PedidoId
                            };
                            cliente.Pedidos.Add(novoPedido);
                        }
                    };
                    return cliente;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<ClienteGet>> ObterClientes()
        {
            try
            {
                List<ClienteGet> clientes = new List<ClienteGet>();
                var result = await repositorio.Listar();
                foreach (var item in result)
                {
                    ClienteGet cliente = new ClienteGet()
                    {
                        ClienteId = item.ClienteId,
                        Email = item.Email,
                        Nome = item.Nome
                    };
                    clientes.Add(cliente);
                }
                return clientes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
