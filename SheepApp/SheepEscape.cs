using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SheepApp;

public class SheepEscape
{
    public void Run()
    {
        var inputPath = "./Data.txt";
        var outputPath = "./OutputData.txt";

        var method = GetData(inputPath);

        foreach (var segment in method)
        {
            int result = Method(segment);

            WriteIntoFile(outputPath, $"Projde: {result} ovcí"); //Zápis do souboru.
        }

    }
    int Method(OopClass segment)
    {
        int result = 0;
        int x = Math.Min(segment.A, segment.B);

        if (x > 0)
        {
            result += x;
            segment.A -= x;
            segment.B -= x;
        }

        int y = Math.Min(segment.D, segment.E);

        if (y > 0)
        {
            result += y;
            segment.D -= y;
            segment.E -= y;
        }

        result += Math.Min(segment.A, Math.Min(segment.C, segment.E));
        result += Math.Min(segment.B, Math.Min(segment.C, segment.D));

        return result;

    }

    public OopClass[] GetData(string x)
    {
        var lines = File.ReadAllLines(x);
        int segmentCount = SafelyConvertToInt(lines[0]); //Toto je počet segmentů
        var informations = new OopClass[segmentCount];

        for (int i = 0; i < segmentCount; i++) //segmentCount je tam proto, že iterace se vykoná tolikrát, kolik je segmentů. Každý segment má svoje cesty na jednom řádku v txt.
        {
            var split = lines[i + 1].Split(' '); //Musíme začínat od druhého řádku, protože na prvním je počet segmentů.
            informations[i] = new()
            {
                Segments = i + 1,
                A = int.Parse(split[0]), //Hodnota pro A
                B = int.Parse(split[1]), //Hodnota pro B
                C = int.Parse(split[2]), //Hodnota pro C
                D = int.Parse(split[3]), //Hodnota pro D
                E = int.Parse(split[4])  //Hodnota pro E
            };
        }
        return informations;
    }
    public void WriteIntoFile(string path, string content)
    {
        using var sr = new StreamWriter(path, true);
        sr.WriteLine(content);
    }

    public int SafelyConvertToInt(string input)
    {
        if (int.TryParse(input, out int result))
        {
            return result;
        }
        else
        {
            return 0;
        }
    }
    public void PrintDeLimter()
    {
        Console.WriteLine();
        Console.WriteLine("-----------------------");
        Console.WriteLine();
    }
}