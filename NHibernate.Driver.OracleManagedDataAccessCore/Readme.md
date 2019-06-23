# NHibernate.Driver.OracleManagerDataAccessCore
This repo is forked from [icsharp/NHibernate.Oracle](https://github.com/icsharp/NHibernate.Oracle), and update to .Net Core 2.0.
### Install Package
```
Install-Package NHibernate.Driver.OracleManagedDataAccessCore
```
### Configuration samples
```c#
	var assembly = Assembly.GetExecutingAssembly();
	
	var types = assembly.GetTypes()
	        .Where(t => t.Namespace != null && t.Namespace.StartsWith("App.Models")) // part of namespace to mapping classes
	        .Where(t => !t.IsAbstract && !t.IsInterface)
	        .Except(ignoreTypes)
	        .Distinct();
	
	var mapping = mapper.CompileMappingFor(types);

	var configuration = new Configuration();
    var configuration.DataBaseIntegration(x =>
    {
            x.ConnectionString = $"Data Source={Server}:{Port}/{Database};User Id={Login};Password={Password};DBA Privilege={privileges}";
            x.Driver<OracleManagedDriver>();
            x.ConnectionProvider<DriverConnectionProvider>();
            x.Dialect<Oracle12cDialect>();
            x.Timeout = 60;
            x.LogSqlInConsole = true;
            x.LogFormattedSql = true;
            x.IsolationLevel = IsolationLevel.ReadCommitted;
    });
    configuration.AddAssembly(Assembly.GetExecutingAssembly());
    configuration.AddMapping(mapping);
	var factory = configuration.BuildSessionFactory());
    var session = Factory.OpenSession();
	
	// and now can use NHibernate and linq
	var test = session.Query<App.Models.Model>()
		.Where(x => x.Visible)
		.OrderBy(x => x.Name)
		.ToList();
```