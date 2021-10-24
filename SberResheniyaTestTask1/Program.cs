using System;
using System.Collections.Generic;
using System.Linq;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = GetEmployee(); // экземпляр класса сотрудника для хранения данных о времени работы

            List<KeyValuePair<DateTime, int>> changePrice = GetChangePriceList(); // список изменения стоимости питания

            var foodPayment = FoodPayments.CalculateFoodPayments(employee.TimeTable, changePrice); // выплаты за питание
            Console.WriteLine($"Выплаты по питанию для работника {employee.Name} за срок от {employee.StartWork} до {employee.EndWork} составляет {foodPayment}");
        }

        static List<KeyValuePair<DateTime, int>> GetChangePriceList()
        {
            List<KeyValuePair<DateTime, int>> changePrice = new List<KeyValuePair<DateTime, int>>();
            changePrice.Add(new KeyValuePair<DateTime, int>(DateTime.MinValue, 200)); // базовая стоимость питания составляет 200
            changePrice.Add(new KeyValuePair<DateTime, int>(new DateTime(2020, 4, 20), 300)); // 20 апреля 2020 года стоимость питания изменена до 300
            return changePrice;
        }

        static Employee GetEmployee()
        {
            DateTime startWork = new DateTime(2020, 4, 3); // начало периода учета работы сотрудника 3 апреля 2020
            DateTime endWork = new DateTime(2020, 4, 30); // конец периода учета работы сотрудника 30 апреля 2020
            List<DayOfWeek> weekends = new List<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Sunday };// базовые выходные сотрудника

            DateTime sickPeriodStart = new DateTime(2020, 4, 6); // начало болезни сотрудника 6 апреля 2020
            DateTime sickPeriodEnd = new DateTime(2020, 4, 12); // конуц болезни сотрудника 12 апреля 2020
            List<DateTime> sickDays = new List<DateTime>(); // период болезни
            for (DateTime daySick = sickPeriodStart; daySick < sickPeriodEnd; daySick = daySick.AddDays(1))
            {
                sickDays.Add(daySick);
            }

            Employee employee = new Employee("Employee 1", startWork, endWork, weekends, sickDays);
            return employee;
        }
    }
}
