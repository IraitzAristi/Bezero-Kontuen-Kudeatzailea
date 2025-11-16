using System.Formats.Asn1;
using System.IO.Compression;
using System.Reflection;

namespace Proiektua;
public class Program
{
    static string[,] kontuak = new string[50,4]; //sortzen da array bat non jarri ahal dituzu 50 kontu eta kontu bakoitzean 3 informazio edo datu gehiago.
    static string[] mota = {"Soziala", "Lana", "Pertsonala", "Bankukoa", "Educa-koa", "Erosteko", "Entretenimendua"}; //array bat kontu mota desberdinekin (educa-ko kontu bat, erosteko kontu bat, kontu pertsonala, laneko kontu bat...)
    static int kontu_kopurua = 0;
    static bool piztuta = true;
    static void Main(string[] args)
    {
        Console.WriteLine("\n====ALLSECURITY ENPRESARAKO BEZERO KONTUEN KUDEATZAILEA====\n");
        Console.WriteLine("Zure datu guztiak modu seguruan gordetzen ditugu\n");
        while (piztuta)
        {
            Menua();
        }

        Console.WriteLine("Zure datuak seguru daude, Agur");
    }

    public static void Menua()
    {
        Console.WriteLine("--MENUA--");
        Console.WriteLine("1. Kontu berria sortu");
        Console.WriteLine("2. Kontu guztiak ikusi");
        Console.WriteLine("3. Kontuak inportatu");
        Console.WriteLine("4. Kontuak zerrendatu");
        Console.WriteLine("0. Atera\n");
        Console.Write("Aukeratu bat (0-4): ");
        string aukera = Console.ReadLine()!;

        switch (aukera)
        {
            case "1":
                Kontua_berria();
                break;

            case "2":
                Kontuak_ikusi();
                break;
            case "3":

                Datuak_kargatu();
                break;
            case "4":

                Kontuak_zerrendatu();
                break;

            case "0":
                Console.WriteLine("Programatik ateratzen...");
                piztuta = false;
                break;

            default:
                Console.WriteLine("Jarri duzun karakterea ez da egokia.");
                break;
        }
    }

