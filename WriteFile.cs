using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace WindowsApplication1
{
    class WriteFile
    {
        public void writeF(List<DataStruct> Q)
        {
            int len = Q.Count;
            FileStream fs = new FileStream("check.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < len; i++)
            {
                sw.Write(Q[i].getStartTime() + " ");
                sw.WriteLine(Q[i].getEndTime());
            }
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }

}
