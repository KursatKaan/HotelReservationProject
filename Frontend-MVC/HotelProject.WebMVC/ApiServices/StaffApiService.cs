using HotelProject.Core.Concrates.DTOs.CustomResponseDto;
using HotelProject.Core.Concrates.DTOs.StaffDto;

namespace HotelProject.WebUI.ApiServices
{
    public class StaffApiService
    {

        private readonly HttpClient _httpClient;

        public StaffApiService(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            _httpClient = httpClientFactory.CreateClient("StaffApiClient");
        }

        public async Task<List<StaffDTO>> GetAllStaff()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<List<StaffDTO>>>("api/Staff");
            return response.Data;
        }

        public async Task<UpdateStaffDTO> GetStaffById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<UpdateStaffDTO>>($"api/Staff/{id}");
            return response.Data;
        }

        public async Task<CreateStaffDTO> CreateStaff(CreateStaffDTO createStaffDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Staff", createStaffDto);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDTO<CreateStaffDTO>>();

            return responseBody.Data;
        }

        public async Task<bool> UpdateStaff(UpdateStaffDTO updateStaffDto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Staff", updateStaffDto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteStaff(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Staff/{id}");

            return response.IsSuccessStatusCode;
        }

    }
}
