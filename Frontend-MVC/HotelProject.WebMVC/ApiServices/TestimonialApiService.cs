using HotelProject.Core.Concrates.DTOs.CustomResponseDto;
using HotelProject.Core.Concrates.DTOs.TestimonialDto;

namespace HotelProject.WebUI.ApiServices
{
    public class TestimonialApiService
    {
        private readonly HttpClient _httpClient;

        public TestimonialApiService(IHttpClientFactory httpClientFactory, HttpClient httpClient)
        {
            _httpClient = httpClientFactory.CreateClient("TestimonialApiClient");
        }

        public async Task<List<TestimonialDTO>> GetAllTestimonial()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<List<TestimonialDTO>>>("api/Testimonial");
            return response.Data;
        }

        public async Task<UpdateTestimonialDTO> GetTestimonialById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDTO<UpdateTestimonialDTO>>($"api/Testimonial/{id}");
            return response.Data;
        }

        public async Task<CreateTestimonialDTO> CreateTestimonial(CreateTestimonialDTO createTestimonialDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Testimonial", createTestimonialDTO);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDTO<CreateTestimonialDTO>>();

            return responseBody.Data;
        }

        public async Task<bool> UpdateTestimonial(UpdateTestimonialDTO updateTestimonialDTO)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Testimonial", updateTestimonialDTO);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTestimonial(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Testimonial/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
