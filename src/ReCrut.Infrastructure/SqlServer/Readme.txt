﻿﻿migration command
power shell command line

Event DB :  
	dotnet ef migrations add <name> --context EventDbContext -o SqlServer\EventDatabase\Migrations\
	dotnet ef database update --context EventDbContext

ViewProjection DB :
	dotnet ef migrations add <name> --context ProjectionDbContext -o SqlServer\ProjectionDatabase\Migrations\
	dotnet ef database update --context ProjectionDbContext