using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EscalonamentoHorarios_Grupo3.Models
{
    public static class SeedDataEnfermeiro

{
    public static void Populate(IServiceProvider applicationServices)
    {
        using (var serviceScope = applicationServices.CreateScope())
        {
            var db = serviceScope.ServiceProvider.GetService<EscalonamentoHorarios_Grupo3DbContext>();
            if (db.Products.Any()) return;
            db.Enfermeiro.AddRange(
            new Enfermeiro { Name = "Kayak", Cellphone = 961234567, Department = "Watersports", Email = "ass@gmail.com", Street = "1", Genre = "M"},
            new Enfermeiro { Name = "Lifejacket", Cellphone = 962345678, Department = "Watersports", Email = "hsbh@gmail.com", Street = "2", Genre = "M" },
            new Enfermeiro { Name = "Soccer Ball", Cellphone = 963456789, Department = "Soccer", Email = "mdamd@gmail.com", Street = "3", Genre = "M" },
            new Enfermeiro { Name = "Corner Flags", Cellphone = 965678901, Department = "Soccer", Email = "dda@gmail.com", Street = "4", Genre = "M" },
            new Enfermeiro { Name = "Stadium", Cellphone = 966789012, Department = "Soccer", Email = "mdiad@gmail.com", Street = "5", Genre = "M" },
            new Enfermeiro { Name = "Thinking Cap", Cellphone = 967890123, Department = "Chess", Email ="ddud@gmail.com", Street = "6", Genre = "M" },
            new Enfermeiro { Name = "Unsteady Chair", Cellphone = 968901234, Department = "Chess", Email = "sjas@gmail.com", Street = "7", Genre = "M" },
            new Enfermeiro { Name = "Human Chess Board", Cellphone = 969012345, Department = "Chess", Email ="iki@gmail.com", Street = "8", Genre = "M" },
            new Enfermeiro { Name = "Bling-Bling King", Cellphone = 912345678, Department = "Chess", Email ="kiksia@gmail.com", Street = "9", Genre = "M" },
            new Enfermeiro { Name = "Bling-Bling King", Cellphone = 913456789, Department = "Chess", Email ="kki@gmail.com", Street = "10", Genre = "M" }
            );
            db.SaveChanges();
        }
    }
}