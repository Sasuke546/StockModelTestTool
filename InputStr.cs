using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    class InputStr
    {
        string Data;
        string Time;
        double price;
        int volume;

        public string getData()
        {
            return Data;
        }

        public void setData(string t)
        {
            Data = t;
        }

        public string getTime()
        {
            return Time;
        }

        public void setTime(string t)
        {
            Time = t;
        }

        public double getPrice()
        {
            return price;
        }

        public void setPrice(double p)
        {
            price = p;
        }

        public int getVolume()
        {
            return volume;
        }

        public void setVolume(int v)
        {
            volume = v;
        }
    }
}
