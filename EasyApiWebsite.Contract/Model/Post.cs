namespace EasyApiWebsite.Contract.Model;

public record Post(Guid Id, string Author, string Content, int Likes);
