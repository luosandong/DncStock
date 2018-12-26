using Autofac;
using Sdl.Service;
using Sdl.Repository;
using Stock.Models;
using System;

namespace Sdl.StockCreeper
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建注册组件的builder
            var builder = new ContainerBuilder();
            //根据类型注册组件 ConsoleLogger 暴漏服务：ILogger
            //builder.RegisterType<ConsoleLogger>().As<ILogger>();

            // 根据实例注册组件 output  暴漏服务：TextWriter
            DbSession output = new DbSession("server=.;database=Stock;uid=sa;pwd=1", DbDialect.SqlServer);
            builder.RegisterInstance(output).As<DbSession>();

            //#region Repository
            //builder.RegisterGeneric(typeof(IBaseRepository<>));
            //builder.RegisterGeneric(typeof(BaseRepository<>));

            builder.RegisterGeneric(typeof(BaseRepository<>)).Named("basepository", typeof(IBaseRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<StockBaseInfoRepository>().As<IStockBaseInfoRepository>();
            builder.RegisterType<StockDayInfoRepository>().As<IStockDayInfoRepository>();
            //#endreion

            //反射注册组件，手动指定构造函数，这里指定了调用 MyComponent（ILogger log,IConfigReader config）的构造函数进行注册
            builder.RegisterType<StockService>()
             .UsingConstructor(typeof(IStockBaseInfoRepository), typeof(IStockDayInfoRepository)).As<IStockService>();

            StockBaseInfo info = new StockBaseInfo()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Test"
            };

            //构建一个容器完成注册
            var rootcontainer = builder.Build();

            //可以通过下面这种方式手动获取IConfigReader 的实现类
            //这种手动解析的方式需要 从生命周期作用域内获取组件,以保证组件最终被释放
            //不要直接从根容器rootcontainer中解析组件，很有可能会导致内存泄漏
            using (var scope = rootcontainer.BeginLifetimeScope())
            {
                var stockService = scope.Resolve<IStockService>();
                stockService.SaveStock(info);
            }

            Console.WriteLine("Hello World!");
        }
    }
}
