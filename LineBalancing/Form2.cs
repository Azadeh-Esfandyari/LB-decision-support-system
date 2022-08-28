using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineBalancing
{
    public partial class Form2 : Form
    {
        public static int row1;
        public static int col1;
        public static int Taskid1;
        public static string Taskname1;
        public static double Tasktime1;
        public static int NofSides;
        int indexcom;
        int indexcom2;
        public static string successors1, sides1;
        public static string Cvalue;
        public static int[] tabsides;
        public static int tabsidesindex = 0;
        public static bool flag=true;
        public static int[] tabtaskids;
        int tabtaskidsindex=0;
        UserControl1 f;
        public Form2(UserControl1 f1)//Form3 f1  داخل پرانتز به عنوان پارامتر بود
        {
            InitializeComponent();
            dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
           dataGridView2.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView2_EditingControlShowing);
            dataGridView1.UserAddedRow += dataGridView1_RowCountChanged;
            dataGridView1.UserDeletedRow += dataGridView1_RowCountChanged;
            dataGridView2.UserAddedRow += dataGridView2_RowCountChanged;
            dataGridView2.UserDeletedRow += dataGridView2_RowCountChanged;
            this.f = f1;
           
        }

      

      

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                DataGridView dg = (DataGridView)sender;
                indexcom = dg.CurrentRow.Index;
                ComboBox combo = e.Control as ComboBox;

                if (combo != null)
                {
                    combo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                    combo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);

                }
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

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            ComboBox cb = (ComboBox)sender;
            int Taskid = 0;
            string item = cb.Text;
            flag = true;
            if (item != null && item != "")
            {
                Taskid = 0;
                for (int i = 0; i < Form3.alltasksname.Length - 1; i++)
                    if (Form3.alltasksname[i] == item)
                    {
                        Taskid = Form3.alltasksid[i];
                        break;
                    }
                if (Taskid != 0)
                {
                    dataGridView1.Rows[indexcom].Cells[0].Value = Taskid;

                    //////////////////////////////////////////////////

                    // ComboBox cb = (ComboBox)sender;


                    //int sid = System.Convert.ToInt32(cb.Text);

                    //flag = true;

                    //for (int i = 0; i < tabtaskids.Length; i++)
                    //    if (tabtaskids[i] == Taskid)
                    //        flag = false;
                    //if (flag)
                    //{
                    //    tabtaskids[tabtaskidsindex] = Taskid;
                    //    tabtaskidsindex++;

                    //}


                    //else
                    //{
                    //    string message = "You are not allowed to enter duplicate task ide's number ";
                    //    string caption = "Error Detected in Input";
                    //    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    //    DialogResult result;



                    //    result = MessageBox.Show(message, caption, buttons);
                    //    cb.SelectedIndex = Form3.alltasksname.Length - 1;
                    //    dataGridView1.Rows[indexcom].Cells[0].Value = null;

                    //    return;
                    //}
                }
            }

            //////////////////////////////////////////////////
        }
          catch (Exception t)
            {
                string message = t.Message;
        string caption = "Error";
        MessageBoxButtons buttons = MessageBoxButtons.OK;
        DialogResult result;
        result = MessageBox.Show(message, caption, buttons);
                return ;

            }

}
        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                DataGridView dg = (DataGridView)sender;
                indexcom2 = dg.CurrentRow.Index;
                ComboBox combo = e.Control as ComboBox;

                if (combo != null)
                {
                    combo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged1);
                    combo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged1);
                }
            }
            catch (Exception te)
            {
                string message = te.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return ;

            }
        }

        private void ComboBox_SelectedIndexChanged1(object sender, EventArgs e)
        {

            //ComboBox cb = (ComboBox)sender;
          

            //if (cb.Text != null && cb.Text != "")
            //{
            //    int side = System.Convert.ToInt32(cb.Text);

            //     flag = true;

            //    for (int i = 0; i < tabsides.Length; i++)
            //        if (tabsides[i] == side)
            //            flag = false;
            //    if (flag)
            //    {
            //        tabsides[tabsidesindex] = side;
            //        tabsidesindex++;
             
            //    }
            //    else
            //    {
            //        string message = "You are not allowed to enter duplicate side's number ";
            //        string caption = "Error Detected in Input";
            //        MessageBoxButtons buttons = MessageBoxButtons.OK;
            //        DialogResult result;

            //        // Displays the MessageBox.
                    
            //        result = MessageBox.Show(message, caption, buttons);
            //        cb.SelectedIndex = NofSides;
                
            //        return;
            //    }
            //}

        }

        private string find(int n)
        {
           
            string Taskname="";
            try
            {
                for (int i = 0; i < Form3.alltasksid.Length - 1; i++)
                    if (Form3.alltasksid[i] == n)
                    {
                        Taskname = Form3.alltasksname[i];
                        break;
                    }
                return Taskname;
            }
            catch (Exception te)
            {
                string message = te.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return Taskname;

            }


        }
        private void dataGridView1_RowCountChanged(object sender, EventArgs e)
        {
            CheckRowCount();
        }
        private void CheckRowCount()
        {
            try
            {
                // The data grid view's default behavior is such that it creates an additional row up front.
                // e.g. when you add 1st row, it creates 2nd row automatically.
                // If you use Count < MaxRows, the user won't be able to add the 10th row.
                if (dataGridView1.Rows.Count <= Form3.alltasksname.Length - 1)
                {
                    dataGridView1.AllowUserToAddRows = true;
                }
                else
                {
                    dataGridView1.AllowUserToAddRows = false;
                }
            }
            catch (Exception te)
            {
                string message = te.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return ;

            }

        }
        private void dataGridView2_RowCountChanged(object sender, EventArgs e)
        {
            CheckRowCount1();
        }
        private void CheckRowCount1()
        {
            try { 
            // The data grid view's default behavior is such that it creates an additional row up front.
            // e.g. when you add 1st row, it creates 2nd row automatically.
            // If you use Count < MaxRows, the user won't be able to add the 10th row.
            if (dataGridView2.Rows.Count <= Form3.NofSides)
            {
                dataGridView2.AllowUserToAddRows = true;
            }
            else
            {
                dataGridView2.AllowUserToAddRows = false;
            }
        }
              catch (Exception te)
            {
                string message = te.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return;

            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                int row;

                row = e.RowIndex;
                DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dataGridView1.Rows[row].Cells[1];
                for (int i = 0; i < Form3.alltasksname.Length - 1; i++)
                {
                    comboCell.Items.Add(Form3.alltasksname[i]);
                }
                comboCell.Items.Add("");
            }
            catch (Exception te)
            {
                string message = te.Message;
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                return;

            }
        }
      

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*

           int i = e.RowIndex;

            if (i != -1)// by loading the form this event occure!!!!and i will be -1
            {
                DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[1];
                if (dataGridView1.Rows[i].Cells[0].Value != null)
                {
                    string taskid = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    if (taskid != null)
                    {
                        int id = Convert.ToInt32(taskid);
                       
                        comboCell.Value = find(id);
                    }
                }
            }*/
            
        }
  

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            tabtaskidsindex = 0; tabsidesindex = 0;
            tabsides = new int[Form3.NofSides];
            // comboCell.Items.Add
            tabtaskids = new int[Form3.alltasksname.Length - 1];
            string sids = "", sides = "";
            //both button must trasfer both datagrid information and close// same code for both
            int i = 0;
            /*          tabtaskids = new int[dataGridView1.Rows.Count];

                      foreach (DataGridViewRow row1 in dataGridView1.Rows)
                      {

                              var s = row1.Cells[0].Value;

                          if (s != null)
                          {

                              tabtaskids[i] = Convert.ToInt32(row1.Cells[0].Value.ToString()); 
                              if (i < dataGridView1.Rows.Count - 1)
                                  sids =sids+ row1.Cells[0].Value.ToString() + ',';
                              else if (i == dataGridView1.Rows.Count - 1)
                                  sids = sids + row1.Cells[0].Value.ToString();
                          }
                          i++;

                      }
                      */
            //////////////////////////////////
            foreach (DataGridViewRow row1 in dataGridView1.Rows)
            {
                if (row1.Cells[0].Value != null)
                {
                    tabtaskids[tabtaskidsindex] = Convert.ToInt32(row1.Cells[0].Value);
                    tabtaskidsindex++;
                }
            }
            bool flag = true;

            for (int ii = 0; ii < tabtaskidsindex - 1; ii++)
                for (int jj = ii + 1; jj < tabtaskidsindex; jj++)
                    if (tabtaskids[ii] == tabtaskids[jj])
                    {
                        flag = false;
                        break;
                    }
            if (!flag)

            {
                string message = "You are not allowed to enter duplicate task ide's number ";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                // cb.SelectedIndex = NofSides;
                //  DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dataGridView2.Rows[indexcom2].Cells[0];
                // comboCell.sele ;
                //  dataGridView2.CurrentRow.Cells[0] = "";
                //dataGridView2.CurrentRow.Cells[0].ReadOnly = true;
                // dataGridView2.Rows[indexcom2].Cells[0].Value=null;

                // dataGridView1.Rows[indexcom2].Cells[0].Selected = false;
                //  cb.Refresh();
                return;
            }

            /////////////////////////////////////////////////

            flag = true;
            foreach (DataGridViewRow row1 in dataGridView2.Rows)

            {
                DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)row1.Cells[0];
                if (comboCell.Value != null)
                {
                    tabsides[tabsidesindex] = Convert.ToInt32(comboCell.Value.ToString());
                    tabsidesindex++;
                }
            }

            for (int ii = 0; ii < tabsidesindex - 1; ii++)
                for (int jj = ii + 1; jj < tabsidesindex; jj++)
                    if (tabsides[ii] == tabsides[jj])
                        flag = false;
            if (!flag)

            {
                string message = "You are not allowed to enter duplicate side's number ";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
                // cb.SelectedIndex = NofSides;
                //  DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dataGridView2.Rows[indexcom2].Cells[0];
                // comboCell.sele ;
                //  dataGridView2.CurrentRow.Cells[0] = "";
                //dataGridView2.CurrentRow.Cells[0].ReadOnly = true;
                // dataGridView2.Rows[indexcom2].Cells[0].Value=null;

                // dataGridView1.Rows[indexcom2].Cells[0].Selected = false;
                //  cb.Refresh();
                return;
            }



            /////////////////////////////////
            for (i = 0; i < tabtaskidsindex; i++)
            {

                if (i < tabtaskidsindex - 1)
                    sids = sids + tabtaskids[i].ToString() + ',';
                else if (i == tabtaskidsindex - 1)
                    sids = sids + tabtaskids[i].ToString();
            }


            for (i = 0; i < tabsidesindex; i++)
            {

                if (i < tabsidesindex - 1)
                    sides = sides + tabsides[i].ToString() + ',';
                else if (i == tabsidesindex - 1)
                    sides = sides + tabsides[i].ToString();
            }





                // Form3 f = new Form3();

                //  f.datagridupdate(sids, row1);

                f.fromform2(sids.ToString(), sides.ToString(), row1);

           //   f.userControl11.dataGridView1.Rows[row1].Cells[3].Value = sids.ToString();
            //  f.userControl11.dataGridView1.Rows[row1].Cells[4].Value = sides.ToString();
               
                this.Close();
            //  f.Refresh();
            //   f.Show();
            //    textBox1.Text= Form3.dataGridView1.Rows.Count.ToString();
            //  label1.Text= f.dataGridView1.Rows[row1].Cells[0].Value.ToString();
            // label1.Text= Form3.dataGridView1.Rows[row1].Cells[0].Value.ToString();
            //   f.dataGridView1.Rows.Add

            //  f.dataGridView1.Rows[row1].Cells[3].Value = sids.ToString();
        }
          catch (Exception te)
            {
                string message = te.Message;
        string caption = "Error";
        MessageBoxButtons buttons = MessageBoxButtons.OK;
        DialogResult result;
        result = MessageBox.Show(message, caption, buttons);
                return ;

            }

}

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try { 
            int row;

            row = e.RowIndex;
            // DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dataGridView2.Rows[row].Cells[1];
            DataGridViewComboBoxCell comboCell2 = (DataGridViewComboBoxCell)dataGridView2.Rows[row].Cells[0];
            for (int i = 1; i <= Form3.NofSides; i++)
                comboCell2.Items.Add(i.ToString());
            comboCell2.Items.Add(" ");
        }
          catch (Exception te)
            {
                string message = te.Message;
        string caption = "Error";
        MessageBoxButtons buttons = MessageBoxButtons.OK;
        DialogResult result;
        result = MessageBox.Show(message, caption, buttons);
                return ;

            }

}

        private void button4_Click(object sender, EventArgs e)
        {
            //both button must trasfer both datagrid information and close// same code for both
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            this.Close();
        }

        /*     private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
              {
                  int row;
                  row = e.RowIndex;

                 // int row = e.RowIndex;
                  dataGridView2.Rows[row].Cells[0].Value = row + 1;

                  DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dataGridView2.Rows[row].Cells[1];

                  for (int i = 0; i < Form3.NofSides; i++)
                  {
                      comboCell.Items.Add(i + 1);

                  }

              }
              */


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void Form2_Load(object sender, EventArgs e)
        {
            try { 

            row1 = Form3.row;
            col1 = Form3.col;
            Taskid1 = Form3.Taskid;
            Taskname1 = Form3.Taskname;
            Tasktime1 = Form3.Tasktime;
            successors1 = Form3.successors;
            sides1 = Form3.sides;
            NofSides = Form3.NofSides;
            textBox1.Text = Taskname1;
            textBox4.Text = Taskname1;
            textBox2.Text = Tasktime1.ToString();
            textBox3.Text = Tasktime1.ToString();
            textBox5.Text = NofSides.ToString();



            dataGridView2.ColumnCount = 1;
            //  DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            //    cmb.HeaderText = "Side";
            //    cmb.Name = "cmb";
            //    cmb.MaxDropDownItems = NofSides;
            //     for (int i = 1; i <= Form3.NofSides; i++)
            //         cmb.Items.Add(i.ToString());
            //     cmb.Items.Add("");
            //      dataGridView2.Columns.Insert(0,cmb);

            DataGridViewComboBoxCell comboCell2 = (DataGridViewComboBoxCell)dataGridView2.Rows[0].Cells[0];
            for (int i = 1; i <= Form3.NofSides; i++)
                comboCell2.Items.Add(i.ToString());
            comboCell2.Items.Add(" ");

            //   DataGridViewComboBoxCell comboCell1 = (DataGridViewComboBoxCell)dataGridView2.Rows[0].Cells[0];
            DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)dataGridView1.Rows[0].Cells[1];
            for (int i = 0; i < Form3.alltasksname.Length - 1; i++)
            {
                comboCell.Items.Add(Form3.alltasksname[i]);
            }
            comboCell.Items.Add(" ");
            //  dataGridView2.Rows[0].Cells[0].Value = 1;
            //DataGridViewComboBoxCell comboCell2 = (DataGridViewComboBoxCell)dataGridView2.Rows[0].Cells[1];
            // for (int i = 0; i < Form3.NofSides; i++)
            //  {
            //     comboCell2.Items.Add(i+1);
            //  }



            //   comboCell.Value = Form3.alltasksname[0];

            if (successors1 != null && successors1 != "")
            {
                string[] words = successors1.Split(',');
                int i = 0;
                foreach (var word in words)
                {
                    if (!(word[0] >= '0' && word[0] <= '9'))
                    {
                        string message = "please enter task's Id for successors";
                        string caption = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;
                        result = MessageBox.Show(message, caption, buttons);
                        this.Close();
                        return;

                    }
                    else
                    {
                        int SucTaskId = Convert.ToInt32(word);
                        string SucTaskname = find(SucTaskId);
                        if (SucTaskname == "")
                        {
                            string message = "Successor task Id is not valid";
                            string caption = "Error";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;
                            result = MessageBox.Show(message, caption, buttons);
                            this.Close();
                            return;

                        }
                        else
                        {
                            ///////////////////////////////////
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells[0].Value = SucTaskId;
                            comboCell = (DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells[1];

                            comboCell.Value = SucTaskname;
                            //  tabtaskids[tabtaskidsindex] = SucTaskId;
                            //  tabtaskidsindex++;
                            //////////////////////////////////
                            i++;
                        }
                    }
                }
            }
            if (sides1 != null && sides1 != "")
            {
                string[] words = sides1.Split(',');
                int i = 0;
                foreach (var word in words)
                {
                    if (!(word[0] >= '0' && word[0] <= '9'))
                    {
                        string message = "please enter side's Id for successors";
                        string caption = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;
                        result = MessageBox.Show(message, caption, buttons);
                        this.Close();
                        return;

                    }
                    else
                    {

                        int side = Convert.ToInt32(word);
                        if (side > NofSides || side < 1)
                        {
                            string message = "side number is not valid";
                            string caption = "Error";
                            MessageBoxButtons buttons = MessageBoxButtons.OK;
                            DialogResult result;
                            result = MessageBox.Show(message, caption, buttons);

                            this.Close();
                            return;
                            // break;
                        }
                        else
                        {
                            // string SidTaskname = find(SidTaskId);
                            ///////////////////////////////////
                            //dataGridView2.Columns.Add();
                            dataGridView2.Rows.Add();
                            DataGridViewComboBoxCell comboCell1 = (DataGridViewComboBoxCell)dataGridView2.Rows[i].Cells[0];
                            //  tabsides[tabsidesindex] = side;
                            //  tabsidesindex++;
                            comboCell1.Value = side.ToString();

                            /*     dataGridView2.Rows.Add();

                                 dataGridView2.Rows[i].Cells[0].Value = side.ToString();*/


                            //  DataGridViewComboBoxCell comboBoxCell = (dataGridView2.Rows[i].Cells[0] as DataGridViewComboBoxCell);
                            // comboBoxCell.Value = side;
                            // DataGridViewComboBoxColumn comboCell11 = (DataGridViewComboBoxColumn)dataGridView2.CurrentCell
                            //////////////////////////////////
                            i++;
                        }
                        /// dataGridView2.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView2_EditingControlShowing);
                    }
                }
            }

        }
          catch (Exception te)
            {
                string message = te.Message;
        string caption = "Error";
        MessageBoxButtons buttons = MessageBoxButtons.OK;
        DialogResult result;
        result = MessageBox.Show(message, caption, buttons);
                return ;

            }

}
    }
}
