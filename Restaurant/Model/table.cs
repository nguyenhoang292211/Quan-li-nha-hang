using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Model
{
    class table
    {
        private int idTable;
        private int nameTable;

        public int NameTable { get => nameTable; set => nameTable = value; }
        public int IdTable { get => idTable; set => idTable = value; }
        public table()
        {

        }
        public table(int id,int name)
        {
            this.idTable = id;
            this.nameTable = name;
        }
        public table(table a)
        {
            this.idTable = a.idTable;
            this.nameTable = a.nameTable;
        }
    }
}
