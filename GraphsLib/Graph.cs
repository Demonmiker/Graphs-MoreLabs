using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsLib
{
    public class Graph
    {
        /// <summary>
        /// Лист для хранения узлов
        /// </summary>
        public List<Node> Nodes = new List<Node>();
        /// <summary>
        /// Метод добавления узлов в граф
        /// </summary>
        /// <param name="n"></param>
        public void Add(Node n)
        { 
            Nodes.Add(n);
        }
        /// <summary>
        /// Метод ищущий узле пр его имени
        /// </summary>
        /// <param name="name">имя</param>
        /// <returns></returns>
        public Node GetNode(string name)
        {
            return Nodes.Find((elem) => { return elem.Name == name; });
        }
        /// <summary>
        /// Метод удаляющий узел а также удаляющий все соединения к нему и от него(по имени)
        /// </summary>
        /// <param name="name">имя</param>
        public void RemoveNode(string name)
        {
            RemoveNode(GetNode(name));
        }
        /// <summary>
        /// Метод удаляющий узел а также удаляющий все соединения к нему и от него(по сслылке на узел)
        /// </summary>
        /// <param name="n">узел</param>
        public void RemoveNode(Node n)
        {
            Link RemL = new Link(null,null,1);
            string curName = n.Name;
            foreach(Node n2 in Nodes)
            {
                foreach(Link l in n2.Links)
                {
                    if (l.To == n) RemL = l;
                }
                n2.Links.Remove(RemL);
            }
            Nodes.Remove(n);
        }
        /// <summary>
        /// метод удаяющий соединение
        /// </summary>
        /// <param name="l">соединение</param>
        public void RemoveLink(Link l)
        {
            if(l!=null)
                l.From.Links.Remove(l);
        }
        /// <summary>
        /// метод возращает true если в графе есть узел с таким именем 
        /// </summary>
        /// <param name="name">имя</param>
        /// <returns>наличие</returns>
        public bool Contains(string name)
        {
            if (Nodes.Find((elem) => { return elem.Name == name; }) != null)
                return true;
            else
                return false;

        }
    }
}
