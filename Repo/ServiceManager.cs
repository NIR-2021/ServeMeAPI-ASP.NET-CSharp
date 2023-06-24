using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServeMe_M2.Contract;
using ServeMe_M2.Data;
using ServeMe_M2.Model;
using ServeMe_M2.Model.DTOs;
using ServeMe_M2.Model.RequestResponse;

namespace ServeMe_M2.Repo
{
    public class ServiceManager : IService
    {
        private readonly IMapper mapper;
        private readonly ServeMeDbContext context;
        private readonly float TAX = 15;

        public ServiceManager(IMapper mapper,ServeMeDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ServiceModel> RequestService(RequestServiceDto requestServiceDto)
        {
            ServiceModel service = mapper.Map<ServiceModel>(requestServiceDto);
            context.services.Add(service);
            await context.SaveChangesAsync();
            return service;

        }

        public async Task<IEnumerable<ServiceModel>> getAllServiceRequest(string userId)
        {
            var result =  await context.services
                                .Include(b=> b.category)
                                .Where(b => b.Id == userId)
                                .ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await context.categories.ToListAsync();
        }

        public async Task<ServiceModel> getServiceRequest(int serviceId)
        {
            var item = await context.services
                .Include(b=>b.user)
                .Include(b=> b.category)
                                    .FirstOrDefaultAsync(a=>a.serviceId == serviceId);

            var temp2 = mapper.Map<ApiUserDto>(item.user);
            item.user = mapper.Map<ApiUser>(temp2);
           
            return item;
        }

        public async Task<QuotationTemplate> GetQuotation(QuotiationRequestTemplate quotiationRequestTemplate)
        {
            var servie = await getServiceRequest(quotiationRequestTemplate.serviceId);
            var item = mapper.Map<QuotationTemplate>(servie);

            if (item != null)
            {
                float tax = (servie.bid * 15) / 100;
                float total = servie.bid + tax;
                float commission = tax;
                float vendor_profit = servie.bid - tax;

                item.tax = tax;
                item.total = total;
                item.commission = commission;
                item.vendor_profit = vendor_profit;

            }


            return item;
        }

        public QuotationTemplate getPreRequestQuotation(RequestServiceDto serviceModel)
        {

            float bid = serviceModel.bid;
            float tax = (bid * 15) / 100;
            float total = bid + tax;
            var service = mapper.Map<ServiceModel>(serviceModel);
            var item = mapper.Map<QuotationTemplate>(service);
            item.tax = tax;
            item.total = total;

            return item;
        }

        public async Task<bool> AcceptService(AcceptService acceptService)
        {
            ServiceModel service = await context.services
                                                .Where(a =>a.serviceId == acceptService.serviceId)
                                                .Where(a => a.Id == acceptService.Id)
                                                .FirstOrDefaultAsync();

            if (service == null)
            {
                return false;
            }
            else {

                service.status = "accepted";
                context.services.Update(service);
                //Create order .And finalize payment 
                context.SaveChanges();
                return true;
            }

        }

        public async Task<IEnumerable<ServiceModel>> getPendingServices(string userId)
        {
            var result = await context.services
                                .Include(b => b.category)
                                .Where(b => b.Id == userId)
                                .Where(c=>c.status == "pending")
                                .ToListAsync();
            return result;
        }

        public async Task<bool> cancelRequest(AcceptService acceptService){
            ServiceModel service = await context.services
                                               .Where(a => a.serviceId == acceptService.serviceId)
                                               .Where(a => a.Id == acceptService.Id)
                                               .FirstOrDefaultAsync();

            if(service != null)
            {
                service.status = "cancelled";
                context.services.Update(service);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }


    }

}
