using BlazorUtils.EasyApi;

namespace EasyApiWebsite.Contract;

[Route($"api/posts/{nameof(PostId)}")]
public class DeletePost : IDelete
{
    [RouteParam]
    public Guid PostId { get; init; }
}
