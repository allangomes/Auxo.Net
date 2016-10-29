using System;
using Auxo.Core;

namespace Auxo.Unit
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}