using BlazorUtils.EasyApi;
using BlazorUtils.EasyApi.Server;
using EasyApiWebsite.Contract;
using EasyApiWebsite.Contract.Model;
using EasyApiWebsite.Persistence;

namespace EasyApiWebsite.Handlers;

internal class LikePostHandler(PostsRepository PostsRepository) : IHandle<LikePost, Post>
{
    public async Task<HttpResult<Post>> Handle(LikePost request, CancellationToken cancellationToken)
    {
        var postToLike = await PostsRepository.GetById(request.PostId);

        if (postToLike is null)
        {
            return HttpResult<Post>.NotFound();
        }

        var likedPost = new Post(postToLike.Id, postToLike.Author, postToLike.Content, postToLike.Likes + 1);
        await PostsRepository.Update(likedPost);

        return HttpResult<Post>.Ok(likedPost);
    }
}
