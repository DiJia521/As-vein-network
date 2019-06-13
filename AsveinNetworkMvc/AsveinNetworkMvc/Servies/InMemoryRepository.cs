using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace AsveinNetworkMvc.Servies
{
    public class InMemoryRepository : IRepository<AsveinNetwork>
    {
        public IEnumerable<AsveinNetwork> GetAll()
        {
            return new List<AsveinNetwork>
            {
                new AsveinNetwork
                {
                    Join_Id=1,
                    Join_Recruitment="张品",
                    join_Seeker="求值"
                },
                new AsveinNetwork
                {
                    Join_Id=2,
                    Join_Recruitment="张",
                    join_Seeker="求"
                },
                new AsveinNetwork
                {
                    Join_Id=3,
                    Join_Recruitment="品",
                    join_Seeker="值"
                },
                new AsveinNetwork
                {
                    Join_Id=4,
                    Join_Recruitment="张品d",
                    join_Seeker="求值d"
                },

            };
        }
    }
}
