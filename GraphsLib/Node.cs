using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphsLib
{
    public class Node
    {
        /// <summary>
        /// Наименование узла
        /// </summary>
        public string Name;
        /// <summary>
        /// Позиция узла на экране
        /// </summary>
        public Point UIPos;
        /// <summary>
        /// Исходящие от узла соединения
        /// </summary>
        public List<Link> Links = new List<Link>();
        /// <summary>
        /// входящие в граф соединения
        /// </summary>
        public List<Link> ToMe = new List<Link>();
        //Коструктор
        public Node(string name, Point Pos)
        {
            Name = name;
            UIPos = Pos;
        }

        /// <summary>
        /// метод соединяет данный граф с другим соединением определенным весом
        /// </summary>
        /// <param name="n">граф для соединения</param>
        /// <param name="Weight">все</param>
        public void Link(Node n, double Weight = 1)
        {
            if (Links.Find((elem) => { return elem.To == n; }) == null)
            {
                Link New = new Link(this, n, Weight);
                Links.Add(New);
                n.ToMe.Add(New);
            }

        }
        /// <summary>
        /// Вполняет операцию соединения узлов с двух сторон что делает
        /// соединение не направленным
        /// </summary>
        /// <param name="n">узел для соединения</param>
        /// <param name="Weight">все</param>
        public void LinkTwo(Node n, double Weight = 1)
        {

            Link(n);
            n.Link(this);
        }
        /// <summary>
        /// Преобразует узел в его строчное представление
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }
    }

}
