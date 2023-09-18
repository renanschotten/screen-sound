using System.Collections.Generic;
using System.Linq.Expressions;
Dictionary<String, List<int>> bands = new Dictionary<String, List<int>>();
bands.Add("Iron Maiden", new List<int> { 10, 8, 6 });
bands.Add("AC/DC", new List<int>());

void ShowMenuOptions()
{
    ShowGreeting();
    Console.WriteLine("1 - Registrar uma banda");
    Console.WriteLine("2 - Mostrar todas as bandas");
    Console.WriteLine("3 - Avaliar uma banda");
    Console.WriteLine("4 - Exibir a media de uma banda");
    Console.WriteLine("0 - Sair");
    Console.Write("Digite sua opcao: ");
    string option = Console.ReadLine()!;
    int optionInt = int.Parse(option);
    switch (optionInt)
    {
        case 1:
            RegisterBand();
            break;
        case 2:
            ShowBand();
            break;
        case 3:
            RateBand();
            break;
        case 4:
            BandAvarege();
            break;
        case 0:
            Console.WriteLine("Finalizando...");
            break;
        default:
            Console.WriteLine("Opcao nao valida");
            break;
    }
}

void ShowGreeting()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Bem-vindo ao Screen Sound\n");
}

void RegisterBand()
{
    Console.Clear();
    ShowOptionsTitle("Registro de Bandas");
    bool finish = false;
    while (!finish)
    {
        Console.Write("Digite o nome da banda [sair/SAIR para sair]: ");
        string band = Console.ReadLine()!;
        if (band.ToUpper() == "SAIR")
        {
            finish = true;
        }
        else
        {
            bands.Add(band, new List<int>());
            Console.WriteLine($"Banda {band} adicionada com sucesso");
        }
    }
    Console.Clear();
    ShowMenuOptions();
}
void ShowBand()
{
    Console.Clear();
    if (bands.Count > 0)
    {
        ShowOptionsTitle("Bandas Cadastradas");
        foreach (string item in bands.Keys)
        {
            Console.WriteLine($"Banda: {item}");
        }
        Console.Write("Pressione qualquer tecla para voltar");
        Console.ReadKey();
        Console.Clear();
        ShowMenuOptions();
    }
    else
    {
        Console.WriteLine("\nNao ha bandas cadastradas\n");
        Console.Write("Pressione qualquer tecla para voltar");
        Console.ReadKey();
        Console.Clear();
        ShowMenuOptions();
    }
}

void RateBand()
{
    Console.Clear();
    ShowOptionsTitle("Avaliar banda");
    Console.Write("Nome da banda a ser avaliada: ");
    string bandName = Console.ReadLine()!;
    if (bands.ContainsKey(bandName))
    {
        Console.Write($"Digite a nota para {bandName}: ");
        int note = int.Parse(Console.ReadLine()!);
        bands[bandName].Add(note);
        Console.WriteLine("Nota registrada!");
        Thread.Sleep(1000);
        Console.Clear();
        ShowMenuOptions();
    }
    else
    {
        Console.WriteLine($"\nBanda {bandName} nao encontrada!");
        Console.Write("Pressione qualquer tecla para voltar");
        Console.ReadKey();
        Console.Clear();
        ShowMenuOptions();
    }

}

void BandAvarege()
{
    Console.Clear();
    ShowOptionsTitle("Media de nota da banda");
    Console.Write("Nome da banda a ser pesquisada: ");
    string bandName = Console.ReadLine()!;
    if (bands.ContainsKey(bandName))
    {
        Console.WriteLine($"A media de nota da banda {bandName} e: {bands[bandName].Average()}");
        Console.Write("Pressione qualquer tecla para voltar");
        Console.ReadKey();
        Console.Clear();
        ShowMenuOptions();
    }
    else
    {
        Console.WriteLine($"\nBanda {bandName} nao encontrada!");
        Console.Write("Pressione qualquer tecla para voltar");
        Console.ReadKey();
        Console.Clear();
        ShowMenuOptions();
    }

}
void ShowOptionsTitle(string title)
{
    int lettersQuantity = title.Length;
    string asterisks = string.Empty.PadLeft(lettersQuantity, '*');
    Console.WriteLine(asterisks);
    Console.WriteLine(title);
    Console.WriteLine(asterisks + "\n");
}


ShowMenuOptions();
