using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace LineBalancing
{
    public partial class UserControl1 : UserControl
    {
      //  public static int row;
   //     public static int col;
     //   public static int Taskid;
      //  public static string Taskname;
     //   public static double Tasktime;
      //  public static int NofSides;
       // public static string successors, sides;
        //public static string[] alltasksname;
        //public static int[] alltasksid;
        //Tasks[] Tasks;
        //private int rowIndex = 0;
        //float cycleTime;
        //int numoftasks;
        public int opendialogflag = 0;
        public UserControl1()
        {
            InitializeComponent();
        }
        public  void fromform2(string sucids, string sides, int row111)
        {
           dataGridView1.Rows[row111].Cells[3].Value = sucids;
            dataGridView1.Rows[row111].Cells[4].Value = sides;
        }
        /*
        public int checkinput()
        {
            try
            {

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
        */
        /////////////
        /*
                public void save(string path)
                {



                    //////////////////////////////////

                    /////////////////////////////////////
                    try
                    {


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

                                    writer.WriteLine(t.taskid + "," + t.taskname + "," + t.tasktime + "," + s + "," + s1 + "," + cycleTime + "," + numoftasks + "," + NofSides);
                                }
                            }






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
                */
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
                return;

            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)

        {
            try
            {
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
                  Form3.NofSides = Convert.ToInt32(comboBox1.Text);
                    try
                    {

                        Form3.row = e.RowIndex;
                        Form3.col = e.ColumnIndex;

                        Form3.Taskid = Convert.ToInt32(dataGridView1.Rows[Form3.row].Cells[0].Value);
                        Form3.Taskname = dataGridView1.Rows[Form3.row].Cells[1].Value.ToString();
                        Form3.Tasktime = Convert.ToDouble(dataGridView1.Rows[Form3.row].Cells[2].Value);
                        Form3.successors = "";
                        dataGridView1.EndEdit();

                        var s1 = dataGridView1.Rows[Form3.row].Cells[3].Value;
                        if (s1 != null)
                            Form3.successors = dataGridView1.Rows[Form3.row].Cells[3].Value.ToString();
                        dataGridView1.CurrentCell = dataGridView1.Rows[Form3.row].Cells[3];
                        Form3.sides = "";
                        var s2 = dataGridView1.Rows[Form3.row].Cells[4].Value;
                        if (s2 != null)
                            Form3.sides = dataGridView1.Rows[Form3.row].Cells[4].Value.ToString();

                        // Convert.ToInt32(dataGridView1.Rows[row].Cells[0].Value);
                        int n = dataGridView1.Rows.Count;
                        Form3.alltasksid = new int[n - 1];
                        Form3.alltasksname = new string[n - 1];
                        int i = 0, j = 0;
                        foreach (DataGridViewRow row1 in dataGridView1.Rows)
                        {
                            if (row1.Index != Form3.row)
                            {
                                var s = row1.Cells[1].Value;

                                if (s != null)
                                {
                                    Form3.alltasksid[i] = Convert.ToInt32(row1.Cells[0].Value); i++;
                                    Form3.alltasksname[j] = row1.Cells[1].Value.ToString(); j++;
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
                    Form3 f1=new Form3();
                    Form2 form2 = new Form2(this);//(this)

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


    }
}
