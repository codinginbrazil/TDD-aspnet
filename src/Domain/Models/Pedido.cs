namespace Domain.Models;

public sealed class Pedido
{
    private readonly List<PedidoItem> _pedidoItens;
    public IReadOnlyCollection<PedidoItem> PedidoItens => _pedidoItens.AsReadOnly();
    public decimal ValorTotal { get; private set; }

    public Pedido() => _pedidoItens = [];

    public void AdicionarItem(PedidoItem item)
    {
        _pedidoItens.Add(item);
        ValorTotal = PedidoItens.Sum(i => i.ValorUnitario * i.Quantidade);
    }
}
