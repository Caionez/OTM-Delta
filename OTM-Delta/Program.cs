using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTM_Delta
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph G;

            MontaGrafo(out G);

            G.printVertexCover();
            Console.ReadKey();
        }

        public static void MontaGrafo(out Graph G)
        {
            G = new Graph(26);

            G.AddEdge(0, 1);

            G.AddEdge(1, 2);
            G.AddEdge(1, 13);

            G.AddEdge(2, 3);
            G.AddEdge(2, 6);

            G.AddEdge(3, 4);

            G.AddEdge(4, 5);
            G.AddEdge(4, 7);

            G.AddEdge(5, 16);

            G.AddEdge(6, 7);
            G.AddEdge(6, 8);

            G.AddEdge(7, 9);

            G.AddEdge(8, 9);
            G.AddEdge(8, 10);

            G.AddEdge(9, 11);

            G.AddEdge(10, 11);
            G.AddEdge(10, 14);

            G.AddEdge(11, 15);

            G.AddEdge(12, 13);

            G.AddEdge(13, 14);

            G.AddEdge(14, 15);

            G.AddEdge(15, 16);

            G.AddEdge(16, 18);

            G.AddEdge(17, 18);
            G.AddEdge(17, 20);

            G.AddEdge(18, 21);

            G.AddEdge(19, 20);
            G.AddEdge(19, 22);

            G.AddEdge(20, 21);

            G.AddEdge(21, 23);

            G.AddEdge(22, 23);
            G.AddEdge(22, 24);

            G.AddEdge(23, 25);
        }
    }
        
    class Graph
    {
        int V;    // No. of vertices
        LinkedList<int>[] adj;  // Pointer to an array containing adjacency lists       

        public Graph(int V)
        {
            this.V = V;
            adj = new LinkedList<int>[V];

            for (int i = 0; i < V; i++)
            {
                adj[i] = new LinkedList<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            adj[v].AddLast(w); // Add w to v’s list.
            adj[w].AddLast(v); // Since the graph is undirected
        }

        // The function to print vertex cover
        public void printVertexCover()
        {
            // Initialize all vertices as not visited.
            bool[] visited = new bool[V];

            bool[] selected = new bool[V];

            //for (int i = 0; i < V; i++)
            //    visited[i] = false;

            // Consider all edges one by one
            for (int u = 0; u < V; u++)
            {
                // An edge is only picked when both visited[u] and visited[v]
                // are false
                if (visited[u] == false)
                {
                    // Go through all adjacents of u and pick the first not
                    // yet visited vertex (We are basically picking an edge
                    // (u, v) from remaining edges.
                    foreach (var item in adj[u])
                    {
                        int v = item;

                        if (visited[v] == false)
                        {
                            selected[v] = true;

                            visited[v] = true;
                            visited[u] = true;
                        }
                    }
                }
            }

            for (int i = 0; i < V; i++)
                if (selected[i])
                    Console.WriteLine(i);
        }

    }
}
