using System;
using Auxo.Models;

namespace Auxo.Unit.Models
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}