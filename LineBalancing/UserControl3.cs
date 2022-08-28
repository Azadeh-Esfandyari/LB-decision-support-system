using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineBalancing
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }
        public void Update1( int job,int[,] BSeed ,float[,] BStFi,float Bct, int bstation) {
            int ii = 0;
            for (int i1 = 0; i1 < job; i1++)
            {
                dataGridView1.Rows.Add();
                     dataGridView1.Rows[ii].Cells[0].Value = (i1+1);
                dataGridView1.Rows[ii].Cells[1].Value = (BSeed[0, i1] + 1).ToString();
                dataGridView1.Rows[ii].Cells[2].Value = (BSeed[1, i1] + 1).ToString();
                dataGridView1.Rows[ii].Cells[3].Value = BStFi[0, i1].ToString();
                dataGridView1.Rows[ii].Cells[4].Value = BStFi[1, i1].ToString();
                // Console.Write((i1 + 1) + "  ");//اسم کارها که در فرم نمایش داده نمی شود
                //  Console.Write((BSeed[0, i1] + 1) + "  ");///شماره ایستگاه تخصیص داده شده
                //  Console.Write((BSeed[1, i1] + 1) + "  ");//شماره ساید تخصیص داده شده
                //    Console.Write(BStFi[0, i1] + "  ");//زمان شروع و پایان به عنوان خروجی
                //      Console.Write(BStFi[1, i1] + "  ");//زمان  پایان به عنوان خروجی
                ii++;
            }
          textBox2.Text = Bct.ToString();
          textBox3.Text = bstation.ToString();
        }
        private void UserControl3_Load(object sender, EventArgs e)
        {

        }
    }
}
