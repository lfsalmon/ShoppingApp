using ShopServer.Business.Dto;
using ShopServer.Business.Request.AddRequest;
using ShopServer.Business.Request.UpdateRequest;
using ShopServer.Business.Service.Interface;
using ShopServer.Data.Repositories;
using ShopServer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServer.Business.Service
{
    public class CustomerService : ICustomerService
    {

        private readonly IGenericRepository<Customer> _repository;

        public CustomerService(IGenericRepository<Customer> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<CustomerDto> Add(CustomerAddRequest _request) => new CustomerDto(await _repository.Add(_request.GetEntity()));

        public async Task<CustomerDto> Delete(int id) => new CustomerDto(await _repository.Delete(id));

        public async Task<List<CustomerDto>> GetAll() => (await _repository.GetAll()).Select(x => new CustomerDto(x)).ToList();

        public async Task<CustomerDto> GetCustomer(int id) => new CustomerDto(await _repository.GetById(id));

        public async Task<CustomerDto> Update(CustomerUpdateRequest _request) => new CustomerDto(await _repository.Update(_request.GetEntity()));
    }
}
