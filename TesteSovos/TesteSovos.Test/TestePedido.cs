using NUnit.Framework;
using TesteSovos.Domain.Models;

namespace TesteSovos.Test
{
    [TestFixture]
    public class TestePedido
    {
        [Test]
        public void ClienteComNomeVazio()
        {
            Pedido p = new Pedido("");
            bool vazio = true;
            if (p.Descricao.Equals(string.Empty))
                vazio = false;

            Assert.IsTrue(vazio, "Descrição não pode ser vazio");
        }

        [Test]
        public void PedidoSemCliente()
        {
            Pedido p = new Pedido("Descricao");
            Assert.NotZero(p.ClienteId, "O pedido tem que ter um cliente");
        }
    }
}
