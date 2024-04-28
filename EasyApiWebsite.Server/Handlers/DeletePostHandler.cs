using BlazorUtils.EasyApi;
using BlazorUtils.EasyApi.Server;
using EasyApiWebsite.Contract;
using EasyApiWebsite.Persistence;

namespace EasyApiWebsite.Handlers;

internal class DeletePostHandler(PostsRepository PostsRepository) : IHandle<DeletePost>
{
    public async Task<HttpResult> Handle(DeletePost request, CancellationToken cancellationToken)
    {
        var deleted = await PostsRepository.Delete(request.PostId);
        return deleted ? HttpResult.NoContent() : HttpResult.NotFound();
    }
}
