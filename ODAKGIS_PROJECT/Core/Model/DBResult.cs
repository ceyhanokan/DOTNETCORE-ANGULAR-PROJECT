using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class SelectResult<T>
    {
        public T RecordSingle { get; set; }
        public List<T> RecordList { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public int TotalRecord { get; set; }
        public int FilteredRecord { get; set; }
        public Exception Ex { get; set; }
    }
    public class InsertResult<T>
    {
        public bool IsSuccess { get; set; }
        public int InsertedID { get; set; }
        public string Message { get; set; }
        public T InsertedRecord { get; set; }
        public List<T> InsertedMultipleRecords { get; set; }
        public Exception Ex { get; set; }
    }

    public class UpdateResult<T>
    {
        public bool IsSuccess { get; set; }
        public int UpdatedID { get; set; }
        public string Message { get; set; }
        public T UpdatedRecord { get; set; }
        public Exception Ex { get; set; }
    }

    public class DeleteResult<T>
    {
        public bool IsSuccess { get; set; }
        public int DeletedID { get; set; }
        public string Message { get; set; }
        public T DeletedRecord { get; set; }
        public Exception Ex { get; set; }
    }
}
