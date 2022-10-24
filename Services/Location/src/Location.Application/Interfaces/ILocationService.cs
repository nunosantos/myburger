using Location.Application.Models;

namespace Location.Application.Interfaces
{
    public interface ILocationService
    {
        void Create(LocationDTO locationDTO);
    }
}