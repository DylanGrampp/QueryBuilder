using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Models
{
    internal class Pokemon : IClassModel
    {
        public int Id { get; set; }
        public int DexNumber { get; set; }
        public string Name { get; set; }
        public string? Form { get; set; }
        public string Type1 { get; set; }
        public string? Type2 { get; set; }
        public int Total { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }

        public Pokemon() { }

        public override string ToString()
        {
            string msg = "";

            msg += $"ID: {Id}\n";
            msg += $"Dex Number: {DexNumber}\n";
            msg += $"Name: {Name}\n";
            msg += $"Form: {Form}\n";
            msg += $"Type1: {Type1}\n";
            msg += $"Type2: {Type2}\n";
            msg += $"Total: {Total}\n";
            msg += $"HP: {HP}\n";
            msg += $"Attack: {Attack}\n";
            msg += $"Defense: {Defense}\n";
            msg += $"Special Attack: {SpecialAttack}\n";
            msg += $"Special Defense: {SpecialDefense}\n";
            msg += $"Speed: {Speed}\n";
            msg += $"Generation: {Generation}\n";

            return msg;
        }
    }
}
