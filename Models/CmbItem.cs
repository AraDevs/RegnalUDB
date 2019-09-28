using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegnalUDB.Models
{
    class CmbItem
    {
        private string value;
        private int id;

        public CmbItem(string value, int id)
        {
            this.value = value;
            this.id = id;
        }

        public string Value { get => value; }
        public int Id { get => id; }

        override
        public string ToString()
        {
            return Value;
        }
    }
}
