# gravatar-dotnet [![CI](https://github.com/patchoulish/gravatar-dotnet/actions/workflows/ci.yml/badge.svg)](https://github.com/patchoulish/gravatar-dotnet/actions/workflows/ci.yml)
A .NET library for interacting with the [Gravatar](https://gravatar.com/) API.


## Installation
Install the library via [NuGet](https://www.nuget.org/packages/gravatar-dotnet):
```bash
dotnet add package gravatar-dotnet
```

### Extensions
Install optional library extensions for more functionality, depending on your use case.
#### Dependency Injection
Integrate gravatar-dotnet and your DI container of choice. Install the extension library via [NuGet](https://www.nuget.org/packages/gravatar-dotnet-dependencyinjection):
```bash
dotnet add package gravatar-dotnet-dependencyinjection
```
#### ASP.Net Core Additions
Integrate gravatar-dotnet and ASP.NET Core with Razor Tag Helpers for avatars and profile QR codes. Install the extension library via [NuGet](https://www.nuget.org/packages/gravatar-dotnet-aspnetcore):
```bash
dotnet add package gravatar-dotnet-aspnetcore
```


## Usage
1. Obtain an API key from the [Gravatar Developer Dashboard](https://gravatar.com/developers/applications) (requires a Gravatar account and developer application).
2. Pass the API key into a new instance of the `GravatarService` class or use a configured `HttpClient` if advanced configuration (e.g., proxies) is required.
3. Use the methods available on `GravatarService` to interact with the Gravatar API.

### Initialization
The library can be initialized in three ways:
#### Basic Initialization
Pass in your API key directly:
```csharp
var gravatar = new GravatarService("YOUR_GRAVATAR_API_KEY");
```
#### Advanced Initialization
Use an existing `HttpClient`, ensuring that `BaseAddress` and an `Authorization` header have been set:
```csharp
var httpClient = new HttpClient(
	new GravatarDelegatingHandler()
	{
		InnerHandler = new HttpClientHandler()
	},
	disposeHandler: true)
{
	BaseAddress = new Uri("https://api.gravatar.com/v3/"),
	Timeout = TimeSpan.FromSeconds(5)
};

httpClient.DefaultRequestHeaders.Add(
	$"Authorization",
	$"Bearer YOUR_GRAVATAR_API_KEY");

var gravatar = new GravatarService(httpClient);
```
#### Dependency Injection
If you've installed the appropriate extension library.
1. Register `GravatarService` with your dependency container:
```csharp
services.AddGravatarHttpClient(options =>
{
	options.BaseUrl = new Uri("https://api.gravatar.com/v3/");
	options.ApiKey = "YOUR_GRAVATAR_API_KEY";
});
```
2. Inject `IGravatarService` where needed:
```csharp
public class MyClass
{
    private readonly IGravatarService gravatar;

    public MyClass(IGravatarService gravatar)
    {
        this.gravatar = gravatar;
    }
}
```

### Getting an Avatar URL
You can construct a valid Gravatar Avatar URL as follows:
```csharp
var gravatarAvatarUrl =
	GravatarHelper.GetAvatarUrl(
		"self@example.com",
		size: 64,
		defaultValue: GravatarAvatarDefault.Identicon,
		forceDefaultValue: false,
		rating: GravatarAvatarRating.G,
		withFileExtension: false)
```
To retrieve the avatar image, make a HTTP GET request to the URL that is returned.

### Getting a Profile
```csharp
var gravatarProfile =
    await gravatar.GetProfileAsync(
        GravatarHelper.GetEmailAddressHash(
            "self@example.com"));
```

### Getting a Profile QR Code URL
You can construct a valid Gravatar Profile QR Code URL as follows:
```csharp
var gravatarProfileQRCodeUrl =
	GravatarHelper.GetProfileQRCodeUrl(
		"self@example.com",
		size: 256,
		type: GravatarProfileQRCodeType.Logo,
		version: GravatarProfileQRCodeVersion.Modern)
```
To retrieve the profile QR code image, make a HTTP GET request to the URL that is returned.

### Using Tag Helpers
If you've installed the appropriate extension library, add the following to your `_ViewImport.cshtml`:
```razor
@addTagHelper *, Gravatar.Extensions.AspNetCore
```

To automatically construct the `src` URL for an `img` tag from a Gravatar Avatar URL, use `gravatar-avatar` and the various `gravatar-*` attributes supplied.
```razor
<img gravatar-avatar
     gravatar-email-address="Context.User.Claims..."
     gravatar-default="identicon"
     ... />
```

To automatically construct the `src` URL for an `img` tag from a Gravatar Profile QR Code URL, use `gravatar-profile-qrcode` and the various `gravatar-*` attributes supplied.
```razor
<img gravatar-profile-qrcode
     gravatar-email-address="Context.User.Claims..."
     ... />
```


## Documentation
Refer to the [Usage](#usage) section above for a quick start, or consult the inline documentation while working in your IDE. For detailed information about the underlying API endpoints, parameters, and expected responses, refer to the [official Gravatar API documentation](https://docs.gravatar.com/api/profiles/rest-api/).


## Contributing
Contributions are welcome! To contribute, fork the repository, create a new branch, and submit a pull request with your changes. Please make sure all tests pass before submitting.


## License
This project is licensed under the MIT license. See `license.txt` for full details.
