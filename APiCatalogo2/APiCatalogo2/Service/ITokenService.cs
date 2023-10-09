using APiCatalogo2.Model;

namespace APiCatalogo2.Service
{
    public interface ITokenService
    {

        string GerarToken(string key, string issuer, string audience, UserModel userModel);


    }
}
