using BryantUniversity.Data;
using BryantUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BryantUniversity.Repo
{
    public class BuildingRepo
    {
        public Context _context;

        public BuildingRepo(Context context)
        {
            _context = context;
        }

        public IList<Building> GetAllBuildings()
        {
            return _context.Buildings.ToList();

        }

        public Building GetById(int buildingId)
        {
            return _context.Buildings.SingleOrDefault(c => c.Id == buildingId);
        }


        public void Update(Building building)
        {
            _context.Buildings.Attach(building);
            _context.Entry(building).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Insert(Building building)
        {
            _context.Buildings.Add(building);
            _context.SaveChanges();
        }

    }
}