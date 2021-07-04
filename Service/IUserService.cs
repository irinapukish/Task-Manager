namespace TaskManager.Service
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}