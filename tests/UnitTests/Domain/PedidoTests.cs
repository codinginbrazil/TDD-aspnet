using Domain.Models;
using Domain.Statics.Exceptions;
using FluentAssertions;

namespace UnitTests.Domain;

public class PedidoTests
{
    [Fact(DisplayName = "Adicionar Item Pedido Vazio")]
    [Trait("Categoria", "Pedido Tests" )]
    public void Trocar_Nome_Metodo()
    {
        // Arrange
        var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(clienteId: Guid.NewGuid());
        var pedidoItem = new PedidoItem(new Guid(), "Produto Teste", 2, 100);

        // Act
        pedido.AdicionarItem(pedidoItem);

        // Assert
        pedido.ValorTotal.Should().Be(200);
    }

    [Fact(DisplayName = "Adicionar Item Pedido Existente")]
    [Trait("categoria", "Pedido Tests")]
    public void AdicionarItemPedido_ItemExistente_DeveIncrementarUnidadesSomarValorres()
    {
        // Arrange
        var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(clienteId: Guid.NewGuid());
        var produtoId = Guid.NewGuid();
        var pedidoItem = new PedidoItem(produtoId, nome: "Produto Teste", quantidade: 2, valorUnitario: 100);
        pedido.AdicionarItem(pedidoItem);

        var pedidoItem2 = new PedidoItem(produtoId, nome: "Produto Teste", quantidade: 1, valorUnitario: 100);

        // Act
        pedido.AdicionarItem(pedidoItem2);

        //Assert
        pedido.ValorTotal.Should().Be(300);
        pedido.PedidoItens.Count.Should().Be(1);
        pedido.PedidoItens.FirstOrDefault(x => x.Id == produtoId).Quantidade.Should().Be(3);
    }

    [Fact(DisplayName = "Adicionar Item Pedido Acima de 15")]
    [Trait("Categoria", "Pedido Tests")]
    public void AdicionarItemPedido_ItemAcimaDe15Unidades_DeveRetornarException()
    {
        // Arrange
        var pedido = Pedido.PedidoFactory.NovoPedidoRascunho(clienteId: Guid.NewGuid());
        var produtoId = Guid.NewGuid();
        var pedidoItem = new PedidoItem(produtoId, nome: "Produto Teste", quantidade: 16, valorUnitario: 100);

        // Act

        //Assert
        Assert.Throws<DomainException>(() => pedido.AdicionarItem(pedidoItem));
    }
}
