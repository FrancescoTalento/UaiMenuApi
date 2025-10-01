using Services.DTO.Request;
using Services.DTO.Response;
namespace Services.Interfaces
{
    public interface IRestaurantService
    {
        public Task<RestaurantResponse> AddRestaurant(CreateRestaurant restaurantRequest);

        public Task<RestaurantResponse>? EditarRestaurant(EditRestaurantRequest editRestaurant);
        
        public Task<bool> DeleteRestaurant(long idRestaurant);

        public Task<IEnumerable<RestaurantResponse>> GetRestaurants();

        public Task<RestaurantResponse>? GetRestaurantById(long id);

    }
}
