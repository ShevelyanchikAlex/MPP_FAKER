namespace GeneratorsLib.Impl.PrimTypeGenerator
{
    public class ByteAbstractGenerator : AbstractGenerator
    {
        private const int MaxValue = 256;

        public ByteAbstractGenerator()
        {
            TypeOfObj = typeof(byte);
        }

        public override object Generate()
        {
            return (byte) Random.Next(MaxValue);
        }
    }
}