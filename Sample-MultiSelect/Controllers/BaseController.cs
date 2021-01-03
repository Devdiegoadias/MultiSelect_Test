using Sample_MultiSelect.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sample_MultiSelect.Controllers
{
    public class BaseController : Controller
    {
        private List<Team> teams;
        private List<Player> players;
        public appDbContext db;

        public BaseController()
        {

            teams = new List<Team>();
            players = new List<Player>();

            for (int i = 0; i < 5; i++)
            {
                teams.Add(new Team { Name = "nameTeam" + i, TeamId = new System.Guid() });
            }

            for (int i = 0; i < 10; i++)
            {
                players.Add(new Player { Name = "name" + i, PlayerId = new System.Guid() });
            }

            db = new appDbContext(this);



        }
        public class appDbContext
        {
            BaseController _baseController;
            public appDbContext(BaseController v)
            {
                _baseController = v;
            }
            public List<Player> Players
            {
                get
                {
                    return _baseController.players;
                }
                set
                {

                }

            }
            public List<Team> Teams
            {
                get
                {
                    return _baseController.teams;
                }
                set
                {

                }

            }

        }
    }
}