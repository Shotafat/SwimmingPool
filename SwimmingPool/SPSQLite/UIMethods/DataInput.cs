using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SPSQLite.UIMethods
{
   public  class DataInput
    {
        
            public DateTime Date { get; set; }
            public int Datelist { get; set; }
        

    }
    //AXALI OBIEQTI ROMELIC SHEICAVS: int ROW |int COLUMN |DATETIME DATE|INT SAVSEADGILEBI
public class FormatedData
    {
        public int Hours { get; set; }
        public List<DataInput> DatainputList { get; set; }
        
    }

    public static class InputMethods
    {
        public static List<DataInput> ScheduleList { get; set; }
        public static int ColumnIndex{ get; set; }
        public static int RowIndex { get; set; }
        public static List<FormatedData> DATAforInput { get; set; }
        public static List<FormatedData> Filldata(DateTime StartDate, DateTime EndDate, List<DataInput> Schedlist)
        {
            //dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = value;
            //rowIndex - გვაქვს 11 რიგი - პირველია დილის 9 სთ, ბოლო 20 სთ.
            //ColumnIndex - გვაქვს 7 სვეტი, პირველი სვეტი დაკავებული აქვს საათს, დანარჩენი კვირის დღეებია
            //Value - უნდა შეიცავდეს თარიღს ფორმატით DD/MM/YYYY და შევსებულ ადგილებს/დარჩენილ ადგილებს, მაგ. 35/5
            var Filter = Schedlist.Where(x => x.Date.Date == StartDate.Date && x.Date.Date <= EndDate.Date).OrderBy(a=>a.Date.Hour).ToList();

            //იგივეა რაც ზედა, მაგრამ დაჯგუფებულია საათებად
            var groupedbyhour = (from p in Filter
                                group p by p.Date.Hour into g
                                orderby g.Key ascending
                                select new FormatedData { Hours = g.Key, DatainputList = g.Where(x=>x.Date.Hour>=9 &&x.Date.Hour<=21).ToList()}).ToList();

            //კვირის რა დღეც არის, იმავე ნომრის სვეტს აბრუნებს
            ColumnReturner(StartDate);

            //რომელ საათსაც გადავცემთ იმის შესაბამის რიგს აბრუნებს
            RowReturner(StartDate.Hour);

            DATAforInput = new List<FormatedData>();
            DATAforInput = groupedbyhour;


            return groupedbyhour;
        }

        public static int ColumnReturner(DateTime startDate)
        {
            var FirstColumn = startDate.DayOfWeek;
            int columnIndex = (int)startDate.DayOfWeek+1;


            ColumnIndex = columnIndex;

            return columnIndex;
        }

        public static int RowReturner(int Hour)
        {

            
            int RowNumber = Hour - 9;
            RowIndex = RowNumber;
            return RowNumber;

        }





    }
}
