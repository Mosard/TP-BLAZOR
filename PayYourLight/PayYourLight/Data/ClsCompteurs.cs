using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PayYourLight.Data
{
    public class ClsCompteurs
    {
        public int Id { get; set; }
        public string NumberCompteur { get; set; }
        public string StatutAbonnement { get; set; }
        public int IdType { get; set; }
        public string NOM { get; set; }
        public string numeroCompteur { get; set; }
        public int id { get; set; }


    }
    public interface ICompteur
    {
        Task<IEnumerable<ClsCompteurs>> GetCompteur();
        Task<IEnumerable<ClsCompteurs>> GetCompteurTable();

        Task<bool> CreateCompteur(ClsCompteurs city);
        Task<bool> EditCompteur(int id, ClsCompteurs compteurs);
        Task<ClsCompteurs> SingleCompteurs(string NumberCompteur);
        Task<bool> DeleteCompteur(int id);

    }

    public class CompteurServices : ICompteur
    {
        private readonly ClsConnection _configuration;
        public CompteurServices(ClsConnection clsConnection)
        {
            _configuration = clsConnection;
        }
        public async Task<bool> CreateCompteur(ClsCompteurs compteurs)
        {
            using var conn = new MySqlConnection(_configuration.Value);
            var parameters = new DynamicParameters();

            parameters.Add("code", compteurs.Id, DbType.Int32);
            parameters.Add("numero", compteurs.NumberCompteur, DbType.Double);
            parameters.Add("foreignKey", compteurs.IdType, DbType.Double);


            using (var conn_ = new MySqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed) conn_.Open();
                try
                {
                    await conn_.ExecuteAsync("proc_Save_Compteur", parameters, commandType: CommandType.StoredProcedure);
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

        public Task<bool> DeleteCompteur(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditCompteur(int id, ClsCompteurs compteurs)
        {
            throw new NotImplementedException();
        }

        public async  Task<IEnumerable<ClsCompteurs>> GetCompteur()
        {
            IEnumerable<ClsCompteurs> typecompteur;
            using (var conn = new MySqlConnection(_configuration.Value))
            {
                const string query = @"select * from vachat_all";
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    typecompteur = await conn.QueryAsync<ClsCompteurs>(query);
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

        public async Task<IEnumerable<ClsCompteurs>> GetCompteurTable()
        {
            IEnumerable<ClsCompteurs> typecompteur;
            using (var conn = new MySqlConnection(_configuration.Value))
            {
                const string query = @"select * from tcompteur Where statusCompteur = 'Available'";
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    typecompteur = await conn.QueryAsync<ClsCompteurs>(query);
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

        public async Task<ClsCompteurs> SingleCompteurs(string NumberCompteur)
        {
            ClsCompteurs Comteurs = new ClsCompteurs();
            using (var conn = new MySqlConnection(_configuration.Value))
            {
                const string query = @"select * from vcompteur where NumCompteur=@NumberCompteur";
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    Comteurs = await conn.QueryFirstOrDefaultAsync<ClsCompteurs>(query, new { NumberCompteur }, commandType: CommandType.Text);
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
            return Comteurs;
        }
    }
}
