using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserAggregate
    {
        LibeyUserResponse FindResponse(string documentNumber);
        void Create(UserUpdateorCreateCommand command);
        void Update(string documentNumber, LibeyUser updatedUser);
        void Delete(string documentNumber);

        List<LibeyUserResponse> GetAll();
    }
}