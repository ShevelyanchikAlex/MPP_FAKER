namespace GeneratorsLib.Impl.PrimTypeGenerator
{
    public class LongGenerator : AbstractGenerator
    {
        public LongGenerator()
        {
            TypeOfObj = typeof(long);
        }

        public override object Generate()
        {
            return (long) Random.Next();
        }
    }
}