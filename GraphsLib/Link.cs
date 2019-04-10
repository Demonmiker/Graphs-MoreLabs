using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsLib
{
    public class Link
    {
        /// <summary>
        /// Откуда идет соединение
        /// </summary>
        public Node From;
        /// <summary>
        /// Куда идет соединение
        /// </summary>
        public Node To;
        /// <summary>
        /// Вес соединения
        /// </summary>
        public double Weight;
        //Конструктор
        public Link(Node from, Node to, double W)
        {
            From = from;
            To = to;
            Weight = W;

        }

        public void Reverse()
        {
            Node temp;
            temp = From;
            From = To;
            To = temp;
        }
    }
}
