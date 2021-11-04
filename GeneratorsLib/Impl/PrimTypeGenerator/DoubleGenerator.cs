namespace GeneratorsLib.Impl.PrimTypeGenerator
{
    public class DoubleGenerator : AbstractGenerator
    {
        public DoubleGenerator()
        {
            TypeOfObj = typeof(double);
        }


        public override object Generate()
        {
            return Random.NextDouble();
        }
    }
}