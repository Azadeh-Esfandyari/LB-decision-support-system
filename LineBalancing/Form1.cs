using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineBalancing
{

    public partial class Form1 : Form
    {
        public static int row;
        public static int col;
        public static int Taskid;
        public static string Taskname;
        public static double Tasktime;
        public static int NofSides;
        public static string successors, sides;
        public static string[] alltasksname;
        public static int[] alltasksid;
        Tasks[] Tasks;
        private int rowIndex = 0;
        float cycleTime;
        int numoftasks;
        int opendialogflag = 0;

        //  public static DataGridView dataGridView1 = new DataGridView();

        public Form1()
        {
            
            InitializeComponent();
        }
        public void EhsanAl()
        {

        }
        public int checkinput()
        {
    try { 

            int numberofside;
            cycleTime = 0;
            if (textBox1.Text == "")
            {
                string message = "please enter cycle time ";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                //  this.Close();
                return 0;
            }
            float n11;
            bool isNumeric11 = float.TryParse(textBox1.Text, out n11);
            if (isNumeric11 == false)
            {
                string message = "You did not enter numeric value for cycle time ";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                return 0;
            }
            else
            { cycleTime = n11; }
            if (comboBox1.SelectedIndex == -1)
            {
                string message = "please enter number of sides ";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                return 0;
            }
            else { numberofside = Convert.ToInt32(comboBox1.Text); NofSides = numberofside; }
            numoftasks = 0;
            if (textBox2.Text == "")
            {
                string message = "please enter number of tasks ";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                return 0;
            }
            ////////
            int n;
            bool isNumeric = int.TryParse(textBox2.Text, out n);
            if (isNumeric == false)
            {
                string message = "You did not enter numeric value for number of tasks ";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                return 0;
            }
            else { numoftasks = n; }
            //////////
            int n111 = dataGridView1.Rows.Count;
            //             alltasksid = new int[n111 -2];
            //              int k = 0,p = 0;
            ////             foreach (DataGridViewRow row1 in dataGridView1.Rows)
            //            {
            //              if (row1.Index != row)
            //            {
            //              var s = row1.Cells[1].Value;
            //
            //            if (s != null)
            //          {
            //            alltasksid[k] = Convert.ToInt32(row1.Cells[0].Value.ToString()); k++;
            //          //  alltasksname[p] = row1.Cells[1].Value.ToString(); p++;
            //    }
            //     }
            // }
            //////////////////////
            int rowcount = dataGridView1.RowCount;
            int tasktime = 0, taskid = 0;
            string taskname, successors, sides;
            if ((rowcount - 1) == numoftasks)
            {
                Tasks = new Tasks[numoftasks];


                for (int i = 0; i < numoftasks; i++)
                {

                    ///////////////////////////////
                    alltasksid = new int[n111 - 2];
                    int kk = 0, pp = 0;
                    foreach (DataGridViewRow row1 in dataGridView1.Rows)
                    {
                        if (row1.Index != i)
                        {
                            var s = row1.Cells[1].Value;

                            if (s != null)
                            {
                                alltasksid[kk] = Convert.ToInt32(row1.Cells[0].Value.ToString()); kk++;
                                //  alltasksname[p] = row1.Cells[1].Value.ToString(); p++;
                            }
                        }
                    }

                    ////////////////////////////////
                    List<Int32> sidelist = new List<Int32>();
                    List<Int32> successorlist = new List<Int32>();
                    taskname = null;
                    // int n;
                    // bool isNumeric = int.TryParse("123", out n);
                    if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[1].Value != null)
                    {
                        taskname = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        taskid = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                        int n1 = 0, n2 = 0;
                        if (dataGridView1.Rows[i].Cells[2].Value != null)
                        {
                            // bool isNumeric1 = int.TryParse(dataGridView1.Rows[i].Cells[0].Value.ToString(), out n1);
                            bool isNumeric2 = int.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString(), out n2);

                            if (isNumeric2 == false)
                            {
                                string message = "You did not enter numeric values in the row" + (i + 1) + " for  tasktime  ";
                                string caption = "Error Detected in Input";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result;

                                // Displays the MessageBox.

                                result = MessageBox.Show(message, caption, buttons);
                                return 0;
                            }
                            else
                            {
                                tasktime = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                            }
                        }
                        else
                        {
                            string message = "You did not enter any values in the row" + (i + 1) + " for  tasktime  ";
                            string caption = "Error Detected in Input";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            // Displays the MessageBox.

                            result = MessageBox.Show(message, caption, buttons);
                            return 0;
                        }
                        /////////////////////////////////////////////////////////////////////////////
                        /////////////////////////////successors//////////////////////////////////
                        int suclen = 0;
                        if (dataGridView1.Rows[i].Cells[3].Value != null)
                        {

                            successors = dataGridView1.Rows[i].Cells[3].Value.ToString();

                            string[] words = successors.Split(',');

                            foreach (var word in words)
                            {
                                if (!(word[0] >= '0' && word[0] <= '9'))
                                {
                                    string message = "You did not enter numeric values in the row" + (i + 1) + " for  successors";
                                    string caption = "Error";
                                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                                    DialogResult result;
                                    result = MessageBox.Show(message, caption, buttons);
                                    return 0;
                                    //  this.Close();
                                }
                                else
                                {
                                    int SucTaskId = Convert.ToInt32(word);
                                    bool SucTask = find(SucTaskId);
                                    if (SucTask == false)
                                    {
                                        string message = "Successor task Id is not valid in the row" + (i + 1);
                                        string caption = "Error";
                                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                                        DialogResult result;
                                        result = MessageBox.Show(message, caption, buttons);
                                        return 0;
                                        //this.Close();
                                    }
                                    else
                                    {


                                        successorlist.Add(SucTaskId);
                                        suclen++;

                                    }
                                }
                            }
                        }
                        else
                        {
                            string message = "You did not enter any values in the row" + (i + 1) + " for  successors  ";
                            string caption = "Error Detected in Input";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            // Displays the MessageBox.

                            result = MessageBox.Show(message, caption, buttons);
                            return 0;
                        }

                        ////////////////////////////////////////////////////////////////////////////

                        //////////////////////////////sides////////////////////////////////////////////    
                        int sidelen = 0;
                        if (dataGridView1.Rows[i].Cells[4].Value != null)
                        {

                            sides = dataGridView1.Rows[i].Cells[4].Value.ToString();

                            string[] words = sides.Split(',');

                            foreach (var word in words)
                            {
                                if (!(word[0] >= '0' && word[0] <= '9'))
                                {
                                    string message = "You did not enter numeric values in the row" + (i + 1) + " for  sides";
                                    string caption = "Error";
                                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                                    DialogResult result;
                                    result = MessageBox.Show(message, caption, buttons);
                                    return 0;
                                    //  this.Close();
                                }
                                else
                                {
                                    int SideId = Convert.ToInt32(word);
                                    ///   bool SucTask = find(SucTaskId);
                                    if (!(SideId >= 1 && SideId <= numberofside))
                                    {
                                        string message = "the side is not valid in the row " + (i + 1);
                                        string caption = "Error";
                                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                                        DialogResult result;
                                        result = MessageBox.Show(message, caption, buttons);
                                        return 0;
                                        //this.Close();
                                    }
                                    else
                                    {


                                        sidelist.Add(SideId);
                                        sidelen++;

                                    }
                                }
                            }
                        }
                        else
                        {
                            string message = "You did not enter any values in the row" + (i + 1) + " for  sides  ";
                            string caption = "Error Detected in Input";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            // Displays the MessageBox.

                            result = MessageBox.Show(message, caption, buttons);
                            return 0;
                        }



                        /////////////////////////////////////////////////////////////////////////

                    }

                    ///////////////////add to array of Tasks objects////////////////////
                    Tasks[i] = new Tasks(successorlist.Count, sidelist.Count);


                    Tasks[i].taskid = taskid;
                    Tasks[i].taskname = taskname;
                    Tasks[i].tasktime = tasktime;
                    // for(int j=0;j< successorlist.Count;j++)
                    int j = 0;
                    foreach (int a in successorlist)
                    {
                        Tasks[i].successors[j] = a;
                        j++;
                    }
                    j = 0;
                    foreach (int a in sidelist)
                    {
                        Tasks[i].sides[j] = a;
                        j++;
                    }

                    ////////////////////////////////////////
                }
            }
            else
            {
                string message = "please enter exactly  " + numoftasks + " tasks";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                return 0;
            }

            return 1;
        }
          catch (Exception e) {
                string message = e.Message;
        string caption = "Error";
        MessageBoxButtons buttons = MessageBoxButtons.OK;
        DialogResult result;
        result = MessageBox.Show(message, caption, buttons);
                return 0;

            }
}
        public void save(string path)
        {

          
         
           //////////////////////////////////

            /////////////////////////////////////
            try { 

           
                //@"D:\test.csv"           
                using (TextWriter writer = new StreamWriter(@path, false, System.Text.Encoding.UTF8))
                {
                    writer.WriteLine("taskid" + "," + "taskname" + "," + "tasktime" + "," + "successors" + "," + "sides" + "," + "cycleTime" + "," + "numoftasks" + "," + "NofSides");
                    int counter = 0;
                    foreach (var t in Tasks)
                    {
                        counter++;
                        if (counter != 1)
                        {
                           
                            string s = "", s1 = "";
                            int scounter = 0;
                            foreach (int a in t.successors)

                            {
                                if (scounter == t.successors.Length - 1)
                                    s = s + a;
                                else
                                s = s + a + ';';
                                scounter++;
                            }
                            scounter = 0;
                            foreach (int a in t.sides)
                            {

                                if (scounter == t.sides.Length - 1)
                                    s1 = s1 + a;
                                else
                                    s1 = s1 + a + ';';
                                scounter++;
                            }
                            
                            writer.WriteLine(t.taskid + ","+ t.taskname + ","+ t.tasktime + ","+s+","+s1);
                        }
                        else
                        {

                            string s = "", s1 = "";
                            int scounter = 0;
                            foreach (int a in t.successors)
                            {
                                if (scounter == t.successors.Length - 1)
                                    s = s + a;
                                else
                                    s = s + a + ';';
                                scounter++;
                            }
                            scounter = 0;
                            foreach (int a in t.sides)
                            {
                                if (scounter == t.sides.Length - 1)
                                    s1 = s1 + a;
                                else
                                    s1 = s1 + a + ';';
                                scounter++;
                            }
                            
                            writer.WriteLine(t.taskid + "," + t.taskname + "," + t.tasktime + "," + s + "," + s1 + ","+ cycleTime + ","+ numoftasks + ","+ NofSides);
                        }
                    }
                    /* var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                     
                         Delimiter = ";"
                     };
                     using (var csvWriter = new CsvWriter(writer, config))
                     {

                         csvWriter.WriteField("taskid");
                         csvWriter.WriteField("taskname");
                         csvWriter.WriteField("tasktime");
                         csvWriter.WriteField("successors");
                         csvWriter.WriteField("sides");
                         csvWriter.WriteField("cycleTime");
                         csvWriter.WriteField("numoftasks");
                         csvWriter.WriteField("NofSides");

                         csvWriter.NextRecord(); // adds new line after header
                         int counter = 0;
                         foreach (var t in Tasks)
                         {
                             counter++;
                             if (counter != 1)
                             {
                                 csvWriter.WriteField(t.taskid);
                                 csvWriter.WriteField(t.taskname);
                                 csvWriter.WriteField(t.tasktime);
                                 string s = "", s1 = "";
                                 foreach (int a in t.successors)
                                 {
                                     s = s + a + ',';
                                 }
                                 csvWriter.WriteField(s);
                                 foreach (int a in t.sides)
                                 {
                                     s1 = s1 + a + ',';
                                 }
                                 csvWriter.WriteField(s1);
                                 csvWriter.NextRecord();
                             }
                             else
                             {
                                 csvWriter.WriteField(t.taskid);
                                 csvWriter.WriteField(t.taskname);
                                 csvWriter.WriteField(t.tasktime);

                                 string s = "", s1 = "";
                                 foreach (int a in t.successors)
                                 {
                                     s = s + a + ',';
                                 }
                                 csvWriter.WriteField(s);
                                 foreach (int a in t.sides)
                                 {
                                     s1 = s1 + a + ',';
                                 }
                                 csvWriter.WriteField(s1);
                                 csvWriter.WriteField(cycleTime);
                                 csvWriter.WriteField(numoftasks);
                                 csvWriter.WriteField(NofSides);
                                 csvWriter.NextRecord();
                             }
                         }


                         writer.Flush();

                     }
                     */





                }
                string message = "File saved successfully. ";
                string caption = "";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return;

            }
        catch (Exception e) {
                string message = e.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return;

            }

        }
        
        private bool find(int n)
        {
            try
            {
                int i;
                //  string Taskname = "";
                for (i = 0; i <= Form1.alltasksid.Length - 1; i++)
                    if (alltasksid[i] == n)
                    {
                        // Taskname = Form1.alltasksname[i];
                        break;
                    }
                if (i <= alltasksid.Length - 1)
                    return true;
                else return false;
            }
            catch (Exception e)
            {
                string message = e.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return false;

            }
        }
        private void Form1_Load(object sender, EventArgs e)

        {
            try { 
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf("1");
            //    dataGridView1.ColumnCount = 5;
            //      dataGridView1.Columns[0].Name = "Task ID";
            //    dataGridView1.Columns[0].ReadOnly = true;
            //    dataGridView1.Columns[1].Name = "Task Name";
            //     dataGridView1.Columns[2].Name = "Task Time";
            //    dataGridView1.Columns[3].Name = "Successors";
            //    dataGridView1.Columns[4].Name = "Sides";

            dataGridView1.Rows[0].Cells[0].Value = 1;
            //  dataGridView1.
            // dataGridView1.Rows.Add();
            //  dataGridView1.ClearSelection();



            /*  string[] row = new string[] { "1", "Product 1", "1000" };
              dataGridView1.Rows.Add(row);
              row = new string[] { "2", "Product 2", "2000" };
              dataGridView1.Rows.Add(row);
              row = new string[] { "3", "Product 3", "3000" };
              dataGridView1.Rows.Add(row);
              row = new string[] { "4", "Product 4", "4000" };
              dataGridView1.Rows.Add(row);*/
        }
          catch (Exception eee)
            {
                string message = eee.Message;
        string caption = "Error";
        MessageBoxButtons buttons = MessageBoxButtons.OK;
        DialogResult result;
        result = MessageBox.Show(message, caption, buttons);
                return ;

            }

}

    

        private void button3_Click(object sender, EventArgs e)

        {
            int numberofside;
            float cycleTime = 0;
            if (textBox1.Text == null)
            {
                string message = "please enter cycle time ";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                return;
            }
            float n11;
            bool isNumeric11 = float.TryParse(textBox1.Text, out n11);
            if (isNumeric11 == false)
            {
                string message = "You did not enter numeric value for cycle time ";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                return;
            }
            else
            { cycleTime = n11; }
            if (comboBox1.SelectedIndex== -1)
            {
                string message = "please enter number of sides ";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                return;
            }
            else { numberofside = Convert.ToInt32(comboBox1.Text); }
            int numofWorks=0;
            if (textBox2.Text == "")
            {
                string message = "please enter number of tasks ";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                return;
            }
            ////////
            int n;
             bool isNumeric = int.TryParse(textBox2.Text, out n);
            if (isNumeric==false) {
                string message = "You did not enter numeric value for number of tasks ";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                return;
            }
            else { numofWorks = n; }
            //////////
            int n111 = dataGridView1.Rows.Count;
      /*      alltasksid = new int[n111 -2];
            int k = 0,p = 0;
            foreach (DataGridViewRow row1 in dataGridView1.Rows)
            {
                if (row1.Index != row)
                {
                    var s = row1.Cells[1].Value;

                    if (s != null)
                    {
                        alltasksid[k] = Convert.ToInt32(row1.Cells[0].Value.ToString()); k++;
                        //  alltasksname[p] = row1.Cells[1].Value.ToString(); p++;
                    }
                }
            }*/
                //////////////////////
                int rowcount=dataGridView1.RowCount;
            int tasktime=0,taskid=0;
            string taskname, successors,sides;
            if ((rowcount - 1) == numofWorks)
            {
                Tasks=new Tasks[numofWorks];


                for (int i = 0; i < numofWorks; i++)
                {

                    ///////////////////////////////
                    alltasksid = new int[n111 - 2];
                    int kk = 0, pp = 0;
                    foreach (DataGridViewRow row1 in dataGridView1.Rows)
                    {
                        if (row1.Index != i)
                        {
                            var s = row1.Cells[1].Value;

                            if (s != null)
                            {
                                alltasksid[kk] = Convert.ToInt32(row1.Cells[0].Value.ToString()); kk++;
                                //  alltasksname[p] = row1.Cells[1].Value.ToString(); p++;
                            }
                        }
                    }

                    ////////////////////////////////
                    List<Int32> sidelist = new List<Int32>();
                    List<Int32> successorlist = new List<Int32>();
                    taskname = null;
                    // int n;
                    // bool isNumeric = int.TryParse("123", out n);
                    if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[1].Value != null)
                    {
                        taskname = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        taskid = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value.ToString());
                        int n1 = 0, n2 = 0;
                        if (dataGridView1.Rows[i].Cells[2].Value != null)
                        {
                           // bool isNumeric1 = int.TryParse(dataGridView1.Rows[i].Cells[0].Value.ToString(), out n1);
                            bool isNumeric2 = int.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString(), out n2);

                            if ( isNumeric2 == false)
                            {
                                string message = "You did not enter numeric values in the row" + (i + 1) + " for  tasktime  ";
                                string caption = "Error Detected in Input";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result;

                                // Displays the MessageBox.

                                result = MessageBox.Show(message, caption, buttons);
                                return;
                            }
                            else
                            {
                                tasktime = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                            }
                        }
                        else
                        {
                            string message = "You did not enter any values in the row" + (i + 1) + " for  tasktime  ";
                            string caption = "Error Detected in Input";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            // Displays the MessageBox.

                            result = MessageBox.Show(message, caption, buttons);
                            return;
                        }
                        /////////////////////////////////////////////////////////////////////////////
                        /////////////////////////////successors//////////////////////////////////
                        int suclen = 0;
                            if (dataGridView1.Rows[i].Cells[3].Value != null)
                            {
                            
                            successors = dataGridView1.Rows[i].Cells[3].Value.ToString();

                                string[] words = successors.Split(',');

                                foreach (var word in words)
                                {
                                    if (!(word[0] >= '0' && word[0] <= '9'))
                                    {
                                        string message = "You did not enter numeric values in the row" + (i + 1) + " for  successors";
                                        string caption = "Error";
                                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                                        DialogResult result;
                                        result = MessageBox.Show(message, caption, buttons);
                                        return;
                                        //  this.Close();
                                    }
                                    else
                                    {
                                        int SucTaskId = Convert.ToInt32(word);
                                        bool SucTask = find(SucTaskId);
                                        if (SucTask ==false)
                                        {
                                            string message = "Successor task Id is not valid in the row" + (i + 1);
                                            string caption = "Error";
                                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                                            DialogResult result;
                                            result = MessageBox.Show(message, caption, buttons);
                                             return;
                                            //this.Close();
                                        }
                                        else
                                        {

                                        
                                        successorlist.Add(SucTaskId);
                                        suclen++;

                                    }
                                    }
                                }
                            }
                            else
                            {
                                string message = "You did not enter any values in the row" + (i + 1) + " for  successors  ";
                                string caption = "Error Detected in Input";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult result;

                                // Displays the MessageBox.

                                result = MessageBox.Show(message, caption, buttons);
                                return;
                            }

                        ////////////////////////////////////////////////////////////////////////////

                        //////////////////////////////sides////////////////////////////////////////////    
                        int sidelen = 0;
                        if (dataGridView1.Rows[i].Cells[4].Value != null)
                        {
                            
                            sides = dataGridView1.Rows[i].Cells[4].Value.ToString();

                            string[] words = sides.Split(',');

                            foreach (var word in words)
                            {
                                if (!(word[0] >= '0' && word[0] <= '9'))
                                {
                                    string message = "You did not enter numeric values in the row" + (i + 1) + " for  sides";
                                    string caption = "Error";
                                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                                    DialogResult result;
                                    result = MessageBox.Show(message, caption, buttons);
                                    return;
                                    //  this.Close();
                                }
                                else
                                {
                                    int SideId = Convert.ToInt32(word);
                                 ///   bool SucTask = find(SucTaskId);
                                    if( !(SideId>=1 && SideId<= numberofside))
                                    {
                                        string message = "the side is not valid in the row + (i + 1)";
                                        string caption = "Error";
                                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                                        DialogResult result;
                                        result = MessageBox.Show(message, caption, buttons);
                                        return;
                                        //this.Close();
                                    }
                                    else
                                    {

                                        
                                        sidelist.Add(SideId);
                                        sidelen++;

                                    }
                                }
                            }
                        }
                        else
                        {
                            string message = "You did not enter any values in the row" + (i + 1) + " for  sides  ";
                            string caption = "Error Detected in Input";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;

                            // Displays the MessageBox.

                            result = MessageBox.Show(message, caption, buttons);
                            return;
                        }



                        /////////////////////////////////////////////////////////////////////////

                    }

                    ///////////////////add to array of Tasks objects////////////////////
                    Tasks[i] = new Tasks(successorlist.Count, sidelist.Count);
                
        
                    Tasks[i].taskid = taskid;
                    Tasks[i].taskname = taskname;
                    Tasks[i].tasktime = tasktime;
                    // for(int j=0;j< successorlist.Count;j++)
                    int j = 0;
                    foreach (int a in successorlist)
                    {
                        Tasks[i].successors[j] = a;
                        j++;
                    }
                     j = 0;
                    foreach (int a in sidelist)
                    {
                        Tasks[i].sides[j] = a;
                        j++;
                    }

                    ////////////////////////////////////////
                }
                }
            else
            {
                    string message = "please enter exactly  " + numofWorks + " tasks";
                    string caption = "Error Detected in Input";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(message, caption, buttons);
                    return;
                }
            //// getting inputs and run the value;





