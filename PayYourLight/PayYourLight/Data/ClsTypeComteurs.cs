using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PayYourLight.Data
{
    public class ClsTypeComteurs
    {
        public int Id { get; set; }
        public string Designation { get; set; }
        public double Montantmoi { get; set; }
        public double MontantAbonnement { get; set; }

    }

    public interface IClsTypeCompteur
    {
        Task<IEnumerable<ClsTypeComteurs>> GetTypeCompteur();
        Task<bool> CreateTypeCompteur(ClsTypeComteurs city);
        Task<bool> EditTypeCompteur(int id, ClsTypeComteurs city);
        Task<ClsTypeComteurs> SingleTypeCompteurs(int id);
        Task<bool> DeleteTypeCompteur(int id);
    }

    

    public class ClsTypeCompteurService : IClsTypeCompteur
    {
        private readonly ClsConnection _clsConnection;
        public ClsTypeCompteurService(ClsConnection clsConnection)
        {
            _clsConnection = clsConnection;
        }
        public async Task<bool> CreateTypeCompteur(ClsTypeComteurs compteurType)
        {
            using (var conn = new MySqlConnection(_clsConnection.Value))
            {
                const string query = @"INSERT INTO ttypecompteur(designation, montantParKw, montantAbonnement)VALUES( @Designation, @MontantPrMoi, @MontantAbonnement)";
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    await conn.ExecuteAsync(query, new { compteurType.Designation, compteurType.Montantmoi, compteurType.MontantAbonnement }, commandType: CommandType.Text);
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

        public Task<bool> DeleteTypeCompteur(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EditTypeCompteur(int id, ClsTypeComteurs typeCompt)
        {
            var parameters = new DynamicParameters();
            parameters.Add("code", typeCompt.Id, DbType.Int32);
            parameters.Add("montantParKws", typeCompt.Montantmoi, DbType.Double);
            parameters.Add("montantAb", typeCompt.MontantAbonnement, DbType.Double);
            parameters.Add("designation", typeCompt.Designation, DbType.String);

            using (var conn = new MySqlConnection(_clsConnection.Value))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    await conn.ExecuteAsync("proc_Save_typeCompteur", parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<ClsTypeComteurs>> GetTypeCompteur()
        {
            IEnumerable<ClsTypeComteurs> typecompteur;
            using (var conn = new MySqlConnection(_clsConnection.Value))
            {
                const string query = @"select * from ttypecompteur";
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    typecompteur = await conn.QueryAsync<ClsTypeComteurs>(query);
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
            return typecompteur;
        }

        public async Task<ClsTypeComteurs> SingleTypeCompteurs(int id)
        {
            ClsTypeComteurs typeComteurs = new ClsTypeComteurs();
            using (var conn = new MySqlConnection(_clsConnection.Value))
            {
                const string query = @"select * from ttypecompteur where Id=@Id";
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    typeComteurs = await conn.QueryFirstOrDefaultAsync<ClsTypeComteurs>(query, new { id }, commandType: CommandType.Text);
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
