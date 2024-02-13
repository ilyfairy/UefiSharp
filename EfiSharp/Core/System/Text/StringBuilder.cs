namespace System.Text;

public class StringBuilder : IDisposable
{
    internal char[] m_ChunkChars;

    internal int m_ChunkLength;

    public int Capacity => m_ChunkChars.Length;
    public int Length => m_ChunkLength;

    public StringBuilder(int capacity)
    {
        
    }

    public void Dispose()
    {
        
    }
}
