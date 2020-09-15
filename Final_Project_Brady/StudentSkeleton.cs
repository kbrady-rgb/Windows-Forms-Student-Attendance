using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Final_Project_Brady;

namespace Final_Project_Brady
{
    class StudentSkeleton
    {
        //fields
        private string _first;
        private string _last;
        private string _id;

        //constructor
        public StudentSkeleton(string first, string last, string id)
        {
            _first = first;
            _last = last;
            _id = id;
        }

        //first property
        public string First
        {
            get { return _first; }
            set { _first = value; }
        }

        //last property
        public string Last
        {
            get { return _last; }
            set { _last = value; }
        }

        //first property
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
