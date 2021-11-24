using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using CsvHelper;

namespace Cms20LinqOchAnnat
{
    class Program
    {
        static void Main(string[] args)
        {

            var players = ReadAllFromFile();

            var file = File.OpenText("c:\\hello.txt");
            string line;
            while ((line = file.ReadLine()) != null)
            {
                //if (line...)
            }

            file.Close();
            //Från dokumentation 
            // Closes the current stream and releases any resources (such as sockets and file handles) associated with the current stream.
        }


        private static List<Player> ReadAllFromFile()
        {
            using (var reader = new StreamReader(@"..\..\..\Summary.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Player>().ToList();
                    return records;
                }
        }


        //class Program
        //{
        //    static Player FindPlayerByName(List<Player> all, string name)
        //    {
        //        foreach(var p in all)
        //            if (p.Name == name)
        //                return p;
        //        return null;
        //    }

        //    static bool IsForward(Player p)
        //    {
        //        return p.Position == "F";
        //    }
        //    static void Main(string[] args)
        //    {
        //        var listOfAllPlayer = ReadAllFromFile();

        //        var res = listOfAllPlayer
        //            .Where(p => p.Team == "TOR")
        //            .OrderBy(p=>p.Name)
        //            .ThenByDescending(p=>p.Age)
        //            .ToList();

        //        //Player p = listOfAllPlayer.FirstOrDefault(p => p.Name == "Mats");
        //        //Player p = listOfAllPlayer.First(p => p.Name == "Mats");



        //        res = listOfAllPlayer
        //            .Where(p => p.Position == "F" && p.Name.StartsWith("P")  )
        //            .ToList();


        //        res = listOfAllPlayer
        //            .Where(p =>  (p.Position == "F" || p.Position == "D") && 
        //                         p.Name.StartsWith("R")
        //                         )
        //            .ToList();


        //        foreach (var p in res)
        //        {
        //            Console.WriteLine($"{p.Name} {p.Team}");
        //        }



        //        var forwards =
        //            listOfAllPlayer.Where(player =>
        //            {
        //                return player.Position == "C";
        //            }).ToList();

        //        forwards = forwards.OrderBy(player => player.Name).ToList();


        //        var antal =
        //            listOfAllPlayer
        //                .Count(player => player.Team == "BOS");

        //        //var bos =
        //        //    listOfAllPlayer
        //        //        .Where(player => player.Team == "BOS")
        //        //        .ToList();
        //        //int cnt = bos.Count();


        //        var forwards2 =
        //            listOfAllPlayer
        //                .Where(player => player.Position == "C")
        //                .OrderBy(player => player.Name).ToList();


        //        //Player oldestSoFar = listOfAllPlayer[0];
        //        //foreach (var p in listOfAllPlayer)
        //        //    if (p.Age > oldestSoFar.Age)
        //        //        oldestSoFar = p;


        //        foreach (var p in forwards)
        //        {
        //            Console.WriteLine($"{p.Name} {p.Team}");
        //        }



        //        string[] kontaktLista =
        //        {
        //            "Kalle", "Anna", "Pelle",
        //            "Kristina"
        //        };

        //        var k = new List<string>();
        //        foreach (var s in kontaktLista)
        //        {
        //            if (s.StartsWith("K")) k.Add(s);
        //        }
        //        var list = kontaktLista.Where(s =>
        //            {
        //                if (s.StartsWith("K")) return true;
        //                return false;
        //            }
        //            );

        //        list = kontaktLista.Where(s => s.StartsWith("K"))
        //                .ToList();



        //        var playersFromBoston =
        //            listOfAllPlayer.Where(player =>
        //            {
        //                return player.Team == "BOS" ||
        //                       player.Team == "CHI";
        //            }).ToList();


        //        //COnsole.Rea
        //        //var list = from k in listOfAllPlayer
        //        //           where (k.Name == "Mats")
        //        //           select k;





        //        foreach (var player in listOfAllPlayer)
        //        {
        //            //player.Position = positions[rnd.Next(0,positions.Length)];
        //        }


        //        Console.WriteLine("Hello World!");
        //    }

    }
}
