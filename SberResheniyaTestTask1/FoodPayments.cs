using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TestTask
{
    static class FoodPayments
    {
        static public int CalculateFoodPayments(TimeTable timeTable, List<KeyValuePair<DateTime, int>> changePrice)
        {
            var workingDays = timeTable.GetTimeTable();
            var _changePrice = changePrice.OrderBy(x => x.Key).ToList();
            int resultPrice = 0;
            foreach(var currDay in workingDays)
            {
                if (currDay.Value == TypeDay.WorkingDay) 
                    resultPrice += _changePrice.FindLast(p => p.Key <= currDay.Key).Value;
            }
            return resultPrice;
        }
    }
}
