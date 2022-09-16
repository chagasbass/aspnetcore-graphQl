using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using RestoqueMinimal.Extensions.Shared.Configurations;
using System.Data;

namespace Wise.Produtos.Infrastructure.Data.ContextosDeDados
{
    public class ContextoDeDados : IDisposable
    {
        private readonly BaseConfigurationOptions _baseConfigurationOptions;
        private IDbConnection _DbConnection;

        public ContextoDeDados(IOptions<BaseConfigurationOptions> options)
        {
            _baseConfigurationOptions = options.Value;
        }

        public IDbConnection AbrirConexao()
        {
            if (_DbConnection is null || _DbConnection.State != ConnectionState.Open)
            {
                _DbConnection = new SqlConnection(_baseConfigurationOptions.StringConexaoBancoDeDados);
                _DbConnection.Open();
            }

            return _DbConnection;

        }

        public void Dispose()
        {
            if (_DbConnection != null && _DbConnection.State == ConnectionState.Open)
                _DbConnection.Dispose();
        }
    }
}
