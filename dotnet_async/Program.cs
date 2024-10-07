void LerArquivo()
{
    var conteudo = File.ReadAllText("voos.txt");
    Task.Delay(new Random().Next(300, 8000));
    Console.WriteLine($"Conteúdo: \n{conteudo}");
}

void ExibirRelatorio()
{
    Console.WriteLine("Executando relatório de compra de passagens!");
    Task.Delay(new Random().Next(300, 8000));
}

var task1 = Task.Run(()=> LerArquivo());

var task2 = Task.Run(() => ExibirRelatorio());

Console.WriteLine("Outras operações.");
Console.ReadKey();