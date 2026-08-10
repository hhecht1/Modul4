
// namespace ServicesMethodChanging.Kaffeeservice
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Willkommen beim KaffeeService!");
//             var kaffeeService = new KaffeeService()
//                 .WähleSorte("Cappuccino")
//                 .FügeZuckerHinzu(1)
//                 .MitMilch();
//             kaffeeService.Bestellen();
//         }
//     }
// }
// public class KaffeeService
// {
//     private string _kaffeeSorte = "Standard";
//     private int _zuckerMenge = 0;
//     private bool _mitMilch = false;

//     public KaffeeService WähleSorte(string sorte)
//     {
//         _kaffeeSorte = sorte;
//         return this; // Gibt das aktuelle Objekt zurück für die Kette
//     }

//     public KaffeeService FügeZuckerHinzu(int anzahl)
//     {
//         _zuckerMenge = anzahl;
//         return this;
//     }

//     public KaffeeService MitMilch()
//     {
//         _mitMilch = true;
//         return this;
//     }

//     public void Bestellen()
//     {
//         Console.WriteLine($"Dein {_kaffeeSorte} mit {_zuckerMenge} Zucker und Milch={_mitMilch} ist fertig!");
//     }
// }