using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask
{
    public enum TypeDay {WorkingDay, WeekendDay, SickLeaveDay}
    public class TimeTable
    {
        private Dictionary<DateTime, TypeDay> _Dates;
        public TimeTable(DateTime startPeriod, DateTime endPeriod, List<DayOfWeek> weekends, List<DateTime> sickLeave)
        {
            this._Dates = new Dictionary<DateTime, TypeDay>();
            for (DateTime i = startPeriod; i <= endPeriod; i = i.AddDays(1))
            {
                bool isWorkingDay = !(weekends.Contains(i.DayOfWeek)); // проверяем - рабочий ли день
                if(isWorkingDay)
                    this._Dates.Add(i.Date, TypeDay.WorkingDay); // если рабочий - выставляем тип как рабочий
                else
                    this._Dates.Add(i.Date, TypeDay.WeekendDay); // если не рабочий - выставляем как выходной
            }

            this._Dates = this._Dates.Select(
                    d => sickLeave.Contains(d.Key) ?  // проверяем - входит ли этот день в список больничных дней
                new KeyValuePair<DateTime, TypeDay>(d.Key, TypeDay.SickLeaveDay) : // если входит - помечаем как день болезни
                new KeyValuePair<DateTime, TypeDay>(d.Key, d.Value))// если не входит - оставляем без изменений
                .ToDictionary(x => x.Key, x => x.Value);

        }
        public Dictionary<DateTime,TypeDay> GetTimeTable()
        {
            return this._Dates;
        }
    }
}
