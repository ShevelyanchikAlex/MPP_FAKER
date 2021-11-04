namespace GeneratorsLib.Impl.PrimTypeGenerator
{
    public class BoolAbstractGenerator : AbstractGenerator
    {
        private const int MaxValue = 10;
        private const int CompareValue = 5;

        public BoolAbstractGenerator()
        {
            TypeOfObj = typeof(bool);
        }


        public override object Generate()
        {
            return Random.Next(MaxValue) < CompareValue;
        }
    }
}