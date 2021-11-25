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

        static bool FilterPlayer(Player p)
        {
            if(p.GamesPlayed > 100)
                return true;
            return false;
        }

        static void Main(string[] args)
        {

            var players = ReadAllFromFile();
            ////foreach(var p in players)
            ////{
            ////    Console.WriteLine(p.Name);
            ////}

            //Console.WriteLine("Skriv in lag");
            //string team = Console.ReadLine();
            ////Skriv ut alla spelare i EDM
            ////      SELECT * Player WHERE Team='{team}' ORDER By Namn DESC


            //Console.WriteLine(players.Count());
            ////SKriva ut hur många som gjort minst 30 mål
            ////var filter = players.Where(r => r.Goals > 30).ToList();
            ////Console.WriteLine(filter.Count());

            //var cnt = players.Count(p => p.Goals > 30);



            //var lista = players.Where(p => p.Team == "EDM").ToList(); //List<Player>


            //foreach (var player in lista)
            //{
            //    Console.WriteLine($"{player.Name}");
            //}

            ////ALLT vi gör funkar ju på primitiva datatyper (int, string osv osv) men ofta är det objekt
            ////vi jobbar med

            //var allaSiffror = new[] { 11, 4,123,56,778,12345 };
            //foreach( var i in allaSiffror.Where(t => t < 100) )
            //{
            //    Console.WriteLine(i);
            //}
            ////Minsta talet?
            //var minsta = allaSiffror.Min();
            //var avg = allaSiffror.Average();

            //// average
            //// summan av alla?


            // FIRST  = single
            // ta fram (ENDA) spelaren som heter "Mika Zibanejad"
            var player = players.First(r => r.Name == "Mika Zibanejad");
            player.Goals = player.Goals + 10;


            // Skriv ut spelaren "Stefan Holmberg" poäng
            player = players.FirstOrDefault(r => r.Name == "Stefan Holmberg");
            //ANTINGEN OBJEKTET eller NULL
            // Men den kraschar inte
            if (player == null)
                Console.WriteLine("Den nollan finns ju inte i topp 100 i NHL dummer");



            //Alla vars namn börjar på P


            //foreach (var player2 in players.Where(p => FilterPlayer(p)))
            //{
            //    Console.WriteLine(player2.Name);
            //}

            //LAMBDA EXPRESSION Where -> True eller false

            foreach (var player2 in players.Where(p => p.Name.StartsWith("P") && (p.Team == "EDM" || p.Team == "NYR") ))
            { 
                Console.WriteLine(player2.Name); 
            }



            foreach (var player2 in players.OrderBy(p => p.Name ))
            {
                Console.WriteLine(player2.Name);
            }



            //var file = File.OpenText("c:\\hello.txt");
            //string line;
            //while ((line = file.ReadLine()) != null)
            //{
            //    //if (line...)
            //}

            //file.Close();
            ////Från dokumentation 
            //// Closes the current stream and releases any resources (such as sockets and file handles) associated with the current stream.
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
