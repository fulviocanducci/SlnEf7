using ClsApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

using DatabaseGeneric databaseGeneric = new();
Console.WriteLine("Iniciando ...");

Expression<Func<SetPropertyCalls<People>, SetPropertyCalls<People>>> 
    properties = 
        c => c.SetProperty(u => u.Status, false)
              .SetProperty(u => u.College, "E");

int count = databaseGeneric.People
    .Where(c => c.Name != null && c.Name.Contains("MS."))
    .ExecuteUpdate(properties);
Console.WriteLine("Atualizou {0} ...", count);
