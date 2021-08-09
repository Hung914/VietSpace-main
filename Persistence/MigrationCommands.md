Check if dotnet dotnet-ef CLI is installed      
`
dotnet tool list --global       
`       
If don't have install with:     
`
dotnet tool install --global dotnet-ef --version 5.0.4
`

Run initial migration from the VietSpace folder: (project Persistence startup project API)

`
dotnet ef migrations add InitialCreate -p Persistence -s API/
`

`
dotnet ef migrations add AddCategory -p Persistence -s API/
`

`
dotnet ef migrations add AddBusinessPhoto -p Persistence -s API/
`