    public static void Kontua_berria()
    {
        if (kontu_kopurua >= 50)
        {
            Console.WriteLine("Gehienez 50 kontu sortu ahal dituzu momentuz.");
            return;
        }

        Console.WriteLine("\n--KONTU BERRI BAT SORTU--");
        Console.WriteLine("1. Gmail");
        Console.WriteLine("2. Facebook");
        Console.WriteLine("3. Instagram");
        Console.WriteLine("4. Amazon");
        Console.WriteLine("5. Educa");
        Console.WriteLine("6. Kutxabank");
        Console.WriteLine("0. Atzera");
        Console.Write("Zerbitzuaren izena (zenbakia ez) edo 0 ateratzeko: ");
        string aukera2 = Console.ReadLine()!;

        if (aukera2 == "0")
        {
            Console.WriteLine("Ateratzen...");
            return;
        }

        Console.Write("\nErabiltzailearen izena: ");
        string erabiltzailea = Console.ReadLine()!;

        Console.Write($"{erabiltzailea} erabiltzailearen pasahitza: ");
        string Pasahitza = Console.ReadLine()!;

        Console.WriteLine("\nKategoriak:");

        for (int i = 0; i < mota.Length; i++) //aldagaia.lenght da python-eko len(aldagaia)
        {
            Console.WriteLine($"{i+1}. {mota[i]}");
        }
        Console.Write($"Aukeratu bat (1-{mota.Length}): ");

        string aukera_mota = Console.ReadLine()!;
        Console.WriteLine($"\nKontua prestatuta: {aukera2} - {erabiltzailea}");
        string plataforma = aukera2; //aldatzen diot izena liatzen naizelako aukera2 izenarekin

        kontuak[kontu_kopurua,0] = plataforma;
        kontuak[kontu_kopurua,1] = erabiltzailea;
        kontuak[kontu_kopurua,2] = Pasahitza;
        kontuak[kontu_kopurua,3] = aukera_mota;
        kontu_kopurua++; //bat gehitu

        Console.WriteLine($"Kontua erregistratu da: {plataforma} - {erabiltzailea}\n");
    }
    public static void Kontuak_ikusi()
    {
        Console.WriteLine("\n--KONTU GUZTIAK--");

        if (kontu_kopurua == 0)
        {
            Console.WriteLine("Ez daude kontuak erregistratuak oraindik");
            return;
        }

        for (int i = 0; i < kontu_kopurua; i++)
        {
            Console.WriteLine($"Kontua #{i+1}");
            Console.WriteLine($"Plataforma: {kontuak[i,0]}");
            Console.WriteLine($"Erabiltzailea: {kontuak[i,1]}");
            Console.WriteLine($"Pasahitza: {kontuak[i,2]}");
            Console.WriteLine($"Mota: {kontuak[i,3]}\n");
        }

        Console.WriteLine($"\nGuztira: {kontu_kopurua} kontu\n");

    }
    public static void Datuak_kargatu()
    {
        if (kontu_kopurua == 0)
        {
            Console.WriteLine("\n--KONTUAK KARGATU--");
            Console.Write("Kontu kopurua kargatzeko: ");
            int kopurua_kargatu = int.Parse(Console.ReadLine()!);
            for (int i = 0; i < kopurua_kargatu; i++)
            {
                Console.Write($"{i+1}. Kontuaren izena: ");
                string erabiltzailea = Console.ReadLine()!;

                Console.Write($"{i+1}. Kontuaren pasahitza: ");
                string pasahitza = Console.ReadLine()!;

                Console.Write($"{i+1}. Kontuaren plataformaren izena (Gmail, Facebook...): ");
                string plataforma = Console.ReadLine()!;

                Console.Write($"{i+1}. Kontuaren mota (Lana, Educa, Erosteko, Pertsonala): ");
                string kontu_mota = Console.ReadLine()!;

                kontuak[i,0] = plataforma;
                kontuak[i,1] = erabiltzailea;
                kontuak[i,2] = pasahitza;
                kontuak[i,3] = kontu_mota;
            }

            kontu_kopurua = kopurua_kargatu;
            Console.WriteLine("Datuak ongi kargatu dira");
        }
        else if (kontu_kopurua > 0)
        {
            Console.WriteLine("Ezin dituzu datuak kargatu beste kontu batzuk sortu dituzulako");
            return;
        }
    }

    public static void Datuak_garbitu()
    {
        Console.WriteLine("\n--DATUAK GARBITU--");

        if (kontu_kopurua == 0)
        {
            Console.WriteLine("Oraindik ez daude konturik erregistratuak, orduan ezin da ezer ezabatu.\n");
            return;
        }

        else if (kontu_kopurua >= 0)
        {
            Console.Write($"Zihur zaude {kontu_kopurua} kontu ezabatu nahi dituzula (B/E): ");
            string aukera3 = Console.ReadLine()!.ToUpper(); //Mayuskulaz jartzen da horrela beti

            if (aukera3 == "B")
            {
                Console.WriteLine($"\nKontu guztiak ({kontu_kopurua} kontu) ezabatu dira.");
                kontu_kopurua = 0;
            }

            else if (aukera3 == "E")
            {
                return;
            }

            else
            {
                Console.WriteLine("\nEz da ezer ezabatu");
                return;
            }
        }
    }
    
    public static void Kontuak_zerrendatu()
    {
        if (kontu_kopurua == 0)
        {
            Console.WriteLine("Oraindik ez daude konturik erregistratuak, orduan ezin da ezer ezabatu.\n");
            return;
        }

        Console.WriteLine("\n--KONTUAK ZERRENDATU--");
        Console.WriteLine("\nZure kontuak: ");

        for (int i = 0; i < kontu_kopurua; i++)
        {
            Console.WriteLine($"{i+1}. {kontuak[i,0]} - {kontuak[i,1]}\n");
        }
    }
}