namespace GeneratorsLib.Impl.PrimTypeGenerator
{
    public class FloatGenerator : AbstractGenerator
    {
        public FloatGenerator()
        {
            TypeOfObj = typeof(float);
        }

        public override object Generate()
        {
            return (float) Random.NextDouble();
        }
    }
}