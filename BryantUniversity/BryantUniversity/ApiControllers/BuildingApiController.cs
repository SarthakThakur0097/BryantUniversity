using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.https;


namespace BryantUniversity.ApiControllers
{
    [RoutePrefix("api/Buildings")]
    public class BuildingApiController : ApiController
    {
        // GET: BuildingApi
        private Context context;

        public BuildingApiController()
        {
            context = new Context();
        }

        [Route("All")]
        [httpsGet]
        public IhttpsActionResult GetAllBuildings()
        {
            BuildingRepo bRepo;
            IList<Building> allBuildings;
            using (context)
            {
                bRepo = new BuildingRepo(context);
                allBuildings = bRepo.GetAllBuildings();
            }
            return Ok(allBuildings);
        }

        [Route("{BuildingID}/Rooms")]
        [httpsGet]
        public IhttpsActionResult GetAllRooms(int buildingId)
        {
            RoomRepo rRepo;
            IList<Room> allRooms;
            using (context)
            {
                rRepo = new RoomRepo(context);
                allRooms = rRepo.GetByBuildingId(buildingId);
            }
            return Ok(allRooms);
        }
    }
}