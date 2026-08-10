using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

public interface IKaffeeService
{
    IKaffeeService WähleSorte(string sorte);
    IKaffeeService FügeZucker(int anzahl);
    IKaffeeService MitMilch();
    void Bestellen();
}

public class KaffeeService2 : IKaffeeService
{
    private string _sorte = "Standard";
    private int _zucker = 0;
    private bool _milch = false;

    public IKaffeeService WähleSorte(string sorte) { _sorte = sorte; return this; }
    public IKaffeeService FügeZucker(int anzahl) { _zucker = anzahl; return this; }
    public IKaffeeService MitMilch() { _milch = true; return this; }

    public void Bestellen()
    {
        Console.WriteLine($"[DI-Service] {_sorte} mit {_zucker}x Zucker und Milch={_milch} serviert.");
    }
}

public class AsyncKaffeeService
{
    private string _sorte = "Filterkaffee";
    private bool _milch = false;

    // Synchrone Konfiguration
    public AsyncKaffeeService WähleSorte(string sorte) { _sorte = sorte; return this; }
    public AsyncKaffeeService MitMilch() { _milch = true; return this; }

    // Asynchrones Finale (Simuliert den Brühvorgang)
    public async Task BestellenAsync()
    {
        Console.WriteLine($"[Async] Starte Brühvorgang für {_sorte}...");
        await Task.Delay(2000); // Simuliert 2 Sekunden Wartezeit
        Console.WriteLine($"[Async] Fertig! Ihr {_sorte} (Milch={_milch}) steht bereit.");
    }
}

public class Program
{
    public static async Task Main()
    {
        var services = new ServiceCollection();
        services.AddTransient<IKaffeeService, KaffeeService2>(); // Registrierung
        var provider = services.BuildServiceProvider();

        // Auflösen des Services und Ausführen der Kette
        var meinKaffee = provider.GetRequiredService<IKaffeeService>();
        meinKaffee
            .WähleSorte("Cappuccino")
            .MitMilch()
            .Bestellen();

        var asyncService = new AsyncKaffeeService();
        // Die Kette läuft synchron, das Await greift erst beim finalen Task
        await asyncService
            .WähleSorte("Late Macchiato")
            .MitMilch()
            .BestellenAsync();
    }
}