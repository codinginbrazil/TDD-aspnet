using Domain.Models;

namespace UnitTests.Domain;

public class PedidoTests
{
    [Fact(DisplayName = "Adicionar Item Pedido Vazio")]
    [Trait("Categoria", "Pedido Tests" )]
    public void Trocar_Nome_Metodo()
    {
        // Arrange
        var pedido = new Pedido();
        var pedidoItem = new PedidoItem(new Guid(), "Produto Teste", 2, 100);

        // Act
        pedido.AdicionarItem(pedidoItem);
        
        // Assert
        Assert.Equal(expected: 200, actual: pedido.ValorTotal);
    }
}
