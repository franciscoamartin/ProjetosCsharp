using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitBasket
{
    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public double Weight { get; set; }

        public Fruit(int id, string name, double weight, string color)
        {
            Id = id;
            Name = name;
            Color = color;
            Weight = weight;
        }
    }
}