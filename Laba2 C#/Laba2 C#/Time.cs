using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lol
{
    internal class Time
    {
        private byte hours { get; set; }
        private byte minutes { get; set; }

        public Time(byte hours, byte minutes)
        {
            this.hours = (byte)((hours + minutes / 60) % 24);
            this.minutes = (byte)(minutes % 60);
        }
        public override string ToString()
        {
            return $"{hours:D2}:{minutes:D2}";
        }
        public static Time operator -(Time a, Time b)
        {
            int totalH = a.hours - b.hours;
            int totalM = a.minutes - b.minutes;
            if (totalM < 0) { totalM += 60; totalH -= 1; }
            if (totalH < 0) { totalH += 24; }
            return new Time((byte)totalH, (byte)totalM);
        }
        public static Time operator ++(Time t)
        {
            return new Time(t.hours, (byte)(t.minutes + 1));
        }
        public static Time operator --(Time t)
        {
            return new Time(t.hours, (byte)(t.minutes - 1));
        }
        public static implicit operator int(Time t)
        {
            return t.hours * 60 + t.minutes;
        }
        public static implicit operator bool(Time t)
        {
            return !(t.hours == 0 && t.minutes == 0);
        }
        public static bool operator <(Time t1, Time t2)
        {
            int totalM1 = t1.hours * 60 + t1.minutes;
            int totalM2 = t2.hours * 60 + t2.minutes;
            return (totalM1 < totalM2);
        }
        public static bool operator >(Time t1, Time t2)
        {
            int totalM1 = t1.hours * 60 + t1.minutes;
            int totalM2 = t2.hours * 60 + t2.minutes;
            return (totalM1 > totalM2);
        }
    }
}
