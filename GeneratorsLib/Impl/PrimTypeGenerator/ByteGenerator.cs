namespace GeneratorsLib.Impl.PrimTypeGenerator
{
    public class ByteGenerator : AbstractGenerator
    {
        private const int MaxValue = 256;

        public ByteGenerator()
        {
            TypeOfObj = typeof(byte);
        }

        public override object Generate()
        {
            return (byte) Random.Next(MaxValue);
        }
    }
}