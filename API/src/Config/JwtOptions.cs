namespace src.Config;

public class JwtOptions
{
    public string? Key { get; init; }
    public string? Issuer { get; init; } 
    public string? Audience { get; init; } 
}

/*
 *  "JWT" : {
    "Key" : "MyVerySecretKey_YouShouldStoreThisIn_AzureVault_AwsSecretManager_UserSecrets",
    "Issuer" : "https://localhost:7059",
    "Audience" : "https://localhost:7059"
  }
 */