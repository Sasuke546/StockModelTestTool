using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    class TimeProc
    {
        public int getMonthDay(string d)
        {
            string[] x = d.Split('-');
            int m = int.Parse(x[1]);
            int y = int.Parse(x[0]);
            if(m==2)
            {
                if(y%100==0 && y%400==0)
                    return 29;
                else
                    if(y%4==0)
                        return 29;
                return 28;
            }
            else
            {
                switch(m)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12: return 31;
                    case 4:
                    case 6:
                    case 9:
                    case 11: return 30;
                }
            }
            return 0;
        }

        public TimeProc()
        {
        }

        public int getSec(string T)
        {
            string[] x = T.Split(':');
            return int.Parse(x[2]);
        }

        public int getDay(string T)
        {
            string[] x = T.Split(':');
            return int.Parse(x[2]);
        }

        public bool isNewMinute(string l, string n)
        {
            if (l == "")
                return false;
            string[] lt = l.Split(':');
            string[] nt = n.Split(':');
            if (int.Parse(nt[1]) > int.Parse(lt[1]))
                return true;
            else
                if (int.Parse(nt[0]) > int.Parse(lt[0]))
                    return true;
            return false;
        }

        public bool isNewDay(string l, string n)
        {
            if (l == "")
                return false;
            string[] lx = l.Split('-');
            string[] nx = n.Split('-');
            int ly = int.Parse(lx[0]);
            int lm = int.Parse(lx[1]);
            int ld = int.Parse(lx[2]);
            int ny = int.Parse(nx[0]);
            int nm = int.Parse(nx[1]);
            int nd = int.Parse(nx[2]);
            if (ny > ly)
                return true;
            else
                if (nm > lm)
                    return true;
                else
                    if (nd > ld)
                        return true;
            return false;
        }

        public string getMinute(string T)
        {
            string[] x = T.Split(':');
            string min = x[0] + ":" + x[1];
            return min;
        }

        public bool DataDiff(string d1, string d2, int margin)
        {
            // assume d2>d1
            int day1 = getDay(d1);
            int day2 = getDay(d2);
            if (day2 < day1 && day2 + getMonthDay(d1) - day1 <= margin)
                return true;
            if (day2 - day1 <= margin)
                return true;
            return false;
        }

        public int TimeDiff(string t1, string t2)
        {
            // assume t2>t1
            string[] n1 = t1.Split(':');
            string[] n2 = t2.Split(':');

            int s1 = int.Parse(n1[0])*3600+int.Parse(n1[1])*60+int.Parse(n1[2]);
            int s2 = int.Parse(n2[0]) * 3600 + int.Parse(n2[1]) * 60 + int.Parse(n2[2]) ;

            return s2 - s1;
        }

        public int time2int(string s)
        {
            string[] x = s.Split(':');
            int k = int.Parse(x[0]) * 3600 + int.Parse(x[1]) * 60 + int.Parse(x[2]);
            return k;
        }
    }
}
