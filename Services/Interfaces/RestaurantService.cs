using Services.DTO.Request;
using Services.DTO.Response;
namespace Services.Interfaces
{
    public interface RestaurantService
    {
        public bool AddRestaurant(AddRestaurant restaurantRequest);

        public bool DeleteRestaurant(int idRestaurant);

        public bool EditarRestaurant(int idRestaurant,EditRestaurantRequest editRestaurant);

        public IEnumerable<RestaurantResponse> GetRestaurants();

    }
}
