namespace GeneratorsLib.Impl.PrimTypeGenerator
{
    public class LongAbstractGenerator : AbstractGenerator
    {
        public LongAbstractGenerator()
        {
            TypeOfObj = typeof(long);
        }

        public override object Generate()
        {
            return (long) Random.Next();
        }
    }
}