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
            Tentativa1();
            Console.ReadKey();
            Tentativa2();
            Console.ReadKey();
        }

        public static void Tentativa1()
        {
            Grafo G = new Grafo();

            G.AdicionarAresta(new Aresta(new Vertice(0), new Vertice(1)));

            G.AdicionarAresta(new Aresta(new Vertice(1), new Vertice(2)));
            G.AdicionarAresta(new Aresta(new Vertice(1), new Vertice(13)));

            G.AdicionarAresta(new Aresta(new Vertice(2), new Vertice(3)));
            G.AdicionarAresta(new Aresta(new Vertice(2), new Vertice(6)));

            G.AdicionarAresta(new Aresta(new Vertice(3), new Vertice(4)));

            G.AdicionarAresta(new Aresta(new Vertice(4), new Vertice(5)));
            G.AdicionarAresta(new Aresta(new Vertice(4), new Vertice(7)));

            G.AdicionarAresta(new Aresta(new Vertice(5), new Vertice(16)));

            G.AdicionarAresta(new Aresta(new Vertice(6), new Vertice(7)));
            G.AdicionarAresta(new Aresta(new Vertice(6), new Vertice(8)));

            G.AdicionarAresta(new Aresta(new Vertice(7), new Vertice(9)));

            G.AdicionarAresta(new Aresta(new Vertice(8), new Vertice(9)));
            G.AdicionarAresta(new Aresta(new Vertice(8), new Vertice(10)));

            G.AdicionarAresta(new Aresta(new Vertice(9), new Vertice(11)));

            G.AdicionarAresta(new Aresta(new Vertice(10), new Vertice(11)));
            G.AdicionarAresta(new Aresta(new Vertice(10), new Vertice(14)));

            G.AdicionarAresta(new Aresta(new Vertice(11), new Vertice(15)));

            G.AdicionarAresta(new Aresta(new Vertice(12), new Vertice(13)));

            G.AdicionarAresta(new Aresta(new Vertice(13), new Vertice(14)));

            G.AdicionarAresta(new Aresta(new Vertice(14), new Vertice(15)));

            G.AdicionarAresta(new Aresta(new Vertice(15), new Vertice(16)));

            G.AdicionarAresta(new Aresta(new Vertice(16), new Vertice(18)));

            G.AdicionarAresta(new Aresta(new Vertice(17), new Vertice(18)));
            G.AdicionarAresta(new Aresta(new Vertice(17), new Vertice(20)));

            G.AdicionarAresta(new Aresta(new Vertice(18), new Vertice(21)));

            G.AdicionarAresta(new Aresta(new Vertice(19), new Vertice(20)));
            G.AdicionarAresta(new Aresta(new Vertice(19), new Vertice(22)));

            G.AdicionarAresta(new Aresta(new Vertice(20), new Vertice(21)));

            G.AdicionarAresta(new Aresta(new Vertice(21), new Vertice(23)));

            G.AdicionarAresta(new Aresta(new Vertice(22), new Vertice(23)));
            G.AdicionarAresta(new Aresta(new Vertice(22), new Vertice(24)));

            G.AdicionarAresta(new Aresta(new Vertice(23), new Vertice(25)));

            Console.ReadKey();
        }

        public static void Tentativa2()
        {
            Graph G = new Graph(26);

            G.AddEdge(new Edge(0, 1));

            G.AddEdge(new Edge(1, 2));
            G.AddEdge(new Edge(1, 13));

            G.AddEdge(new Edge(2, 3));
            G.AddEdge(new Edge(2, 6));

            G.AddEdge(new Edge(3, 4));

            G.AddEdge(new Edge(4, 5));
            G.AddEdge(new Edge(4, 7));

            G.AddEdge(new Edge(5, 16));

            G.AddEdge(new Edge(6, 7));
            G.AddEdge(new Edge(6, 8));

            G.AddEdge(new Edge(7, 9));

            G.AddEdge(new Edge(8, 9));
            G.AddEdge(new Edge(8, 10));

            G.AddEdge(new Edge(9, 11));

            G.AddEdge(new Edge(10, 11));
            G.AddEdge(new Edge(10, 14));

            G.AddEdge(new Edge(11, 15));

            G.AddEdge(new Edge(12, 13));

            G.AddEdge(new Edge(13, 14));

            G.AddEdge(new Edge(14, 15));

            G.AddEdge(new Edge(15, 16));

            G.AddEdge(new Edge(16, 18));

            G.AddEdge(new Edge(17, 18));
            G.AddEdge(new Edge(17, 20));

            G.AddEdge(new Edge(18, 21));

            G.AddEdge(new Edge(19, 20));
            G.AddEdge(new Edge(19, 22));

            G.AddEdge(new Edge(20, 21));

            G.AddEdge(new Edge(21, 23));

            G.AddEdge(new Edge(22, 23));
            G.AddEdge(new Edge(22, 24));

            G.AddEdge(new Edge(23, 25));

            Console.WriteLine(G.toString());

            HashSet<int> resultado = G.ObterCoberturaMinima();

            foreach (int item in resultado)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }

    public class Edge
    {
        private readonly int _v;
        private readonly int _w;

        public Edge(int v, int w)
        {
            this._v = v;
            this._w = w;
        }

        public int Source()
        {
            return _v;
        }

        public int Target(int vertex)
        {
            if (vertex == _v) return _w;
            else if (vertex == _w) return _v;
            else throw new Exception("Illegal endpoint");
        }

        public String toString()
        {
            return String.Format("{0:d}-{1:d}", _v, _w);
        }
    }

    public class Graph
    {
        private readonly int _v;
        private int _e;
        private LinkedList<Edge>[] _adj;

        public Graph(int V)
        {
            if (V < 0)
                throw new Exception("Number of vertices in a Graph must be nonnegative");

            this._v = V;

            this._e = 0;

            _adj = new LinkedList<Edge>[V];

            for (int v = 0; v < V; v++)
            {
                _adj[v] = new LinkedList<Edge>();
            }
        }

        public int V()
        {
            return _v;
        }

        public int E()
        {
            return _e;
        }

        public void AddEdge(Edge e)
        {
            int v = e.Source();
            int w = e.Target(v);
            _adj[v].AddFirst(e);
            _adj[w].AddFirst(e);
            _e++;
        }

        public IEnumerable<Edge> Adj(int v)
        {
            return _adj[v];
        }

        public IEnumerable<Edge> Edges()
        {
            LinkedList<Edge> list = new LinkedList<Edge>();

            for (int v = 0; v < _v; v++)
            {
                int selfLoops = 0;

                foreach (Edge e in Adj(v))
                {
                    if (e.Target(v) > v)
                    {
                        list.AddFirst(e);
                    }
                    else if (e.Target(v) == v)
                    {
                        if (selfLoops % 2 == 0)
                            list.AddFirst(e);
                        selfLoops++;
                    }
                }
            }

            return list;
        }

        public String toString()
        {
            String NEWLINE = Environment.NewLine;

            StringBuilder s = new StringBuilder();

            s.Append(_v + " " + _e + NEWLINE);

            for (int v = 0; v < _v; v++)
            {
                s.Append(v + ": ");

                foreach (Edge e in _adj[v])
                {
                    s.Append(e.toString() + "  ");
                }

                s.Append(NEWLINE);
            }
            return s.ToString();
        }

        public HashSet<int> ObterCoberturaMinima()
        {
            HashSet<int> resultado = new HashSet<int>();

            foreach (Edge item in Edges())
            {
                if (!resultado.Contains(item.Source()) &&
                    !resultado.Contains(item.Target(item.Source())))
                {
                    resultado.Add(item.Source());
                    resultado.Add(item.Target(item.Source()));
                }
            }

            return resultado;
        }

        public HashSet<int> ObterCoberturaMinima2()
        {
            HashSet<int> resultado = new HashSet<int>();

            while (Edges().Count() > 0)
            {
                var item = Edges().ElementAt(0);

                resultado.Add(item.Source());
                resultado.Add(item.Target(item.Source()));

                while (this.Adj(item.Source()).Count() > 0)
                {
                    this.Remove(this.Adj(item.Source()).ElementAt(0));
                }

                while (this.Adj(item.Target(item.Source())).Count() > 0)
                {
                    this.Remove(this.Adj(item.Target(item.Source())).ElementAt(0));
                }
            }

            return resultado;
        }

        public void Remove(Edge edge)
        {
            try
            {
                _adj[edge.Source()].Remove(edge);
                _adj[edge.Target(edge.Source())].Remove(edge);
            }
            catch { }
        }

    }


    class Grafo
    {
        HashSet<Vertice> Vertices;
        HashSet<Aresta> Arestas;
        Dictionary<Vertice, HashSet<Aresta>> ListaAdjacencia;

        public Grafo()
        {
            Vertices = new HashSet<Vertice>();
            Arestas = new HashSet<Aresta>();
            ListaAdjacencia = new Dictionary<Vertice, HashSet<Aresta>>();
        }

        public bool AdicionarVertice(int pID)
        {
            return Vertices.Add(new Vertice(pID));
        }

        public bool AdicionarVertice(Vertice pVertice)
        {
            return Vertices.Add(pVertice);
        }

        public bool AdicionarVertices(ICollection<Vertice> pVertices)
        {
            foreach (Vertice item in pVertices)
                if (Vertices.Contains(item)) return false;

            foreach (Vertice item in pVertices)
                Vertices.Add(item);

            return true;
        }

        public bool RemoverVertice(int pID)
        {
            return Vertices.Remove(new Vertice(pID));
        }

        public bool RemoverVertice(Vertice pVertice)
        {
            return Vertices.Remove(pVertice);
        }

        public bool AdicionarAresta(Aresta pAresta)
        {
            if (!Arestas.Add(pAresta)) return false;

            ListaAdjacencia.Add(pAresta.v1, new HashSet<Aresta>());
            ListaAdjacencia.Add(pAresta.v2, new HashSet<Aresta>());

            ListaAdjacencia[pAresta.v1].Add(pAresta);
            ListaAdjacencia[pAresta.v2].Add(pAresta);

            return true;
        }

        public bool AdicionarAresta(int pID1, int pID2)
        {
            return AdicionarAresta(new Aresta(new Vertice(pID1), new Vertice(pID2)));
        }

        public bool RemoverAresta(Aresta pAresta)
        {
            if (!Arestas.Remove(pAresta)) return false;

            ListaAdjacencia[pAresta.v1].Remove(pAresta);
            ListaAdjacencia[pAresta.v2].Remove(pAresta);

            return true;
        }

        public HashSet<Vertice> ObterVerticesAdjacentes(Vertice pVertice)
        {
            var lista = ListaAdjacencia[pVertice];
            HashSet<Vertice> vertices = new HashSet<Vertice>();

            foreach (Aresta item in lista)
                if (item.v1.Equals(pVertice))
                    vertices.Add(item.v2);
                //Nunca vai acontecer?
                else if (item.v2.Equals(pVertice))
                    vertices.Add(item.v1);

            return vertices;
        }


        public HashSet<Vertice> ObterAproxCoberturaMinima()
        {
            HashSet<Vertice> ConjuntoVertices = new HashSet<Vertice>();

            foreach (Aresta item in Arestas)
            {
                if (!ConjuntoVertices.Contains(item.v1) &&
                    !ConjuntoVertices.Contains(item.v2))
                {
                    ConjuntoVertices.Add(item.v1);
                    ConjuntoVertices.Add(item.v2);
                }
            }
            return ConjuntoVertices;
        }

    }

    class Vertice
    {
        public int ID { get; private set; }

        public Vertice(int pID)
        {
            ID = pID;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            else if (!(obj is Vertice)) return false;
            else return ((obj as Vertice).ID == this.ID);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return ID.ToString();
        }
    }

    class Aresta
    {
        public Vertice v1 { get; private set; }
        public Vertice v2 { get; private set; }

        public Aresta(Vertice pv1, Vertice pv2)
        {
            v1 = pv1;
            v2 = pv2;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            else if (!(obj is Aresta)) return false;
            else
            {
                Aresta _obj = obj as Aresta;
                return ((_obj.v1.Equals(this.v1) && _obj.v2.Equals(this.v2)) ||
                        (_obj.v1.Equals(this.v2) && _obj.v2.Equals(this.v1)));
            }
        }

        public override int GetHashCode()
        {
            var hashCode = -1579017031;
            hashCode = hashCode * -1521134295 + EqualityComparer<Vertice>.Default.GetHashCode(v1);
            hashCode = hashCode * -1521134295 + EqualityComparer<Vertice>.Default.GetHashCode(v2);
            return hashCode;
        }
    }
}
