using HotelProject.Core.Concrates.DTOs.AppUserDto;
using HotelProject.Core.Concrates.DTOs.CustomResponseDto;

namespace HotelProject.WebUI.ApiServices
{
    public class AppUserApiService
    {
        private readonly HttpClient _httpClient;

        public AppUserApiService(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            _httpClient = httpClientFactory.CreateClient("AppUserApiClient");
        }

        public async Task<List<UserDTO>> GetAllUser()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<List<UserDTO>>>("api/AppUser");
            return response.Data;
        }

        public async Task<UpdateUserDTO> GetUserById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<UpdateUserDTO>>($"api/AppUser/{id}");
            return response.Data;
        }

        public async Task<CreateUserDTO> CreateUser(CreateUserDTO createUserDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/AppUser", createUserDto);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDTO<CreateUserDTO>>();

            return responseBody.Data;
        }

        public async Task<bool> UpdateUser(UpdateUserDTO updateUserDto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/AppUser", updateUserDto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/AppUser/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
