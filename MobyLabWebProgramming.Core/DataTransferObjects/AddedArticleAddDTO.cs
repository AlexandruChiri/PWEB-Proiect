namespace MobyLabWebProgramming.Core.DataTransferObjects;

public class AddedArticleAddDTO
{
    public Guid ArticleId { get; set; }
    // public Guid CosId { get; set; }
    public int Cnt { get; set; } = default!;
}