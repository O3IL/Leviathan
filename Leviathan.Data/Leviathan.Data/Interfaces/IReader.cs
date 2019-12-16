using System.Text;

namespace Leviathan.Data.Interfaces
{
    public interface IReader
    {
        string Read(EncodingProvider encodingProvider, string encodingName);
        string Read(Encoding encoding);

        int AddBytes(byte[] data);
    }
}