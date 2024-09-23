namespace Domain.Models;

public sealed class PedidoItem
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public int Quantidade { get; private set; }
    public decimal ValorUnitario { get; private set; }

    public PedidoItem(Guid id, string nome, int quantidade, decimal valorUnitario)
    {
        Id = id;
        Nome = nome;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
    }

    internal void AdicionarUnidades(int unidades) => Quantidade += unidades;

    internal decimal CalcularValor() => Quantidade * ValorUnitario;
}
