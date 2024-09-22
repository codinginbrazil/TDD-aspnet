namespace Domain.Models;

public class Pedido
{
    public decimal ValorTotal { get; private set; } 

    public void AdicionarItem(PedidoItem item)
    {
        ValorTotal = item.ValorUnitario * item.Quantidade;
    }
}
