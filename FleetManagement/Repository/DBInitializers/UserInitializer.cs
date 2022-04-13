
using Microsoft.AspNetCore.Identity;



namespace Repository.DBInitializers
{
    public class UserInitializer
    {

        static private readonly List<Tuple<string, string>> _users = new()
        {
            new Tuple<string, string>("normaluser", "Normal"),
            new Tuple<string, string>("manageruser", "Manager"),
            new Tuple<string, string>("adminuser", "Admin"),
        };


        public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
            SeedRolesToUsers(userManager, roleManager);

        }

        private static  void SeedRolesToUsers(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            foreach(var user in _users)
            {
                var u =  userManager.FindByNameAsync(user.Item1).Result;
                var ur =  userManager.GetRolesAsync(u).Result;

                if(!ur.Contains(user.Item2))
                {
                    var result =  userManager.AddToRoleAsync(u, user.Item2).Result;

                    if(result == null)
                    {
                        throw new Exception("Failed to assigne role to User: " + user.Item1 + " Role: " + user.Item2);
                    }
                }
              
            }
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {

            foreach(var user in _users)
            {
                EnsureUser(userManager, user.Item1, "user123");
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach(var user in _users)
            {
                EnsureRole(roleManager, user.Item2);
            }

        }


        private static void EnsureUser(UserManager<IdentityUser> userManager, string username, string password)
        {
            var user = userManager.FindByNameAsync(username).Result;
            if(user == null)
            {
                user = new IdentityUser
                {
                    UserName = username,
                    EmailConfirmed = true
                };
                userManager.CreateAsync(user, password).Wait();
            }

            if(user == null)
            {
                throw new Exception("Failed to create User: " + username);
            }
        }

        private static void EnsureRole(RoleManager<IdentityRole> roleManager, string role)
        {

            if(!roleManager.RoleExistsAsync(role).Result)
            {
                var IR = roleManager.CreateAsync(new IdentityRole(role)).Result;

                if(IR == null)
                {
                    throw new Exception("Failed to create Role: " + role);
                }
            }
        }

    }
}
