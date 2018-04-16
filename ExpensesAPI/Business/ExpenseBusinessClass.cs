using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpensesAPI.Models;

namespace ExpensesAPI.Business
{
    public class ExpenseBusinessClass
    {
        private ExpensesDBEntities context;
        public ExpenseBusinessClass()
        {
            context = new ExpensesDBEntities();
        }


        public UserClass GetUsers(UserClass obj)
        {
            try
            {
                var result = context.Users.Where(x => x.Username == obj.Username && x.Password==obj.Password).FirstOrDefault();
                if (result != null)
                {
                    UserClass user = new UserClass()
                    {
                        Fname = result.Fname,
                        Lname = result.Lname,
                        Mobile= result.Mobile,
                        Username = result.Username,
                        UserId= result.UserId,
                        IsActive=result.IsActive
                       
                    };
                    return user;

                }
                else
                {
                    return null;
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
          
        }

        public UserClass GetUserDeatils(int id)
        {
            var result= context.Users.Where(x => x.UserId == id).FirstOrDefault();
            UserClass user = new UserClass()
            {
                Fname = result.Fname,
                Lname = result.Lname,
                Mobile = result.Mobile,
                Username = result.Username,
                UserId = result.UserId,
                IsActive = result.IsActive

            };
            return user;
        }

        public UserClass ResgisterUser(UserClass user)
        {
            try { 
            User newuser = new User()
            {
                Fname = user.Fname,
                Lname = user.Lname,
                Username = user.Username,
                Password = user.Password,
                Mobile = user.Mobile,
                IsActive = true
            };

            context.Users.Add(newuser);
            context.SaveChanges();
            UserClass usernew = new UserClass()
            {
                Fname = newuser.Fname,
                Lname = newuser.Lname,
                Mobile = newuser.Mobile,
                Username = newuser.Username,
                UserId = newuser.UserId,
                IsActive = newuser.IsActive

            };
            return usernew;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ExpenseCatClass> GetExpesneType()
        {
            try
            {
                var res = context.ExpenseCategories.ToList();
                List<ExpenseCatClass> catlist = new List<ExpenseCatClass>();
                res.ForEach(x => { catlist.Add(new ExpenseCatClass() { ExpenseCategoryId = x.ExpenseCategoryId, ExpenseCategoryName = x.ExpenseCategoryName });
                });
                return catlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ExpensClass> GetExpense(DateTime date)
        {
            return null;
        }

        public  int SaveExpense( IEnumerable<ExpensClass> expense)
        {
            try
            {
                //foreach (var item in expense)
                //{
                //    Expens exp = new Expens() { Comment = item.Comment, ExpenseCatId = item.ExpenseCatId, ExpenseCost = item.ExpenseCost, UserId = item.UserId, ExpenseDate = item.ExpenseDate };
                //    context.Expenses.Add(exp);
                //}
                expense.ToList().ForEach(x => { context.Expenses.Add(new Expens() { Comment = x.Comment, ExpenseCatId = x.ExpenseCatId, ExpenseCost = x.ExpenseCost, UserId = x.UserId, ExpenseDate = x.ExpenseDate });
                });
                var res = context.SaveChanges();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}