using BlazorUtils.EasyApi;
using EasyApiWebsite.Contract.Model;

namespace EasyApiWebsite.Contract;

[Route("api/posts/{PostId}")]
public class LikePost : IPatch<Post>
{
    [RouteParam]
    public Guid PostId { get; init; }
}
