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
            Grafo G;

            MontaGrafo(out G);

            List<int> resultado = G.ObterCoberturaMinimal();

            Console.WriteLine("Subconjunto minimal:");

            foreach (var item in resultado)
            {                
                Console.Write(" - {0}", item);
            }

            Console.ReadKey();
        }

        public static void MontaGrafo(out Grafo G)
        {
            G = new Grafo(26);

            G.AdicionarAresta(0, 2);

            G.AdicionarAresta(1, 3);

            G.AdicionarAresta(2, 3);
            G.AdicionarAresta(2, 7);


            G.AdicionarAresta(3, 11);

            G.AdicionarAresta(4, 5);
            G.AdicionarAresta(4, 12);

            G.AdicionarAresta(5, 6);
            G.AdicionarAresta(5, 24);

            G.AdicionarAresta(7, 8);
            G.AdicionarAresta(7, 13);

            G.AdicionarAresta(8, 9);
            G.AdicionarAresta(8, 15);

            G.AdicionarAresta(9, 10);
            G.AdicionarAresta(9, 16);

            G.AdicionarAresta(10, 11);
            G.AdicionarAresta(10, 17);

            G.AdicionarAresta(11, 18);

            G.AdicionarAresta(12, 19);
            G.AdicionarAresta(12, 23);

            G.AdicionarAresta(13, 14);

            G.AdicionarAresta(14, 15);
            G.AdicionarAresta(14, 20);

            G.AdicionarAresta(15, 16);

            G.AdicionarAresta(16, 17);

            G.AdicionarAresta(17, 18);

            G.AdicionarAresta(18, 21);

            G.AdicionarAresta(17, 18);

            G.AdicionarAresta(18, 21);

            G.AdicionarAresta(20, 21);

            G.AdicionarAresta(21, 22);

            G.AdicionarAresta(22, 23);

            G.AdicionarAresta(23, 24);

            G.AdicionarAresta(24, 25);
        }
    }

    class Grafo
    {
        private int numeroVertices;        // Quantidade de vértices do grafo
        LinkedList<int>[] listaAdjacencia; // Array de listas de adjacencia para cada vértice

        public Grafo(int numeroVertices)
        {
            this.numeroVertices = numeroVertices;
            listaAdjacencia = new LinkedList<int>[numeroVertices];

            for (int i = 0; i < numeroVertices; i++)
                listaAdjacencia[i] = new LinkedList<int>();
        }

        public void AdicionarAresta(int vertice1, int vertice2)
        {
            listaAdjacencia[vertice1].AddLast(vertice2); // Adiciona o vertice2 a lista de adjacencia do vertice1
            listaAdjacencia[vertice2].AddLast(vertice1); // E vice versa, pois o grafo não é direcionado
        }

        /// <summary>
        /// Função que retorna um array contendo o conjunto de vértices que formam a cobertura
        /// </summary>
        public List<int> ObterCoberturaMinimal()
        {
            //Vetor referente a cada vértice do grafo
            bool[] verticesVisitados = new bool[numeroVertices];

            //Subconjunto de cobertura minimal
            List<int> verticesSelecionados = new List<int>();

            //Passando por todos os vértices
            for (int u = 0; u < numeroVertices; u++)
            {
                //Seleciona um vértice ainda não visitado
                if (verticesVisitados[u] == false)
                {
                    //Para cada vértice adjacente ao selecionado
                    foreach (var item in listaAdjacencia[u])
                    {
                        int v = item;
                        //Se o adjacente não tiver sido visitado ainda,
                        //marca tanto a origem (u) quanto o destino (v)
                        //como visitados
                        if (verticesVisitados[v] == false)
                        {
                            verticesVisitados[v] = true;
                            verticesVisitados[u] = true;

                            //Adicionando o destino ao subconjunto de cobertura minimal
                            verticesSelecionados.Add(v);                         
                        }
                    }
                }
            }
            verticesSelecionados.Sort();
            return verticesSelecionados;
        }
    }
}
