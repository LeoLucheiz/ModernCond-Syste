class Pagamento
{
    public Pagamento(string mes, int ano, bool pago)
    {
        Mes = mes;
        Ano = ano;
        Pago = pago;
       
    }

    public string Mes { get; set; }
    public int Ano { get; set; }
    public bool Pago { get; set; }

    public double Valor { get;  } = 500.75;


}