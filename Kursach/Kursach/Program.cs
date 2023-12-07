SQLDBConnector connector = new SQLDBConnector("Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;");

if(connector.connectToDB()) Console.WriteLine("+");

if(connector.disconnectFromDB()) Console.WriteLine("+");