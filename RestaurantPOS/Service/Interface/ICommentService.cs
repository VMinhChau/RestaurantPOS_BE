using RestaurantPOS.Dtos.Comment.Request;
using RestaurantPOS.Dtos.Comment.Response;

namespace RestaurantPOS.Service.Interface
{
    public interface ICommentService
    {
        Task<CommentDto> CreateAsync(CreateCommentDto input);
        Task<CommentDto> UpdateAsync(int id, UpdateCommentDto input);
        Task DeleteAsync(int id);
        Task<List<CommentDto>> GetAsync();
    }
}
