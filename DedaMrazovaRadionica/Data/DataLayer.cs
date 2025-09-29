using DedaMrazovaRadionica.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DedaMrazovaRadionica.Data
{
    public class DataLayer : IDataLayer
    {
        private readonly ISessionFactory _sessionFactory;

        public DataLayer()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OracleCS"].ConnectionString;

            var cfg = OracleManagedDataClientConfiguration.Oracle10
                .ConnectionString(c => c.Is(connectionString));
            
            _sessionFactory = Fluently.Configure()
                .Database(cfg.ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DeteMapping>())
                .BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
