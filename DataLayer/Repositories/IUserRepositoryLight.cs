namespace DataLayer.Repositories
{
    public interface IUserRepositoryLight
    {
        bool ExistsByPhone(string phone);
        bool ExistsByUsername(string username);
        bool ExistsByNationalId(string nationalId);
    }
}
