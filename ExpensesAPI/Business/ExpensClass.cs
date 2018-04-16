using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpensesAPI.Business
{
    public class ExpensClass
    {
        public int ExpenseId { get; set; }
        public Nullable<int> ExpenseCatId { get; set; }
        public Nullable<System.DateTime> ExpenseDate { get; set; }
        public Nullable<int> ExpenseCost { get; set; }
        public string Comment { get; set; }
        public Nullable<int> UserId { get; set; }
        public string ExpenseCategoryName { get; set; }
    }
}