# Pacote NuGet Dotnet - APIGratis by API BRASIL
Conjunto de API, para desenvolvedores.

Transforme seus projetos em soluções inteligentes com nossa API. Com recursos como API do WhatsApp, geolocalização, rastreamento de encomendas, verificação de CPF/CNPJ e mais, você pode criar soluções eficientes e funcionais.

# Canais de suporte (Comunidade)
[![WhatsApp Group](https://img.shields.io/badge/WhatsApp-Group-25D366?logo=whatsapp)](https://chat.whatsapp.com/KsxrUGIPWvUBYAjI1ogaGs)
[![Telegram Group](https://img.shields.io/badge/Telegram-Group-32AFED?logo=telegram)](https://t.me/apigratisoficial)

# Obtenha suas credenciais
https://apibrasil.com.br/

# Exemplo 

AppSettings.Json
```
"ApiBrasilConfiguration": {
        "SecretKey": "mySecretKey",
        "PublicToken": "myPublicToken",
        "DeviceToken": "myDeviceToken",
        "Authorization": "myAuthorization"
    }
```

Option Pattern importing ApiBrasil.Domain
Program.cs
```
builder.Services.Configure<ApiBrasilConfiguration>(builder.Configuration.GetSection("ApiBrasilConfiguration"));
```

Example
```
import ApiBrasil;

private readonly ApiBrasilConfiguration _apiBrasil;

public Construct(IOptions<ApiBrasilConfiguration> apibrasil)
{
    _apiBrasil = apibrasil.Value;
}

public class ApiBrasilDto
{
    public string Type { get; set; }
    public string Action { get; set; }
    public object Content { get; set; }
}

[HttpPost("v1/apibrasil")]
public async Task<IActionResult> TestApiBrasil([FromBody] ApiBrasilDto var)
{
    try
    {
        var result = await ApiBrasil.GenericCaller.Call(var.Type, var.Action, var.Content, _apiBrasil);

        return Ok(result);
    }
    catch (Exception ex)
    {
        return StatusCode(500, ex);
    }
}
```
