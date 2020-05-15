using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteSovos.Domain.DTO;

namespace TesteSovos.Domain.Interface.Application
{
    public interface IClienteApplication
    {
        Task<int> InserirCliente(ClientePost cliente);
        Task<ClienteGet> ObterCliente(int IdCliente);
        Task<List<ClienteGet>> ObterClientes();
    }
}
