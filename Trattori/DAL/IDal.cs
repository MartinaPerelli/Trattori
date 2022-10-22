namespace Trattori.DAL
{
    public interface IDal
    {
        public void WriteAndSerialize<T>(IEnumerable<T> collection);
        public IEnumerable<T> ReadAndDeserialize<T>();
    
    }
}
