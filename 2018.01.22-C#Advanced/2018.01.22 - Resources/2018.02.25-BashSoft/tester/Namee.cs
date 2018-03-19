using System;
using System.Collections.Generic;
using System.Text;

namespace tester
{
    class Namee
    {
        private string name;
        private List<string> nameList = new List<string>();

        public Namee()
        {
            this.nameList = new List<string>();
        }

        public Namee(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public IReadOnlyCollection<string> GetListWithNames
        {
            get
            {
                return this.nameList;
            }
        }

        public void AddNameToListOfNames(string name)
        {
            this.nameList.Add(name);
        }

    }
}
