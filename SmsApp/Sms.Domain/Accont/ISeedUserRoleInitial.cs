namespace Sms.Domain.Accont
{
    public interface ISeedUserRoleInitial
    {
        Task SeedRolesAsync();

        Task SeedUsersAsync();
    }
}
