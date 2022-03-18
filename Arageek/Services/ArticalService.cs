using Arageek.Models;
using Arageek.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Services
{
    public class ArticalService : IArtical
    {
        ArageekDbContext dbContext = new ArageekDbContext();
        public void Add(Artical artical)
        {
            if (!IsExist(artical.Name))
            {
            artical.CreatedDate = DateTime.Now;
            dbContext.articals.Add(artical);
            dbContext.SaveChanges();
            }
        }
        public List<Artical> Get()
        {
            return dbContext.articals.ToList();
        }
        public Artical Get(int ArticalId)
        {
            return dbContext.articals.Find(ArticalId);
        }
        public void Update(Artical artical)
        {
            if (IsExist(artical.Id))
            {
                Artical oldArticle = Get(artical.Id);
                oldArticle.Name = artical.Name;
                dbContext.articals.Update(oldArticle);
                dbContext.SaveChanges();
            }
        }
        public void Delete(int Id)
        {
            if (IsExist(Id))
            {
                dbContext.articals.Remove(Get(Id));
                dbContext.SaveChanges();
            }
        }
        public bool IsExist(int Id)
        {
            return dbContext.articals.Any(x => x.Id == Id);
        }
        public bool IsExist(string name)
        {
            return dbContext.articals.Any(x => x.Name == name);
        }
    }
}
