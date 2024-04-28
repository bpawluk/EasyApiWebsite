using BlazorUtils.EasyApi;
using BlazorUtils.EasyApi.Server;
using EasyApiWebsite.Contract;
using EasyApiWebsite.Persistence;

namespace EasyApiWebsite.Handlers;

internal class AddPostHandler(PostsRepository PostsRepository) : IHandle<AddPost>
{
    public async Task<HttpResult> Handle(AddPost request, CancellationToken cancellationToken)
    {
        await PostsRepository.Add(request.Author, request.Content);
        return HttpResult.Created();
    }
}
