using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Projeto.DAL.Mapping;


namespace Projeto.DAL.Util
{
    public class HibernateUtil
    {
        private static ISessionFactory factory;

        public static ISessionFactory Factory
        {
            get
            {
                if (factory == null)
                {
                    factory = Fluently.Configure()
                                      .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConfigurationManager.ConnectionStrings["projeto"].ConnectionString))
                                      .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TimeMap>())
                                      .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                                      .BuildSessionFactory();
                }
                return factory;
            }
        }
    }
}
