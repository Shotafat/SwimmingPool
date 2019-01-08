using System;
using System.Collections.Generic;
using System.Text;

namespace SPSQLite
{
   public interface IHealthNotice
    {
         int ID{ get; set; }
         DateTime DateCreated { get; set; }
         string CurrencyName { get; set; }
         int AbonentId { get; set; }
    }
}
