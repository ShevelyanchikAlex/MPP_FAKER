namespace GeneratorsLib.Impl.PrimTypeGenerator
{
    public class IntGenerator : AbstractGenerator
    {
        private const int MinValue = -1000;
        private const int MaxValue = 1000;

        public IntGenerator()
        {
            TypeOfObj = typeof(int);
        }

        public override object Generate()
        {
            return Random.Next(MinValue, MaxValue);
        }
    }
}