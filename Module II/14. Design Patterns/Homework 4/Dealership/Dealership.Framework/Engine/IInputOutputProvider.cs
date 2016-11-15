namespace Dealership.Engine
{
    public interface IInputOutputProvider
    {
        string ReadLine();

        void WriteLine(string line);
    }
}
