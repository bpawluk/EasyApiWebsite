using BlazorUtils.EasyApi;

namespace EasyApiWebsite.Contract;

[Route("api/posts")]
public class AddPost : IPost
{
    [BodyParam]
    public string Author { get; init; } = default!;

    [BodyParam]
    public string Content { get; init; } = default!;
}
