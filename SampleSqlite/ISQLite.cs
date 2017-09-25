using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleSqlite
{
     public interface ISQLite
    {
        SQLite.Net.SQLiteConnection GetConnection();
    }
}
