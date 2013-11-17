using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AntColoniesDistance {
    class Program {
        // Values for graph
        static int[] wheights;
        static int[] colonies;

        // Values for cases
        static int[] distances;

        // Read file, initialize graph for colonies and their weights
        static void Main(string[] args) {
            using (StreamReader file = new StreamReader("input.txt")) {
                string line;
                int n;

                // Get quantity of colonies to initialize
                line = file.ReadLine();
                n = int.Parse(line);

                // Initialize array of colonies and their wheights
                // add 1 to index to Skip zero slot as default
                wheights = new int[n + 1];
                colonies = new int[n + 1];

                // Initialize slot zero for array of colonies
                colonies[0] = -1;

                // Initializa all remaining slots for colonies
                // from the n next lines in file
                string[] tokens;
                int weight, nextColony;
                for (int i = 1; i < n; i++) {
                    // Parse lines to get values for colonies
                    tokens = file.ReadLine().Split();
                    nextColony = int.Parse(tokens[0]);
                    weight = int.Parse(tokens[1]);

                    // Initialize current colony and its weight
                    colonies[i] = nextColony;
                    wheights[i] = weight;
                }

                /// Processing cases for measuring distances ///
                
                
                // Get number of cases and create array for distances
                line = file.ReadLine();
                n = int.Parse(line);
                distances = new int[n];

                // Processing next cases to fill array of distances

                int a, b;
                for (int i = 0; i < n; i++) {
                    line = file.ReadLine();
                    tokens = line.Split();

                    // Get ids for two colonies
                    a = int.Parse(tokens[0]);
                    b = int.Parse(tokens[1]);

                    distances[i] = GetDistance(a, b);
                }

                // Print all calculated distances
                foreach (int distance in distances) {
                    Console.Write(distance);
                    Console.Write("\t");
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }

        static bool[] marks;
        static int GetDistance(int colony1, int colony2) {
            marks = new bool[colonies.Length];

            // Initialize array 
            for (int i = 0; i < marks.Length; i++)
                marks[i] = false;

            // Call recursive marker for both colonies
            Marker(colony1);
            Marker(colony2);

            // Adding weights for marked colonies
            int totalWeight = 0;

            for (int i = 0; i < marks.Length; i++) {
                if (marks[i]) {
                    totalWeight += wheights[i];
                }
            }

            return totalWeight;
        }

        static void Marker(int colony) {
            // Base case
            if (colony == -1)
                return;

            // Mark colony (inverted boolean value)
            marks[colony] = !marks[colony];

            // Mark next colony.
            Marker(colonies[colony]);
        }
    }
}
