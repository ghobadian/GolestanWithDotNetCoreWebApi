namespace DataLayer.Repositories
{
    public interface IAbstractUserRepository
    {
        bool ExistsByPhone(string phone);
        bool ExistsByUsername(string username);
        bool ExistsByNationalId(string nationalId);
    }
}
