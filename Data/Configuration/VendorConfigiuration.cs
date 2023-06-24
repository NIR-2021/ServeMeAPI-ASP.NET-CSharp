using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServeMe_M2.Model;

namespace ServeMe_M2.Data.Configuration
{
    public class VendorConfigiuration : IEntityTypeConfiguration<VendorModel>
    {
        

        public void Configure(EntityTypeBuilder<VendorModel> builder)
        {
            builder.HasData(
                new VendorModel
                {
                    vendorId = 1,
                    vendorName = "Nirbheek",
                    vendorAddress = "america",
                    vendorEmail = "Username@gmail.com",
                    vendorPhone = "9924804879",
                    Id = "7302a0e6-58b7-4bac-a96e-ac2f7419c1b3"

                }


                );
            ;
        }
    }
}
