using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
                (
                    new User
                    {
                        Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                        Name = "Manye",
                        PhoneNumber = "1234567890",
                        RefreshToken = "1234567890",
                        RefreshTokenExpiryTime = new DateTime(),
                    },
                    new User
                    {
                        Id = new Guid("80abbca8-664d-83d3-b5de-024705497d4a"),
                        Name = "Akweley",
                        PhoneNumber = "1234567890",
                        RefreshToken = "1234567890",
                        RefreshTokenExpiryTime = new DateTime(),
                    }
                );
        }
    }
}
