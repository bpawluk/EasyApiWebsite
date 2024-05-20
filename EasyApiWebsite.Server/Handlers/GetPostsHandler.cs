using BlazorUtils.EasyApi;
using BlazorUtils.EasyApi.Server;
using EasyApiWebsite.Contract;
using EasyApiWebsite.Contract.Model;
using EasyApiWebsite.Server.Persistence;

namespace EasyApiWebsite.Server.Handlers;

internal class GetPostsHandler(PostsRepository PostsRepository) : IHandle<GetPosts, IEnumerable<Post>>
{
    public async Task<HttpResult<IEnumerable<Post>>> Handle(GetPosts request, CancellationToken cancellationToken)
    {
        var posts = await PostsRepository.GetAll();
        return HttpResult<IEnumerable<Post>>.Ok(posts);
    }
}
