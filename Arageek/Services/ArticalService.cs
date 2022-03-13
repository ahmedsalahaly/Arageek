using Arageek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Services
{
    public class ArticalService
    {
        ArageekDbContext context = new ArageekDbContext();
        public void Add(Artical artical)
        {
            if (!IsExist(artical.Name))
            {
            artical.CreatedDate = DateTime.Now;
            context.articals.Add(artical);
            context.SaveChanges();
            }
        }
        public List<Artical> Get()
        {
            return context.articals.ToList();
        }
        public Artical Get(int ArticalId)
        {
            return context.articals.Find(ArticalId);
        }
        public void Update(Artical artical)
        {
            if (IsExist(artical.Id))
            {
                Artical oldArticle = Get(artical.Id);
                oldArticle.Name = artical.Name;
                context.articals.Update(oldArticle);
                context.SaveChanges();
            }
        }
        public void Delete(int Id)
        {
            if (IsExist(Id))
            {
                context.articals.Remove(Get(Id));
                context.SaveChanges();
            }
        }
        public bool IsExist(int Id)
        {
            return context.articals.Any(x => x.Id == Id);
        }
        public bool IsExist(string name)
        {
            return context.articals.Any(x => x.Name == name);
        }
    }
}
