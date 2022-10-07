using SharedProject;

DatabaseService databaseService = new DatabaseService();
databaseService.EnsureCreated();

Model model = new Model(10000000.0, 6.0, 30);
databaseService.Insert(model);