/*

           var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };

            //  using (var mem = new MemoryStream())
            //  using (var writer = new StreamWriter(mem))
            using (TextWriter writer = new StreamWriter(@"D:\test.csv", false, System.Text.Encoding.UTF8))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                // csvWriter.Configuration.Delimiter = ";";
                //  csvWriter.Configuration.AutoMap<Tasks>();

                // csvWriter.WriteHeader<Tasks>();
                csvWriter.WriteField("taskid");
                csvWriter.WriteField("taskname");
                csvWriter.WriteField("tasktime");
                csvWriter.WriteField("successors");
                csvWriter.WriteField("sides");

                csvWriter.NextRecord(); // adds new line after header
                foreach (var t in Tasks)
                {
                    csvWriter.WriteField(t.taskid);
                    csvWriter.WriteField(t.taskname);
                    csvWriter.WriteField(t.tasktime);
                    string s = "", s1 = "";
                    foreach (int a in t.successors)
                    {
                        s = s + a + ',';
                    }
                    csvWriter.WriteField(s);
                    foreach (int a in t.sides)
                    {
                        s1 = s1 + a + ',';
                    }
                    csvWriter.WriteField(s1);
                    csvWriter.NextRecord();
                }
              //  csvWriter.WriteRecords(Tasks);
          //     csvWriter.Configuration.HasHeaderRecord = true;
              //  csvWriter.Configuration.AutoMap<Tasks>();

               // csvWriter.WriteHeader<Tasks>();
              //  csvWriter.WriteRecords(Tasks);

                writer.Flush();
              //  var result = Encoding.UTF8.GetString(mem.ToArray());
              //  Console.WriteLine(result);
            }
        */


            /*       foreach (Tasks t in Tasks)
                   { string s = "",s1="";



                          // int ii = 0;
                       foreach (int a in t.successors)
                       {
                           s = s + a + ',';
                       }
                       foreach (int a in t.sides)
                       {
                           s1 = s1 + a + ',';
                       }
                       System.Diagnostics.Debug.WriteLine(t.taskid+"--" + t.taskname+"--" + t.tasktime+ "--"+s+ "--"+s1);


                   }*/
        }
        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            // dataGridView1.RefreshEdit();
            //این مشکل را داشتم که وقتی مقادیر دیتاگرید را تغییر میدادم و دوباره ذخیره را کلیک میکردم همان مقادیر قبلی را درنظر میگرفت
            //مجبور شدم فوکوس را به یک کنترل دیگه تغییر بدم که مشکل حل شه
            textBox1.Focus();
            int check = checkinput();

            //   saveFileDialog1.ShowDialog();
            if (check == 1)
            {

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string filename = System.IO.Path.GetFileName(saveFileDialog1.FileName);
                    if (filename != "")
                    {
                        string path = saveFileDialog1.FileName;
                        save(@path);
                        // textBox1.Text = saveFileDialog1.FileName;
                        saveFileDialog1.FileName = "";

                    }
                    else
                    {
                        string message = "Please enter file name. ";
                        string caption = "Error ";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;

                        // Displays the MessageBox.

                        result = MessageBox.Show(message, caption, buttons);
                        return;
                    }

                }
                else
                {

                }

            }
        }
              catch (Exception f)
            {
                string message = f.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return ;

            }


        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)

        {
            try { 
            if (comboBox1.SelectedText == null)
            {
                string message = "please enter number of sides ";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                return;
            }
            else
            {
                NofSides = Convert.ToInt32(comboBox1.Text);
                try
                {

                    row = e.RowIndex;
                    col = e.ColumnIndex;

                    Taskid = Convert.ToInt32(dataGridView1.Rows[row].Cells[0].Value);
                    Taskname = dataGridView1.Rows[row].Cells[1].Value.ToString();
                    Tasktime = Convert.ToDouble(dataGridView1.Rows[row].Cells[2].Value);
                    successors = "";
                    dataGridView1.EndEdit();

                    var s1 = dataGridView1.Rows[row].Cells[3].Value;
                    if (s1 != null)
                        successors = dataGridView1.Rows[row].Cells[3].Value.ToString();
                    dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[3];
                    sides = "";
                    var s2 = dataGridView1.Rows[row].Cells[4].Value;
                    if (s2 != null)
                        sides = dataGridView1.Rows[row].Cells[4].Value.ToString();

                    // Convert.ToInt32(dataGridView1.Rows[row].Cells[0].Value);
                    int n = dataGridView1.Rows.Count;
                    alltasksid = new int[n - 1];
                    alltasksname = new string[n - 1];
                    int i = 0, j = 0;
                    foreach (DataGridViewRow row1 in dataGridView1.Rows)
                    {
                        if (row1.Index != row)
                        {
                            var s = row1.Cells[1].Value;

                            if (s != null)
                            {
                                alltasksid[i] = Convert.ToInt32(row1.Cells[0].Value); i++;
                                alltasksname[j] = row1.Cells[1].Value.ToString(); j++;
                            }
                        }

                    }
                }
                catch (Exception error)
                {
                    string message = "Task information is not entered";
                    string caption = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    return;
                }

                    //// باید برشگردونی اگه خواستی از فرم یک استفاده کنی
                    ///   Form2 form2 = new Form2(this);//(this)

                    // form2.Show();
                }

            }   catch (Exception g)
            {
                string message =g.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return;

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          /*  if (comboBox1.SelectedText == null)
            {
                string message = "please enter number of sides ";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                return;
            }
            else
            {
                NofSides = Convert.ToInt32(comboBox1.Text);
                try
                {

                    row = e.RowIndex;
                    col = e.ColumnIndex;

                    Taskid = Convert.ToInt32(dataGridView1.Rows[row].Cells[0].Value);
                    Taskname = dataGridView1.Rows[row].Cells[1].Value.ToString();
                    Tasktime = Convert.ToDouble(dataGridView1.Rows[row].Cells[2].Value);
                    successors = "";
                    var s1 = dataGridView1.Rows[row].Cells[3].Value;
                    if (s1 != null)
                        successors = dataGridView1.Rows[row].Cells[3].Value.ToString();
                    dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[3];
                    sides = "";
                    var s2 = dataGridView1.Rows[row].Cells[4].Value;
                    if (s2 != null)
                        sides = dataGridView1.Rows[row].Cells[4].Value.ToString();

                    // Convert.ToInt32(dataGridView1.Rows[row].Cells[0].Value);
                    int n = dataGridView1.Rows.Count;
                    alltasksid = new int[n - 1];
                    alltasksname = new string[n - 1];
                    int i = 0, j = 0;
                    foreach (DataGridViewRow row1 in dataGridView1.Rows)
                    {
                        if (row1.Index != row)
                        {
                            var s = row1.Cells[1].Value;

                            if (s != null)
                            {
                                alltasksid[i] = Convert.ToInt32(row1.Cells[0].Value); i++;
                                alltasksname[j] = row1.Cells[1].Value.ToString(); j++;
                            }
                        }

                    }
                }
                catch (Exception error)
                {
                    string message = "Task information is not entered";
                    string caption = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    return;
                }
                Form2 form2 = new Form2();

                form2.ShowDialog();
            }
            */
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         /*   if (comboBox1.SelectedText == null)
            {
                string message = "please enter number of sides ";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                return;
            }
            else
            {
                NofSides = Convert.ToInt32(comboBox1.Text);
                try
                {

                    row = e.RowIndex;
                    col = e.ColumnIndex;

                    Taskid = Convert.ToInt32(dataGridView1.Rows[row].Cells[0].Value);
                    Taskname = dataGridView1.Rows[row].Cells[1].Value.ToString();
                    Tasktime = Convert.ToDouble(dataGridView1.Rows[row].Cells[2].Value);
                    successors = "";
                    var s1 = dataGridView1.Rows[row].Cells[3].Value;
                    if (s1 != null)
                        successors = dataGridView1.Rows[row].Cells[3].Value.ToString();
                    dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[3];
                    sides = "";
                    var s2 = dataGridView1.Rows[row].Cells[4].Value;
                    if (s2 != null)
                        sides = dataGridView1.Rows[row].Cells[4].Value.ToString();

                    // Convert.ToInt32(dataGridView1.Rows[row].Cells[0].Value);
                    int n = dataGridView1.Rows.Count;
                    alltasksid = new int[n - 1];
                    alltasksname = new string[n - 1];
                    int i = 0, j = 0;
                    foreach (DataGridViewRow row1 in dataGridView1.Rows)
                    {
                        if (row1.Index != row)
                        {
                            var s = row1.Cells[1].Value;

                            if (s != null)
                            {
                                alltasksid[i] = Convert.ToInt32(row1.Cells[0].Value); i++;
                                alltasksname[j] = row1.Cells[1].Value.ToString(); j++;
                            }
                        }

                    }
                }
                catch (Exception error)
                {
                    string message = "Task information is not entered";
                    string caption = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    return;
                }
                Form2 form2 = new Form2();

                form2.ShowDialog();
            }
            */
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                int row = e.RowIndex;


                dataGridView1.Rows[row].Cells[0].Value = row + 1;
                // if(row==0 && opendialogflag ==0) dataGridView1.Rows[row+1].Cells[0].Value = 2;
                opendialogflag = 0;
            }
            catch (Exception h)
            {
                string message = h.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return ;

            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.dataGridView1.Rows[e.RowIndex].Selected = true;
                    this.rowIndex = e.RowIndex;
                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1];
                    this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
            catch (Exception j)
            {
                string message =j.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return ;

            }

        }
        private void contextMenuStrip1_Click(object sender, EventArgs e)

        {
            try
            {
                if (!this.dataGridView1.Rows[this.rowIndex].IsNewRow)
                {
                    this.dataGridView1.Rows.RemoveAt(this.rowIndex);
                }
            }
            catch (Exception q)
            {
                string message = q.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return;

            }
        }

        private void deletRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.dataGridView1.Rows[this.rowIndex].IsNewRow)
                {
                    this.dataGridView1.Rows.RemoveAt(this.rowIndex);
                }
            }
            catch (Exception w)
            {
                string message = w.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return ;

            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string path = "";
                
            //    if (openFileDialog11.ShowDialog() == DialogResult.OK)
            //    {
            //        path = openFileDialog11.FileName;
            //        int i = 0;
            //         using (var reader = new StreamReader(@path))
            //        {
            //            int counter = 0;
            //            while (!reader.EndOfStream)
            //            {
            //                var line = reader.ReadLine();
            //                var values = line.Split(',');

            //                if (counter == 1)
            //                {
                               
            //                  //  DataRow row = new DataRow();
            //                  //  dataGridView.Rows.Add(row);
                                
            //                    dataGridView1.Rows[i].Cells[0].Value = values[0];
            //                    dataGridView1.Rows[i].Cells[1].Value = values[1];
            //                    dataGridView1.Rows[i].Cells[2].Value = values[2];
            //                    dataGridView1.Rows[i].Cells[3].Value = values[3];
            //                    dataGridView1.Rows[i].Cells[4].Value = values[4];
            //                    ///////////////
            //                    textBox1.Text= values[5];
            //                    textBox2.Text = values[6];
            //                    comboBox1.Text = values[7];
            //                    dataGridView1.Rows.Add();
            //                    i++;

            //                }
            //                else if (counter >1)
            //                {

            //                    dataGridView1.Rows[i].Cells[0].Value = values[0];
            //                    dataGridView1.Rows[i].Cells[1].Value = values[1];
            //                    dataGridView1.Rows[i].Cells[2].Value = values[2];
            //                    dataGridView1.Rows[i].Cells[3].Value = values[3];
            //                    dataGridView1.Rows[i].Cells[4].Value = values[4];
            //                    dataGridView1.Rows.Add();
            //                    i++;
            //                }
                           
            //                counter++;
            //            }
            //        }

            //    }
            //}
            //catch (Exception ee)
            //{
            //    string message = ee.Message;
            //    string caption = "Error";
            //    MessageBoxButtons buttons = MessageBoxButtons.OK;
            //    DialogResult result;
            //    result = MessageBox.Show(message, caption, buttons);
            //    return;

            //}

        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {/*
            if (openFileDialog11.ShowDialog() == DialogResult.OK)
            {
               string filePath = openFileDialog11.FileName;
                DataTable dt = new DataTable();
                string[] lines = System.IO.File.ReadAllLines(filePath);
                if (lines.Length > 0)
                {
                    //first line to create header
                    //    string firstLine = lines[0];
                    //    string[] headerLabels = firstLine.Split(',');
                    //    foreach (string headerWord in headerLabels)
                    //    {
                    //        dt.Columns.Add(new DataColumn(headerWord));
                    //    }
                    //For Data

                    dt.Columns.Add(new DataColumn("Task ID"));
                    dt.Columns.Add(new DataColumn("Task Name"));
                    dt.Columns.Add(new DataColumn("Task Time"));
                    dt.Columns.Add(new DataColumn("Successors"));
                    dt.Columns.Add(new DataColumn("Sides"));
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] dataWords = lines[i].Split(',');
                        DataRow dr = dt.NewRow();
                       // int columnIndex = 0;
                        dr[0] = dataWords[0];
                        dr[1] = dataWords[1];
                        dr[2] = dataWords[2];
                        dr[3] = dataWords[3];
                        dr[4] = dataWords[4];
                      //  dataGridView1.Rows.Add(dr);

                //        foreach (string headerWord in headerLabels)
                  //      {
                    //        dr[headerWord] = dataWords[columnIndex++];
                      //  }
                        dt.Rows.Add(dr);
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
            }*/
                        
            dataGridView1.Rows.Clear();
            try
                        {
                            string path = "";
                               int i = 0;
                            if (openFileDialog11.ShowDialog() == DialogResult.OK)
                            {
                                path = openFileDialog11.FileName;
                                
                                using (var reader = new StreamReader(@path))
                                {
                                    int counter = 0;
                                    while (!reader.EndOfStream)
                                    {
                                        var line = reader.ReadLine();
                                        var values = line.Split(',');

                                        if (counter == 1)
                                        {

                                            //  DataRow row = new DataRow();
                                            //  dataGridView.Rows.Add(row);
                                            dataGridView1.Rows.Add();
                                       //     dataGridView1.Rows[i].Cells[0].Value = values[0];
                                            dataGridView1.Rows[i].Cells[1].Value = values[1].ToString();
                                            dataGridView1.Rows[i].Cells[2].Value = values[2];
                                              string su = values[3].Replace(';', ',');
                                              string si = values[4].Replace(';', ',');

                                              dataGridView1.Rows[i].Cells[3].Value = su;
                                            dataGridView1.Rows[i].Cells[4].Value = si;
                                            ///////////////
                                            textBox1.Text = values[5];
                                            textBox2.Text = values[6];
                                            comboBox1.Text = values[7];
                                            
                                            i++;

                                        }
                                        else if (counter > 1)
                                        {
                                           dataGridView1.Rows.Add();
                                          //  dataGridView1.Rows[i].Cells[0].Value = values[0];
                                            dataGridView1.Rows[i].Cells[1].Value = values[1];
                                            dataGridView1.Rows[i].Cells[2].Value = values[2];
                                             string su = values[3].Replace(';', ',');
                                            string si = values[4].Replace(';', ',');

                                            dataGridView1.Rows[i].Cells[3].Value = su;
                                            dataGridView1.Rows[i].Cells[4].Value = si;
                                                // dataGridView1.Rows[i].Cells[3].Value = values[3];
                                                //dataGridView1.Rows[i].Cells[4].Value = values[4];
                                                // dataGridView1.Rows.Add();
                                                i++;
                                        }

                                        counter++;
                                    }
                                }

                            }
                            opendialogflag = 1;
                dataGridView1.Rows[i].Cells[0].Value = i+1;
            }
                        catch (Exception ee)
                        {
                            string message = ee.Message;
                            string caption = "Error";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;
                            result = MessageBox.Show(message, caption, buttons);
                            return;

                        }

        }

        public void datagridupdate(string s, int row1)
        {
            try
            {
                dataGridView1.Rows[row1].Cells[3].Value = s.ToString();
            }
            catch (Exception r)
            {
                string message = r.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return;

            }

        }
    }
}
