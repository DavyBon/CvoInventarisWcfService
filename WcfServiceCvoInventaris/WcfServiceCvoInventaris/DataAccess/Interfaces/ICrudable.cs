using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfServiceCvoInventaris.DataAccess.Interfaces
{
    interface ICrudable<T>
    {
        T GetById(int id);

        List<T> GetAll();

        int Create(T t);

        bool Update(T t);

        bool Delete(int id);
    }
}