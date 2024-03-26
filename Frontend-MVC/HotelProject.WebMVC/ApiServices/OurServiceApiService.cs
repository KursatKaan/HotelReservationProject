using HotelProject.Core.Concrates.DTOs.CustomResponseDto;
using HotelProject.Core.Concrates.DTOs.OurServiceDto;

namespace HotelProject.WebUI.ApiServices
{
    public class OurServiceApiService
    {
        private readonly HttpClient _httpClient;

        public OurServiceApiService(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            _httpClient = httpClientFactory.CreateClient("OurServiceApiClient");
        }

        public async Task<List<OurServiceDTO>> GetAllOurService()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<List<OurServiceDTO>>>("api/OurService");
            return response.Data;
        }

        public async Task<UpdateOurServiceDTO> GetOurServiceById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<UpdateOurServiceDTO>>($"api/OurService/{id}");
            return response.Data;
        }

        public async Task<CreateOurServiceDTO> CreateOurService(CreateOurServiceDTO createOurServiceDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/OurService", createOurServiceDto);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDTO<CreateOurServiceDTO>>();

            return responseBody.Data;
        }

        public async Task<bool> UpdateOurService(UpdateOurServiceDTO updateOurServiceDto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/OurService", updateOurServiceDto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteOurService(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/OurService/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
