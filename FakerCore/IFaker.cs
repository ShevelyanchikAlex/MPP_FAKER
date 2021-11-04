namespace FakerLib
{
    public interface IFaker
    {
        T Create<T>() where T : class;
    }
}