using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServeMe_M2.Contract;
using ServeMe_M2.Data;
using ServeMe_M2.Model;
using ServeMe_M2.Model.DTOs;

namespace ServeMe_M2.Repo
{
    public class VendorManager : IVendor
    {
        private readonly ServeMeDbContext db;
        private readonly IMapper mapper;

        public VendorManager(ServeMeDbContext db,IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<VendorDto>> getVendorDetails(VendorDto v)
        {
            var vendors = await db.vendors
                                    .Where(a => a.Id == v.Id)
                                    .Include(b => b.Category)
                                    .ToListAsync();
            var vendors_new = mapper.Map<IEnumerable<VendorDto>>(vendors);
            return vendors_new;
        }

        public async Task<bool>addVendorWithCat(List<VendorDto> vendorDtos)
        {

            List<VendorModel> list = new List<VendorModel>();

            foreach(VendorDto v in vendorDtos)
            {
                var vendor = mapper.Map<VendorModel>(v);
                list.Add(vendor);
            }

            db.AddRange(list);
            var done =await db.SaveChangesAsync();

            return done > 0 ? true:false ;
        }
    }
}
