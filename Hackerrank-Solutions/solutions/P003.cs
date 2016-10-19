using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackerrank_Solutions.solutions
{
    public class P003
    {
        public static void Test()
        {
            string[] input = new string[] { "4 5", 
                                            "10101",
                                            "11100",
                                            "11010",
                                            "00101"};

            int nLine = 0;
            string[] line = input[nLine++].Split();
            int N = int.Parse(line[0]);
            int M = int.Parse(line[1]);
            int maxNumberOfTopic = 0;
            int numberOfTeams = 0;
            for(int participant1 = nLine; participant1 <= N; participant1++)
                for(int participant2 = participant1+1; participant2 <= N; participant2++)
                {
                    int numberOfTopics = 0;
                    for (int topic = 0; topic < M; topic++)
                        if (input[participant1][topic] == '1' || input[participant2][topic] == '1')
                            numberOfTopics++;
                    if (numberOfTopics == maxNumberOfTopic)
                        numberOfTeams++;
                    else if(numberOfTopics > maxNumberOfTopic)
                    {
                        maxNumberOfTopic = numberOfTopics;
                        numberOfTeams = 1;
                    }
                }
            Console.WriteLine(maxNumberOfTopic);
            Console.WriteLine(numberOfTeams);

        }
    }
}
