using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Models
{
    internal class BannedGame : IClassModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Series { get; set; }
        public string Country { get; set; }
        public string? Details { get; set; }

        public BannedGame() { }

        public override string ToString()
        {
            string msg = "";

            msg += $"ID: {Id}\n";
            msg += $"Title: {Title}\n";
            msg += $"Series: {Series}\n";
            msg += $"Country: {Country}\n";
            msg += $"Details: {Details}\n";

            return msg;
        }
    }
}
