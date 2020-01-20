namespace DependencyInjection.CSharp
{
    public class InMemory : IDatabase
    {
        private int id = 0;
        public int NextDocumentId()
        {
            return id ++;
        }
    }
}