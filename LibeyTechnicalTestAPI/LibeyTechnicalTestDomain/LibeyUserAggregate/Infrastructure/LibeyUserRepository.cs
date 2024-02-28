using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }
        public void Create(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Add(libeyUser);
            _context.SaveChanges();
        }

        public List<LibeyUserResponse> GetAll()
        {
            var q = from libeyUser in _context.LibeyUsers
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Address = libeyUser.Address ?? "",
                        DocumentTypeId = libeyUser.DocumentTypeId ,
                        Email = libeyUser.Email ?? "",
                        FathersLastName = libeyUser.FathersLastName ?? "",
                        MothersLastName = libeyUser.MothersLastName ?? "",
                        Name = libeyUser.Name ?? "",
                        Password = libeyUser.Password ?? "",
                        UbigeoCode = libeyUser.UbigeoCode ?? "",
                        Phone = libeyUser.Phone ?? "",
                        Active = libeyUser.Active ?? false
                    };
            return q.ToList();
        }
        public LibeyUserResponse FindResponse(string documentNumber)
        {

            var q = from libeyUser in _context.LibeyUsers.Where(x => x.DocumentNumber.Equals(documentNumber))
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber ,
                        Address = libeyUser.Address ?? "",
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email ?? "",
                        FathersLastName = libeyUser.FathersLastName ?? "",
                        MothersLastName = libeyUser.MothersLastName ?? "",
                        Name = libeyUser.Name ?? "",
                        Password = libeyUser.Password ?? "",
                        Phone = libeyUser.Phone ?? "",
                        Active = libeyUser.Active ?? false
                    };
            List<LibeyUserResponse> list = q.ToList();
            if (list.Any()) return list.First();
            else return new LibeyUserResponse();
        }

        public void Update(string documentNumber, LibeyUser updatedUser)
        {
            var user = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == documentNumber);
            if (user != null)
            {
                user.DocumentNumber = updatedUser.DocumentNumber;
                user.DocumentTypeId = updatedUser.DocumentTypeId;
                user.Name = updatedUser.Name;
                user.FathersLastName = updatedUser.FathersLastName;
                user.MothersLastName = updatedUser.MothersLastName;
                user.Address = updatedUser.Address ?? "";
                user.UbigeoCode = updatedUser.UbigeoCode ?? "";
                user.Phone = updatedUser.Phone ?? "";
                user.Email = updatedUser.Email ?? "";
                user.Password = updatedUser.Password ?? "";
                user.Active = updatedUser.Active ?? false;

                _context.SaveChanges();
            }
        }
        public void Delete(string documentNumber)
        {
            var user = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == documentNumber);
            if (user != null)
            {
                _context.LibeyUsers.Remove(user);
                _context.SaveChanges();
            }
        }

    }
}