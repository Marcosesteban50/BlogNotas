using BlogdeNotas.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace BlogdeNotas.Servicios
{
    public interface IRepositorioNotas
    {
        Task Actualizar(Notas notas);
        Task Borrar(int id);
        Task Crear(Notas notas);
        Task<bool> Existe(string nombre, int usuarioId);
        Task<IEnumerable<Notas>> Obtener(int usuarioId);
        Task<Notas> ObtenerporId(int id, int usuarioid);
    }

    public class RepositorioNotas : IRepositorioNotas
    {
        private readonly string connectionString;

        public RepositorioNotas(IConfiguration configuration)
        {

            connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public async Task Crear(Notas notas)
        {
            using var connection = new SqlConnection(connectionString);

            var id = await connection.QuerySingleAsync<int>(@"Insert into NotasDatos(UsuarioId,FechaCreacion,Nombre,Nota)
                                 Values(@UsuarioId,@FechaCreacion,@Nombre,@Nota);
                                    Select Scope_Identity();",notas);

            notas.Id = id;
        }

        public async Task<bool> Existe(string nombre,int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);

            var existe = await connection.QueryFirstOrDefaultAsync
                <int>(@"Select 1
                    From NotasDatos
                  Where Nombre = @Nombre and 
              UsuarioId = @UsuarioId", new {nombre,usuarioId});

            return existe == 1;
        }



        public async Task<IEnumerable<Notas>> Obtener(int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Notas>(@"select Id,Nombre,Nota,FechaCreacion
from NotasDatos
Where UsuarioId = @UsuarioId", new {usuarioId});
        }

        public async Task Actualizar(Notas notas)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"Update NotasDatos
                                   Set Nombre = @Nombre , Nota = @Nota
                                    Where Id = @Id",notas);
        }



        public async Task<Notas> ObtenerporId(int id, int usuarioid)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<Notas>(@"Select Id,Nombre,Nota
                        From NotasDatos
                        where Id = @Id and UsuarioId = @UsuarioId", new {id,usuarioid});
        }

        public async Task Borrar(int id)
        {
            using var connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync("Delete NotasDatos Where Id = @Id", new { id });
        }
    }
}
