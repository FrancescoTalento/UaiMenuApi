using Services.DTO.Request;
using Services.DTO.Response;
namespace Services.Interfaces
{
    public interface IRestaurantService
    {
        public Task<RestaurantResponse> AddRestaurant(CreateRestaurant restaurantRequest);

        public Task<bool> DeleteRestaurant(long idRestaurant);

        public Task<RestaurantResponse> EditarRestaurant(long idRestaurant,EditRestaurantRequest editRestaurant);

        public Task<IEnumerable<RestaurantResponse>> GetRestaurants();

    }
}
