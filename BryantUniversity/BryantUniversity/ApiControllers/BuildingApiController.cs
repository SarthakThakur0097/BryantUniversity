using BryantUniversity.Data;
using BryantUniversity.Models;
using BryantUniversity.Models.Repo;
using BryantUniversity.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


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
        [HttpGet]
        public IHttpActionResult GetAllBuildings()
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
        [HttpGet]
        public IHttpActionResult GetAllRooms(int buildingId)
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