namespace HW_PrototypePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Invoke(new Prototype());
        }

        private static void Invoke(IPattern pattern)
        {
            pattern.Execute();
        }
    }
}