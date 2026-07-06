using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
    // Wir nutzen Port 5000 für die Kommunikation
    private const int Port = 5000;

    static void Main(string[] args)
    {
        Console.Title = "Einfacher C# Konsolen-Chat";
        Console.WriteLine("--- Chat-App wird gestartet ---");

        // 1. SERVER STARTEN (im Hintergrund-Thread)
        Thread serverThread = new Thread(StartServer);
        serverThread.IsBackground = true; // Schließt sich automatisch, wenn die App beendet wird
        serverThread.Start();

        // Ein kurzer Moment Wartezeit, damit die Server-Ausgabe zuerst erscheint
        Thread.Sleep(500);

        // 2. CLIENT STARTEN (im Haupt-Thread)
        StartClient();
    }

    // =========================================================================
    // SERVER-LOGIK (Empfangen von Nachrichten)
    // =========================================================================
    static void StartServer()
    {
        try
        {
            // Höre auf allen verfügbaren Netzwerkschnittstellen (IPs) auf Port 5000
            TcpListener server = new TcpListener(IPAddress.Any, Port);
            server.Start();
            Console.WriteLine($"[Server] Gestartet. Warte auf Verbindungen auf Port {Port}...");

            while (true)
            {
                // Warte blockierend, bis sich ein Client verbindet
                TcpClient connectedClient = server.AcceptTcpClient();
                Console.WriteLine("\n[Server] Ein Chat-Partner hat sich verbunden!");

                // Starte das Lesen der Nachrichten in einer Schleife
                NetworkStream stream = connectedClient.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead;

                // Lies den Stream, solange Daten gesendet werden
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Farbige Ausgabe für empfangene Nachrichten zur besseren Unterscheidung
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n[Partner]: {message}");
                    Console.ResetColor();
                    Console.Write("[Du]: "); // Cursor wieder für die eigene Eingabe bereitstellen
                }

                Console.WriteLine("\n[Server] Verbindung vom Partner geschlossen.");
                connectedClient.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Server-Fehler]: {ex.Message}");
        }
    }

    // =========================================================================
    // CLIENT-LOGIK (Senden von Nachrichten)
    // =========================================================================
    static void StartClient()
    {
        Console.WriteLine("\nBitte Ziel-IP-Adresse eingeben (z. B. 127.0.0.1 für lokalen Test):");
        Console.Write("IP: ");
        string targetIp = Console.ReadLine();

        // Wenn die Eingabe leer ist, nutzen wir standardmäßig localhost
        if (string.IsNullOrWhiteSpace(targetIp))
        {
            targetIp = "127.0.0.1";
        }

        TcpClient client = new TcpClient();

        try
        {
            Console.WriteLine($"[Client] Verbinde mit {targetIp} auf Port {Port}...");
            client.Connect(targetIp, Port);
            Console.WriteLine("[Client] Erfolgreich verbunden! Schreibe eine Nachricht und drücke Enter.");

            NetworkStream stream = client.GetStream();

            while (true)
            {
                Console.Write("[Du]: ");
                string message = Console.ReadLine();

                if (string.IsNullOrEmpty(message)) continue;
                if (message.ToLower() == "exit") break;

                // Konvertiere den Text in ein Byte-Array und sende es
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }

            stream.Close();
            client.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Client-Fehler]: Verbindung fehlgeschlagen ({ex.Message})");
            Console.WriteLine("Drücke Enter, um das Programm zu beenden.");
            Console.ReadLine();
        }
    }
}