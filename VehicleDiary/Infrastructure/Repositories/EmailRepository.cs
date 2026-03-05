using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using VehicleDiary.Application.Services.MapperService;
using VehicleDiary.Core.Constants;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Infrastructure.Data;

namespace VehicleDiary.Infrastructure.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly AppDbContext _context;
        private readonly IEmailSenderM _emailSender;
        private readonly UserManager<IdentityUser> _userManager;
        
        public EmailRepository(AppDbContext context, IEmailSenderM emailSender , UserManager<IdentityUser> userManager)
        {
            _context = context;
            _emailSender = emailSender;
            _userManager = userManager;
        }
        public async Task EmailVignetteSender(Guid vehicleIDRoute, ClaimsPrincipal User)
        {
            var nextMonth = DateTime.Now.AddMonths(1);

            var outedDates = _context.DBVignetteSet
                .Where(find =>
                    find.VignetteValidTo.Month == nextMonth.Month &&
                    find.VignetteValidTo.Year == nextMonth.Year &&
                    find.VehicleId == vehicleIDRoute &&
                    !find.EmailSend.HasValue)
                .ToList();
            if (outedDates.Count > 0)
            {
                foreach (var vignette in outedDates)
                {
                    var mailto = _userManager.GetUserName(User);
                    var subject = $"Motorway vignette is ending next month";
                    string message =
    "Dear customer,\n" +
    $"We would like to inform you that your motorway vignette {vignette.VignetteCountry} will expire next month. " +
    "Please remember to renew it in time to avoid any issues while using toll roads. " +
    "If you have already renewed your vignette, please ignore this message.\n\n" +
    "Vážený zákazníku,\n" +
    $"rádi bychom Vás informovali, že platnost Vaší dálniční známky {vignette.VignetteCountry} končí příští měsíc. " +
    "Prosíme, nezapomeňte ji včas obnovit, abyste se vyhnuli případným komplikacím při používání zpoplatněných komunikací. " +
    "Pokud jste již známku obnovili, prosím ignorujte tuto zprávu." +
    "\n\n VehicleDiary";
                    vignette.EmailSend = DateTime.Now;
                    await _emailSender.SendEmailAsync(mailto, subject, message);

                }
                _context.SaveChanges();
            }
        }
        public async Task EmailVehicleSender( ClaimsPrincipal User)
        {
            var nextMonth = DateTime.Now.AddMonths(1);

            var vehicleSTK = _context.DBVehiclesSet
            .Where(find => find.STK.HasValue &&
                find.STK.Value.Month == nextMonth.Month &&
                find.STK.Value.Year == nextMonth.Year &&
                    !find.EmailSendDate.HasValue)
            .ToList();
            if (vehicleSTK.Count > 0)
            {
                foreach (var car in vehicleSTK)
                {
                    var mailto = _userManager.GetUserName(User);
                    var subject = $"Your Vehicle Inspection (STK) Expires Next Month";
                    var message =
$@"Dear User,

We would like to inform you that the technical inspection (MOT) for your vehicle {car.Name} {car.Model} will expire next month.

To ensure your vehicle remains legally compliant and safe to drive, we recommend scheduling your inspection in advance.

Thank you for your attention

Best regards,
VehicleDiary

vehiclediary@gmail.com
----------------------------------------------------------------------------------

Vážený uživateli,

Rádi bychom Vás informovali, že technická kontrola (STK) Vašeho vozidla {car.Name} {car.Model} vyprší příští měsíc.

Aby Vaše vozidlo zůstalo v souladu s právními předpisy a bylo bezpečné k provozu, doporučujeme objednat se na technickou kontrolu včas.

Děkujeme za Vaši pozornost

S pozdravem,
VehicleDiary

vehiclediary@gmail.com";
                        car.EmailSendDate = DateTime.Now;
                        await _emailSender.SendEmailAsync(mailto, subject, message);
                    }
                    _context.SaveChanges();

                }
            }
        }
    }

