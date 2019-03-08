namespace GraphsLib
{
    public class HeapNode<T>
    {
        /// <summary>
        /// ключ по которому определяется положение в куче
        /// </summary>
        public double Key;
        /// <summary>
        /// Привязанное к ключу значение
        /// </summary>
        public T Value;
        //Конструктор
        public HeapNode (double key,T o)
        {
            Key = key;
            Value = o;
        }
        /// <summary>
        /// Строчное представление
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Key}:{Value}";
        }
    }





   

}
