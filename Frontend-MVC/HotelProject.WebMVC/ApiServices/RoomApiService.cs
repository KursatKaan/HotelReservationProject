using HotelProject.Core.Concrates.DTOs.CustomResponseDto;
using HotelProject.Core.Concrates.DTOs.RoomDto;

namespace HotelProject.WebUI.ApiServices
{
    public class RoomApiService
    {
        private readonly HttpClient _httpClient;

        public RoomApiService(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            _httpClient = httpClientFactory.CreateClient("RoomApiClient");
        }

        public async Task<List<RoomDTO>> GetAllRoom()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<List<RoomDTO>>>("api/Room");
            return response.Data;
        }

        public async Task<UpdateRoomDTO> GetRoomById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<UpdateRoomDTO>>($"api/Room/{id}");
            return response.Data;
        }

        public async Task<CreateRoomDTO> CreateRoom(CreateRoomDTO createRoomDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Room", createRoomDto);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDTO<CreateRoomDTO>>();

            return responseBody.Data;
        }

        public async Task<bool> UpdateRoom(UpdateRoomDTO updateRoomDto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Room", updateRoomDto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteRoom(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Room/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
