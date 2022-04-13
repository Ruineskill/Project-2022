using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntityTypeConfigurations
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.Ignore(u => u.NormalizedUserName);
            builder.Ignore(u => u.Email);
            builder.Ignore(u => u.EmailConfirmed);
            builder.Ignore(u => u.NormalizedEmail);
            builder.Ignore(u => u.PhoneNumber);
            builder.Ignore(u => u.PhoneNumberConfirmed);
            builder.Ignore(u => u.LockoutEnabled);
            builder.Ignore(u => u.LockoutEnd);
            builder.Ignore(u => u.TwoFactorEnabled);

        }
    }
}
