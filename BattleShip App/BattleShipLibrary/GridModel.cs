using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleShipLibrary
{
    public class GridModel
    {
        public int Carrier { get; set; }
        public int Battleship{ get; set; }
        public int Cruiser { get; set; }
        public int Submarine { get; set; }
        public int Mine { get; set; }

        public List<List<int>> Grid { get; private set; }
        public GridModel()
        {
            Grid = new List<List<int>>();
            Carrier = 0;
            Battleship = 0;
            Cruiser = 0;
            Submarine = 0;
            Mine = 0;
            for (int i = 0; i < 10; i++)
            {
                var row = new List<int>(new int[10]);
                Grid.Add(row);
            }
        }
    }
    public class Probability
    {
        public List<List<int>> Matrix { get; private set; }
        public Probability()
        {
            Matrix = new List<List<int>>();
            for (int i = 0; i < 10; i++)
            {
                var row = new List<int>(new int[10]);
                Matrix.Add(row);
            }
        }
    }
    public class Suita
    {
        public List<bool> Ship { get; private set; }
        public Suita()
        {
            Ship = new List<bool>();
            for (int i = 0; i < 5; i++)
            {
                Ship.Add(false);
            }
        }
    }

}
