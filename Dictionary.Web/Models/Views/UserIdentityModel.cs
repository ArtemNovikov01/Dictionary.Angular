using Dictionary.Domain.Data.Entity.Enum;

namespace Dictionary.Web.Models.Views
{
    public class UserIdentityModel
    {
        public UserIdentityModel(RoleType roleType, string roleName) 
        {
            RoleType = roleType;
            RoleName = roleName;
        }

        /// <summary>
        ///     Роль пользователя.
        /// </summary>
        public RoleType RoleType { get; set; }
        public string RoleName { get; set;}
    }
}
