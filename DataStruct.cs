using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    class DataStruct
    {
        private string Data;
        private string QiTime;
        private string PiTime;
        private double Qi;
        private double PiBefore;
        private double PiNext;
        private double PiOpen;
        private double PiEnd;
        private double PiMax;
        private double PiMin;
        private double PStopProfit;
        private double PStopLoss;
        private double P3;
        private string PStopProfitTime;
        private string PStopLossTime;
        private string P3Time;
        private string Type;
        private int NextMinIndex;
        private int StartMinIndex;
        private int PiTotal;
        private string StartTime;
        private string EndTime;

        public DataStruct()
        {
        }

        public string getData()
        {
            return Data;
        }

        public void setData(string tData)
        {
            Data = tData;
        }

        public string getQiTime()
        {
            return QiTime;
        }

        public void setQiTime(string tTime)
        {
            QiTime = tTime;
        }

        public string getPiTime()
        {
            return PiTime;
        }

        public void setPiTime(string tTime)
        {
            PiTime = tTime;
        }

        public double getQi()
        {
            return Qi;
        }

        public void setQi(double tQ)
        {
            Qi = tQ;
        }

        public double getPiBefore()
        {
            return PiBefore;
        }

        public void setPiBefore(double tP)
        {
            PiBefore = tP;
        }

        public double getPiNext()
        {
            return PiNext;
        }

        public void setPiNext(double tP)
        {
            PiNext = tP;
        }

        public double getPiOpen()
        {
            return PiOpen;
        }

        public void setPiOpen(double tP)
        {
            PiOpen = tP;
        }

        public double getPiEnd()
        {
            return PiEnd;
        }

        public void setPiEnd(double tP)
        {
            PiEnd = tP;
        }

        public double getPiMax()
        {
            return PiMax;
        }

        public void setPiMax(double t)
        {
            PiMax = t;
        }

        public double getPiMin()
        {
            return PiMin;
        }

        public void setPiMin(double t)
        {
            PiMin = t;
        }

        public double getPStopProfit()
        {
            return PStopProfit;
        }

        public void setPStopProfit(double t)
        {
            PStopProfit = t;
        }

        public double getPStopLoss()
        {
            return PStopLoss;
        }

        public void setPStopLoss(double t)
        {
            PStopLoss = t;
        }

        public string getPStopProfitTime()
        {
            return PStopProfitTime;
        }

        public void setPStopProfitTime(string t)
        {
            PStopProfitTime = t;
        }

        public string getPStopLossTime()
        {
            return PStopLossTime;
        }

        public void setPStopLossTime(string t)
        {
            PStopLossTime = t;
        }

        public string getType()
        {
            return Type;
        }

        public void setType(string t)
        {
            Type = t;
        }

        public int getNextMinIndex()
        {
            return NextMinIndex;
        }

        public void setNextMinIndex(int id)
        {
            NextMinIndex = id;
        }

        public int getStartMinIndex()
        {
            return StartMinIndex;
        }

        public void setStartMinIndex(int id)
        {
            StartMinIndex = id;
        }

        public void setPiTotal(int t)
        {
            PiTotal = t;
        }

        public int getPiTotal()
        {
            return PiTotal;
        }

        public void addPiTotal(int x)
        {
            PiTotal += x;
        }

        public string getStartTime()
        {
            return StartTime;
        }

        public void setStartTime(string t)
        {
            StartTime = t;
        }

        public string getEndTime()
        {
            return EndTime;
        }

        public void setEndTime(string t)
        {
            EndTime = t;
        }

        public double getP3()
        {
            return P3;
        }

        public void setP3(double p)
        {
            P3 = p;
        }

        public string getP3Time()
        {
            return P3Time;
        }

        public void setP3Time(string t)
        {
            P3Time = t;
        }

    }
}
