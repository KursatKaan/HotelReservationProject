using HotelProject.Core.Concrates.DTOs.CustomResponseDto;
using HotelProject.Core.Concrates.DTOs.SubscribeDto;

namespace HotelProject.WebUI.ApiServices
{
    public class SubscribeApiService
    {
        private readonly HttpClient _httpClient;

        public SubscribeApiService(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            _httpClient = httpClientFactory.CreateClient("SubscribeApiClient");
        }

        public async Task<List<SubscribeDTO>> GetAllSubscribe()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<List<SubscribeDTO>>>("api/Subscribe");
            return response.Data;
        }

        public async Task<UpdateSubscribeDTO> GetSubscribeById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<UpdateSubscribeDTO>>($"api/Subscribe/{id}");
            return response.Data;
        }

        public async Task<CreateSubscribeDTO> CreateSubscribe(CreateSubscribeDTO createSubscribeDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Subscribe", createSubscribeDto);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDTO<CreateSubscribeDTO>>();

            return responseBody.Data;
        }

        public async Task<bool> UpdateSubscribe(UpdateSubscribeDTO updateSubscribeDto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Subscribe", updateSubscribeDto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteSubscribe(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Subscribe/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
