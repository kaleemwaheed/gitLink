using DAL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBs
    {
        private UserDb objDB;
        public UserBs()
        {
            objDB = new UserDb();
        }
        public IEnumerable<tbl_User> GetAll()
        {
            return objDB.GetAll();
        }
        public tbl_User GetByID(int Id)
        {
            return objDB.GetByID(Id);
        }
        public void Insert(tbl_User user)
        {
            objDB.Insert(user);
        }

        public void Delete(int Id)
        {
            objDB.Delete(Id);
        }
        public void Update(tbl_User user)
        {
            objDB.Update(user);
        }
    }
}
