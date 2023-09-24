using Lab3.Models;
using QueryBuilderStarter;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace Lab3
{
    internal class Program
    {
        public static string? Root { get; } = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
        static string dbPath = Root + "\\data\\data.db";

        static void Main(string[] args)
        {
             QueryBuilder connection = new QueryBuilder(dbPath);
             Pokemon pokedex = new Pokemon();
             BannedGame bannedGames = new BannedGame();

             var filePath = Root + "\\data\\AllPokemon.csv";

             using (var reader = new StreamReader(filePath))
             {
                 while(!reader.EndOfStream)
                 {
                     var line = reader.ReadLine();
                     var row = line.Split(',');

                     Pokemon p = new Pokemon();

                     p.DexNumber = Convert.ToInt32(row[0]);
                     p.Name = row[1];
                     p.Form = row[2];
                     p.Type1 = row[3];
                     p.Type2 = row[4];
                     p.Total = Convert.ToInt32(row[5]);
                     p.HP = Convert.ToInt32(row[6]);
                     p.Attack = Convert.ToInt32(row[7]);
                     p.Defense = Convert.ToInt32(row[8]);
                     p.SpecialAttack = Convert.ToInt32(row[9]);
                     p.SpecialDefense = Convert.ToInt32(row[10]);
                     p.Speed = Convert.ToInt32(row[11]);
                     p.Generation = Convert.ToInt32(row[12]);

                     connection.Create<Pokemon>(p);
                 }

                 List<Pokemon> pokemonList = connection.ReadAll<Pokemon>();
                 Console.WriteLine("Pokedex: ");
                 foreach (var p in pokemonList)
                 {
                     Console.WriteLine(p);
                 }    
             }

             var filepath2 = Root + "\\data\\BannedGames.csv";

             using(var reader2 = new StreamReader(filepath2))
             {
                 while(!reader2.EndOfStream)
                 {
                     var line = reader2.ReadLine();
                     var row = line.Split(',');

                     BannedGame b = new BannedGame();

                     b.Title = row[0];
                     b.Series = row[1];
                     b.Country = row[2];
                     b.Details = row[3];

                     connection.Create<BannedGame>(b);
                 }

                 List<BannedGame> bannedGamesList = connection.ReadAll<BannedGame>();
                 Console.WriteLine("Banned Games: ");
                 foreach (var b in bannedGamesList)
                 {
                     Console.WriteLine(b);
                 }    
             }

            Console.WriteLine("\nSuccessfully displayed all objects in the database. Press ENTER to continue.");
            Console.ReadLine();
            Console.Clear();
            
            Console.WriteLine("----------------------------------------------------");
            
            int menuInput;

            do
            {
                Console.WriteLine();
                Console.WriteLine("\n     Menu for Lab3 - QueryBuilder");
                Console.WriteLine("     ------------------------\n");
                Console.WriteLine("     1. Create a new pokemon");
                Console.WriteLine("     2. Create a new banned game");
                Console.WriteLine("     3. Display pokedex or banned games");
                Console.WriteLine("     4. Delete a table from the database");
                Console.WriteLine("     5. End the program\n");
                Console.Write($"     Please type the number of your choice: ");

                menuInput = Convert.ToInt32(Console.ReadLine());

                
                switch (menuInput)
                {
                    case 1:
                        Pokemon addedPokemon = new Pokemon();

                        Console.WriteLine("\n----------------------------------------------------");
                        Console.WriteLine("Creating a new pokemon: ");
                        Console.WriteLine("Enter in the following information: ");

                        Console.Write("Dex Number: ");
                        addedPokemon.DexNumber = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Name: ");
                        addedPokemon.Name = Console.ReadLine();

                        Console.Write("Form: ");
                        addedPokemon.Form = Console.ReadLine();

                        Console.Write("Type 1: ");
                        addedPokemon.Type1 = Console.ReadLine();

                        Console.Write("Type 2: ");
                        addedPokemon.Type2 = Console.ReadLine();

                        Console.Write("Total HP: ");
                        addedPokemon.HP = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Total Attack: ");
                        addedPokemon.Attack = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Total Defense: ");
                        addedPokemon.Defense = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Total Special Attack: ");
                        addedPokemon.SpecialAttack = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Total Special Defense: ");
                        addedPokemon.SpecialDefense = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Total Speed: ");
                        addedPokemon.Speed = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Generation: ");
                        addedPokemon.Generation = Convert.ToInt32(Console.ReadLine());

                        addedPokemon.Total = addedPokemon.HP + addedPokemon.Attack + addedPokemon.Defense + addedPokemon.SpecialAttack + addedPokemon.SpecialDefense + addedPokemon.Speed;
                        Console.Write($"Pokemon Total: {addedPokemon.Total} ");

                        connection.Create(addedPokemon);

                        Console.WriteLine("\nYour pokemon has been added to the pokedex.");

                        break;

                    case 2:
                        BannedGame addedBannedGame = new BannedGame();

                        Console.WriteLine("\n----------------------------------------------------");
                        Console.WriteLine("Creating a new banned game: \n");
                        Console.WriteLine("Enter in the following information: ");

                        Console.Write("Title: ");
                        addedBannedGame.Title = Console.ReadLine();

                        Console.Write("Series: ");
                        addedBannedGame.Series = Console.ReadLine();

                        Console.Write("Country banned in: ");
                        addedBannedGame.Country = Console.ReadLine();

                        Console.Write("Details regarding ban: ");
                        addedBannedGame.Details = Console.ReadLine();

                        connection.Create(addedBannedGame);

                        Console.WriteLine("\nYour banned game has been added to the table.");

                        break;

                    case 3:
                        
                        Console.WriteLine("\n----------------------------------------------------");
                        Console.WriteLine("Would you like to see from the pokedex or banned games?");
                        string userinput2 = Console.ReadLine().ToLower().Trim().Substring(0,1);

                        if (userinput2 == "p")
                        {
                                List<Pokemon> pokemonList = connection.ReadAll<Pokemon>();
                                Console.WriteLine("\nPokedex: ");
                                foreach (var p in pokemonList)
                                {
                                    Console.WriteLine(p);
                                }
                        }
                        else if (userinput2 == "b")
                        {
                                List<BannedGame> bannedGamesList = connection.ReadAll<BannedGame>();
                                Console.WriteLine("\nBanned Games: ");
                                foreach (var b in bannedGamesList)
                                {
                                    Console.WriteLine(b);
                                }
                        }

                        Console.WriteLine("\nSuccessfully displayed the objects in the database. Press ENTER to go back to main menu.");
                        Console.ReadLine(); 

                        break;

                    case 4:

                        Console.WriteLine("\n----------------------------------------------------");
                        Console.WriteLine("Would you like to delete from the pokedex or banned games?");
                        string input = Console.ReadLine().ToLower().Trim().Substring(0,1);

                        if(input == "p")
                        {
                            connection.DeleteALL(pokedex);
                            Console.WriteLine("\nThe pokedex has been deleted.");
                        }
                        else if(input == "b")
                        {
                            connection.DeleteALL(bannedGames);
                            Console.WriteLine("\nThe banned games table has been deleted.");
                        }
                        break;
                }
            } while (menuInput != 5);
        }
    }
}