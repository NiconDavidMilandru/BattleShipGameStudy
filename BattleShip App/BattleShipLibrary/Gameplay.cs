using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace BattleShipLibrary
{
    public class Gameplay
    {
        public static bool Win(GridModel grid)
        {
            int s = grid.Carrier + grid.Battleship + grid.Cruiser + grid.Submarine + grid.Mine;
            if (s == 0)
                return true;
            return false;
        }
        public static int EasyGuess(GridModel grid)
        {
            while (true)
            {
                Random rnd = new();
                int x = rnd.Next(0, 10);
                int y = rnd.Next(0, 10);
                if (grid.Grid[x][y] != -1)
                {
                    int aux = grid.Grid[x][y];
                    grid.Grid[x][y] = -1;
                    return aux;
                }
            }
            return 0;
        }
        public static void Destroy (GridModel grid, int aux)
        {
            switch(aux)
            {
                case 0:
                    return;
                case 5:
                    grid.Carrier--;
                    return;
                case 4:
                    grid.Battleship--;
                    return;
                case 3:
                    grid.Cruiser--;
                    return;
                case 2:
                    grid.Submarine--;
                    return;
                case 1:
                    grid.Mine--;
                    return;
            }
        }
        public static void Destroy1(GridModel grid, int aux, Suita s)
        {
            switch (aux)
            {
                case 0:
                    return;
                case 5:
                    grid.Carrier--;
                    if(grid.Carrier == 0)
                        s.Ship[4] = true;
                    return;
                case 4:
                    grid.Battleship--;
                    if (grid.Battleship == 0)
                        s.Ship[3] = true;
                    return;
                case 3:
                    grid.Cruiser--;
                    if (grid.Cruiser == 0)
                        s.Ship[2] = true;
                    return;
                case 2:
                    grid.Submarine--;
                    if (grid.Submarine == 0)
                        s.Ship[1] = true;
                    return;
                case 1:
                    grid.Mine--;
                    if (grid.Mine == 0)
                        s.Ship[0] = true;
                    return;
            }
        }
        public static int EasyBot()
        {
            GridModel player1 = new GridModel();

            GridModel player2 = new GridModel();
            Place(player2);
            int moves = 0;
            while(true)
            {
                int a=EasyGuess(player2);
                Destroy(player2, a);
                bool ok = Win(player2);
                moves++;
                if (ok)
                    break;
            }
            return moves;
        }
        public static int MediumBot()
        {
            GridModel player1 = new GridModel();
            GridModel player2 = new GridModel();
            Place(player2);
            int moves = 0;
            Probability m = new Probability();
            Suita suita = new Suita();

            m = Generare(suita, player2);

            List<int> di = new();
            di.Add(0);
            di.Add(0);
            di.Add(-1);
            di.Add(1);
            List<int> dj = new();
            dj.Add(1);
            dj.Add(-1);
            dj.Add(0);
            dj.Add(0);
            while (true)
            {
                Random rnd = new();
                int x = -1, y = -1;
                int maxi = -1000;
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                        if (m.Matrix[i][j] > maxi)
                        {
                            maxi = m.Matrix[i][j];
                            x = i;
                            y = j;
                        }
                if (player2.Grid[x][y] != -1)
                {
                    moves++;
                    int aux = player2.Grid[x][y];
                    player2.Grid[x][y] = -1;
                    Destroy1(player2, aux, suita);
                    m.Matrix[x][y] = -10000;
                    if (aux > 0)
                    {
                        Stack<Tuple<int, int>> Q = new();
                        var pair = Tuple.Create(x, y);
                        Q.Push(pair);
                        while (Q.Count() > 0)
                        {
                            var curent = Q.Pop();
                            for (int i = 0; i < 4; i++)
                            {
                                int new_x = curent.Item1 + di[i];
                                int new_y = curent.Item2 + dj[i];
                                if (Inside(new_x, new_y))
                                    if (player2.Grid[new_x][new_y] > 0)
                                    {
                                        int new_aux = player2.Grid[new_x][new_y];
                                        player2.Grid[new_x][new_y] = -1;
                                        Destroy1(player2, new_aux, suita);
                                        m.Matrix[new_x][new_y]=-10000;
                                        moves++;
                                        if (new_aux > 0)
                                        {
                                            var new_curent = Tuple.Create(new_x, new_y);
                                            Q.Push(new_curent);
                                        }
                                    }
                            }
                        }
                    }
                }
                if (Win(player2) == true)
                    break;
            }
            return moves;
        }

        public static void Probabilitate_Calcul(Probability m, bool broken, GridModel player2, int length)
        {
            if (broken)
                return;
            if (length == 1)
            {
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                        if (player2.Grid[i][j] != -1)
                            m.Matrix[i][j]++;
                return;
            }
            for(int i=0;i<10;i++)
                for(int j=0;j<10;j++)
                {
                    int total = 0;
                    for (int l = 0; l < length; l++)
                        if (Inside(i, j + l) && player2.Grid[i][j + l] != -1)
                            total++;
                    if(total==length)
                        for (int l = 0; l < length; l++)
                            m.Matrix[i][j+l]++;
                }
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                {
                    int total = 0;
                    for (int l = 0; l < length; l++)
                        if (Inside(i + l, j) && player2.Grid[i + l][j] != -1)
                            total++;
                    if (total == length)
                        for (int l = 0; l < length; l++)
                            m.Matrix[i + l][j]++;
                }
        }
        public static Probability Generare(Suita s, GridModel player2)
        {
            Probability m = new Probability();
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    if (player2.Grid[i][j] == -1)
                        m.Matrix[i][j] = -1000;
                    else
                        m.Matrix[i][j] = 0;
            Probabilitate_Calcul(m, s.Ship[4], player2, 5);
            Probabilitate_Calcul(m, s.Ship[3], player2, 4);
            Probabilitate_Calcul(m, s.Ship[2], player2, 3);
            Probabilitate_Calcul(m, s.Ship[1], player2, 2);
            Probabilitate_Calcul(m, s.Ship[0], player2, 1);
            return m;
        }
        public static int ImpossibleBot()
        {
            GridModel player1 = new GridModel();
            GridModel player2 = new GridModel();
            Place(player2);
            int moves = 0;
            Probability m = new Probability();
            Suita suita = new Suita();

            m = Generare(suita, player2);

            List<int> di = new();
            di.Add(0);
            di.Add(0);
            di.Add(-1);
            di.Add(1);
            List<int> dj = new();
            dj.Add(1);
            dj.Add(-1);
            dj.Add(0);
            dj.Add(0);
            while (true)
            {
                Random rnd = new();
                int x = -1, y = -1;
                int maxi = -1000;
                for(int i=0;i<10;i++)
                    for(int j=0;j<10;j++)
                        if (m.Matrix[i][j]>maxi)
                        {
                            maxi=m.Matrix[i][j];
                            x = i;
                            y = j;
                        }
                if (player2.Grid[x][y] != -1)
                {
                    moves++;
                    int aux = player2.Grid[x][y];
                    player2.Grid[x][y] = -1;
                    Destroy1(player2, aux, suita);
                    if (aux > 0)
                    {
                        Stack<Tuple<int, int>> Q = new();
                        var pair = Tuple.Create(x, y);
                        Q.Push(pair);
                        while (Q.Count() > 0)
                        {
                            var curent = Q.Pop();
                            for (int i = 0; i < 4; i++)
                            {
                                int new_x = curent.Item1 + di[i];
                                int new_y = curent.Item2 + dj[i];
                                if (Inside(new_x, new_y))
                                    if (player2.Grid[new_x][new_y] > 0)
                                    {
                                        int new_aux = player2.Grid[new_x][new_y];
                                        player2.Grid[new_x][new_y] = -1;
                                        Destroy1(player2, new_aux, suita);
                                        moves++;
                                        if (new_aux > 0)
                                        {
                                            var new_curent = Tuple.Create(new_x, new_y);
                                            Q.Push(new_curent);
                                        }
                                    }
                            }
                        }
                    }
                }
                m = Generare(suita, player2);
                if (Win(player2) == true)
                    break;
            }
            return moves;
        }
        public static bool Inside(int x,int y)
        {
            if (x >= 0 && x < 10 && y >= 0 && y < 10)
                return true;
            return false;
        }
        public static int HardBot()
        {
            GridModel player1 = new GridModel();

            GridModel player2 = new GridModel();
            Place(player2);
            int moves = 0;
            List<int> di = new();
            di.Add(0);
            di.Add(0);
            di.Add(-1);
            di.Add(1);
            List<int> dj = new();
            dj.Add(1);
            dj.Add(-1);
            dj.Add(0);
            dj.Add(0);
            while (true)
            {
                Random rnd = new();
                int x = rnd.Next(0, 10);
                int y = rnd.Next(0, 10);
                if (player2.Grid[x][y]!=-1)
                {
                    moves++;
                    int aux = player2.Grid[x][y];
                    player2.Grid[x][y] = -1;
                    Destroy(player2, aux);
                    if (aux>0)
                    {
                        Stack<Tuple<int, int>> Q = new();
                        var pair = Tuple.Create(x, y);
                        Q.Push(pair);
                        while (Q.Count() > 0)
                        {
                            var curent = Q.Pop();
                            for (int i = 0; i < 4; i++)
                            {
                                int new_x = curent.Item1 + di[i];
                                int new_y = curent.Item2 + dj[i];
                                if (Inside(new_x, new_y))
                                    if (player2.Grid[new_x][new_y] > 0)
                                    {
                                        int new_aux = player2.Grid[new_x][new_y];
                                        player2.Grid[new_x][new_y] = -1;
                                        Destroy(player2, new_aux);
                                        moves++;
                                        if (new_aux>0)
                                        {
                                            var new_curent = Tuple.Create(new_x, new_y);
                                            Q.Push(new_curent);
                                        }
                                    }
                            }
                        }
                    }
                }
                if(Win(player2)==true)
                    break;
            }
            return moves;
        }
        public static bool PlaceCarrierV(GridModel grid,int x,int y)
        {
            if (x >= 6)
                return false;
            for (int i = 0; i < 5; i++)
                if (grid.Grid[x + i][y] != 0)
                    return false;
            for (int i = 0; i < 5; i++)
                grid.Grid[x + i][y]=5;
            return true;    
        }
        public static bool PlaceCarrierH(GridModel grid,int x,int y)
        {
            if (y >= 6)
                return false;
            for (int i = 0; i < 5; i++)
                if (grid.Grid[x][y+i] != 0)
                    return false;
            for (int i = 0; i < 5; i++)
                grid.Grid[x][y+i] = 5;
            return true;
        }

        public static bool PlaceBattleshipV(GridModel grid, int x, int y)
        {
            if (x >= 7)
                return false;
            for (int i = 0; i < 4; i++)
                if (grid.Grid[x + i][y] != 0)
                    return false;
            for (int i = 0; i < 4; i++)
                grid.Grid[x + i][y] = 4;
            return true;
        }
        public static bool PlaceBattleshipH(GridModel grid, int x, int y)
        {
            if (y >= 7)
                return false;
            for (int i = 0; i < 4; i++)
                if (grid.Grid[x][y + i] != 0)
                    return false;
            for (int i = 0; i < 4; i++)
                grid.Grid[x][y + i] = 4;
            return true;
        }

        public static bool PlaceCruiserV(GridModel grid, int x, int y)
        {
            if (x >= 8)
                return false;
            for (int i = 0; i < 3; i++)
                if (grid.Grid[x + i][y] != 0)
                    return false;
            for (int i = 0; i < 3; i++)
                grid.Grid[x + i][y] = 3;
            return true;
        }
        public static bool PlaceCruiserH(GridModel grid, int x, int y)
        {
            if (y >= 8)
                return false;
            for (int i = 0; i < 3; i++)
                if (grid.Grid[x][y + i] != 0)
                    return false;
            for (int i = 0; i < 3; i++)
                grid.Grid[x][y + i] = 3;
            return true;
        }

        public static bool PlaceSubmarineV(GridModel grid, int x, int y)
        {
            if (x >= 9)
                return false;
            for (int i = 0; i < 2; i++)
                if (grid.Grid[x + i][y] != 0)
                    return false;
            for (int i = 0; i < 2; i++)
                grid.Grid[x + i][y] = 2;
            return true;
        }
        public static bool PlaceSubmarineH(GridModel grid, int x, int y)
        {
            if (y >= 9)
                return false;
            for (int i = 0; i < 2; i++)
                if (grid.Grid[x][y + i] != 0)
                    return false;
            for (int i = 0; i < 2; i++)
                grid.Grid[x][y + i] = 2;
            return true;
        }
        public static bool PlaceMine(GridModel grid,int x,int y)
        {
            if (grid.Grid[x][y]==0)
            {
                grid.Grid[x][y] = 1;
                return true;
            }
            return false;
        }
        public static void Place(GridModel grid)
        {
            while(true)
            {
                Random rnd = new();
                int x = rnd.Next(0,10);
                int y = rnd.Next(0, 10);
                int directie = rnd.Next(0, 2);
                bool ok;
                if (directie==0)
                    ok = PlaceCarrierV(grid,x,y);
                else
                    ok = PlaceCarrierH(grid,x,y);
                if (ok)
                {
                    grid.Carrier = 5;
                    break;
                }
            }
            while (true)
            {
                Random rnd = new();
                int x = rnd.Next(0, 10);
                int y = rnd.Next(0, 10);
                int directie = rnd.Next(0, 2);
                bool ok;
                if (directie == 0)
                    ok = PlaceBattleshipV(grid, x, y);
                else
                    ok = PlaceBattleshipH(grid, x, y);
                if (ok)
                {
                    grid.Battleship = 4;
                    break;
                }
            }

            while (true)
            {
                Random rnd = new();
                int x = rnd.Next(0, 10);
                int y = rnd.Next(0, 10);
                int directie = rnd.Next(0, 2);
                bool ok;
                if (directie == 0)
                    ok = PlaceCruiserV(grid, x, y);
                else
                    ok = PlaceCruiserH(grid, x, y);
                if (ok)
                {
                    grid.Cruiser = 3;
                    break;
                }
            }

            while (true)
            {
                Random rnd = new();
                int x = rnd.Next(0, 10);
                int y = rnd.Next(0, 10);
                int directie = rnd.Next(0, 2);
                bool ok;
                if (directie == 0)
                    ok = PlaceSubmarineV(grid, x, y);
                else
                    ok = PlaceSubmarineH(grid, x, y);
                if (ok)
                {
                    grid.Submarine = 2;
                    break;
                }
            }

            while(true)
            {
                Random rnd = new();
                int x = rnd.Next(0, 10);
                int y = rnd.Next(0, 10);
                bool ok = PlaceMine(grid,x, y);
                if(ok)
                {
                    grid.Mine = 1;
                    break;
                }
            }
        }
    }
}
