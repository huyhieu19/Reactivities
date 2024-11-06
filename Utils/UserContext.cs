using Domain;

namespace Utils;

public class UserContext
{
    private static readonly AsyncLocal<RuntimeContextInstance> _runtimeContext = new();

    public static RuntimeContextInstance RuntimeContext
    {
        get
        {
            if (_runtimeContext.Value == null)
            {
                _runtimeContext.Value = new RuntimeContextInstance();
            }
            return _runtimeContext.Value;
        }
        set
        {
            _runtimeContext.Value = value;
        }
    }
    public static void SetDefault()
    {
        RuntimeContext.User = new CurrentUser();
    }
    public static void SetUserData(CurrentUser user)
    {
        RuntimeContext.User = user;
    }
}

public class CurrentUser
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<RoleType> Roles { get; set; }

    public CurrentUser(Guid id, string name, string email, string phoneNumber, List<RoleType> roles)
    {
        Id = id;
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Roles = roles;
    }
    public CurrentUser()
    {
        //this.SetDefault();
    }
    public void SetDefault()
    {
        Id = Guid.Empty;
        Name = string.Empty;
        Email = string.Empty;
        PhoneNumber = string.Empty;
        Roles = [RoleType.Guest];
    }

}

public class RuntimeContextInstance
{
    public CurrentUser User { get; set; }
}