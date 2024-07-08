using ShopServer.Business.Dto;
using ShopServer.Business.Request.AddRequest;
using ShopServer.Business.Request.UpdateRequest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Business.Service.Interface
{
    public interface ICustomerService
    {
        public Task<CustomerDto> GetCustomer(int id);
        public Task<CustomerDto> Add(CustomerAddRequest _request);
        public Task<CustomerDto> Update(CustomerUpdateRequest _request);
        public Task<CustomerDto> Delete(int id);
        public Task<List<CustomerDto>> GetAll();
    }
}
