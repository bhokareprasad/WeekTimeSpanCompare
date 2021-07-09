using System;
using System.Collections.Generic;

namespace ConsoleApp1
    {
    class Program
        {
        static void Main (string[] args)
            {
            var result= CheckConditions(DateTime.Now);
            }

        public static bool CheckConditions (DateTime now)
            {
            List<WeekTimeSpan> timeSpans=new List<WeekTimeSpan>()
            {
                new WeekTimeSpan()
                {
                    StartDayTime = new WeekDayTime() { DayOfWeek = DayOfWeek.Friday,HourOfTheDay = 18,MinuteOfHour = 0},
                    EndDayTime = new WeekDayTime()   {DayOfWeek = DayOfWeek.Saturday,HourOfTheDay = 6,MinuteOfHour = 0}
                }
            };

            return timeSpans.Exists (span => span.DoesFallInTimeSpan (now));
            }
        }


    public class WeekTimeSpan
        {
        public WeekDayTime StartDayTime
            {
            get; set;
            }
        public WeekDayTime EndDayTime
            {
            get; set;
            }

        public bool DoesFallInTimeSpan (DateTime dateTime)
            {
            return StartDayTime.IsLessThan (dateTime) && EndDayTime.IsGreaterThan (dateTime);
            }
        }

    public class WeekDayTime
        {
        public DayOfWeek DayOfWeek
            {
            get; set;
            }
        public int HourOfTheDay
            {
            get; set;
            }

        public int MinuteOfHour
            {
            get; set;
            }

        public bool IsGreaterThan (DateTime dateTime)
            {
            if (DayOfWeek > dateTime.DayOfWeek)
                return true;
            if (DayOfWeek < dateTime.DayOfWeek)
                return false;
            if (HourOfTheDay > dateTime.Hour)
                return true;
            if (HourOfTheDay < dateTime.Hour)
                return false;
            return MinuteOfHour > dateTime.Minute;
            }

        public bool IsLessThan (DateTime dateTime)
            {
            if (DayOfWeek < dateTime.DayOfWeek)
                return true;
            if (DayOfWeek > dateTime.DayOfWeek)
                return false;
            if (HourOfTheDay < dateTime.Hour)
                return true;
            if (HourOfTheDay > dateTime.Hour)
                return false;
            return MinuteOfHour < dateTime.Minute;
            }
        }
    }
