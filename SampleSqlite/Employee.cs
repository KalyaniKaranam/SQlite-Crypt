using SQLite;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSqlite
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public long EmpId
        { get; set; }
        [NotNull]
        public string EmpName
        { get; set; }
      
        public string Designation
        { get; set; }
        public string Department
        { get; set; }
        public string Qualification
        { get; set; }
    }
}
