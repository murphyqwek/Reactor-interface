using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Reactor_Interface.Classes.Experiment
{
    public class FieldData
    {
        public string FieldName { get; }
        public string MetaData { get; }
        public string FieldValue { get; }
        public int Row { get; }
        public int Column { get; }

        public FieldData(string fieldName, string metaData, string fieldValue, int row, int column)
        {
            FieldName = fieldName;
            MetaData = metaData;
            FieldValue = fieldValue;
            Row = row;
            Column = column;
        }

        public void ClearValue()
        {

        }
    }
}
