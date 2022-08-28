using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
//using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace LineBalancing
{
    class Algorithm
    {
        public  Tasks[] Tasks;
     //   public static int row;
       // public static int col;
       // public static int Taskid;
        //public static string Taskname;
        //public static double Tasktime;
        public static int NofSides;
    //    public static string successors, sides;
      //  public static string[] alltasksname;
        public static int[] alltasksid;
     
    //    private int rowIndex = 0;
        public static int numofstations;
        public static int numofsuc=-1;
        public static int numoftasks;
       Form3 f3;
       UserControl3 u3;
        /// /////////////////////////
        /// </summary>
        //////Global parameters and variables
        static int job;//job is the number of tasks,p is the maximum number of positions
        static int ma = 50;//ma is the maximum number of pre or suc
        static int mside = 2;
        static int big = 100000;
        //static int Direct=3;//
        static float ct;
        static int NbSt;//Number of mated-stations
        static double Nmove = 0.02;
        static double Nmove1 = 0.00002;
        ///////////////////////////
        public Algorithm(Tasks[] tasks, UserControl3 u3)
        {
            this.Tasks = tasks;
            this.u3 = u3;


        }


        //public bool find(int n)
        //{
        //    try
        //    {
        //        int i;
        //        //  string Taskname = "";
        //        for (i = 0; i <= alltasksid.Length - 1; i++)
        //            if (alltasksid[i] == n)
        //            {
        //                // Taskname = Form1.alltasksname[i];
        //                break;
        //            }
        //        if (i <= alltasksid.Length - 1)
        //            return true;
        //        else return false;
        //    }
        //    catch (Exception e)
        //    {
        //        string message = e.Message;
        //        string caption = "Error";
        //        MessageBoxButtons buttons = MessageBoxButtons.OK;
        //        DialogResult result;
        //        result = MessageBox.Show(message, caption, buttons);
        //        return false;

        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
 
        //public  int checkinput()
        //{
        //    try
        //    {

        //        int numberofside;
        //       numofstations = 0;
        //        if (Form3.userControl11.textBox1.Text == "")
        //        {
        //            string message = "please enter number of stations ";
        //            string caption = "Error Detected in Input";
        //            MessageBoxButtons buttons = MessageBoxButtons.OK;
        //            DialogResult result;

        //            // Displays the MessageBox.

        //            result = MessageBox.Show(message, caption, buttons);
        //            //  this.Close();
        //            return 0;
        //        }
        //       int n11;
        //        bool isNumeric11 = int.TryParse(Form3.userControl11.textBox1.Text, out n11);
        //        if (isNumeric11 == false)
        //        {
        //            string message = "You did not enter numeric value for number of stations ";
        //            string caption = "Error Detected in Input";
        //            MessageBoxButtons buttons = MessageBoxButtons.OK;
        //            DialogResult result;

        //            // Displays the MessageBox.

        //            result = MessageBox.Show(message, caption, buttons);
        //            return 0;
        //        }
        //        else
        //        { numofstations = n11; }
        //        if (Form3.userControl11.comboBox1.SelectedIndex == -1)
        //        {
        //            string message = "please enter number of sides ";
        //            string caption = "Error Detected in Input";
        //            MessageBoxButtons buttons = MessageBoxButtons.OK;
        //            DialogResult result;

        //            // Displays the MessageBox.

        //            result = MessageBox.Show(message, caption, buttons);
        //            return 0;
        //        }
        //        else { numberofside = Convert.ToInt32(Form3.userControl11.comboBox1.Text);NofSides = numberofside; }
        //       numoftasks = 0;
        //        if (Form3.userControl11.textBox2.Text == "")
        //        {
        //            string message = "please enter number of tasks ";
        //            string caption = "Error Detected in Input";
        //            MessageBoxButtons buttons = MessageBoxButtons.OK;
        //            DialogResult result;

        //            // Displays the MessageBox.

        //            result = MessageBox.Show(message, caption, buttons);
        //            return 0;
        //        }
        //        ////////
        //        int n;
        //        bool isNumeric = int.TryParse(Form3.userControl11.textBox2.Text, out n);
        //        if (isNumeric == false)
        //        {
        //            string message = "You did not enter numeric value for number of tasks ";
        //            string caption = "Error Detected in Input";
        //            MessageBoxButtons buttons = MessageBoxButtons.OK;
        //            DialogResult result;

        //            // Displays the MessageBox.

        //            result = MessageBox.Show(message, caption, buttons);
        //            return 0;
        //        }
        //        else { numoftasks = n; }
        //        //////////
        //        int n111 = Form3.userControl11.dataGridView1.Rows.Count;
        //        //             alltasksid = new int[n111 -2];
        //        //              int k = 0,p = 0;
        //        ////             foreach (DataGridViewRow row1 in dataGridView1.Rows)
        //        //            {
        //        //              if (row1.Index != row)
        //        //            {
        //        //              var s = row1.Cells[1].Value;
        //        //
        //        //            if (s != null)
        //        //          {
        //        //            alltasksid[k] = Convert.ToInt32(row1.Cells[0].Value.ToString()); k++;
        //        //          //  alltasksname[p] = row1.Cells[1].Value.ToString(); p++;
        //        //    }
        //        //     }
        //        // }
        //        //////////////////////
        //        int rowcount = Form3.userControl11.dataGridView1.RowCount;
        //        int tasktime = 0, taskid = 0;
        //        string taskname, successors, sides;
        //        if ((rowcount - 1) == numoftasks)
        //        {
        //            Tasks = new Tasks[numoftasks];


        //            for (int i = 0; i < numoftasks; i++)
        //            {
        //                numofsuc = -1;
        //                ///////////////////////////////
        //                alltasksid = new int[n111 - 2];
        //                int kk = 0, pp = 0;
        //                foreach (DataGridViewRow row1 in Form3.userControl11.dataGridView1.Rows)
        //                {
        //                    if (row1.Index != i)
        //                    {
        //                        var s = row1.Cells[1].Value;

        //                        if (s != null)
        //                        {
        //                            alltasksid[kk] = Convert.ToInt32(row1.Cells[0].Value.ToString()); kk++;
        //                            //  alltasksname[p] = row1.Cells[1].Value.ToString(); p++;
        //                        }
        //                    }
        //                }

        //                ////////////////////////////////
        //                List<Int32> sidelist = new List<Int32>();
        //                List<Int32> successorlist = new List<Int32>();
        //                taskname = null;
        //                // int n;
        //                // bool isNumeric = int.TryParse("123", out n);
        //                if (Form3.userControl11.dataGridView1.Rows[i].Cells[0].Value != null && Form3.userControl11.dataGridView1.Rows[i].Cells[1].Value != null)
        //                {
        //                    taskname = Form3.userControl11.dataGridView1.Rows[i].Cells[1].Value.ToString();
        //                    taskid = Convert.ToInt32(Form3.userControl11.dataGridView1.Rows[i].Cells[0].Value.ToString());
        //                    int n1 = 0, n2 = 0;
        //                    if (Form3.userControl11.dataGridView1.Rows[i].Cells[2].Value != null)
        //                    {
        //                        // bool isNumeric1 = int.TryParse(dataGridView1.Rows[i].Cells[0].Value.ToString(), out n1);
        //                        bool isNumeric2 = int.TryParse(Form3.userControl11.dataGridView1.Rows[i].Cells[2].Value.ToString(), out n2);

        //                        if (isNumeric2 == false)
        //                        {
        //                            string message = "You did not enter numeric values in the row" + (i + 1) + " for  tasktime  ";
        //                            string caption = "Error Detected in Input";
        //                            MessageBoxButtons buttons = MessageBoxButtons.OK;
        //                            DialogResult result;

        //                            // Displays the MessageBox.

        //                            result = MessageBox.Show(message, caption, buttons);
        //                            return 0;
        //                        }
        //                        else
        //                        {
        //                            tasktime = Convert.ToInt32(Form3.userControl11.dataGridView1.Rows[i].Cells[2].Value);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        string message = "You did not enter any values in the row" + (i + 1) + " for  tasktime  ";
        //                        string caption = "Error Detected in Input";
        //                        MessageBoxButtons buttons = MessageBoxButtons.OK;
        //                        DialogResult result;

        //                        // Displays the MessageBox.

        //                        result = MessageBox.Show(message, caption, buttons);
        //                        return 0;
        //                    }
        //                    /////////////////////////////////////////////////////////////////////////////
        //                    /////////////////////////////successors//////////////////////////////////
        //                    int suclen = 0;
        //                    if (Form3.userControl11.dataGridView1.Rows[i].Cells[3].Value != null)
        //                    {

        //                        successors = Form3.userControl11.dataGridView1.Rows[i].Cells[3].Value.ToString();

        //                        string[] words = successors.Split(',');

        //                        foreach (var word in words)
        //                        {
        //                            if (!(word[0] >= '0' && word[0] <= '9'))
        //                            {
        //                                string message = "You did not enter numeric values in the row" + (i + 1) + " for  successors";
        //                                string caption = "Error";
        //                                MessageBoxButtons buttons = MessageBoxButtons.OK;
        //                                DialogResult result;
        //                                result = MessageBox.Show(message, caption, buttons);
        //                                return 0;
        //                                //  this.Close();
        //                            }
        //                            else
        //                            {
        //                                int SucTaskId = Convert.ToInt32(word);
        //                                bool SucTask = find(SucTaskId);
        //                                if (SucTask == false)
        //                                {
        //                                    string message = "Successor task Id is not valid in the row" + (i + 1);
        //                                    string caption = "Error";
        //                                    MessageBoxButtons buttons = MessageBoxButtons.OK;
        //                                    DialogResult result;
        //                                    result = MessageBox.Show(message, caption, buttons);
        //                                    return 0;
        //                                    //this.Close();
        //                                }
        //                                else
        //                                {


        //                                    successorlist.Add(SucTaskId);
        //                                    suclen++;

        //                                }
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        /*  string message = "You did not enter any values in the row" + (i + 1) + " for  successors  ";
        //                          string caption = "Error Detected in Input";
        //                          MessageBoxButtons buttons = MessageBoxButtons.OK;
        //                          DialogResult result;

        //                          // Displays the MessageBox.

        //                          result = MessageBox.Show(message, caption, buttons);
        //                          return 0; */
        //                        numofsuc = 0;
        //                    }

        //                    ////////////////////////////////////////////////////////////////////////////

        //                    //////////////////////////////sides////////////////////////////////////////////    
        //                    int sidelen = 0;
        //                    if (Form3.userControl11.dataGridView1.Rows[i].Cells[4].Value != null)
        //                    {

        //                        sides = Form3.userControl11.dataGridView1.Rows[i].Cells[4].Value.ToString();

        //                        string[] words = sides.Split(',');

        //                        foreach (var word in words)
        //                        {
        //                            if (!(word[0] >= '0' && word[0] <= '9'))
        //                            {
        //                                string message = "You did not enter numeric values in the row" + (i + 1) + " for  sides";
        //                                string caption = "Error";
        //                                MessageBoxButtons buttons = MessageBoxButtons.OK;
        //                                DialogResult result;
        //                                result = MessageBox.Show(message, caption, buttons);
        //                                return 0;
        //                                //  this.Close();
        //                            }
        //                            else
        //                            {
        //                                int SideId = Convert.ToInt32(word);
        //                                ///   bool SucTask = find(SucTaskId);
        //                                if (!(SideId >= 1 && SideId <= numberofside))
        //                                {
        //                                    string message = "the side is not valid in the row " + (i + 1);
        //                                    string caption = "Error";
        //                                    MessageBoxButtons buttons = MessageBoxButtons.OK;
        //                                    DialogResult result;
        //                                    result = MessageBox.Show(message, caption, buttons);
        //                                    return 0;
        //                                    //this.Close();
        //                                }
        //                                else
        //                                {


        //                                    sidelist.Add(SideId);
        //                                    sidelen++;

        //                                }
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        string message = "You did not enter any values in the row" + (i + 1) + " for  sides  ";
        //                        string caption = "Error Detected in Input";
        //                        MessageBoxButtons buttons = MessageBoxButtons.OK;
        //                        DialogResult result;

        //                        // Displays the MessageBox.

        //                        result = MessageBox.Show(message, caption, buttons);
        //                        return 0;
        //                    }



        //                    /////////////////////////////////////////////////////////////////////////

        //                }

        //                ///////////////////add to array of Tasks objects////////////////////
        //                Tasks[i] = new Tasks(successorlist.Count, sidelist.Count);


        //                Tasks[i].taskid = taskid;
        //                Tasks[i].taskname = taskname;
        //                Tasks[i].tasktime = tasktime;
        //                int j = 0;
        //                // for(int j=0;j< successorlist.Count;j++)
        //                if (numofsuc != 0) {
        //                 j = 0;
        //                foreach (int a in successorlist)
        //                {
        //                    Tasks[i].successors[j] = a;
        //                    j++;
        //                }
        //                    Tasks[i].numofsuc = Tasks[i].successors.Length;
        //                }
        //                else {
        //                    Tasks[i].numofsuc = 0;
        //                }
        //                j = 0;
        //                foreach (int a in sidelist)
        //                {
        //                    Tasks[i].sides[j] = a;
        //                    j++;
        //                }

        //                ////////////////////////////////////////
        //            }
        //        }
        //        else
        //        {
        //            string message = "please enter exactly  " + numoftasks + " tasks";
        //            string caption = "Error Detected in Input";
        //            MessageBoxButtons buttons = MessageBoxButtons.OK;
        //            DialogResult result;

        //            // Displays the MessageBox.

        //            result = MessageBox.Show(message, caption, buttons);
        //            return 0;
        //        }

        //        return 1;
        //    }
        //    catch (Exception e)
        //    {
        //        string message = e.Message;
        //        string caption = "Error";
        //        MessageBoxButtons buttons = MessageBoxButtons.OK;
        //        DialogResult result;
        //        result = MessageBox.Show(message, caption, buttons);
        //        return 0;

        //    }
        //}
        ////////////
        public static void rpw(float[] Ttime, float[] Trank, int[,] Astar)
        {
            int i, j;
            float sum = 0;
            for (i = 0; i < job; i++)
            {
                sum = Ttime[i];
                for (j = 0; j < job; j++)
                    if (Astar[i, j] == 1)
                        sum += Ttime[i];
                Trank[i] = sum;
            }
        }
        public static void multiple(int[,] A, int[,] b, int[,] c)
        {
            int i, j, k, sum;
            for (i = 0; i < job; i++)
                for (j = 0; j < job; j++)
                {
                    sum = 0;
                    for (k = 0; k < job; k++)
                        sum += A[i, k] * b[k, j];
                    c[i, j] = sum;
                }
        }
        public static void precedence(int[,] A, int[,] Astar)
        {
            int i, j, m;
            int[,] swap = new int[job, job];
            for (i = 0; i < job; i++)
                for (j = 0; j < job; j++)
                {
                    Astar[i, j] = A[i, j];
                    swap[i, j] = A[i, j];
                }
            do
            {
                m = 0;
                multiple(A, swap, swap);
                for (i = 0; i < job; i++)
                    for (j = 0; j < job; j++)
                        if (swap[i, j] > 0)
                        {
                            Astar[i, j] = 1;
                            m++;
                        }
            } while (m > 0);
        }
        public static int iis(int i, int[,] As)
        {

            int j, sw = 0;
            for (j = 0; j < job; j++)
                if (As[j, i] == 1)
                    sw++;
            if (sw > 0)
                return 0;
            else
                return 1;
        }
        public static int inDirection(int i1, int k1, int[] Tdirectionno, int[,] Tdirection)
        {
            int sw = 0;
            for (int l = 0; l < Tdirectionno[i1]; l++)
            {
                if (Tdirection[i1, l] == k1)
                {
                    sw = 1;
                }
            }
            return sw;
        }
        public static float Min(int i, int position, int[] Tdirectionno, int[,] Tdirection, float[,] StCom)
        {
            float min;
            min = big;
            for (int k = 0; k < mside; k++)
            {
                if (inDirection(i, (k + 1), Tdirectionno, Tdirection) == 1)
                {
                    if (StCom[position, k] <= min)
                        min = StCom[position, k];
                }
            }
            return min;
        }
        public static int available(int[] F, int position, int[,] Seed, int[,] As, float[,] timesum,
                float[] Ttime, float Lct, int[] Tdirectionno, int[,] Tdirection, float[,] StFi, float[,] StCom, int[,] Pre, int[] NPre)
        {
            int i, l, sup, sw;
            float start;
            int[] S = new int[job];
            l = 0;
            for (i = 0; i < job; i++)
            {//main
                if ((iis(i, As) == 1) && (Seed[0, i] == -1))
                {// 1
                    if (position < (NbSt - 1))
                    {//position<NbSt-1
                        sup = 0;
                        int m;
                        //System.out.println("task="+NPre[i]);
                        for (int j = 0; j < NPre[i]; j++)
                        {
                            m = Pre[i, j];
                            ///System.out.println("m="+m);
                            if (Seed[0, m] >= sup)
                                sup = Seed[0, m];
                        }
                        start = 0;
                        if (position == sup)
                        {// 2
                            for (int j = 0; j < NPre[i]; j++)
                            {
                                m = Pre[i, j];
                                if (Seed[0, m] == sup)
                                    if (StFi[1, m] >= start)
                                        start = StFi[1, m];
                            }
                            sw = 0;
                            for (int k = 0; k < mside; k++)
                            {
                                //System.out.println("k="+k);
                                if (inDirection(i, (k + 1), Tdirectionno, Tdirection) == 1)
                                {
                                    if ((start + Ttime[i] <= Lct) && (StCom[position, k] + Ttime[i] <= Lct))
                                        sw++;
                                }
                            }
                            if (sw > 0)
                            {
                                F[l] = i;
                                l++;
                            }
                        }//end of if number 2
                        else
                        {
                            sw = 0;
                            for (int k = 0; k < mside; k++)
                            {
                                if (inDirection(i, (k + 1), Tdirectionno, Tdirection) == 1)
                                {
                                    if ((StCom[position, k] + Ttime[i]) <= Lct)
                                        sw++;
                                }
                            }
                            if (sw > 0)
                            {
                                F[l] = i;
                                l++;
                            }
                        }//The End of else block
                    }//if position<NbSt-1
                    else
                    {////else position<NbSt-1
                        for (int k = 0; k < mside; k++)
                        {
                            if (inDirection(i, (k + 1), Tdirectionno, Tdirection) == 1)
                            {
                                F[l] = i;
                                l++;
                            }
                        }
                    }//End else position<NbSt-1
                     ////
                }//The End of if number 1
            }//The end of main for
            return l;
        }//The end of available function
        public static int determinetask(int position, int[,] Seed, float[] Trank, int[,] As,
                float[,] timesum, float[] Ttime, float Lct, int[] Tdirectionno, int[,] Tdirection, float[,] StFi, float[,] StCom, int[,] Pre, int[] NPre)
        {
            int[] F = new int[job];//F is the array that keeps the id of available tasks
            int ret = -1;
            int k = 0, i, j;//k keeps the number of  available tasks
                            //float max;
            int min;
            k = available(F, position, Seed, As, timesum, Ttime, Lct, Tdirectionno, Tdirection, StFi, StCom, Pre, NPre);
            if (k == 0)
                ret = -1;
            if (k == 1)
            {
                ret = F[0];
            }
            if (k > 1)
            {//1
             //max=Trank[F[0]];
                min = Seed[2, F[0]];
                j = F[0];
                for (i = 0; i < k; i++)
                    //if(Trank[F[i]]>max){
                    //	  max=Trank[F[i]];
                    if (Seed[2, F[i]] < min)
                    {
                        min = Seed[2, F[i]];
                        j = F[i];
                    }
                ret = j;
            }//1
            return ret;
        }// The end of determinetask function
        public static int last(int i, float[] Blue, int[,] Seed, float[,] StFi, int[,] Pre, int[] NPre)
        {
            int j, max = -1, m, finishtask = -1;
            float start;
            for (j = 0; j < NPre[i]; j++)
            {
                m = Pre[i, j];
                if (Seed[0, m] >= max)
                    max = Seed[0, m];
            }
            start = 0;
            for (j = 0; j < NPre[i]; j++)
            {
                m = Pre[i, j];
                if (Seed[0, m] == max)
                    if (StFi[1, m] >= start)
                    {
                        start = StFi[1, m];
                        finishtask = m;
                    }
            }
            if (max != -1)
            {
                Blue[0] = finishtask;
                Blue[1] = max;
                Blue[2] = Seed[1, finishtask];
                Blue[3] = StFi[1, finishtask];
                return 1;
            }
            else
                return 0;
        }
        public static float starttime1(int i, int position, int st, int[,] Seed, float[,] StFi,
                int[] Tdirectionno, int[,] Tdirection, float[,] StCom, int[,] Pre, int[] NPre)
        {//i is the task  number
            int pt;
            float[] Blue = new float[4];
            if (last(i, Blue, Seed, StFi, Pre, NPre) == 1)
            {//1
                pt = (int)Blue[1];
                if (pt == position)
                {//2
                    if (StCom[position, st] < Blue[3])
                        return (Blue[3]);
                    else
                        return (StCom[position, st]);
                }//The end of if number 2
                else
                {
                    ///System.out.println("i="+i);
                    //System.out.println("position="+position);
                    //System.out.println("st="+st);
                    return (StCom[position, st]);
                }
            }//The end of if number 1
            else
            {
                return (StCom[position, st]);
            }
        }//The end of starttime function
        public static int find(int f, int position, int[] D, int[] Tdirectionno, int[,] Tdirection, float[,] timesum,
                float[] Ttime, float Lct, float[,] StCom, int[,] Seed, float[,] StFi, int[,] Pre, int[] NPre)
        {//This function finds those sides in which task f can be assigned to
            float start = 0;
            int sw = 0;
            int l = 0;
            if (position < (NbSt - 1))
            {//position<NbSt-1
                int sup = 0;
                int m;
                //System.out.println("task="+NPre[i]);
                for (int j = 0; j < NPre[f]; j++)
                {
                    m = Pre[f, j];
                    ///System.out.println("m="+m);
                    ///System.out.println("task="+Seed[0][m]);
                    if (Seed[0, m] >= sup)
                        sup = Seed[0, m];
                }
                start = 0;
                if (position == sup)
                {// 2
                    for (int j = 0; j < NPre[f]; j++)
                    {
                        m = Pre[f, j];
                        if (Seed[0, m] == sup)
                            if (StFi[1, m] >= start)
                                start = StFi[1, m];
                    }
                    sw = 0;
                    for (int k = 0; k < mside; k++)
                    {
                        if (inDirection(f, (k + 1), Tdirectionno, Tdirection) == 1)
                        {
                            if ((start + Ttime[f] <= Lct) && (StCom[position, k] + Ttime[f] <= Lct))
                            {
                                D[l] = k;
                                l++;
                            }
                        }
                    }
                }//end of if number 2
                else
                {
                    sw = 0;
                    for (int k = 0; k < mside; k++)
                    {
                        if (inDirection(f, (k + 1), Tdirectionno, Tdirection) == 1)
                        {
                            if ((StCom[position, k] + Ttime[f]) <= Lct)
                            {
                                D[l] = k;
                                l++;
                            }
                        }
                    }
                }//The End of else block
            }//if position<NbSt-1
            else
            {////else position<NbSt-1
                for (int k = 0; k < mside; k++)
                {
                    if (inDirection(f, (k + 1), Tdirectionno, Tdirection) == 1)
                    {
                        D[l] = k;
                        l++;
                    }
                }
            }//End else position<NbSt-1
             ////
            return l;
        }
        public static int determineside(int[] D, int position, int j)
        {
            int select = 0;
            double[] wheel = new double[j + 1];
            wheel[0] = 0;
            for (int l = 1; l <= j; l++)
            {
                wheel[l] = wheel[l - 1] + (1 / j);
            }
            Random rand = new Random();
            double rand1 = rand.NextDouble();
            for (int l = 0; l < j; l++)
            {
                if ((rand1 >= wheel[l]) && (rand1 <= wheel[l + 1]))
                {
                    select = l;
                }
            }
            return D[select];
        }//The end of function
         //////////////////////////////Rebuilt///////////////////////////////////////////
        public static void Assign(int i, int position, int st, int[,] Seed, float[,] StFi, float[] Ttime
                , int[,] As, float[,] StCom, int[] Tdirectionno, int[,] Tdirection, int[,] Pre, int[] NPre)
        {

            float delay;
            Seed[0, i] = position;
            Seed[1, i] = st;//task's side
            StFi[0, i] = starttime1(i, position, st, Seed, StFi, Tdirectionno, Tdirection, StCom, Pre, NPre);
            StFi[1, i] = StFi[0, i] + Ttime[i];
            delay = StFi[0, i] - StCom[position, st];
            StCom[position, st] += (delay + Ttime[i]);
            for (int j = 0; j < job; j++)
                As[i, j] = 0;
        }
        public static void Assign1(int i, int position, int st, int[,] Seed, float[,] StFi, float[] Ttime
                , int[,] As, float[,] StCom, int[] Tdirectionno, int[,] Tdirection, int[,] Pre, int[] NPre)
        {
            int loadno;
            float delay;
            StFi[0, i] = starttime1(i, position, st, Seed, StFi, Tdirectionno, Tdirection, StCom, Pre, NPre);
            StFi[1, i] = StFi[0, i] + Ttime[i];
            delay = StFi[0, i] - StCom[position, st];
            StCom[position, st] += (delay + Ttime[i]);
            for (int j = 0; j < job; j++)
                As[i, j] = 0;
        }
        //////////////////////////////End rebuilt///////////////////////////////////////
        /////////////////////Neighborhood generation mechanisms
        public static void availmove(int i1, int[] pos, int[,] Astar, int[,] Seed)
        {//this function finds the positions that each task can be transfer to    
         //int NS=0;                  need reference 
         //for(int i=0;i<job;i++)
         //if(NS<tasks[i].position)
         //NS=tasks[i].position;
            int prepos = 0;
            int sucpos = (NbSt - 1);
            for (int j = 0; j < job; j++)
            {
                if (Astar[j, i1] == 1)
                    if (prepos < Seed[0, j])
                        prepos = Seed[0, j];
                if (Astar[i1, j] == 1)
                    if (sucpos > Seed[0, j])
                        sucpos = Seed[0, j];
            }
            pos[0] = prepos;
            pos[1] = sucpos;
        }
        public static int precheck(int tsk1, int tsk2, int[,] Astar)
        {//This function checks if two tasks have precednece relation or not.
            if ((Astar[tsk1, tsk2] == 0) && (Astar[tsk2, tsk1] == 0))
                return 1;
            else
                return 0;
        }
        /////
        public static int Swap1(int[,] CSeed, int[,] NSeed, int[,] A, int[,] Astar, int[] Tdirectionno, int[,] Tdirection)
        {
            int[] js = new int[2]; int[] jj = new int[2];
            int i1, i2, i11, i21, i12, i22, prep = -1, pres = -1, prep1 = -1, pres1 = -1;
            int[] pos = new int[2];
            int[] pos1 = new int[2];
            int[] pretsk = new int[job];
            int kkk = 0;
            //do{
            Random rand = new Random();
            //Console.WriteLine(rand.NextDouble());
            i1 = (int)(job * rand.NextDouble());
            if (i1 > job)
            {
                i1 = (job - 1);
            }
            if (i1 < 0)
            {
                i1 = 0;
            }
            availmove(i1, pos, Astar, CSeed);
            prep = pos[0];
            pres = pos[1];
            kkk = 0;
            for (int iii = 0; iii < job; iii++)
                if ((precheck(i1, iii, Astar) == 1) && (i1 != iii))
                {
                    availmove(iii, pos1, Astar, CSeed);
                    prep1 = pos1[0];
                    pres1 = pos1[1];
                    if (CSeed[0, i1] < CSeed[0, iii])
                        if ((prep1 <= CSeed[0, i1]) && (pres >= CSeed[0, iii]))
                        {
                            pretsk[kkk] = iii;
                            kkk++;
                        }
                    if (CSeed[0, i1] > CSeed[0, iii])
                        if ((prep <= CSeed[0, iii]) && (pres1 >= CSeed[0, i1]))
                        {
                            pretsk[kkk] = iii;
                            kkk++;
                        }
                }
            if (kkk > 0)
            {
                int i222 = (int)((kkk) * rand.NextDouble());
                if (i222 >= kkk)
                    i222--;
                if (i222 < 0)
                    i222 = 0;
                i2 = pretsk[i222];
                for (int j = 0; j < job; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        NSeed[k, j] = CSeed[k, j];
                    }
                }
                i11 = CSeed[0, i1];
                i21 = CSeed[0, i2];
                i12 = CSeed[1, i1];
                i22 = CSeed[1, i2];
                jj[0] = i1;
                jj[1] = i2;
                if ((inDirection(i1, i22, Tdirectionno, Tdirection) == 1) && (inDirection(i2, i12, Tdirectionno, Tdirection) == 1))
                {
                    NSeed[0, i1] = i21;
                    NSeed[0, i2] = i11;
                    NSeed[1, i1] = i22;
                    NSeed[1, i2] = i12;
                    js[0] = NSeed[0, i1];
                    js[1] = NSeed[0, i2];
                    return 1;
                }
                else
                {
                    NSeed[0, i1] = i21;
                    NSeed[0, i2] = i11;
                    js[0] = NSeed[0, i1];
                    js[1] = NSeed[0, i2];
                    // Console.WriteLine("here" + 1);
                    return 1;

                }
            }
            else
            {
                //Console.WriteLine("here" + 0);
                return 0;
            }
            //}while(kkk==0);
        }
        /////
        public static int Swap2(int[,] CSeed, int[,] NSeed, int[,] A, int[,] Astar, int[] Tdirectionno, int[,] Tdirection)
        { //need reference
            int[] js = new int[2]; int[] jj = new int[2];
            int i1, i2, i1_1, i2_1, i1_2, i2_2, i1_3, i2_3, prep = -1, pres = -1, prep1 = -1, pres1 = -1;
            int[] pos = new int[2];
            int[] pos1 = new int[2];
            int[] pretsk = new int[job];
            int kkk = 0;
            //do{
            Random rand = new Random();
            i1 = (int)(job * rand.NextDouble());
            if (i1 > job)
            {
                i1 = (job - 1);
            }
            if (i1 < 0)
            {
                i1 = 0;
            }
            availmove(i1, pos, Astar, CSeed);
            prep = pos[0];
            pres = pos[1];
            kkk = 0;
            for (int iii = 0; iii < job; iii++)
                if ((precheck(i1, iii, Astar) == 1) && (i1 != iii))
                {
                    availmove(iii, pos1, A, CSeed);
                    prep1 = pos1[0];
                    pres1 = pos1[1];
                    if (CSeed[0, i1] < CSeed[0, iii])
                        if ((prep1 <= CSeed[0, i1]) && (pres >= CSeed[0, iii]))
                        {
                            pretsk[kkk] = iii;
                            kkk++;
                        }
                    if (CSeed[0, i1] > CSeed[0, iii])
                        if ((prep <= CSeed[0, iii]) && (pres1 >= CSeed[0, i1]))
                        {
                            pretsk[kkk] = iii;
                            kkk++;
                        }
                }
            if (kkk > 0)
            {
                int i222 = (int)((kkk) * rand.NextDouble());
                if (i222 >= kkk)
                    i222--;
                if (i222 < 0)
                    i222 = 0;
                i2 = pretsk[i222];
                for (int j = 0; j < job; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        NSeed[k, j] = CSeed[k, j];
                    }
                }
                i1_1 = CSeed[0, i1];
                i2_1 = CSeed[0, i2];
                i1_2 = CSeed[1, i1];
                i2_2 = CSeed[1, i2];
                i1_3 = CSeed[2, i1];
                i2_3 = CSeed[2, i2];
                jj[0] = i1;
                jj[1] = i2;
                if ((inDirection(i1, i2_2, Tdirectionno, Tdirection) == 1) && (inDirection(i2, i1_2, Tdirectionno, Tdirection) == 1))
                {
                    NSeed[0, i1] = i2_1;
                    NSeed[0, i2] = i1_1;
                    NSeed[1, i1] = i2_2;
                    NSeed[1, i2] = i1_2;
                    NSeed[2, i1] = i2_3;
                    NSeed[2, i2] = i1_3;
                    js[0] = NSeed[0, i1];
                    js[1] = NSeed[0, i2];
                }
                else
                {
                    NSeed[0, i1] = i2_1;
                    NSeed[0, i2] = i1_1;
                    NSeed[2, i1] = i2_3;
                    NSeed[2, i2] = i1_3;
                    js[0] = NSeed[0, i1];
                    js[1] = NSeed[0, i2];
                }
                return 1;
            }
            else
                return 0;
            //}while(kkk==0);
        }
        /////
        public static int MutationW(int[,] CSeed, int[,] NSeed, int[,] Astar)
        {//need call by reference 
            int[] js = new int[2]; int[] jj = new int[2];
            int i1, i, prep = -1, sucp = -1, iposition = -1, j = -1;
            int[] pos = new int[2];
            int swi = 0;
            //do{
            Random rand = new Random();
            i1 = (int)(job * rand.NextDouble());
            if (i1 == job)
                i1 = job - 1;
            for (int j1 = 0; j1 < job; j1++)
            {
                for (int k = 0; k < 3; k++)
                {
                    NSeed[k, j1] = CSeed[k, j1];
                }
            }
            availmove(i1, pos, Astar, CSeed);
            prep = pos[0];
            sucp = pos[1];
            iposition = NSeed[0, i1];
            if ((iposition == prep) && (iposition < sucp))
            {
                j = (int)((rand.NextDouble() * ((sucp + 1) - iposition)) + iposition);
                if (j == iposition)
                    j++;
                swi++;
            }
            if ((iposition > prep) && (iposition == sucp))
            {
                j = (int)((rand.NextDouble() * ((iposition + 1) - prep)) + prep);
                if (j == iposition)
                    j--; swi++;
            }
            if ((iposition > prep) && (iposition < sucp))
            {
                do
                {
                    j = (int)((rand.NextDouble() * ((sucp + 1) - prep)) + prep);
                    swi++;
                } while (j == iposition);
            }
            //}while((iposition==prep)&&(iposition==sucp));
            if (swi > 0)
            {
                NSeed[0, i1] = j;
                js[0] = NSeed[0, i1];
                js[1] = CSeed[0, i1];
                jj[0] = i1;
                return 1;
            }
            else
                return 0;
        }
        /////
        public static void SwapP(int[,] CSeed, int[,] NSeed)
        {//Swap Priority 
            int i1 = -1, i2 = -1, temp;
            Random rand = new Random();
            i1 = (int)(job * rand.NextDouble());
            if (i1 > job)
            {
                i1 = (job - 1);
            }
            if (i1 < 0)
            {
                i1 = 0;
            }
            do
            {
                i2 = (int)(job * rand.NextDouble());
                if (i2 > job)
                {
                    i2 = (job - 1);
                }
                if (i2 < 0)
                {
                    i2 = 0;
                }
            } while (i1 == i2);
            for (int i = 0; i < job; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    NSeed[j, i] = CSeed[j, i];
                }
            }
            temp = NSeed[2, i1];
            NSeed[2, i1] = NSeed[2, i2];
            NSeed[2, i2] = temp;
        }
        public static void ShiftP(int[,] CSeed, int[,] NSeed)
        {//Shift Priority 
            int i1 = -1, i2 = -1, temp;
            Random rand = new Random();
            i1 = (int)(job * rand.NextDouble());
            if (i1 > job)
            {
                i1 = (job - 1);
            }
            if (i1 < 0)
            {
                i1 = 0;
            }
            do
            {
                i2 = (int)(job * rand.NextDouble());
                if (i2 > job)
                {
                    i2 = (job - 1);
                }
                if (i2 < 0)
                {
                    i2 = 0;
                }
            } while (i1 == i2);
            if (i1 > i2)
            {
                temp = i1;
                i1 = i2;
                i2 = temp;
            }
            for (int i = 0; i < job; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    NSeed[j, i] = CSeed[j, i];
                }
            }
            temp = NSeed[2, i2];
            for (int i = i1; i < i2; i++)
            {
                NSeed[2, i + 1] = CSeed[2, i];
            }
            NSeed[2, i1] = temp;
        }
        public static int MutationE(int[,] CSeed, int[,] NSeed, int[] Tdirectionno, int[,] Tdirection)
        {
            int[] List = new int[job];
            int[] ListS = new int[mside];
            int ListSno = 0;
            int Listno = 0;
            int ret = 0;
            int select;
            int Tselect = -1;
            int Wselect = -1;
            for (int j = 0; j < job; j++)
            {
                List[j] = -1;
            }
            for (int j = 0; j < mside; j++)
            {
                ListS[j] = -1;
            }
            for (int j = 0; j < job; j++)
            {
                if (Tdirectionno[j] > 1)
                {
                    List[Listno] = j;
                    Listno++;
                }
            }
            if (Listno == 0)
            {
                ret = 0;
            }
            else
            {
                Random rand = new Random();
                select = (int)(Listno * rand.NextDouble());
                if (select == Listno)
                {
                    select--;
                }
                Tselect = List[select];

                for (int i = 0; i < job; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        NSeed[j, i] = CSeed[j, i];
                    }
                }
                for (int ii1 = 0; ii1 < Tdirectionno[Tselect]; ii1++)
                {
                    if ((Tdirection[Tselect, ii1] - 1) != NSeed[1, Tselect])
                    {
                        ListS[ListSno] = (Tdirection[Tselect, ii1] - 1);
                        ListSno++;
                    }
                }
                select = (int)(ListSno * rand.NextDouble());
                if ((select == ListSno) && (ListSno != 0))
                {
                    select--;

                }
                Wselect = ListS[select];
                NSeed[1, Tselect] = Wselect;
            }
            return ret;
        }
        public static void NeighborGeneration(int[,] CSeed, int[,] NSeed, int Number,
                int[,] A, int[,] Astar, int[] Tdirectionno, int[,] Tdirection)
        {
            switch (Number)
            //switch (5)
            {
                case 1:
                    MutationW(CSeed, NSeed, Astar);
                    break;
                case 2:
                    SwapP(CSeed, NSeed);
                    break;
                case 3:
                    //MutationE(CSeed, NSeed, Tdirectionno, Tdirection);
                    MutationW(CSeed, NSeed, Astar);
                    break;
                case 4:
                    //Swap2(CSeed, NSeed, A, Astar, Tdirectionno, Tdirection);
                    SwapP(CSeed, NSeed);
                    break;
                case 5:
                    //Swap1(CSeed, NSeed, A, Astar, Tdirectionno, Tdirection);
                    MutationW(CSeed, NSeed, Astar);
                    break;
                case 6:
                    ShiftP(CSeed, NSeed);
                    //SwapP(CSeed, NSeed);
                    break;
            }
        }
        /////////////////////////////////////////////////Rebulit/////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static int available2(int[] F, int position, int[] Atasks, int Notsk, int[,] As, float[,] StFi)
        {
            int i;
            int k = 0;
            for (i = 0; i < Notsk; i++)
                if ((iis(Atasks[i], As) == 1) && (StFi[1, Atasks[i]] <= 0.0))
                {// 1
                    F[k] = Atasks[i];
                    k++;
                }
            return k;
        }//The end of available function
        public static int determinetask2(int position, int[] Atasks, int Notasks, float[,] StFi, int[,] As, int[,] Seed)
        {
            int[] F = new int[job];//F is the array that keeps the id of available tasks
            int k = 0, i, j = 0;//k keeps the number of  available tasks
            int ret = -1;
            int min;
            k = available2(F, position, Atasks, Notasks, As, StFi);
            if (k == 0)
                ret = -1;
            if (k == 1)
            {
                ret = (F[0]);
            }
            if (k > 1)
            {//1
                min = Seed[2, F[0]];
                j = F[0];
                for (i = 0; i < k; i++)
                    if (Seed[2, F[i]] < min)
                    {
                        min = Seed[2, F[i]];
                        j = F[i];
                    }
                ret = j;
            }//1
            return ret;
        }// The end of determinetask2 function
         /////////////////////////////////////////////////////////////////////
        public static float CalObj(int[,] Seed, float[,] StFi, float[,] StCom, int[,] A,
                int[] Tdirectionno, int[,] Tdirection, int[,] Pre, int[] NPre, float[] Ttime, int[] Station)
        {
            float objective = 100000;
            int f1 = -1;
            int station;
            int[,] As = new int[job, job];
            for (int i = 0; i < job; i++)
            {
                StFi[0, i] = 0;
                StFi[1, i] = 0;
            }
            for (int j = 0; j < NbSt; j++)
            {
                for (int k = 0; k < mside; k++)
                {
                    StCom[j, k] = 0;
                }
            }
            int nk = 0;
            for (int i1 = 0; i1 < job; i1++)
                for (int j1 = 0; j1 < job; j1++)
                    As[i1, j1] = A[i1, j1];
            int position = 0;
            for (position = 0; position < NbSt; position++)
            {//main for
                int[] Atasks = new int[job];
                int lll = 0; //0:js1,1:js2
                for (int i = 0; i < job; i++)
                    if (Seed[0, i] == position)
                    {
                        Atasks[lll] = i;
                        lll++;
                    }
                //*******************************************************************
                int h = lll;
                if (lll == 0)
                {
                    for (int k = 0; k < mside; k++)
                    {
                        StCom[position, k] = 0;
                    }
                }
                else
                {
                    while (lll >= 0)
                    {
                        f1 = determinetask2(position, Atasks, h, StFi, As, Seed);
                        if (f1 == -1)
                        {
                            //position++;
                            nk = 0;
                            if (lll == 0)
                                lll = -2;
                        }//if
                        else
                        {//e1:there is a task for assignment
                         //System.out.println(" Assign1  ");
                            int st1 = Seed[1, f1];
                            //if(Seed[1][f1]==0){//1

                            Assign1(f1, position, st1, Seed, StFi, Ttime, As, StCom, Tdirectionno, Tdirection, Pre, NPre);
                            lll--;
                            nk++;
                            //	}//The end of if number 1
                            //else{//The Else of if number 1
                            //	Assign1(f1, position, 1, Seed, StFi, Ttime, As, StCom, Tdirectionno,Tdirection, Pre, NPre);
                            //	lll--;
                            //	nk++;
                            //	}//The end of Else of if number 1
                        }//The End of if 1
                    }
                }//else
                 //*******************************************************************
            }///End of For
            objective = 0;
            station = 0;
            for (int j1 = 0; j1 < NbSt; j1++)
            {
                for (int k1 = 0; k1 < mside; k1++)
                {
                    if (StCom[j1, k1] > objective)
                    {
                        objective = StCom[j1, k1];
                    }
                    if (StCom[j1, k1] > 0)
                    {
                        station++;
                    }
                }
            }
            Station[0] = station;
            return objective;
        }
        public static int Nselect(double[] weight)
        {
            int Number = 0;
            double[] w = new double[7];
            w[0] = 0;
            for (int i = 0; i < 6; i++)
            {
                w[i + 1] = w[i] + weight[i];
            }
            Random rand1 = new Random();
            double rand = rand1.NextDouble() * w[6];
            for (int i = 0; i < 6; i++)
            {
                if ((w[i] <= rand) && (rand <= w[i + 1]))
                {
                    Number = (i + 1);
                }
            }
            return Number;
        }
        ////////////////////////////////////Main Function/////////////////////////////////////////////////
        public  void Main1()//String[] args
        {
            f3 = new Form3();
           // f11 = new UserControl1();
            //////////////////////////ورود داده ها/////////////////////////////////
            //  checkinput();

            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            //using (FileStream fs = File.OpenRead("E:\\Assembly_P_2.xls")) ;
            //    File ff = new File("E:\\Assembly_P_2.xls");
            int sheetno = 0;
            int Nbsheet = 1;
            //  Excel.Application xlApp = new Excel.Application();
            //  Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"E:\\Assembly_P_2.xls");
            //Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            //Excel.Range xlRange = xlWorksheet.UsedRange;
            //    Excel._Worksheet[] xlWorksheet = new Excel._Worksheet[Nbsheet];
            //    for (int i1 = 1; i1 <= Nbsheet; i1++)
            //    {
            //       xlWorksheet[i1 - 1] = xlWorkbook.Sheets[i1];
            //  }
            //   for (sheetno = 1; sheetno < 2; sheetno++)
            // {//Sheet
            ///   Excel.Range xlRange = xlWorksheet[sheetno - 1].UsedRange;

            job = Form3.numoftasks;//تعداد کارها به عنوان ورودی
                NbSt = Form3.numofstations;//تعداد ایستگاه ها به عنوان ورودی

                int[,] A = new int[job, job];//Precedence matrix
                int[,] Astar = new int[job, job];//Precedence Star matrix
                int[,] As = new int[job, job];
                //int[][] As1=new int[job][job];
                float[] Ttime = new float[job];//Task times
                float[] Ctime = new float[job];//Maximum Compression time
                float[] Trank = new float[job];//Task's ranked positional weight 
                int[] Tdirectionno = new int[job];
                int[,] Tdirection = new int[job, mside];
                int i = 0, j = 0, n;


                int[] NSuc = new int[job];//Number of Successors 
                int[,] Suc = new int[job, ma];//Successors
                int[] NPre = new int[job];//Number of predecessors 
                int[,] Pre = new int[job, ma];//Predecessors
                int Istation = 0;
                n = job;
                for (i = 0; i < n; i++)
                    for (j = 0; j < n; j++)
                    {

                        A[i, j] = 0;
                        Astar[i, j] = 0;
                        As[i, j] = 0;
                        //As1[i][j]=0;
                    }
                float cp = 0, ci = 0, cc = 0, sc = 0;
                int l = 1;
                for (int j1 = 2; j1 <= job + 1; j1++)
                {
              
                    Ttime[j1 - 2] = Tasks[j1 - 2].tasktime;//زمان کارها به عنوان ورودی
                    //Console.WriteLine(Ttime[j1 - 2]);
                    l++;
                }
                l = 1;
                for (int j1 = 2; j1 <= job + 1; j1++)
                {
                  //  Ctime[j1 - 2] = float.Parse(xlRange.Cells[j1, 4].Value2.ToString());//این ورودی رو در برنامه نمی خوایم
                    l++;
                }
                l = 1;
                for (int j1 = 2; j1 <= job + 1; j1++)
                {
                    NSuc[j1 - 2] = Tasks[j1 - 2].numofsuc;//تعداد successor ها به عنوان ورودی
                    l++;
                }
                int sumsuc = 0;
                for (int j1 = 0; j1 < job; j1++)
                {
                    sumsuc += NSuc[j1];
                }
                l = 1;
                for (int j1 = 2; j1 <= job + 1; j1++)
                    for (int l1 = 0; l1 < NSuc[j1 - 2]; l1++)
                    {
                        Suc[j1 - 2, l1] = Tasks[j1 - 2].successors[l1];//ورود successor ها
                        l++;
                    }
                l = 1;
                for (int j1 = 2; j1 <= job + 1; j1++)
                {
                    Tdirectionno[j1 - 2] = Tasks[j1 - 2].sides.Length;//تعداد ساید ها برای هر کار
                    l++;
                }
                l = 1;
                for (int j1 = 2; j1 <= job + 1; j1++)
                {
                    for (int l1 = 0; l1 < Tdirectionno[j1 - 2]; l1++)
                    {
                        Tdirection[j1 - 2, l1] = Tasks[j1 - 2].sides[l1];//ساید ها برای هر کار
                        l++;
                    }
                }
                ////////////////////////به این ورودی ها نیاز نداریم
            //    cp = float.Parse(xlRange.Cells[2, 9].Value2.ToString());
              //  ci = float.Parse(xlRange.Cells[2, 10].Value2.ToString());
                //cc = float.Parse(xlRange.Cells[2, 11].Value2.ToString());
                //sc = float.Parse(xlRange.Cells[2, 12].Value2.ToString());
                //////////////////////////////////////////////////////////////////
                for (i = 0; i < job; i++)
                    for (j = 0; j < NSuc[i]; j++)
                        A[i, (Suc[i, j]-1)] = 1;
                for (i = 0; i < n; i++)
                    for (j = 0; j < n; j++)
                        if (A[j, i] == 1)
                        {
                            Pre[i, NPre[i]] = j;
                            NPre[i]++;
                        }

                precedence(A, Astar);

                rpw(Ttime, Trank, Astar);
                /*for(i=0;i<n;i++){
                    for(j=0;j<n;j++){
                        System.out.print(A[i][j]+" ");
                    }
                    System.out.println();
                }*/
                for (i = 0; i < n; i++)
                    for (j = 0; j < n; j++)
                        As[i, j] = A[i, j];
                //for(i=0;i<n;i++)
                //	for(j=0;j<n;j++)
                //		As1[i][j]=A[i][j];
                int[,] Seed = new int[4, job];//Seed[0][]:Mated station;Seed[1][]:Side;Seed[2][]:Priority;Seed[3][]:Speed
                int[,] ISeed = new int[4, job];//best initial seed
                int[,] CSeed = new int[4, job];// Current Solution Seed
                int[,] NSeed = new int[4, job];// Neighbor Seed
                int[,] NNSeed = new int[4, job];// Neighbor of Neighbor Seed
                int[,] BSeed = new int[4, job];//Best Solution Seed
                float[,] StFi = new float[2, job];//the first row is the start time and the second row is the finish time
                float[,] IStFi = new float[2, job];
                float[,] CStFi = new float[2, job];
                float[,] NStFi = new float[2, job];
                float[,] NNStFi = new float[2, job];
                float[,] BStFi = new float[2, job];
                float[,] StCom = new float[NbSt, mside];//Robot completion time
                float[,] IStCom = new float[NbSt, mside];
                float[,] NStCom = new float[NbSt, mside];
                float[,] NNStCom = new float[NbSt, mside];
                float[,] BStCom = new float[NbSt, mside];
                float[,] CStCom = new float[NbSt, mside];
                for (i = 0; i < job; i++)
                {
                    StFi[0, i] = 0;
                    StFi[1, i] = 0;
                }
                for (i = 0; i < job; i++)
                {
                    Seed[0, i] = -1;
                    Seed[1, i] = -1;
                    Seed[2, i] = i;
                }
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < job; j++)
                    {
                        ISeed[i, j] = Seed[i, j];
                        BSeed[i, j] = Seed[i, j];
                        CSeed[i, j] = Seed[i, j];
                        NSeed[i, j] = Seed[i, j];
                        NNSeed[i, j] = Seed[i, j];
                    }
                }
                for (i = 0; i < 2; i++)
                {
                    for (j = 0; j < job; j++)
                    {
                        IStFi[i, j] = StFi[i, j];
                        CStFi[i, j] = StFi[i, j];
                        BStFi[i, j] = StFi[i, j];
                        NStFi[i, j] = StFi[i, j];
                        NNStFi[i, j] = StFi[i, j];
                    }
                }
                for (j = 0; j < NbSt; j++)
                {
                    for (int k = 0; k < mside; k++)
                    {
                        StCom[j, k] = 0;
                        IStCom[j, k] = 0;
                        CStCom[j, k] = 0;
                        BStCom[j, k] = 0;
                        NStCom[j, k] = 0;
                        NNStCom[j, k] = 0;
                    }
                }
                float objective = 1000000;
                float Iobjective = 1000000;
                float tsum_comp = 0;
                for (i = 0; i < job; i++)
                    tsum_comp += (Ttime[i]);
                float LCT_comp = (float)Math.Ceiling(tsum_comp / (NbSt * mside));
                //System.out.println("LCT_comp="+LCT_comp);
                //////Calculating the lower bound//////
                float tsum = 0;
                for (i = 0; i < job; i++)
                    tsum += Ttime[i];
                int LCT = (int)Math.Ceiling(tsum / (NbSt * mside));
                for (i = 0; i < job; i++)
                    if (LCT < Ttime[i])

                        LCT = (int)Ttime[i];
                double UB;
                UB = (float)Math.Ceiling(tsum / LCT);
                //////Building an Initial Solution
                n = job;
                ct = (int)LCT;
                double uub = ((LCT * UB - tsum) / UB);
                int position;
                int nk = 0, f1;
                int[] D = new int[mside];
                position = 0;
                float[,] timesum = new float[NbSt, mside];
                int[] priority = new int[job];
                float gamma = (float)1.0;
                float gamma_max = (float)2.2;
                float gamma_inc = (float)0.02;
                stopwatch.Start();
                float Ict = 0;
                int station = 0;
                while (gamma <= gamma_max)
                {
                    ////
                    for (int j1 = 0; j1 < NbSt; j1++)
                    {
                        for (int l1 = 0; l1 < mside; l1++)
                        {
                            timesum[j1, l1] = 0;
                        }
                    }
                    for (int i2 = 0; i2 < job; i2++)
                    {
                        Seed[0, i2] = -1;
                        Seed[1, i2] = -1;
                        Seed[2, i2] = i2;
                    }
                    for (i = 0; i < job; i++)
                    {
                        StFi[0, i] = 0;
                        StFi[1, i] = 0;
                    }
                    for (j = 0; j < NbSt; j++)
                    {
                        for (int k = 0; k < mside; k++)
                        {
                            StCom[j, k] = 0;
                        }
                    }
                    n = job;
                    nk = 0;
                    position = 0;
                    for (int i1 = 0; i1 < job; i1++)
                        for (int j1 = 0; j1 < job; j1++)
                            As[i1, j1] = A[i1, j1];
                    while (n >= 0)
                    {//#1
                     //System.out.println("n="+n);
                        float Lct = (gamma * LCT);
                        f1 = determinetask(position, Seed, Trank, As, timesum, Ttime, Lct, Tdirectionno, Tdirection, StFi, StCom, Pre, NPre);
                        //if((f1==-1)||(((timesum[position][1]+Ttime[f1])>(LCT_comp*gamma))&&((timesum[position][0]+Ttime[f1])>(LCT_comp*gamma))&&(position<NbSt-1))){
                        if (f1 == -1)
                        {
                            position++;
                            nk = 0;
                            if (n == 0)
                                n = -2;
                        }//if
                        else
                        {
                            j = 0;
                            for (i = 0; i < mside; i++)
                                D[i] = -1;
                            j = find(f1, position, D, Tdirectionno, Tdirection, timesum, Ttime, Lct, StCom, Seed, StFi, Pre, NPre);
                            //System.out.println("j="+j);
                            //for(i=0;i<mside;i++)
                            //	System.out.println("D ="+D[i]);
                            if (j == 1)
                            {//1
                             //System.out.println(position);
                             //System.out.println("assign_1");
                                Assign(f1, position, D[0], Seed, StFi, Ttime, As, StCom, Tdirectionno, Tdirection, Pre, NPre);
                                timesum[position, D[0]] += Ttime[f1];
                                n--;
                                nk++;
                            }//The end of if number 1
                            if (j > 1)
                            {//The Else of if number 1
                             //System.out.println("assign>1");
                                int s1 = 0;
                                s1 = determineside(D, position, j);

                                Assign(f1, position, s1, Seed, StFi, Ttime, As, StCom, Tdirectionno, Tdirection, Pre, NPre);
                                timesum[position, s1] += Ttime[f1];
                                n--;
                                nk++;
                                //  }//**
                            }//The end of Else of if number 1
                        }
                    }//End of While#1
                     /*System.out.println(" gamma =  "+gamma);
                     System.out.println(" tsum  ");
                     for(i=0;i<NbSt;i++){
                         for(int k=0;k<mside;k++){
                             System.out.print(timesum[i][k]+"  ");
                         }
                     }
                     System.out.println("   ");
                     for(i=0;i<job;i++){
                         System.out.print(Seed[0][i]+"  ");
                     }
                     System.out.println("   ");
                     for(i=0;i<job;i++){
                         System.out.print(Seed[1][i]+"  ");
                     }
                     System.out.println("   ");
                     for(i=0;i<job;i++){
                         System.out.print(Seed[2][i]+"  ");
                     }
                     System.out.println("   ");*/
                    objective = 0;
                    ct = 0;
                    station = 0;
                    for (int j1 = 0; j1 < NbSt; j1++)
                    {
                        for (int k1 = 0; k1 < mside; k1++)
                        {
                            if (StCom[j1, k1] > ct)
                            {
                                ct = StCom[j1, k1];
                            }
                            if (StCom[j1, k1] > 0)
                            {
                                station++;
                            }
                        }
                    }
                    objective = (float)(ct + ((1.0 / (NbSt * mside + 1)) * station));


                    ////
                    if (objective < Iobjective)
                    {
                        Iobjective = objective;
                        Ict = ct;
                        Istation = station;
                        for (i = 0; i < 3; i++)
                        {
                            for (j = 0; j < job; j++)
                            {
                                ISeed[i, j] = Seed[i, j];
                                BSeed[i, j] = Seed[i, j];
                                CSeed[i, j] = Seed[i, j];
                                NSeed[i, j] = Seed[i, j];
                                NNSeed[i, j] = Seed[i, j];
                            }
                        }
                        for (int k = 0; k < 2; k++)
                        {
                            for (i = 0; i < job; i++)
                            {
                                IStFi[k, i] = StFi[k, i];
                                BStFi[k, i] = StFi[k, i];
                                CStFi[k, i] = StFi[k, i];
                                NStFi[k, i] = StFi[k, i];
                                NNStFi[k, i] = StFi[k, i];
                            }
                        }
                        for (j = 0; j < NbSt; j++)
                        {
                            for (int k = 0; k < mside; k++)
                            {
                                IStCom[j, k] = StCom[j, k];
                                BStCom[j, k] = StCom[j, k];
                                CStCom[j, k] = StCom[j, k];
                                NStCom[j, k] = StCom[j, k];
                                NNStCom[j, k] = StCom[j, k];
                            }
                        }
                    }
                    gamma = gamma + gamma_inc;
                }
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < job; j++)
                    {
                        Seed[i, j] = ISeed[i, j];
                    }
                }
                // System.out.println("=============Station completion===================");
                /* for (j = 0; j < NbSt; j++)
                 {
                     System.out.println("   ");
                     for (int k = 0; k < mside; k++)
                     {
                         System.out.print(IStCom[j][k] + "  ");
                     }
                 }
                 System.out.println("   ");
                 System.out.println("================================");
                 System.out.println("Iobjective=" + (Iobjective));
                 System.out.println("initial ct=" + (Ict));
                 System.out.println("initial station=" + (Istation));
                 for (i = 0; i < job; i++)
                 {
                     System.out.print((ISeed[0][i] + 1) + "  ");
                 }
                 System.out.println("   ");
                 for (i = 0; i < job; i++)
                 {
                     System.out.print((ISeed[1][i] + 1) + "  ");
                 }
                 System.out.println("   ");
                 for (i = 0; i < job; i++)
                 {
                     System.out.print((ISeed[2][i] + 1) + "  ");
                 }
                 System.out.println("   ");*/
                //////////////////////////////
                ////////VNS Algorithm/////////
                //////////////////////////////
                double[] Nweight = new double[6];
                for (int i1 = 0; i1 < 6; i1++)
                {
                    Nweight[i1] = 1;
                }
                float bobjective = Iobjective;
                float cobjective = Iobjective;
                float nobjective = Iobjective;
                float nnobjective = Iobjective;
                float Bct = Ict;
                float Cct = Ict;
                float Nct = Ict;
                float NNct = Ict;
                //float DeltaF = 100000;
                int bstation = Istation;
                int cstation = Istation;
                int nstation = Istation;
                int nnstation = Istation;
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < job; j++)
                    {
                        BSeed[i, j] = ISeed[i, j];
                        CSeed[i, j] = ISeed[i, j];
                        NSeed[i, j] = ISeed[i, j];
                        NNSeed[i, j] = ISeed[i, j];
                    }
                }
                for (int k = 0; k < 2; k++)
                {
                    for (i = 0; i < job; i++)
                    {
                        CStFi[k, i] = IStFi[k, i];
                        BStFi[k, i] = IStFi[k, i];
                        NStFi[k, i] = IStFi[k, i];
                        NNStFi[k, i] = IStFi[k, i];
                    }
                }
                for (j = 0; j < NbSt; j++)
                {
                    for (int k = 0; k < mside; k++)
                    {
                        CStCom[j, k] = IStCom[j, k];
                        BStCom[j, k] = IStCom[j, k];
                        NStCom[j, k] = IStCom[j, k];
                        NNStCom[j, k] = IStCom[j, k];
                    }
                }
                int MaxNumIter = 4;
                int MaxIntIter = 120;
                int Num_Iter = 1;
                int Neigh_Iter = 1;
                int Num_neigh = 6;
                double T0 = 3 * bobjective;
                double Tf = 0.1;
                double Tc = T0;
                double landa = 0.8;
                int num_sol = 0;
                int num_imp = 0;
                int[] Station = new int[1];
                /////////// Main body of VNS algorithm //////////////////////////
                int selection = 0;


                //while((Num_Iter<MaxNumIter)&&(bobjective>LCT)){//Main While
                while ((Num_Iter < MaxNumIter))
                {//Main While
                    Neigh_Iter = 1;
                    Tc = (1.0 / Num_Iter) * T0;
                 //   Console.WriteLine("Num_Iter=" + Num_Iter);
                    //while(Neigh_Iter<=Num_neigh){
                    //System.out.println("Neigh_Iter="+Neigh_Iter);
                    //while((Tc>=Tf)&&(Neigh_Iter<=Num_neigh)){
                    while ((Tc >= Tf) && (num_sol <= 4000000))
                    {
                       // Console.WriteLine("Tc=" + Tc);
                        selection = Nselect(Nweight);
                        //NeighborGeneration(CSeed, NSeed, selection, A, Astar, Tdirection);
                        NeighborGeneration(CSeed, NSeed, selection, A, Astar, Tdirectionno, Tdirection);
                        nobjective = CalObj(NSeed, NStFi, NStCom, A, Tdirectionno, Tdirection, Pre, NPre, Ttime, Station);
                        Nct = nobjective;
                        nstation = Station[0];
                        nobjective = (float)(Nct + ((1.0 / (NbSt * mside + 1)) * nstation));
                        //System.out.println("nobjective="+nobjective);
                        //////////////////////////////Local search for priority ////////////////////
                        int[,] BNSeed = new int[3, job];//Best Internal Solution Seed
                        float[,] BNStFi = new float[2, job];
                        float[,] BNStCom = new float[NbSt, mside];
                        for (i = 0; i < 3; i++)
                        {
                            for (j = 0; j < job; j++)
                            {
                                BNSeed[i, j] = NSeed[i, j];
                            }
                        }
                        float BNobjective = nobjective;
                        float BNct = Nct;
                        int BNstation = nstation;
                        for (int k = 0; k < 2; k++)
                        {
                            for (i = 0; i < job; i++)
                            {
                                BNStFi[k, i] = NStFi[k, i];
                            }
                        }
                        for (j = 0; j < NbSt; j++)
                        {
                            for (int k = 0; k < mside; k++)
                            {
                                BNStCom[j, k] = NStCom[j, k];
                            }
                        }
                        ///////Local search//////
                        int int_iter = 0;
                        while (int_iter < MaxIntIter)
                        {//Internal
                         //NeighborGeneration(NSeed, NNSeed, Neigh_Iter, A, Astar, Tdirection);
                         //selection = (int) (Math.random()*Num_neigh);
                         //selection = 3;
                         //selection++;
                            selection = Nselect(Nweight);

                            NeighborGeneration(NSeed, NNSeed, selection, A, Astar, Tdirectionno, Tdirection);
                            nnobjective = (float)CalObj(NNSeed, NNStFi, NNStCom, A, Tdirectionno, Tdirection, Pre, NPre, Ttime, Station); ;
                            //System.out.println("nnobjective="+nnobjective);
                            NNct = nnobjective;
                            nnstation = Station[0];
                            num_sol++;
                            nnobjective = (float)(NNct + ((1.0 / (NbSt * mside + 1)) * nnstation));
                            if (nnobjective <= BNobjective)
                            {
                                num_imp = 0;
                                for (i = 0; i < 3; i++)
                                {
                                    for (j = 0; j < job; j++)
                                    {
                                        BNSeed[i, j] = NNSeed[i, j];
                                    }
                                }
                                Nweight[selection - 1] += Nmove1;
                                BNobjective = nnobjective;
                                BNct = NNct;
                                BNstation = nnstation;
                                for (int k = 0; k < 2; k++)
                                {
                                    for (i = 0; i < job; i++)
                                    {
                                        BNStFi[k, i] = NNStFi[k, i];
                                    }
                                }
                                for (j = 0; j < NbSt; j++)
                                {
                                    for (int k = 0; k < mside; k++)
                                    {
                                        BNStCom[j, k] = NNStCom[j, k];
                                    }
                                }
                            }
                            else
                            {
                                int_iter = int_iter + 1;
                                num_imp++;
                            }
                        }//Internal While	
                         ///////MOve or Not
                         //System.out.println("bobjective="+bobjective);
                         //if(BNobjective<cobjective){//Current solution update
                        Random rand1 = new Random();
                        double rand = rand1.NextDouble();

                        if ((BNobjective <= cobjective) || (Math.Exp(-(BNobjective - cobjective) / Tc) > rand))
                        {//Current solution update
                         //if((BNobjective<cobjective)){//Current solution update
                            for (i = 0; i < 3; i++)
                            {
                                for (j = 0; j < job; j++)
                                {
                                    CSeed[i, j] = BNSeed[i, j];
                                }
                            }
                            cobjective = BNobjective;
                            Cct = BNct;
                            cstation = BNstation;
                            //System.out.println("Num_neigh="+Neigh_Iter);
                            for (int k = 0; k < 2; k++)
                            {
                                for (i = 0; i < job; i++)
                                {
                                    CStFi[k, i] = BNStFi[k, i];
                                }
                            }
                            for (j = 0; j < NbSt; j++)
                            {
                                for (int k = 0; k < mside; k++)
                                {
                                    CStCom[j, k] = BNStCom[j, k];
                                }
                            }
                            //Neigh_Iter = 1;
                        }
                        else
                        {
                            //Neigh_Iter = Neigh_Iter + 1;
                        }//Current solution 
                         //if(Neigh_Iter>Num_neigh)
                         //	Neigh_Iter = 1;
                        if (BNobjective < bobjective)
                        {///Best solution Update
                            Nweight[selection - 1] += Nmove;//update the weight of neighbors
                            for (i = 0; i < 3; i++)
                            {
                                for (j = 0; j < job; j++)
                                {
                                    BSeed[i, j] = BNSeed[i, j];
                                }
                            }
                            for (int k = 0; k < 2; k++)
                            {
                                for (i = 0; i < job; i++)
                                {
                                    BStFi[k, i] = BNStFi[k, i];
                                }
                            }
                            for (j = 0; j < NbSt; j++)
                            {
                                for (int k = 0; k < mside; k++)
                                {
                                    BStCom[j, k] = BNStCom[j, k];
                                }
                            }
                            bobjective = BNobjective;
                            Bct = BNct;
                            bstation = BNstation;
                        }//Best solution update
                        Tc = landa * Tc;
                        //System.out.println("Tc="+Tc);
                    }//End of while neighbor enumeration 
                    for (i = 0; i < 3; i++)
                    {
                        for (j = 0; j < job; j++)
                        {
                            CSeed[i, j] = BSeed[i, j];
                        }
                    }
                    cobjective = bobjective;
                    Cct = Bct;
                    cstation = bstation;
                    Num_Iter = Num_Iter + 1;
                }//End of Main while
            int ii = 0;
            //  f3.passto(job, BSeed, BStFi, Bct, bstation);
            u3.Update1(job, BSeed, BStFi, Bct, bstation);
