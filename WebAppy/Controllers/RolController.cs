using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
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
            
            var listarol = await RolDAL.ObtenerTodosAsync();
            if (listarol.Count >= 1)
            {
                return listarol;
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

        [HttpPut(Name = "PutRoles")]
        public async Task<int> Put(int id, [FromBody] Rol pRol)
        {

            if (pRol.Id >= 0)
            {
                pRol.Id = id;
                int resultado = await RolDAL.ModificarAsync(pRol);
                return resultado;
            }
            else
            {
                return 0;
            }

        }

        [HttpDelete(Name = "DeleteRoles")]
        public async Task<int> Delete(int id)
        {
            if (id >= 1)
            {
                Rol pRol = new Rol();
                pRol.Id = id;
                int resultado = await RolDAL.EliminarAsync(pRol);
                return 1;
            }
            return 0;
        }
    }
}