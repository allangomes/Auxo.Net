using Auxo.Models;

namespace Auxo.Security
{
    public interface ICryptography
    {
        string Decrypt(Secure security);
        bool Same(Secure security, string value);
    }
}