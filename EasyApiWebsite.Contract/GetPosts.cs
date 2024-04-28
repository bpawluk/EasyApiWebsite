using BlazorUtils.EasyApi;
using EasyApiWebsite.Contract.Model;

namespace EasyApiWebsite.Contract;

[Route("api/posts")]
public class GetPosts : IGet<IEnumerable<Post>> { }
