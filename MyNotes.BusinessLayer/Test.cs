using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNotes.DataAccessLayer;
using MyNotes.Entities;

namespace MyNotes.BusinessLayer
{
    public class Test:RepositoryBase
    {
        private Repository<Category> repo_category = new Repository<Category>();
        private Repository<MyNotesUser> repo_user = new Repository<MyNotesUser>();


        public Test()
        {
            //Db yoksa oluştur.
            db.Database.CreateIfNotExists();
        }

        public void ListTest()
        {
            var list = repo_category.List();
        }
        public void ListTest2()
        {
            var list = repo_category.List(x => x.Title == "Java");
        }
        public void InsertTest()
        {
            int result = repo_user.Insert(new MyNotesUser {
                Name = "Ahmet",
                Surname = "Veli",
                Email = "ahmet@gmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = false,
                Username = "ahmet123",
                Password = "123",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now.AddMinutes(5),
                ModifiedUsername = "ali123"               
                
            });
        }
        public void UpdateTest()
        {
            var user = repo_user.Find(x => x.Name == "Ali");

            if (user!=null)
            {
                user.Name = "Ali2";
                var result = repo_user.Update(user);
            }
        }

    }
}
