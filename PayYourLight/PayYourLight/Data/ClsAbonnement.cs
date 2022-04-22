using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PayYourLight.Data
{
    public class ClsAbonnement
    {
        public int id_Client { get; set; }
        public int id_Compteur { get; set; }
        public double montant { get; set; }
        public int Id { get; set; }
        public string numeroCompteur { get; set; }
        public int IdType { get; set; }
    }
    public interface IAbonnement
    {
        Task<IEnumerable<ClsAbonnement>> GetAbonnement();
        Task<bool> CreateAbonnement(ClsAbonnement abonnement);
        Task<bool> EditAbonnement(int id, ClsAbonnement abonnement);
        Task<ClsAbonnement> SingleAbonnement(int id);
        Task<bool> DeleteAbonnement(int id);

    }
    public class AbonnementService : IAbonnement
    {
        private readonly ClsConnection _configuration;
        public AbonnementService(ClsConnection clsConnection)
        {
            _configuration = clsConnection;
        }
        public async Task<bool> CreateAbonnement(ClsAbonnement abonnement)
        {
            using var conn = new MySqlConnection(_configuration.Value);
            var parameters = new DynamicParameters();

            parameters.Add("montant", abonnement.montant, DbType.Double);
            parameters.Add("id_Client", abonnement.Id, DbType.Int32);
            parameters.Add("id_Compteur", abonnement.IdType, DbType.Int32);


            using (var conn_ = new MySqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed) conn_.Open();
                try
                {
                    await conn.ExecuteAsync("proc_Save_Ab", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }
            return true;
        }

        public Task<bool> DeleteAbonnement(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAbonnement(int id, ClsAbonnement abonnement)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClsAbonnement>> GetAbonnement()
        {
            throw new NotImplementedException();
        }

        public async Task<ClsAbonnement> SingleAbonnement(int id)
        {
            ClsAbonnement typeComteurs = new ClsAbonnement();
            using (var conn = new MySqlConnection(_configuration.Value))
            {
                const string query = @"select * from tclient where Id=@Id";
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    typeComteurs = await conn.QueryFirstOrDefaultAsync<ClsAbonnement>(query, new { id }, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }
            return typeComteurs;
        }
    }
}
