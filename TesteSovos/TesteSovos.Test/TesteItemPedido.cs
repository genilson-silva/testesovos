using NUnit.Framework;
using TesteSovos.Domain.Models;

namespace TesteSovos.Test
{
    [TestFixture]
    public class TesteItemPedido
    {
        [Test]
        public void ItemPedidoComPrecoZero()
        {
            ItemPedido p = new ItemPedido(1, 0,"Descricao");
            Assert.Greater(p.Preco,0, "Preço tem que ser mair que zero");
        }

        [Test]
        public void ItemPedidoComQuantidadeZero()
        {
            ItemPedido p = new ItemPedido(0, 1, "Descricao");
            Assert.Greater(p.Quantidade, 0, "Preço tem que ser mair que zero");
        }
    }
}
