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
            //Fim
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
