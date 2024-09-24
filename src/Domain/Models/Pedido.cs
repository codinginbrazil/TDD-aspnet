using Domain.Statics.Enums;
using Domain.Statics.Exceptions;

namespace Domain.Models;

public sealed class Pedido
{
    public static int MAX_UNIDADES_ITEM => 15;

    private readonly List<PedidoItem> _pedidoItens;

    public IReadOnlyCollection<PedidoItem> PedidoItens => _pedidoItens.AsReadOnly();
    public Guid ClienteId { get; private set; }
    public PedidosStatus PedidosStatus { get; private set; }
    public decimal ValorTotal { get; private set; }

    protected Pedido() => _pedidoItens = [];

    public void AdicionarItem(PedidoItem item)
    {
        if (item.Quantidade > MAX_UNIDADES_ITEM)
            throw new DomainException($"Máximo de {MAX_UNIDADES_ITEM} unidades por produto");

        if(_pedidoItens.Any(p => p.Id == item.Id))
        {
            var itemExistente = _pedidoItens.FirstOrDefault(p => p.Id == item.Id);
            itemExistente!.AdicionarUnidades(item.Quantidade);
            item = itemExistente;

            _pedidoItens.Remove(itemExistente);
        }

        _pedidoItens.Add(item);
        CalcularValorPedido();
    }

    public void CalcularValorPedido() => ValorTotal = PedidoItens.Sum(i => i.CalcularValor());

    public void TornarRascunho() => PedidosStatus = PedidosStatus.Rascunho;

    public static class PedidoFactory
    {
        public static Pedido NovoPedidoRascunho(Guid clienteId)
        {
            var pedido = new Pedido
            {
                ClienteId = clienteId,
            };

            pedido.TornarRascunho();
            return pedido;
        }
    }
}

