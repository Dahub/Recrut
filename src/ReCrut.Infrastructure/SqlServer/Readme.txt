﻿﻿migration command
power shell command line

Event DB :  
	dotnet ef migrations add <name> --context EventDbContext -o SqlServer\EventDatabase\Migrations\
	dotnet ef database update --context EventDbContext

ViewProjection DB :
	dotnet ef migrations add <name> --context ViewProjectionDbContext -o SqlServer\ViewProjectionDatabase\Migrations\
	dotnet ef database update --context ViewProjectionDbContext