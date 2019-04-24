using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GraphsLib
{
    public enum DijkstraMode
    {
        Default,
        BinaryHeap
    }

    public class Dijkstra
    {
        public long Timer = 0;
    
 
        public List<Node>[] FindPath(Node A,Node B,DijkstraMode DM = DijkstraMode.Default)
        {
            //
            Stopwatch SW = new Stopwatch();
            SW.Start();
            queue.Clear();
            heap.Clear();
            //
            List<Node> path = new List<Node>();
            Dictionary<Node, double> D;
            switch (DM)
            {
                case DijkstraMode.BinaryHeap:
                    D = GetDistancesWithHeap(A);
                    break;
                default:
                    D = GetDistances(A);
                    break;
            }
            SW.Stop();
            Node Cur = B;
            if (!D.ContainsKey(B))
                return null;
            path.Add(Cur);
            while (Cur != A)
            {
                foreach (Link l in Cur.ToMe)
                    if (D.ContainsKey(l.From))
                    if (D[l.From]+l.Weight == D[Cur])
                    {
                        Cur = l.From;
                        path.Add(Cur);

                    }
            }
            path.Add(Cur);
            Timer = SW.ElapsedMilliseconds;
            return new List<Node>[] { path };
            
        }


        BinaryHeap<Node> heap = new BinaryHeap<Node>();

        Dictionary<Node, double> GetDistancesWithHeap(Node Start)
        {
            Dictionary<Node, double> Distances = new Dictionary<Node, double>();
            List<Node> Closed = new List<Node>();

            heap.Add(0, Start);
            while (heap.Size > 0)
            {

                HeapNode<Node> KV = heap.GetMin();
                Node Cur = KV.Value;
                double CurPrior = KV.Key;
                foreach (Link l in Cur.Links)
                {
                    if (!Closed.Contains(l.To) && l.To != Cur)
                        heap.DecreaseOrAdd(CurPrior + l.Weight, l.To);
                }
                Closed.Add(Cur);
                Distances.Add(Cur, CurPrior);



            }
            return Distances;
        }

        #region Dijkstra default
        Dictionary<Node, double> queue = new Dictionary<Node, double>();

        Dictionary<Node,double> GetDistances(Node Start)
        {
            Dictionary<Node, double> Distances = new Dictionary<Node, double>();
            List<Node> Closed = new List<Node>();
            queue[Start] = 0;
            while(queue.Count>0)
            {
                Node Cur = GetMin();
                double CurPrior = queue[Cur];
                foreach(Link l in Cur.Links)
                {
                    if (!Closed.Contains(l.To))
                        SetQue(l.To, CurPrior + l.Weight);
                }
                Closed.Add(Cur);
                queue.Remove(Cur);
                Distances.Add(Cur, CurPrior);



            }
            return Distances;
        }


        void SetQue(Node n, double prior)
        {
            if (queue.ContainsKey(n))
            {
                if (queue[n] > prior)
                    queue[n] = prior;
            }
            else
            {
                queue[n] = prior;
            }
        }

        
        Node GetMin()
        {
            double Min = double.MaxValue;
            Node MinNode = null;
            foreach(KeyValuePair<Node,double> KV in queue)
            {
                if (KV.Value < Min)
                {
                    Min = KV.Value;
                    MinNode = KV.Key;
                }
            }
            return MinNode;
        }
        #endregion












    }

    public static class Algorithms
    {
        public enum Color
        {
            White,
            Gray,
            Black
        }

        static List<Node> curpath = new List<Node>();
        static Dictionary<Node, Color> color = new Dictionary<Node, Color>();
        public static List<Node>[] DoDFS(Graph G)
        {
            List<List<Node>> res = new List<List<Node>>();
            
           
            foreach(Node n in G.Nodes)
            {
                color.Add(n, Color.White);
            }

            for (int i = 0; i < G.Nodes.Count; i++)
            {
                if(color[G.Nodes[i]] == Color.White)
                {
                    DFS(G.Nodes[i]);
                    res.Add(curpath);
                    curpath = new List<Node>();
                }
            }
           
            //
            return res.ToArray();



            
            //
           
            
        }
        static void DFS(Node n)
        {
            color[n] = Color.Gray;
            curpath.Add(n);
            foreach (Link l in n.Links)
            {
                if (color[l.To] == Color.White)
                {
                    DFS(l.To);
                }
            }
            color[n] = Color.Black;
        }

        public static List<Node>[] StrongConnection(Graph G)
        {
            List<List<Node>> res = new List<List<Node>>();
            Graph H = G.GetReverse();
            List<Node> f = new List<Node>();
            List<Node>[] a = Algorithms.DoDFS(H);
            foreach (List<Node> l in a)
                f.AddRange(l);
            color.Clear();
            foreach (Node n in G.Nodes)
            {
                color.Add(n, Color.White);
            }

            for (int i =f.Count-1; i >= 0; i--)
            {
                if (color[G.GetNode(f[i].Name)] == Color.White)
                {
                    DFS(G.GetNode(f[i].Name));
                    res.Add(curpath);
                    curpath = new List<Node>();
                }
            }

            return res.ToArray();
        }

        public static List<Node>[] BFS(Graph G,Node StartNode = null)
        {
            if(StartNode==null)
                StartNode = G.Nodes[0];
            //
            List<Node> Result = new List<Node>();
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(StartNode);
            Dictionary<Node, int> mark = new Dictionary<Node, int>();
            while(q.Count>0)
            {
                Node Cur = q.Dequeue();
                mark.Add(Cur, 1); // тут можно в Value что нибдь записать
                Result.Add(Cur);
                foreach(Link l in Cur.Links)
                {
                    if (!mark.ContainsKey(l.To))
                        q.Enqueue(l.To);
                }
            }
            return new List<Node>[] { Result };

        }

        
        public static List<Node>[] EulerCycle(Graph G)
        {
            Graph G2 = G.Clone() as Graph;
            List<Node> Result = new List<Node>();
            Stack<Node> St = new Stack<Node>();
            St.Push(G2.Nodes[0]);
            while(St.Count!=0)
            {
                Node V = St.Peek();
                if(V.Links.Count + V.ToMe.Count==0)
                {
                    Result.Add(V);
                    St.Pop();
                }
                else
                {
                    Link l = V.Links[0];
                    V.Links.Remove(l);
                    l.To.ToMe.Remove(l);
                    St.Push(l.To);
                    
                }
            }
            return new List<Node>[]  { Result };

        }
    }





   

}
