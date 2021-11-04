namespace GeneratorsLib.Impl.PrimTypeGenerator
{
    public class DoubleAbstractGenerator : AbstractGenerator
    {
        public DoubleAbstractGenerator()
        {
            TypeOfObj = typeof(double);
        }


        public override object Generate()
        {
            return Random.NextDouble();
        }
    }
}