using System.ComponentModel;

Console.WriteLine("---------- Sistema ModernCond ----------");
Console.WriteLine(" 1 - Verificar Lista de moradores ");
Console.WriteLine(" 2 - Verificar Lista de pagamentos ");
Console.WriteLine(" 3 - Verificar Lista de inadimplência\n\n");

string[] meses = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };


var ana = new Apartamento(101, 1, "Ana Silva");
var bruno = new Apartamento(102, 1, "Bruno Souza");
var carla = new Apartamento(201, 2, "Carla Pereira");
var daniel = new Apartamento(202, 2, "Daniel Costa");
var eva = new Apartamento(301, 3, "Eva Lima");
var felipe = new Apartamento(302, 3, "Felipe Rocha");
var gabriela = new Apartamento(401, 4, "Gabriela Mendes");
var hugo = new Apartamento(402, 4, "Hugo Fernandes");

foreach (var mes in meses)
{
    ana.Historico.Add(new Pagamento(mes, 2024, true));
    bruno.Historico.Add(new Pagamento(mes, 2024, true));
    carla.Historico.Add(new Pagamento(mes, 2024, true));
    daniel.Historico.Add(new Pagamento(mes, 2024, true));
    eva.Historico.Add(new Pagamento(mes, 2024, true));
    felipe.Historico.Add(new Pagamento(mes, 2024, true));
    gabriela.Historico.Add(new Pagamento(mes, 2024, true));
    hugo.Historico.Add(new Pagamento(mes, 2024, false));
}

ana.Historico.Find(p => p.Mes == "Março").Pago = false;
carla.Historico.Find(p => p.Mes == "Março").Pago = false;

List<Apartamento> apartamentos = new List<Apartamento>
{
    ana, bruno, carla, daniel, eva, felipe, gabriela, hugo
};


Console.WriteLine("-------- LISTA MORADORES --------\n\n");

apartamentos.ForEach(moradores => moradores.ExibirInfo());



Console.WriteLine("-------- LISTA DE PAGAMENTO -------- ");
apartamentos.Where(a => a.TemDebito).ToList().ForEach(a => a.HistoricoDePagamentos());


Console.WriteLine("-------- LISTA DE INADIMPLENTE -------- ");
apartamentos.Where(a => a.TemDebito).ToList().ForEach(a => a.ExibirInadimplente());

//Console.WriteLine("\n\n-------- LISTA INADIMPLENCIA --------\n");

//apartamentos.Where(a => a.TemDebito).ToList().ForEach(a => a.ExibirInadimplente());