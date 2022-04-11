using Arageek.Models.Categories;
using Arageek.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arageek.Services
{
    internal class MainCategoreyService : IMainCategory
    {
        ArageekDbContext dbContext = new ArageekDbContext();
        public void Add(MainCategorey mainCategorey)
        {
            if (!IsExist(mainCategorey.Id));
            {
                dbContext.mainCategoreys.Add(mainCategorey);
                dbContext.SaveChanges();
            } 
        }

        public void Delete(int Id)
        {
            if (IsExist(Id))
            {
                dbContext.mainCategoreys.Remove(Get(Id));
                dbContext.SaveChanges();
            }
        }

        public MainCategorey Get(int MainCategoreyId)
        {
            if (IsExist(MainCategoreyId))
            {
                return dbContext.mainCategoreys.Find(MainCategoreyId);
            }
            return null;
        }
        public void Update(MainCategorey mainCategorey)
        {
            if (IsExist(mainCategorey.Id))
            {
                MainCategorey oldMainCategorey = Get(mainCategorey.Id);
                oldMainCategorey.Name = mainCategorey.Name;
                dbContext.mainCategoreys.Update(oldMainCategorey);
                dbContext.SaveChanges();
            }
        }

        public List<MainCategorey> Get()
        {
            return dbContext.mainCategoreys.ToList();
        }

        public bool IsExist(int Id)
        {
            return dbContext.mainCategoreys.Any(x => x.Id == Id);
        }

        public bool IsExist(string  name)
        {
            return dbContext.articals.Any(x => x.Name == name);
        }


        public bool IsExistById(int Id)
        {
            return dbContext.mainCategoreys.Any(x => x.Id == Id);
        }
        public bool IsExist(MainCategorey entity)
        {
            throw new NotImplementedException();
        }

        public void Dective(int id)
        {
            if (IsExist(id))
            {
                MainCategorey mainCategorey = Get(id);
                mainCategorey.IsDisplay = false;
                dbContext.mainCategoreys.Update(mainCategorey);
                dbContext.SaveChanges();
            }
        }
    }
    }

