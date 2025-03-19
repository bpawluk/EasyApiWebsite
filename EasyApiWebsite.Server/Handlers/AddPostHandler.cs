using BlazorUtils.EasyApi;
using BlazorUtils.EasyApi.Server;
using EasyApiWebsite.Contract;
using EasyApiWebsite.Server.Persistence;

namespace EasyApiWebsite.Server.Handlers;

internal class AddPostHandler(PostsRepository PostsRepository) : Handler<AddPost>
{
    public async override Task<HttpResult> Handle(AddPost request, CancellationToken cancellationToken)
    {
        var user = await GetUser();
        if (user.Identity?.IsAuthenticated is true)
        {
            await PostsRepository.Add(user.Identity.Name!, request.Content);
            return HttpResult.Created();
        }
        else
        {
            return HttpResult.Unauthorized();
        }
    }
}
