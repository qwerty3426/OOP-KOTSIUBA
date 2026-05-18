using IndependentWork19.Core;
using IndependentWork19.Factories;

var manager = DataManager.Instance;

// SQL
manager.SetFactory(new SqlFactory());
manager.GetData();

Console.WriteLine();

// NoSQL
manager.SetFactory(new NoSqlFactory());
manager.GetData();

Console.WriteLine();

// XML
manager.SetFactory(new XmlFactory());
manager.GetData();