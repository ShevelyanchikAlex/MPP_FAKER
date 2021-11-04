namespace GeneratorsLib.Impl.PrimTypeGenerator
{
    public class BoolGenerator : AbstractGenerator
    {
        private const int MaxValue = 10;
        private const int CompareValue = 5;

        public BoolGenerator()
        {
            TypeOfObj = typeof(bool);
        }


        public override object Generate()
        {
            return Random.Next(MaxValue) < CompareValue;
        }
    }
}