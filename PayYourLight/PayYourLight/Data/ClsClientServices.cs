using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace PayYourLight.Data
{
    public class ClsClientServices : IClients
    {
        private  readonly ClsConnection _clsConnection;
        public ClsClientServices(ClsConnection clsConnection)
        {
            _clsConnection = clsConnection;
        }
        public async Task<bool> CreateClients(ClsClients client)
        {
            using (var conn = new MySqlConnection(_clsConnection.Value))
            {
                const string query = @"INSERT INTO tclient(nom, postnom, prenom, profession, email, tel1, tel2)VALUES( @Nom, @Postnom, @Prenom,@Profession,@Email,@Telephone1,@Telephone2)";
                if (conn.State == ConnectionState.Closed) conn.Open();
                try
                {
                    await conn.ExecuteAsync(query, new { client.Nom, client.Postnom, client.Prenom,client.Profession,client.Email,client.Telephone1,client.Telephone2 }, commandType: CommandType.Text);
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
        public async Task<IEnumerable<ClsClients>> GetClients()
        {
            
                IEnumerable<ClsClients> client;
                using (var conn = new MySqlConnection(_clsConnection.Value))
                {
                    const string query = @"select * from tClient";
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    try
                    {
                        client = await conn.QueryAsync<ClsClients>(query);
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
                return client;
            

        }

        public Task<bool> DeleteClients(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditClient(int id, ClsClients city)
        {
            throw new NotImplementedException();
        }

        

        public Task<ClsClients> SingleClients(int id)
        {
            throw new NotImplementedException();
        }
    }
}
