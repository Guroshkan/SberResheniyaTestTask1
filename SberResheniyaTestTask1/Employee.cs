using System;
using System.Collections.Generic;
using System.Text;

namespace TestTask
{
    class Employee
    {
        public Employee(string name, DateTime startWork, DateTime endWork, List<DayOfWeek> weekends, List<DateTime> sickDays)
        {
            if (weekends == null || sickDays == null)
                throw new NullReferenceException("Fields Employee.Weekends and Employee.SickDays can't be null.");
            this.Name = name;
            this.StartWork = startWork; 
            this.EndWork = endWork; 
            this.Weekends = weekends; 
            this.SickDays = sickDays; 
            this.TimeTable = new TimeTable(this.StartWork, this.EndWork, this.Weekends, this.SickDays);
        }

        public TimeTable TimeTable { get; } // расписание дней работы сотрудника
        public string Name { get; } //Имя сотрудника
        public DateTime StartWork { get; } // начало периода учета работы сотрудника
        public DateTime EndWork { get; } // конец периода учета работы сотрудника
        public List<DayOfWeek> Weekends { get; } // базовые выходные сотрудника 
        public List<DateTime> SickDays { get; } // период больничного сотрудника

    }
}
