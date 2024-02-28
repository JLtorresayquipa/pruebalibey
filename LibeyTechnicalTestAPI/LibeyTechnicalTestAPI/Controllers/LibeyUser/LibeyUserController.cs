using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.AspNetCore.Mvc;
namespace LibeyTechnicalTestAPI.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class LibeyUserController : Controller
    {
        private readonly ILibeyUserAggregate _aggregate;
        public LibeyUserController(ILibeyUserAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _aggregate.GetAll();
            return Ok(users);
        }
        [HttpGet]
        [Route("{documentNumber}")]
        public IActionResult FindResponse(string documentNumber)
        {
            var row = _aggregate.FindResponse(documentNumber);
            return Ok(row);
        }
        [HttpPost]       
        public IActionResult Create(UserUpdateorCreateCommand command)
        {
             _aggregate.Create(command);
            return Ok(true);
        }

        [HttpPut]
        [Route("{documentNumber}")]
        public IActionResult Update(string documentNumber, UserUpdateorCreateCommand command)
        {
            // Crear un objeto LibeyUser con los datos del command
            var updatedUser = new LibeyUser(
                documentNumber,
                command.DocumentTypeId,
                command.Name,
                command.FathersLastName,
                command.MothersLastName,
                command.Address,
                command.UbigeoCode,
                command.Phone,
                command.Email,
                command.Password);

          

            // Llamar al método Update del agregado para actualizar el usuario
            _aggregate.Update(documentNumber, updatedUser);

            return Ok(true);
        }

        [HttpDelete]
        [Route("{documentNumber}")]
        public IActionResult Delete(string documentNumber)
        {
            _aggregate.Delete(documentNumber);
            return Ok(true);
        }
    }
}