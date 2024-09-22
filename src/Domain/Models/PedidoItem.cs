namespace Domain.Models;

public class PedidoItem
{
    public Guid Id;
    public string Nome;
    public int Quantidade;
    public decimal ValorUnitario;

    public PedidoItem(Guid id, string nome, int quantidade, decimal valorUnitario)
    {
        Id = id;
        Nome = nome;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
    }
}
