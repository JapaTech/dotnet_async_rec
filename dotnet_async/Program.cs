void LerArquivo()
{
    var conteudo = File.ReadAllText("voos.txt");
    Console.WriteLine($"Conteúdo: \n{conteudo}");
}

var thread = new Thread(()=> LerArquivo());
thread.Start();

Console.WriteLine("Outras operações.");
Console.ReadKey();