namespace GeneratorsLib.Impl.PrimTypeGenerator
{
    public class FloatAbstractGenerator : AbstractGenerator
    {
        public FloatAbstractGenerator()
        {
            TypeOfObj = typeof(float);
        }

        public override object Generate()
        {
            return (float) Random.NextDouble();
        }
    }
}