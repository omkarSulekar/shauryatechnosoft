using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API_MicroServices.Models
{
    public class User
    {
        public int userid { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Organization { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Photopath { get; set; }
    }
}
