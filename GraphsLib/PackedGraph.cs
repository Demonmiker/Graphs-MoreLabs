using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;


namespace GraphsLib
{
    [Serializable]
    public class PackedNode
    {
        public PackedNode() { }

        public PackedNode(string name,Point p)
        {
            Name = name;
            Position = p;
        }

        public string Name;
        public Point Position;

    }

    [Serializable]
    public class PackedLink
    {
        public PackedLink() { }

        public PackedLink(string parent,string dist,double w)
        {
            ParentName = parent;
            Weight = w;
            Dist = dist;
        }

        public double Weight;
        public string ParentName;
        public string Dist;
    }

    [Serializable]
    public class PackedGraph
    {
        public PackedGraph() { }

        public List<PackedNode> Nodes = new List<PackedNode>();

        public List<PackedLink> Links = new List<PackedLink>();

       

        public PackedGraph(Graph G)
        {
            foreach(Node n in G.Nodes)
            {
                Nodes.Add(new PackedNode(n.Name, n.UIPos));
                foreach(Link l in n.Links)
                {
                    Links.Add(new PackedLink(l.From.Name, l.To.Name, l.Weight));
                }
            }

        }

        public Graph UnPack()
        {
            Graph result = new Graph();
            foreach(PackedNode n in Nodes)
            {
                result.Add(new Node(n.Name, n.Position));
            }
            Node From;
            Node To;
            foreach(PackedLink l in Links)
            {
                From = result.Nodes.Find((x) => x.Name == l.ParentName);
                To = result.Nodes.Find((x) => x.Name == l.Dist);
                From.Link(To, l.Weight);
            
            }
            return result;

        }

    }
}
