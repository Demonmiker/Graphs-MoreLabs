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
    
 
        public List<Node> FindPath(Node A,Node B,DijkstraMode DM = DijkstraMode.Default)
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
            return path;
            
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





   

}
