using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Data
{
    public interface IDataLayer
    {
        ISession OpenSession();
    }
}
