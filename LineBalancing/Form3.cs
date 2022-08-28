using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

namespace LineBalancing
{
    public partial class Form3 : Form
    {
        public static int numofsuc = -1;
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
     //   private int rowIndex = 0;
       public static int numofstations;
        public static int numoftasks;
      //  int opendialogflag = 0;

        public Form3()
        {
            InitializeComponent();
            userControl21.BringToFront();
            
        }
   

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {

            // Determine whether the key entered is the F1 key. Display help if it is.
            //  if (e.KeyCode == Keys.F1)
            //  {
            // Display a pop-up help topic to assist the user.
         //   Help.ShowPopup(button1, "Home", new Point(button1.Right, this.button1.Bottom));
         
            // }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            userControl21.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)

        {
            userControl11.textBox1.Text = "";
            userControl11.textBox2.Text = "";
            userControl11.textBox3.Text = "";
            userControl11.dataGridView1.Rows.Clear();
            userControl11.comboBox1.SelectedIndex = userControl11.comboBox1.Items.IndexOf("1");

            userControl11.dataGridView1.Rows[0].Cells[0].Value = 1;
            userControl11.BringToFront();
        }



        private bool find(int n)
        {
            try
            {
                int i;
                //  string Taskname = "";
                for (i = 0; i <= Form3.alltasksid.Length - 1; i++)
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
        public void save(string path)
        {



            //////////////////////////////////

            /////////////////////////////////////
            try
            {


                //@"D:\test.csv"           
                using (TextWriter writer = new StreamWriter(@path, false, System.Text.Encoding.UTF8))
                {
                    writer.WriteLine("taskid" + "," + "taskname" + "," + "tasktime" + "," + "successors" + "," + "sides" + "," + "numofstations" + "," + "numoftasks" + "," + "NofSides");
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

                            writer.WriteLine(t.taskid + "," + t.taskname + "," + t.tasktime + "," + s + "," + s1);
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

                            writer.WriteLine(t.taskid + "," + t.taskname + "," + t.tasktime + "," + s + "," + s1 + "," + numofstations + "," + numoftasks + "," + NofSides);
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
            catch (Exception e)
            {
                string message = e.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return;

            }

        }

        private void userControl11_Load(object sender, EventArgs e)
        {
            try
            {
                userControl11.comboBox1.SelectedIndex = userControl11.comboBox1.Items.IndexOf("1");

                userControl11.dataGridView1.Rows[0].Cells[0].Value = 1;

            }
            catch (Exception eee)
            {
                string message = eee.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return;

            }

        }
        public int checkinput()
        {
            try
            {

                int numberofside;
                numofstations = 0;
                if (userControl11.textBox1.Text == "")
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
                int n11;
                bool isNumeric11 = int.TryParse(userControl11.textBox1.Text, out n11);
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
                { numofstations = n11; }
                if (userControl11.comboBox1.SelectedIndex == -1)
                {
                    string message = "please enter number of sides ";
                    string caption = "Error Detected in Input";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(message, caption, buttons);
                    return 0;
                }
                else { numberofside = Convert.ToInt32(userControl11.comboBox1.Text); NofSides = numberofside; }
                numoftasks = 0;
                if (userControl11.textBox2.Text == "")
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
                bool isNumeric = int.TryParse(userControl11.textBox2.Text, out n);
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
                int n111 = userControl11.dataGridView1.Rows.Count;
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
                int rowcount = userControl11.dataGridView1.RowCount;
                int tasktime = 0, taskid = 0;
                string taskname, successors, sides;
                if ((rowcount - 1) == numoftasks)
                {
                    Tasks = new Tasks[numoftasks];


                    for (int i = 0; i < numoftasks; i++)
                    {
                        numofsuc = -1;
                       
                        ///////////////////////////////
                        alltasksid = new int[n111 - 2];
                        int kk = 0, pp = 0;
                        foreach (DataGridViewRow row1 in userControl11.dataGridView1.Rows)
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
                        if (userControl11.dataGridView1.Rows[i].Cells[0].Value != null && userControl11.dataGridView1.Rows[i].Cells[1].Value != null)
                        {
                            taskname = userControl11.dataGridView1.Rows[i].Cells[1].Value.ToString();
                            taskid = Convert.ToInt32(userControl11.dataGridView1.Rows[i].Cells[0].Value.ToString());
                            int n1 = 0, n2 = 0;
                            if (userControl11.dataGridView1.Rows[i].Cells[2].Value != null)
                            {
                                // bool isNumeric1 = int.TryParse(dataGridView1.Rows[i].Cells[0].Value.ToString(), out n1);
                                bool isNumeric2 = int.TryParse(userControl11.dataGridView1.Rows[i].Cells[2].Value.ToString(), out n2);

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
                                    tasktime = Convert.ToInt32(userControl11.dataGridView1.Rows[i].Cells[2].Value);
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
                            if ((userControl11.dataGridView1.Rows[i].Cells[3].Value != "") &&(userControl11.dataGridView1.Rows[i].Cells[3].Value != null)  )
                            {

                                successors = userControl11.dataGridView1.Rows[i].Cells[3].Value.ToString();

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
                                /*  string message = "You did not enter any values in the row" + (i + 1) + " for  successors  ";
                                  string caption = "Error Detected in Input";
                                  MessageBoxButtons buttons = MessageBoxButtons.OK;
                                  DialogResult result;

                                  // Displays the MessageBox.

                                  result = MessageBox.Show(message, caption, buttons);
                                  return 0; */
                                numofsuc = 0;
                            }

                            ////////////////////////////////////////////////////////////////////////////

                            //////////////////////////////sides////////////////////////////////////////////    
                            int sidelen = 0;
                            if (userControl11.dataGridView1.Rows[i].Cells[4].Value != null)
                            {

                                sides = userControl11.dataGridView1.Rows[i].Cells[4].Value.ToString();

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
                        int j;
                        if (numofsuc!=0)
                        {
                            j = 0;
                            foreach (int a in successorlist)
                            {
                                Tasks[i].successors[j] = a;
                                j++;
                            }
                            Tasks[i].numofsuc = Tasks[i].successors.Length;
                        }
                        else
                        {
                            Tasks[i].numofsuc = 0;
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
            catch (Exception e)
            {
                string message = e.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return 0;

            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)

        {

            userControl11.textBox1.Text = "";
            userControl11.textBox2.Text = "";
            userControl11.textBox3.Text = "";
            userControl11.dataGridView1.Rows.Clear();
            userControl11.comboBox1.SelectedIndex = userControl11.comboBox1.Items.IndexOf("1");

            userControl11.dataGridView1.Rows[0].Cells[0].Value = 1;
            userControl11.BringToFront();
           // userControl11.dataGridView1.Rows.Clear();
            try
            {
                string path = "";
                int i = 0;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog1.FileName;

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
                                userControl11.dataGridView1.Rows.Add();
                                //     dataGridView1.Rows[i].Cells[0].Value = values[0];
                                userControl11. dataGridView1.Rows[i].Cells[1].Value = values[1].ToString();
                                userControl11.dataGridView1.Rows[i].Cells[2].Value = values[2];
                                string su = values[3].Replace(';', ',');
                                string si = values[4].Replace(';', ',');

                                userControl11.dataGridView1.Rows[i].Cells[3].Value = su;
                                userControl11.dataGridView1.Rows[i].Cells[4].Value = si;
                                ///////////////
                                userControl11.textBox1.Text = values[5];
                                userControl11.textBox2.Text = values[6];
                                userControl11.comboBox1.Text = values[7];

                                i++;

                            }
                            else if (counter > 1)
                            {
                                userControl11.dataGridView1.Rows.Add();
                                //  dataGridView1.Rows[i].Cells[0].Value = values[0];
                                userControl11.dataGridView1.Rows[i].Cells[1].Value = values[1];
                                userControl11.dataGridView1.Rows[i].Cells[2].Value = values[2];
                                string su = values[3].Replace(';', ',');
                                string si = values[4].Replace(';', ',');

                                userControl11.dataGridView1.Rows[i].Cells[3].Value = su;
                                userControl11.dataGridView1.Rows[i].Cells[4].Value = si;
                                // dataGridView1.Rows[i].Cells[3].Value = values[3];
                                //dataGridView1.Rows[i].Cells[4].Value = values[4];
                                // dataGridView1.Rows.Add();
                                i++;
                            }

                            counter++;
                        }
                    }

                }
                userControl11.opendialogflag = 1;
                userControl11.dataGridView1.Rows[i].Cells[0].Value = i + 1;
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkinput();
            Algorithm al = new Algorithm(Tasks,userControl31);
            al.Main1();
            userControl31.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // dataGridView1.RefreshEdit();
                //این مشکل را داشتم که وقتی مقادیر دیتاگرید را تغییر میدادم و دوباره ذخیره را کلیک میکردم همان مقادیر قبلی را درنظر میگرفت
                //مجبور شدم فوکوس را به یک کنترل دیگه تغییر بدم که مشکل حل شه
                userControl11.textBox1.Focus();
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
                return;

            }


        }

/*
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)

        {
            try
            {
                if (userControl11.comboBox1.SelectedText == null)
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
                    NofSides = Convert.ToInt32(userControl11.comboBox1.Text);
                    try
                    {

                        row = e.RowIndex;
                        col = e.ColumnIndex;

                        Taskid = Convert.ToInt32(userControl11.dataGridView1.Rows[row].Cells[0].Value);
                        Taskname = userControl11.dataGridView1.Rows[row].Cells[1].Value.ToString();
                        Tasktime = Convert.ToDouble(userControl11.dataGridView1.Rows[row].Cells[2].Value);
                        successors = "";
                        userControl11.dataGridView1.EndEdit();

                        var s1 = userControl11.dataGridView1.Rows[row].Cells[3].Value;
                        if (s1 != null)
                            successors = userControl11.dataGridView1.Rows[row].Cells[3].Value.ToString();
                        userControl11.dataGridView1.CurrentCell = userControl11.dataGridView1.Rows[row].Cells[3];
                        sides = "";
                        var s2 = userControl11.dataGridView1.Rows[row].Cells[4].Value;
                        if (s2 != null)
                            sides = userControl11.dataGridView1.Rows[row].Cells[4].Value.ToString();

                        // Convert.ToInt32(dataGridView1.Rows[row].Cells[0].Value);
                        int n = userControl11.dataGridView1.Rows.Count;
                        alltasksid = new int[n - 1];
                        alltasksname = new string[n - 1];
                        int i = 0, j = 0;
                        foreach (DataGridViewRow row1 in userControl11.dataGridView1.Rows)
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

                    form2.Show();
                }

            }
            catch (Exception g)
            {
                string message = g.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return;

            }

        }

    */

    }
}
