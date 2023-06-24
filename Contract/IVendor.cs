using ServeMe_M2.Model;
using ServeMe_M2.Model.DTOs;

namespace ServeMe_M2.Contract
{
    public interface IVendor
    {
        public Task<IEnumerable<VendorDto>> getVendorDetails(VendorDto v);
        public Task<bool> addVendorWithCat(List<VendorDto> vendorDtos);

    }
}
