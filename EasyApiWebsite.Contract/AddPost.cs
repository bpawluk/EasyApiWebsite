using BlazorUtils.EasyApi;

namespace EasyApiWebsite.Contract;

[ProtectedRoute("api/posts")]
public class AddPost : IPost
{
    [BodyParam]
    public string Content { get; init; } = default!;
}
