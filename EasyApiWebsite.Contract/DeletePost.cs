using BlazorUtils.EasyApi;

namespace EasyApiWebsite.Contract;

[ProtectedRoute("api/posts/{PostId}")]
public class DeletePost : IDelete
{
    [RouteParam]
    public Guid PostId { get; init; }
}
