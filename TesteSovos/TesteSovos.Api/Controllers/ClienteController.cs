using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TesteSovos.Domain.DTO;
using TesteSovos.Domain.Interface.Application;

namespace TesteSovos.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {

        private readonly IClienteApplication _cliente;

        public ClienteController(IClienteApplication cliente)
        {
            _cliente = cliente;
        }

        [HttpPost]
        public IActionResult InserirCliente([FromBody] ClientePost cliente)
        {
            try
            {
                cliente.Validate();
                if (cliente.Invalid)
                {
                    return Json(cliente.Notifications);
                }
                else
                {
                     var result = _cliente.InserirCliente(cliente).Result;
                    if (result > 0)
                        return StatusCode(StatusCodes.Status201Created, "Cliente criado com sucesso");
                    else
                        return StatusCode(StatusCodes.Status400BadRequest, "Erro inesperado");
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status400BadRequest, "Erro inesperado");
            }
        }

        [HttpGet, Route("ListarClientes")]
        public JsonResult ListarClientes()
        {
            try
            {   
                var lista = _cliente.ObterClientes().Result;
                if (lista != null && lista.Count > 0)
                {
                    var result = new JsonResult(lista);
                    result.StatusCode = StatusCodes.Status200OK;
                    return result;
                }
                else
                {
                    return new JsonResult(StatusCode(StatusCodes.Status200OK, "Dados não localizados"));
                }
            }
            catch (Exception)
            {

                return new JsonResult(StatusCode(StatusCodes.Status400BadRequest, "Erro inesperado"));
            }
        }

        [HttpGet, Route("ObterCliente/{idCliente}")]
        public JsonResult ListarClientes(int idCliente)
        {
            try
            {
                var cliente = _cliente.ObterCliente(idCliente).Result;
                if (cliente != null)
                {
                    var result = new JsonResult(cliente);
                    result.StatusCode = StatusCodes.Status200OK;
                    return result;
                }
                else
                {
                    return new JsonResult(StatusCode(StatusCodes.Status200OK, "Dados não localizados"));
                }
            }
            catch (Exception)
            {

                return new JsonResult(StatusCode(StatusCodes.Status400BadRequest, "Erro inesperado"));
            }
        }
    }
}