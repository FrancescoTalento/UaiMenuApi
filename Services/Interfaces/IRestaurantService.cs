using Services.DTO.Request;
using Services.DTO.Response;
namespace Services.Interfaces
{
    public interface IRestaurantService
    {
        public RestaurantResponse AddRestaurant(CreateRestaurant restaurantRequest);

        public bool DeleteRestaurant(int idRestaurant);

        public RestaurantResponse EditarRestaurant(int idRestaurant,EditRestaurantRequest editRestaurant);

        public IEnumerable<RestaurantResponse> GetRestaurants();

    }
}
