using KindergartenMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KindergartenMVCWebApp.Data
{
    public static class InitializeDb
    {
        private static Random random = new Random();

        private static string[] names =
        {
            "Екатерина", "Виолетта", "Наталья", "Анна", "Алина", "Евгения", "Александра", "Любовь", "Татьяна",
            "Вероника", "Ольга", "Светлана", "Елена", "Надежда", "Юлия"
        };

        private static string[] surnames =
        {
            "Кириленко", "Панфилова", "Дубровская", "Долгова", "Яркина", "Черкасова", "Рябцева", "Жилина", "Фокина",
            "Мосина", "Агапова", "Якубовская", "Николина", "Котова", "Прохорова"
        };

        private static string[] middleNames =
        {
            "Алексеевна", "Дмитриевна", "Владимировна", "Евгеньевна", "Артёмовна", "Павловна", "Николаевна",
            "Антоновна", "Викторовна", "Кирилловна", "Андреевна", "Геннадьевна", "Данииловна", "Олеговна", "Егоровна"
        };

        private static string[] cities =
        {
            "Минск", "Могилев", "Барановичи", "Гомель", "Чаусы", "Борисов", "Витебск", "Гродно", "Жлобин", "Москва",
            "Киев", "Полоцк", "Речица", "Любань", "Слуцк"
        };

        private static string[] groupTypes =
        {
            "Младшая группа", "Старшая группа", "Средняя группа", "Подготовительная группа", "Ясли"
        };

        private static string[] positions =
        {
            "Заведующий", "Заместитель директора по учебно-воспитательной работе", "Старший воспитатель",
            "Заведующий по административно-хозяйственной части", "Сторож", "Медицинский работник", "Учитель-логопед",
            "Инструктор по физической культуре", "Музыкальный руководитель", "Педагог-психолог", "Повар",
            "Помощник воспитателя", "Кухонный работник", "Обслуживающий персонал", "Дворник"
        };

        private static char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static string[] phoneCodes = { "33", "29", "44", "17", "25" };

        private static string GetRandomEl(string[] arr)
        {
            return arr[random.Next(0, arr.Length)];
        }

        private static string GetString(int minStringLength, int maxStringLength)
        {
            string result = "";

            int stringLimit = minStringLength + random.Next(maxStringLength - minStringLength);

            int stringPosition;
            for (int i = 0; i < stringLimit; i++)
            {
                stringPosition = random.Next(letters.Length);

                result += letters[stringPosition];
            }

            return result;
        }

        public static void Initialize(kindergartenContext db)
        {
            db.Database.EnsureCreated();
            int rowCount;
            int rowIndex;

            if (!db.Positions.Any())
            {
                rowCount = positions.Length;
                rowIndex = 0;

                while (rowIndex < rowCount)
                {
                    Position position = new Position
                    {
                        PositionName = GetRandomEl(positions)
                    };

                    db.Positions.Add(position);
                    rowIndex++;
                }

                db.SaveChanges();
            }

            if (!db.GroupTypes.Any())
            {
                rowCount = groupTypes.Length;
                rowIndex = 0;

                while (rowIndex < rowCount)
                {
                    GroupType groupType = new GroupType
                    {
                        NameOfType = GetRandomEl(groupTypes),
                        Note = GetString(14, 20)
                    };
                    db.GroupTypes.Add(groupType);
                    rowIndex++;
                }

                db.SaveChanges();
            }

            if (!db.Staff.Any())
            {
                rowCount = 2000;
                rowIndex = 0;

                int minPosId = db.Positions.Min(x => x.Id);
                int maxPosId = db.Positions.Max(x => x.Id);
                while (rowIndex < rowCount)
                {
                    Staff staff = new Staff
                    {
                        FullName = GetRandomEl(surnames)+ " " + GetRandomEl(names) + " " + GetRandomEl(middleNames),
                        Adress = GetRandomEl(cities),
                        Phone = Convert.ToInt32(GetRandomEl(phoneCodes) + Convert.ToString(random.Next(1000000, 9999999))),
                        PositionId = random.Next(minPosId, maxPosId+1),
                        Info = GetString(10, 16),
                        Reward = GetString(8, 12)
                    };
                    db.Staff.Add(staff);
                    rowIndex++;
                }

                db.SaveChanges();
            }

            if (!db.Groups.Any())
            {
                rowIndex = 0;
                rowCount = 2000;

                int minStaffId = db.Staff.Min(x => x.Id);
                int maxStaffId = db.Staff.Max(x => x.Id);

                int minTypeId = db.GroupTypes.Min(x => x.Id);
                int maxTypeId = db.GroupTypes.Max(x => x.Id);

                while (rowIndex < rowCount)
                {
                    Group group = new Group
                    {
                        GroupName = GetString(1,2) + Convert.ToString(random.Next(1, 4)),
                        StaffId = random.Next(minStaffId, maxStaffId+1),
                        CountOfChildren = random.Next(20, 28),
                        YearOfCreation = random.Next(2015, 2020),
                        TypeId = random.Next(minTypeId, maxTypeId)
                    };
                    db.Groups.Add(group);
                    rowIndex++;
                }

                db.SaveChanges();
            }
        }
    }
}
