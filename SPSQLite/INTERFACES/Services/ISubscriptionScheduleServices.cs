﻿using System;
using System.Collections.Generic;
using System.Text;
using SPSQLite.UIMethods;

namespace SPSQLite
{
   public interface ISubscriptionScheduleServices
    {
        void Add(ISubscriptionSchedule a );
        void Delete(ISubscriptionSchedule a);
        void Edit(ISubscriptionSchedule a);
        IList<ISubscriptionSchedule> GetData();
        void UpdateSchedule(ISubscriptionSchedule schedule);
        List<DataInput> Distribute();
    }
}
