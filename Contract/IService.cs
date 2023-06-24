using ServeMe_M2.Model;
using ServeMe_M2.Model.DTOs;
using ServeMe_M2.Model.RequestResponse;

namespace ServeMe_M2.Contract
{
    public interface IService
    {
        public Task<ServiceModel> RequestService(RequestServiceDto requestServiceDto);
        public Task<IEnumerable<ServiceModel>> getAllServiceRequest(string userId);

        public Task<IEnumerable<Category>> GetCategories();
        public Task<QuotationTemplate> GetQuotation(QuotiationRequestTemplate quotiationRequestTemplate);
        public QuotationTemplate getPreRequestQuotation(RequestServiceDto serviceModel);
        public Task<bool> AcceptService(AcceptService acceptService);
        public Task<IEnumerable<ServiceModel>> getPendingServices(string userId);
        public Task<bool> cancelRequest(AcceptService acceptService);


    }
}
