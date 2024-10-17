namespace JobQuest.Interface
{
    public interface IAuthorizationService
    {
        Task<bool> HasPermission(string userId, string permission);
    }
}
