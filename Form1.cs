using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;



namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        //private  object missing = Missing.Value;          
        private Microsoft.Office.Interop.Excel.Application ExcelRS;          
        private Microsoft.Office.Interop.Excel.Workbook RSbook;          
        private Microsoft.Office.Interop.Excel.Worksheet RSsheet;
        private static List<DataStruct> DataList;
        private static int Mode;
        private static int FilterMode;
        private static int TimeWindow;
        private static double Ratio1;
        private static double Ratio2;
        private static int pK;
        private static int Prev;
        private static int Next;
        private static int prevQ;
        private static double inputBaseVol;
        private static double inputBasePrice;
        private static int gzRadioMode;

        public Form1()
        {
            InitializeComponent();
            DataList = new List<DataStruct>();
        }

        public const string LineBetween = "----------------------------------------------------------------------------------------------------------------------";
        
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.textTimeWin.Text);
            //List<string[]> ds;
            //ds = LoadDataFromExcel("IF07_20120702.csv");
            //dataGridView1.DataSource = ds.Tables[0];
            //Word.Document wDoc = new Word.Document();
            //Word.Application WApp = new Word.Application();
            //Work(ds, 1);
            //CreateNewExcel();
            //SaveDataToExcel("result.xls");            
            //WordWriteData(ds);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.TimeZoneRadio.Checked == true)
                Mode = 1;
            else
                Mode = 2;

            if (this.PrevQRadio.Checked == true)
                FilterMode = 1;
            else
                FilterMode = 2;

            if (this.gzRadio1.Checked == true)
                gzRadioMode = 1;
            else
                gzRadioMode = 2;

            TimeWindow = int.Parse(textTimeWin.Text);
            Ratio1 = double.Parse(textRatio1.Text);
            Ratio2 = double.Parse(textRatio2.Text);
            pK = int.Parse(textK.Text);
            Prev = int.Parse(textPrev.Text);
            Next = int.Parse(textNext.Text);
            prevQ = int.Parse(textQ.Text);
            inputBasePrice = double.Parse(basePrice.Text);
            inputBaseVol = double.Parse(baseVol.Text);

            DataList.Clear();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "csv文件(*.csv)|*.csv|Excel文件(*.xls)|*.xls";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            string[] fNamePath = null;
            string[] fName = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fNamePath = openFileDialog.FileNames;
                fName = openFileDialog.SafeFileNames;
                Array.Sort(fName);
                Array.Sort(fNamePath);
                //MessageBox.Show(fName);
            }
            else
                return;

            Work(fName, fNamePath);
            CreateNewExcel();
            //SaveDataToExcel("out.xls");
        }

        private static void Work(string[] fName, string[] fPath)  // start work here
        {
            for (int i = 0; i < fName.Length; i++)
            {
                List<string[]> ds = LoadDataFromExcel(fName[i],fPath[i]);
                if (ds == null)
                    continue;
                List<DataStruct> QminList = ProcessPerMin(ds);
                //WriteFile wf = new WriteFile();
                //wf.writeF(QminList);
                workQList(ref QminList, ref ds);
            }
            MessageBox.Show("处理完成！！");
        }

        public static string getFileNameExtension(string FileName)
        {
            string[] x = FileName.Split('.');
            return x[1];
        }

        public static List<string[]> LoadDataFromExcel(string fName,string fPath)
        {
            string extension = getFileNameExtension(fName);
            if (extension == "csv")  // csv file
            {
                try
                {
                    List<String[]> ls = new List<String[]>();
                    StreamReader fileReader = new StreamReader(fPath);
                    string strLine = "";
                    strLine = fileReader.ReadLine();  // neglect the first line
                    strLine = fileReader.ReadLine();  // neglect the second line
                    while (strLine != null)
                    {
                        strLine = fileReader.ReadLine();
                        if (strLine != null && strLine.Length > 0)
                        {
                            //ls.Add(strLine.Split(','));
                            string[] x = strLine.Split(',');
                            string[] y = new string[4];
                            for (int i = 0; i < 4; i++)
                                y[i] = x[i];
                            ls.Add(y);
                        }
                    }
                    fileReader.Close();
                    return ls;
                }
                catch (Exception err)
                {
                    MessageBox.Show("读取文件" + fPath + "出错：" + err.Message + "\n请检查文件格式", "提示信息",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else  // excel
            {
                try
                {
                    string strConn;
                    strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fPath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
                    OleDbConnection OleConn = new OleDbConnection(strConn);
                    OleConn.Open();
                    String sql = "SELECT * FROM  [Sheet1$]";//可是更改Sheet名称，比如sheet2，等等 
                    OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                    DataSet OleDsExcle = new DataSet();
                    OleDaExcel.Fill(OleDsExcle, "Sheet1");
                    OleConn.Close();

                    List<String[]> ls = new List<String[]>();
                    int fd = 0;
                    foreach (DataRow row in OleDsExcle.Tables[0].Rows)
                    {
                        if (fd == 0)
                        {
                            fd++;
                            continue;
                        }
                        string[] y = new string[4];
                        for (int i = 0; i < 4; i++)
                            y[i] = row[i].ToString();
                        y[0] = y[0].Split(' ')[0];
                        ls.Add(y);
                    }
                    
                    return ls;
                }
                catch (Exception err)
                {
                    MessageBox.Show("数据绑定Excel失败!失败原因：" + err.Message, "提示信息",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }
            }

            return null;

        }


        public static bool SaveDataToExcel(string filePath)
        {
            try
            {
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath + ";" + "Extended Properties=Excel 8.0;";
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                System.Data.OleDb.OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                for (int i = 0; i < DataList.Count; i++)
                {
                    DataStruct d = DataList[i];
                    string sql = "INSERT INTO [Sheet1$] (日期,时间,时刻,极端量,Pi,Pi开盘价,Pi最高价,Pi最低价,Pi收盘价,极价量,Pj,P1,P2,P3,T1,T2,T3,类型) VALUES(";
                    //string sql = "INSERT INTO [Sheet1$] (Data,Tim,Ti,Q,Pi,PiOpen,PiMax,PiMin,PiEnd,Pj,Pk,Pd,T,Tj,Typ) VALUES(";
                    sql += "'" + d.getData() + "',";
                    sql += "'" + d.getQiTime() + "',";
                    sql += "'" + d.getPiTime() + "',";
                    sql += d.getQi().ToString() + ",";
                    sql += d.getPiBefore().ToString() + ",";
                    sql += d.getPiOpen().ToString() + ",";
                    sql += d.getPiMax().ToString() + ",";
                    sql += d.getPiMin().ToString() + ",";
                    sql += d.getPiEnd().ToString() + ",";
                    sql += d.getPiTotal().ToString() + ",";
                    sql += d.getPiNext().ToString() + ",";
                    sql += d.getPStopProfit().ToString() + ",";
                    sql += d.getPStopLoss().ToString() + ",";
                    sql += d.getP3().ToString() + ",";
                    if (d.getPStopProfitTime() == null)
                        sql += "'null',";
                    else
                        sql += "'" + d.getPStopProfitTime() + "',";
                    if (d.getPStopLossTime() == null)
                        sql += "'null',";
                    else
                        sql += "'" + d.getPStopLossTime() + "',";
                    if (d.getP3Time() == null)
                        sql += "'null',";
                    else
                        sql += "'" + d.getP3Time() + "',";
                    sql += "'" + d.getType() + "')";

                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                return true;
            }
            catch (System.Data.OleDb.OleDbException err)
            {
                MessageBox.Show("写入Excel失败!失败原因：" + err.Message, "提示信息",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                //System.Diagnostics.Debug.WriteLine("写入Excel发生错误：" + ex.Message);
            }
            return false;

        }

        private static void CreateNewExcel()
        {
            string OutFilePath = Application.StartupPath + @"\out.xls"; 
            string TemplateFilePath = Application.StartupPath + @"\Book1.xls";
            PrintInit(TemplateFilePath, OutFilePath);
            SaveDataToExcel(OutFilePath);
        }

        public static bool PrintInit(string templetFile, string outputFile)
        {
            try
            {
                if (templetFile == null)
                {
                    MessageBox.Show("模板文件Book1.xls不存在~");
                    return false;
                }
                System.IO.File.Copy(templetFile, outputFile, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }

        private static List<DataStruct> ProcessPerMin(List<string[]> lstEntity)
        {
            List<DataStruct> QminList = new List<DataStruct>();
            try
            {
                int lstLen = lstEntity.Count;
                int tw = TimeWindow;
                string data;
                string time;
                int startIndex=0;
                //double price;
                //double volume;
                InputStr tInput = new InputStr();
                TimeProc timeProc = new TimeProc();
                DataStruct item;
                int lastTime= timeProc.time2int("9:15:00"); // 9:14:00
                string lastData = "";
                List<InputStr> list = new List<InputStr>();
                if (Mode == 1)
                {
                    list.Clear();
                    int index;
                    for (index = 0; index < lstLen; index++)
                    {
                        string[] ht = lstEntity[index];
                        tInput = new InputStr();
                        time = ht[1];
                        data = ht[0];
                        tInput.setTime(time);
                        tInput.setData(data);
                        tInput.setPrice(double.Parse(ht[2]));
                        tInput.setVolume(int.Parse(ht[3]));
                        int now = timeProc.time2int(time);

                        if (now-lastTime >=tw ) // collect a set in 1 minute
                        {
                            item = new DataStruct();
                            item.setNextMinIndex(index);
                            item.setStartMinIndex(startIndex);
                            ProcessList(list, ref item);
                            list.Clear();
                            QminList.Add(item);
                            startIndex = index;
                            while (lastTime + tw <= now)
                            {
                                lastTime += tw;
                                if (lastTime > 41400 && lastTime < 46800) // 41400 = 11:30:00
                                    lastTime = 46800;  // 46800 = 13:00:00
                            }
                        }
                        lastData = data;
                        list.Add(tInput);
                    }
                    // add the last minute
                    item = new DataStruct();
                    item.setNextMinIndex(index);
                    item.setStartMinIndex(startIndex);
                    ProcessList(list, ref item);
                    list.Clear();
                    QminList.Add(item);
                }
                else  // time window
                {
                    int index;
                    for (index = 0; index < lstLen;)
                    {
                        int t = 0;
                        while (index < lstLen)
                        {
                            time = lstEntity[index][1];
                            t = timeProc.time2int(time);
                            if (index < lstLen && t >= lastTime)
                                break;
                            index++;
                        }
                        while (t >= lastTime + tw)
                        {
                            lastTime++;
                            if (lastTime > 41400 && lastTime < 46800)
                                lastTime = 46800;
                            if (lastTime > timeProc.time2int("15:15:00"))
                                break;
                        }

                        list.Clear();
                        int si;
                        for (si = index; si < lstLen; si++)
                        {
                            time = lstEntity[si][1];
                            if (timeProc.time2int(time) < lastTime + tw)
                            {
                                string[] ht = lstEntity[si];
                                tInput = new InputStr();
                                time = ht[1];
                                data = ht[0];
                                tInput.setTime(time);
                                tInput.setData(data);
                                tInput.setPrice(double.Parse(ht[2]));
                                tInput.setVolume(int.Parse(ht[3]));
                                list.Add(tInput);
                            }
                            else
                            {
                                item = new DataStruct();
                                item.setNextMinIndex(si);
                                item.setStartMinIndex(index);
                                ProcessList(list, ref item);
                                QminList.Add(item);                                    
                                list.Clear();
                                lastTime++;
                                break;
                            }
                        }
                        if (list.Count > 0) // the last list
                        {
                            item = new DataStruct();
                            item.setNextMinIndex(si);
                            item.setStartMinIndex(index);
                            ProcessList(list, ref item);
                            list.Clear();
                            QminList.Add(item);
                            lastTime++;
                        }
                    }
                }                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return QminList;
        }

        private static void workQList(ref List<DataStruct> Qlist, ref List<string[]> lstEntity)
        {
            double maxQ = 0;
            int maxQid = -1;
            bool isQable = false;
            int QlistLen = Qlist.Count;
            double Q = getQ(prevQ);

            for (int i = 0; i < QlistLen; i++)
            {
                if (checkQi(ref Qlist,Q,i)) 
                {
                    isQable = true;
                    completeQ(ref Qlist, ref lstEntity, i);
                    DataList.Add(Qlist[i]);
                }
                else
                    if (!isQable)
                    {
                        if (Qlist[i].getQi() > maxQ)
                        {
                            maxQ = Qlist[i].getQi();
                            maxQid = i;
                        }
                    }
            }
            if (!isQable)
            {
                completeQ(ref Qlist, ref lstEntity, maxQid);
                DataList.Add(Qlist[maxQid]);
            }
        }

        private static void completeQ(ref List<DataStruct> Qlist, ref List<string[]> lstEntity, int i)
        {
            int QlistLen = Qlist.Count;
            int len = lstEntity.Count;
            if (Qlist[i].getType() == "沽" && i > 0 && i < QlistLen - 1)
            {
                double prevMin = getPrevNMin(ref Qlist, ref lstEntity, i);
                double nextMax = getNextNMax(ref Qlist, ref lstEntity, i);
                Qlist[i].setPiBefore(prevMin);
                Qlist[i].setPiNext(nextMax);
                Qlist[i].setP3(getP3NextMin(ref Qlist, i + 1));
                Qlist[i].setPStopProfit(Qlist[i].getPiMax() - (Qlist[i].getPiMax() - Qlist[i-1].getPiMin()) * Ratio1);
                Qlist[i].setPStopLoss(Qlist[i].getPiMax() + (Qlist[i].getPiMax() - Qlist[i-1].getPiMin()) * Ratio2);
            }
            if (Qlist[i].getType() == "扎" && i > 0 && i < QlistLen - 1)
            {
                double prevMax = getPrevNMax(ref Qlist, ref lstEntity, i);
                double nextMin = getNextNMin(ref Qlist, ref lstEntity, i);
                Qlist[i].setPiBefore(prevMax);
                Qlist[i].setPiNext(nextMin);
                Qlist[i].setP3(getP3NextMax(ref Qlist, i + 1));
                Qlist[i].setPStopProfit(Qlist[i].getPiMin() + (Qlist[i-1].getPiMax() - Qlist[i].getPiMin()) * Ratio1);
                Qlist[i].setPStopLoss(Qlist[i].getPiMin() - (Qlist[i-1].getPiMax() - Qlist[i].getPiMin()) * Ratio2);
            }

            string today = Qlist[i].getData();
            int j = Qlist[i].getNextMinIndex();
            TimeProc tp = new TimeProc();
            int cc = 0;
            for (; j<len && cc<3; j++)
            {
                string[] ht = lstEntity[j];
                if (floatEqual(double.Parse(ht[2]), Qlist[i].getPStopProfit()))
                {
                    Qlist[i].setPStopProfitTime(ht[1]);
                    cc++;
                }
                if (floatEqual(double.Parse(ht[2]), Qlist[i].getPStopLoss()))
                {
                    Qlist[i].setPStopLossTime(ht[1]);
                    cc++;
                }
                if (floatEqual(double.Parse(ht[2]), Qlist[i].getP3()))
                {
                    Qlist[i].setP3Time(ht[1]);
                    cc++;
                }
            }

        }

        private static double getPrevNMax(ref List<DataStruct> Qlist, ref List<string[]> lstEntity, int index)
        {
            TimeProc tproc = new TimeProc();
            double m = 0;
            int c = Prev;
            int startTime = tproc.time2int(lstEntity[Qlist[index].getStartMinIndex()][1]);
            for (int i = Qlist[index].getStartMinIndex(); i >= 0 && (startTime - tproc.time2int(lstEntity[i][1])<c); i--)
                if (double.Parse(lstEntity[i][2]) > m)
                    m = double.Parse(lstEntity[i][2]);
            return m;
        }

        private static double getPrevNMin(ref List<DataStruct> Qlist, ref List<string[]> lstEntity, int index)
        {
            TimeProc tproc = new TimeProc();
            double m = 999999999;
            int c = Prev;
            int startTime = tproc.time2int(lstEntity[Qlist[index].getStartMinIndex()][1]);
            for (int i = Qlist[index].getStartMinIndex(); i >= 0 && (startTime - tproc.time2int(lstEntity[i][1]) < c); i--)
                if (double.Parse(lstEntity[i][2]) < m)
                    m = double.Parse(lstEntity[i][2]);
            return m;
        }

        private static double getNextNMax(ref List<DataStruct> Qlist, ref List<string[]> lstEntity, int index)
        {
            TimeProc tproc = new TimeProc();
            int len = lstEntity.Count;

            double m = 0;
            int c = Next;
            int startTime = tproc.time2int(lstEntity[Qlist[index].getNextMinIndex()][1]);
            for (int i = Qlist[index].getNextMinIndex(); i <len && (tproc.time2int(lstEntity[i][1])-startTime < c); i++)
                if (double.Parse(lstEntity[i][2]) > m)
                    m = double.Parse(lstEntity[i][2]);
            return m;
        }

        private static double getNextNMin(ref List<DataStruct> Qlist, ref List<string[]> lstEntity, int index)
        {
            TimeProc tproc = new TimeProc();
            int len = lstEntity.Count;
            double m = 999999999;
            int c = Next;
            int startTime = tproc.time2int(lstEntity[Qlist[index].getNextMinIndex()][1]);
            for (int i = Qlist[index].getNextMinIndex(); i < len && (tproc.time2int(lstEntity[i][1]) - startTime < c); i++)
                if (double.Parse(lstEntity[i][2]) < m)
                    m = double.Parse(lstEntity[i][2]);
            return m;
        }

        private static double getP3NextMax(ref List<DataStruct> Qlist, int index)
        {
            int len = Qlist.Count;
            double m = 0;
            int c = 0;
            for (int i = index; i < len && c < pK; i++, c++)
                if (Qlist[i].getPiMax() > m)
                    m = Qlist[i].getPiMax();
            return m;
        }

        private static double getP3NextMin(ref List<DataStruct> Qlist, int index)
        {
            int len = Qlist.Count;
            double m = 999999999;
            int c = 0;
            for (int i = index; i < len && c < pK; i++, c++)
                if (Qlist[i].getPiMin() < m)
                    m = Qlist[i].getPiMin();
            return m;
        }

        private static bool floatEqual(double x,double y)
        {
            if((int)(x*10)==(int)(y*10))
                return true;
            return false;
        }

        private static bool floatLarger(double x, double y)
        {
            if ((int)(x * 10) >= (int)(y * 10))
                return true;
            return false;
        }


        private static void ProcessList(List<InputStr> List, ref DataStruct item)
        {
            item.setStartTime(List[0].getTime());
            item.setData(List[0].getData());
            item.setPiOpen(List[0].getPrice());
            int len = List.Count;
            item.setEndTime(List[len - 1].getTime());
            item.setPiEnd(List[len - 1].getPrice());
            double minPrice = 999999999;
            double maxPrice = 0;
            string maxPriceTime = "";
            int Qi=0;
            int MaxPriceTotal = 0;
            int MinPriceTotal = 0;

            TimeProc tp = new TimeProc();
            item.setQiTime(tp.getMinute(List[0].getTime()));

            for (int i = 0; i < len; i++ )
            {
                InputStr itr = List[i];
                Qi += itr.getVolume();
                if (itr.getPrice() > maxPrice)
                {
                    maxPrice = itr.getPrice();
                    maxPriceTime = itr.getTime();
                    MaxPriceTotal = Qi;
                }
                if (itr.getPrice() < minPrice)
                {
                    minPrice = itr.getPrice();
                    MinPriceTotal = Qi;
                }
            }

            item.setPiMax(maxPrice);
            item.setPiMin(minPrice);
            item.setPiTime(maxPriceTime);
            item.setQi(Qi);

            if (gzRadioMode==1 && item.getPiEnd()>item.getPiOpen() || gzRadioMode==2 && max(item.getPiEnd(),item.getPiMax())>=item.getPiOpen())
            {
                item.setType("沽");
                item.setPiTotal(MaxPriceTotal);
            }
            else
            {
                item.setType("扎");
                item.setPiTotal(MinPriceTotal);
            }
        }

        private static double getQ(int margin)
        {
            int len = DataList.Count;
            if (len == 0)
                return 99999999;
            int d = 0;
            double Q = 0;
            int numday = 0;
            string nowday = "";

            for (int i = len - 1; i >= 0; i--)
            {
                if (DataList[i].getData() != nowday)
                {
                    nowday = DataList[i].getData();
                    numday++;
                }
                if (numday > margin)
                    break;
                Q += DataList[i].getQi();
                d++;
            }
            return Q / d;
        }

        private static bool checkQi(ref List<DataStruct> Qlist, double Q, int i)
        {
            if (FilterMode == 1)
            {
                if (floatLarger(Qlist[i].getQi(), Q))
                    return true;
                else
                    return false;
            }
            else
            {
                if (i < 1 || i==Qlist.Count-1)
                    return false;
                double prevMin = Qlist[i-1].getPiMin();
                double nextMax = Qlist[i+1].getPiMax();
                if (Qlist[i].getQi() > inputBaseVol && (Qlist[i].getType() == "沽" ? Qlist[i].getPiMax() - prevMin > inputBasePrice : nextMax - Qlist[i].getPiMin() > inputBasePrice))
                {
                    inputBaseVol = (inputBaseVol + Qlist[i].getQi()) / 2;
                    if (Qlist[i].getType() == "沽")
                        inputBasePrice = (inputBasePrice + (Qlist[i].getPiMax() - Qlist[i - 1].getPiMin())) / 2;
                    else
                        inputBasePrice = (inputBasePrice + (Qlist[i - 1].getPiMax() - Qlist[i].getPiMin())) / 2;
                    inputBasePrice = smoothBasePrice(inputBasePrice);
                    return true;
                }
                else
                    return false;
            }
        }

        private static double smoothBasePrice(double p)
        {
            double r = p * 10;
            if ((int)r % 2 == 1)
                r -= 1;
            return r / 10;
        }

        private static double max(double a, double b)
        {
            return a > b ? a : b;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textQ_TextChanged(object sender, EventArgs e)
        {

        }
    }
}