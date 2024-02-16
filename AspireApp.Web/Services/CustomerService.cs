using AspireApp.Web.Records;
using Microsoft.AspNetCore.Components;
using System.Collections;
using System.Net.Http.Json;

namespace AspireApp.Web.Services
{
    public class CustomerService(HttpClient httpClient)
    {
        private readonly string remoteServiceBaseUrl = "api/customer/";

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await httpClient.GetFromJsonAsync<Customer[]>(remoteServiceBaseUrl) ?? [];
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            var uri = $"{remoteServiceBaseUrl}/{id}";
            return await httpClient.GetFromJsonAsync<Customer>(uri);
        }

        public async Task<int> CreateCustomer(Customer customer)
        {
            var response = await httpClient.PostAsJsonAsync(remoteServiceBaseUrl, customer);
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var uri = $"{remoteServiceBaseUrl}/{customer.Id}";
            var response = await httpClient.PutAsJsonAsync(uri, customer);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var uri = $"{remoteServiceBaseUrl}/{id}";
            var response = await httpClient.DeleteAsync(uri);

            return response.IsSuccessStatusCode;
        }
    }
}
