

		BO( Ef edmx files or Migration Files) 
	
	UI ---   BLL  --- DLL  -- Database(Ms sql)
    core     c#     ADO.net
                   repository

1) Create the BOL - Create Models
2) Create DAL - Create DBcontext, Add entity framework ,Add Migrations, Create Database , Create Repositories
3) Create BLL Initialise the DAL objects Use Repositories 
4) Create UI Create Contrllers, Layout, viewStart Views
5) In UI create packages , get Js and Bootstrap files
6) Add the project refrences
7) Implement DI in UI for BLL objects in startup using AddTransient
8) Implemeent DI in BLL : to do that add service layer using Microsoft.Extensions.DependencyInjection; Inject a class for DAL objects using AddTransient
   Register BLL Service for BLL in Startup
9) Implemeent DI in DAL : inject DBcontext
10) now to register DAL di in startup , UI shouldnt interact with Dal so this should be registered in BLL


At the end everything is regisered in Startup.cs, so to make it easy comment all serives and add refreence to DAL in UI
and AddTransient for every layer       
		services.AddTransient<ICategoryBs, CategoryBs>();     // For UI layer DI BLL objects
		services.AddTransient<ICategoryDb, CategoryDb>();
		services.AddTransient<LHDbContext>();


11) Add an Appsettings package for Conncetion string.
12) update connection string into statrtup and DAL db context
13) In BOL inhering user object LHuser from Identity user
14) change DB context to Identitydbcontext and add refrences to Identityuser too:
15)            services.AddIdentity<LHUser, IdentityRole>().AddEntityFrameworkStores<LHDbContext>().AddDefaultTokenProviders();
 to startup
 16) app.UseAuthentication to Startup,
 17) Add migration Update Database  -  Its ready for Authentication Authorization
