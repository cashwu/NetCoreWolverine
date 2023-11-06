using Alba;

namespace WolverineTests;

public class Tests
{
    [Fact]
    public async Task HomeTest()
    {
        await using var host = await AlbaHost.For<Program>();
        await host.Scenario(a =>
        {
            a.Get.Url("/");
            a.StatusCodeShouldBeOk();
            a.ContentShouldBe("OK");
        });
    }
}