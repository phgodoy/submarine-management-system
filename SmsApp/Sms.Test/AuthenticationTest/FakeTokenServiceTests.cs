using Sms.Infra.Ioc.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Sms.Infra.Ioc;
using Xunit;

namespace Sms.Test.AuthenticationTest;

public class FakeTokenServiceTests
{
    [Fact]
    public void Generates_fake_token()
    {
        var result = new LocalTokenService().GenerateToken("teste@email.com");

        Assert.Equal(LocalTokenService.Token, result.Token);
        Assert.True(result.Expiration > DateTime.UtcNow);
    }

    [Theory]
    [InlineData("Development", typeof(LocalTokenService))]
    [InlineData("Production", typeof(JwtTokenService))]
    public void Selects_token_service_by_environment(string environmentName, Type expectedType)
    {
        var configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["Jwt:SecretKey"] = "test-secret-key-with-at-least-32-characters",
            ["Jwt:Issuer"] = "test",
            ["Jwt:Audience"] = "test"
        }).Build();
        var services = new ServiceCollection();

        services.AddInfrastructureJWT(configuration, new TestEnvironment(environmentName));

        using var provider = services.BuildServiceProvider();
        Assert.IsType(expectedType, provider.GetRequiredService<ITokenService>());
    }

    private sealed class TestEnvironment(string environmentName) : IHostEnvironment
    {
        public string EnvironmentName { get; set; } = environmentName;
        public string ApplicationName { get; set; } = "Sms.Test";
        public string ContentRootPath { get; set; } = string.Empty;
        public IFileProvider ContentRootFileProvider { get; set; } = new NullFileProvider();
    }
}
