using NUnit.Framework;
using TesteSovos.Domain.Models;

namespace TesteSovos.Test
{
    [TestFixture]
    public class TesteCliente
    {
        [Test]
        public void ClienteComNomeVazio()
        {
            Cliente c = new Cliente("","cliente@cliente.com");
            bool vazio = true;
            if (c.Nome.Equals(string.Empty))
                vazio = false;
            
            Assert.IsTrue(vazio, "Nome não pode ser vazio");
        }

        [Test]
        public void ClienteComEmailVazio()
        {
            Cliente c = new Cliente("Nome", "");
            bool vazio = true;
            if (c.Email.Equals(string.Empty))
                vazio = false;

            Assert.IsTrue(vazio, "E-mail não pode ser vazio");
        }
    }
}
