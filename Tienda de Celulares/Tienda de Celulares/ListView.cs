using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bl.Rentas
{
    internal class ListView
    {
        internal object Items;
        internal Point Location;

        public object Columns { get; internal set; }

        public static implicit operator ListView(System.Windows.Forms.ListView v)
        {
            throw new NotImplementedException();
        }
    }
}