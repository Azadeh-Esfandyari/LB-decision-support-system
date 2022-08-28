using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineBalancing
{
    class Tasks
    {
        public  int taskid, tasktime;
        public  string taskname;
        public  int[] successors;
        public int[] sides;
        public int numofsuc;
        public Tasks(int suclen, int sidelen)
        {
           if(suclen>0) successors = new int[suclen];
            sides = new int[sidelen];
        }

    }
}
