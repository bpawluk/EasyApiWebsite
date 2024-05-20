using EasyApiWebsite.Contract.Model;

namespace EasyApiWebsite.Server.Persistence;

public class PostsRepository
{
    private readonly Dictionary<Guid, Post> _posts = [];

    public PostsRepository()
    {
        Add("Sully", "Just finished an amazing hike in the mountains! 🏞️ Nature always has a way of rejuvenating my soul. Can't wait for the next adventure! #NatureLover #Hiking");
        Add("Brooklyn", "Trying out a new recipe tonight - homemade pizza from scratch! 🍕 Who else loves getting creative in the kitchen? Let's see if I can make it as delicious as it looks on Pinterest! #Foodie #CookingFun");
        Add("Skyler", "Feeling grateful for all the love and support from my friends and family. 💕 It's moments like these that remind me how lucky I am to have such wonderful people in my life. #Gratitude #Blessed");
        Add("Jesse", "Just finished a great workout session at the gym! 🏋️‍♂️ It's amazing how a good sweat can lift your spirits and energize you for the day. Who else loves that post-workout feeling? #FitnessJourney #HealthyLiving");
        Add("Steven", "Exploring a new city today and stumbled upon this charming little café. ☕️ Sometimes the best adventures are the ones you didn't plan for! Can't wait to see what else this city has in store. #TravelBug #AdventureAwaits");
    }

    public Task Add(string author, string content)
    {
        var postId = Guid.NewGuid();
        _posts[postId] = new(postId, author, content, 0);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Post>> GetAll() => Task.FromResult<IEnumerable<Post>>(_posts.Values);

    public Task<Post?> GetById(Guid postId)
    {
        if (_posts.TryGetValue(postId, out Post? value))
        {
            return Task.FromResult<Post?>(value);
        }
        return Task.FromResult<Post?>(null);
    }

    public Task<bool> Update(Post updatedPost)
    {
        if (_posts.ContainsKey(updatedPost.Id))
        {
            _posts[updatedPost.Id] = updatedPost;
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<bool> Delete(Guid postId) => Task.FromResult(_posts.Remove(postId));
}
