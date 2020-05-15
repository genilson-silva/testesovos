using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteSovos.Domain.DTO;
using TesteSovos.Domain.Interface.Application;

namespace TesteSovos.Api.Controllers
{
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoApplication _pedido;

        public PedidoController(IPedidoApplication pedido)
        {
            _pedido = pedido;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InserirPedido([FromBody] PedidoPost pedido)
        {
            try
            {
                pedido.Validate();
                if (pedido.Invalid)
                {
                    return Json(pedido.Notifications);
                }
                else
                {
                    var result = _pedido.InserirPedido(pedido).Result;
                    if (result > 0)
                        return StatusCode(StatusCodes.Status201Created, "pedido criado com sucesso");
                    else
                        return StatusCode(StatusCodes.Status400BadRequest, "Cliente não localizado");
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest, "Erro inesperado");
            }
        }
    }
}