using BlogdeNotas.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BlogdeNotas.Servicios
{
    public interface IRepositorioUsuarios
    {
        Task<Usuario> BuscarUsuarioPorEmail(string emailNormalizado);
        Task<int> CrearUsuario(Usuario usuario);
    }
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly string connectionString;

        public RepositorioUsuarios(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");

        }


        public async Task<int> CrearUsuario(Usuario usuario)
        {
            using var connection  = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>(@"Insert Into Usuarios (Email,EmailNormalizado,PasswordHash,Nombre)
                              values (@Email,@EmailNormalizado,@PasswordHash,@Nombre);
                                Select Scope_Identity();",usuario);

            return id;
        }


        public async Task<Usuario> BuscarUsuarioPorEmail(string emailNormalizado)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QuerySingleOrDefaultAsync<Usuario>(@"
                                    Select * From
                        Usuarios Where EmailNormalizado = @EmailNormalizado",
                       new {emailNormalizado});
        }
    }
}
