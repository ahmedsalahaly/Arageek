using Arageek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Services
{
    public class ArtService
    {
        ArageekDbContext context = new ArageekDbContext();
        public void Add(Art art)
        {
            if (!IsExcist(art.Name))
            {
                art.CreatedDate = DateTime.Now;
                context.arts.Add(art);
                context.SaveChanges();
            }
        }
        public List<Art> Get()
        {
            return context.arts.ToList();
        }
        public Art Get(int ArtId)
        {
            return context.arts.Find(ArtId);
        }
        public void Update(Art art)
        {
            if (IsExcist(art.Id))
            {
                Art oldArt = Get(art.Id);
                oldArt.Name = art.Name;
                context.arts.Update(oldArt);
                context.SaveChanges();
            }
        }
        public void Delete(int Id)
        {
            if (IsExcist(Id))
            {
                context.arts.Remove(Get(Id));
            }
        }
        public bool IsExcist(int Id)
        {
            return context.arts.Any(x => x.Id == Id);
        }
        public bool IsExcist(string Name)
        {
            return context.arts.Any(x => x.Name == Name);
        }
    }
}
