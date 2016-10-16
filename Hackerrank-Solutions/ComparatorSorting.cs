using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions
{
    public class ComparatorSorting
    {
        private static string[] inputs = new string[] { "5",
                                                        "amy 100",
                                                        "david 100",
                                                        "heraldo 50",
                                                        "aakansha 75",
                                                        "aleksa 150" };
        private static string[] output = new string[] { "aleksa 150",
                                                        "amy 100",
                                                        "david 100",
                                                        "aakansha 75",
                                                        "heraldo 50" };
        class Player
        {
            public int score { get; }
            public string name { get; }

            public Player(int score, string name)
            {
                this.score = score;
                this.name = name;
            }
        }

        class Checker : Comparer<Player>
        {
            public override int Compare(Player p1, Player p2)
            {
                if (p1.score != p2.score)
                    return p1.score.CompareTo(p2.score) * -1; // inverse order
                return p1.name.CompareTo(p2.name);
            }
        }

        class GenericCheker : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                if (x is Player && y is Player)
                {
                    Player p1 = (Player)x;
                    Player p2 = (Player)y;
                    if (p1.score != p2.score)
                        return p1.score.CompareTo(p2.score) * -1; // inverse order
                    return p1.name.CompareTo(p2.name);
                }
                else
                    throw new InvalidCastException("GenericCheker: Illegal arguments!");
            }
        }

        public void Test()
        {
            int nLine = 0;
            int n = int.Parse(inputs[nLine++]);
            Player[] players = new Player[n];
            for (; n > 0; n--)
            {
                string[] line = inputs[nLine++].Split();
                players[n - 1] = new Player(int.Parse(line[1]), line[0]);
            }
            //Array.Sort(players, new GenericCheker());
            Array.Sort(players, new Checker());
            for (int i = 0; i < players.Length; i++)
                Console.WriteLine("{0} {1}", players[i].name, players[i].score);
        }
    }
}
