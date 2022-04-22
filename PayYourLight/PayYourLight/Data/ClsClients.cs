using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayYourLight.Data
{
    
    public class ClsClients
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Postnom { get; set; }
        public string Prenom { get; set; }
        public string Profession { get; set; }
        public string Email { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }

    }

    public interface IClients
    {
        Task<IEnumerable<ClsClients>> GetClients();
        Task<bool> CreateClients(ClsClients city);
        Task<bool> EditClient(int id, ClsClients city);
        Task<ClsClients> SingleClients(int id);
        Task<bool> DeleteClients(int id);
    }


}
