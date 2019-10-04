using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SINGIT.Services
{
    public interface ISQLiteInterface
    {
        SQLiteConnection GetSQLiteConnection();
    }
}
