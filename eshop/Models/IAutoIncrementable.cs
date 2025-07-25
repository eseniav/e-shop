using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Models
{
    internal interface IAutoIncrementable
    {
        public int Id { get; set; }
    }
    public static class IDGenerator<T>
    {
        internal static int lastID = 0;
        public static int GetNextId() => ++lastID;
    }
}
