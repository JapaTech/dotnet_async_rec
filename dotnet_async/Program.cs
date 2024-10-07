void LerArquivo()
{
    var conteudo = File.ReadAllText("voos.txt");
    Console.WriteLine($"Conteúdo: \n{conteudo}");
}
LerArquivo();
Console.WriteLine("Outras operações.");
Console.ReadKey();