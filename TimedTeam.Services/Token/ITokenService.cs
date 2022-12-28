
public interface ITokenService
{
    Task<TokenResponse> GetTokenAsync(TokenRequest model);
}
