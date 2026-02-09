class Apartamento
{
    public int Numero { get; set; }
    public int Andar { get; set; }
    public string NomeMorador { get; set; }
    public List<Pagamento> Historico { get; set; } = new List<Pagamento>();


    public Apartamento(int numero, int andar, string nomeMorador)
    {
        Numero = numero;
        Andar = andar;
        NomeMorador = nomeMorador;

    }

    public bool TemDebito => Historico.Any(p => p.Pago == false);
    public void ExibirInfo()
    {

        string status = TemDebito ? "Sim" : "Não";
        Console.WriteLine($"\nMorador: {NomeMorador}, AP: {Numero}, Andar: {Andar}.\n" +
            $"------------------------------------- ");
       
    }

    public double CalcularDividaTotal()
    {
        
        return Historico.Where(p => !p.Pago).Sum(p => p.Valor);
    }


    public void HistoricoDePagamentos()
    {
        if (TemDebito)
        {
            Console.WriteLine($"Morador: {NomeMorador}, do" +
            $"Apartamento: {Numero}, do {Andar} andar, " +
            $"Valor do condominio:R$ {CalcularDividaTotal():F2}, " +
            $"Meses pagos:");
            var pagamentosEfetuados =Historico.Where(p => p.Pago == true).ToList();
            foreach (var pagamento in pagamentosEfetuados)
            {
                Console.WriteLine($"Condominio do Mês de {pagamento.Mes}/{pagamento.Ano}, Status: Pago");
            }
            Console.WriteLine("------------------------------------");
        }
    }

    public void ExibirInadimplente()
    {
        if (TemDebito)
        {


            Console.WriteLine($"Morador: {NomeMorador}, do" +
            $"Apartamento: {Numero}, do {Andar} andar, " +
            $"Divida total:R$ {CalcularDividaTotal():F2}, " +
            $"Meses pendente:");

            var pendente =Historico.Where(p => p.Pago == false).ToList();
            foreach (var pagamento in pendente)
            {
                Console.WriteLine($"Condominio do Mês de {pagamento.Mes}/{pagamento.Ano}, Status: Pendente");
            }
            Console.WriteLine("------------------------------------");
        }

    }


    // public void AdicionarPagamento(Pagamento pagamento)
    //{ }




}
/*  foreach (var pagamento in Historico)
{
    string pagoStatus = pagamento.Pago ? " Pago" : " Pendente";
    Console.WriteLine($"Condominio do Mês de {pagamento.Mes}/{pagamento.Ano}, Status:{pagoStatus}");
}
*/