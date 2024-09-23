using Domain.Models;

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
        Assert.Equal(expected: 200, actual: pedido.ValorTotal);
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
        Assert.Equal(expected: 300, actual: pedido.ValorTotal);
        Assert.Equal(expected: 1, actual: pedido.PedidoItens.Count);
        Assert.Equal(expected: 3, actual: pedido.PedidoItens.FirstOrDefault(x => x.Id == produtoId).Quantidade);
    }
}
