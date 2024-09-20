using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("D29D4237-D4E1-4FD9-94BA-0195AD4676ED"),
                RoleId = Guid.Parse("808544F8-CB21-4496-8DC2-55B640C2DAC1")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("D4FEB138-6AF3-4017-B511-FA9662F062F7"),
                RoleId = Guid.Parse("C940A422-3A97-4DB4-A48A-BEB06D5E1B02"),
            }
            
            );
        }
    }
}
