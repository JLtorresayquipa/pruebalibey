using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        public LibeyUserAggregate(ILibeyUserRepository repository)
        {
            _repository = repository;
        }
        public void Create(UserUpdateorCreateCommand command)
        {
            var newUser = new LibeyUser(
            command.DocumentNumber,
            command.DocumentTypeId,
            command.Name,
            command.FathersLastName,
            command.MothersLastName,
            command.Address,
            command.UbigeoCode,
            command.Phone,
            command.Email,
            command.Password);

        _repository.Create(newUser);
        }
        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }

        public List<LibeyUserResponse> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(string documentNumber, LibeyUser updatedUser)
        {
            _repository.Update(documentNumber, updatedUser);
        }
        public void Delete(string documentNumber)
        {
            _repository.Delete(documentNumber);
        }

    }
}