//for (int i1 = 0; i1 < job; i1++)
//    {
//    f3.dataGridView1.Rows.Add();
//    //     dataGridView1.Rows[i].Cells[0].Value = values[0];
//    f3.dataGridView1.Rows[ii].Cells[1].Value = (BSeed[0, i1] + 1).ToString();
//    f3.userControl31.dataGridView1.Rows[ii].Cells[2].Value = (BSeed[1, i1] + 1).ToString();
//    f3.userControl31.dataGridView1.Rows[ii].Cells[3].Value = BStFi[0, i1].ToString();
//    f3.userControl31.dataGridView1.Rows[ii].Cells[4].Value = BStFi[1, i1].ToString();
//    // Console.Write((i1 + 1) + "  ");//اسم کارها که در فرم نمایش داده نمی شود
//    //  Console.Write((BSeed[0, i1] + 1) + "  ");///شماره ایستگاه تخصیص داده شده
//    //  Console.Write((BSeed[1, i1] + 1) + "  ");//شماره ساید تخصیص داده شده
////    Console.Write(BStFi[0, i1] + "  ");//زمان شروع و پایان به عنوان خروجی
//    //      Console.Write(BStFi[1, i1] + "  ");//زمان  پایان به عنوان خروجی
//    ii++;
//}
/*    Console.WriteLine();
    Console.WriteLine("================================");
    for (int i1 = 0; i1 < job; i1++)
    {
        Console.Write((BSeed[0, i1] + 1) + "  ");///شماره ایستگاه تخصیص داده شده
    }
    Console.WriteLine("   ");
    for (int i1 = 0; i1 < job; i1++)
    {
        Console.Write((BSeed[1, i1] + 1) + "  ");//شماره ساید تخصیص داده شده
    }
    Console.WriteLine("   ");
    for (int i1 = 0; i1 < job; i1++)
    {
        Console.Write((BSeed[2, i1] + 1) + "  ");// به این نیاز نیست
    }
    Console.WriteLine("   ");
    Console.WriteLine("================================");
    Console.WriteLine("=============Start finish===================");
    for (int k = 0; k < 2; k++)//k=0 زمان شروع k=1 زمان پایان
    {
        for (i = 0; i < job; i++)
        {
            Console.Write(BStFi[k, i] + "  ");//زمان شروع و پایان به عنوان خروجی
        }
        Console.WriteLine("   ");
    }
    Console.WriteLine("   ");
    Console.WriteLine("================================");
    Console.WriteLine("=============Station completion===================");
    for (j = 0; j < NbSt; j++)
    {
        Console.WriteLine("   ");
        for (int k = 0; k < mside; k++)
        {
            Console.Write(BStCom[j, k] + "  ");//نیاز نیست
        }
    }
    Console.WriteLine("   ");
    Console.WriteLine("================================");
    Console.WriteLine("=============objective===================");
    Console.WriteLine("Bobjective=" + (bobjective));
    */

            // f3.userControl31.textBox2.Text = Bct.ToString();
            //f3.userControl31.textBox3.Text = bstation.ToString();
            //  Console.WriteLine("Bct=" + (Bct));///خروجی زمان سیکل بهینه
            //  Console.WriteLine("Bstation=" + (bstation));//خروجی تعداد ایستگاه بهینه
            ///////////////////Print the elapsed time////////////////////
            stopwatch.Stop();
            //    Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);//خروجی زمان الگوریتم
            //  Console.WriteLine("================================");
            //Console.WriteLine("================================");
            //Console.ReadKey();
         
           // }
        }
    }
}
