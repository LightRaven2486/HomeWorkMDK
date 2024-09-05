using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HomeWorkMDK
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int daysLeft = 0;

        int weekends = 0;

        int day = DateTime.Now.Day;
        int month = DateTime.Now.Month;
        int year = DateTime.Now.Year;

        DateTime endDate = new DateTime(2025, 06, 28);

        List<DateTime> holidays = new List<DateTime>()
        {
            new DateTime(2024, 11, 03), //День народного единства
            new DateTime(2024, 11, 04), //День народного единства

            new DateTime(2024, 12, 31), //Новый год
            new DateTime(2025, 01, 01), //Новый год
            new DateTime(2025, 01, 02), //Новый год
            new DateTime(2025, 01, 03), //Новый год
            new DateTime(2025, 01, 06), //Новый год
            new DateTime(2025, 01, 07), //Новый год
            new DateTime(2025, 01, 08), //Новый год

            new DateTime(2025, 05, 01), //День труда
            new DateTime(2025, 05, 02), //День труда
            new DateTime(2025, 05, 08), //День труда
            new DateTime(2025, 05, 09), //День победы
            new DateTime(2025, 06, 12), //День России
            new DateTime(2025, 06, 13) //День России
        };

        public MainWindow()
        {
            InitializeComponent();
            int hours = DateTime.Now.Minute;

            DateTime startDate = new DateTime(year, month, day);

            while (true)
            {
                if (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday || holidays.Contains(startDate))
                {
                    weekends++;
                }

                if (startDate == endDate)
                {
                    break;
                }
                startDate = startDate.AddDays(1.0);
            }
            Weekends.Text = weekends.ToString();
            Holidays.Text = holidays.Count.ToString();
            CountDaysLeft();
        }

        async void CountDaysLeft()
        {
            while (endDate.Subtract(DateTime.Now).TotalSeconds != 0)
            {
                await Task.Delay(1000);
                Days.Text = Convert.ToString(endDate.Subtract(DateTime.Now).Days);
                Hours.Text = Convert.ToString(endDate.Subtract(DateTime.Now).Hours);
                Minutes.Text = Convert.ToString(endDate.Subtract(DateTime.Now).Minutes);
                Seconds.Text = Convert.ToString(endDate.Subtract(DateTime.Now).Seconds);
            }     
        }
    }
}