using Microsoft.AspNetCore.Mvc;
using Syssaladebelleza.DAL;
using Syssaladebelleza.EN;

namespace Syssaladebelleza.Controllers
{
    [Route("api/rol")]
    [ApiController]
    public class RolController : ControllerBase
    {
        [HttpGet(Name = "GetRol")]
        public async Task<List<Rol>> Get()
        {
            var ListaRol = await RolDAL.ObtenerTodosAsync();
            if (ListaRol.Count >= 1)
            {
                return ListaRol;
            }
            else
            {
                return new List<Rol>();
            }
        }

        [HttpPost(Name = "PostRol")]
        public async Task<int> Post(Rol pRol)
        {
            if (pRol.Id >= 0)
            {
                int resultado = await RolDAL.CrearAsync(pRol);
                return resultado;
            }
            else
            {
                return 0;
            }
        }
    }
}