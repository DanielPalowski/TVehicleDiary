﻿using System.Diagnostics.Metrics;
using VehicleDiary.Core.Constants;
using VehicleDiary.Core.Interfaces;

namespace VehicleDiary.Application.Services
{
    public class CountryService
    {
        public List<CountriesModel> GetCountries()
        {
            return new List<CountriesModel>
            {
     new CountriesModel { Code = "AL", Name = "Albania" },
    new CountriesModel { Code = "DZ", Name = "Algeria" },
    new CountriesModel { Code = "AD", Name = "Andorra" },
    new CountriesModel { Code = "AO", Name = "Angola" },
    new CountriesModel { Code = "AR", Name = "Argentina" },
    new CountriesModel { Code = "AM", Name = "Armenia" },
    new CountriesModel { Code = "AU", Name = "Australia" },
    new CountriesModel { Code = "AT", Name = "Austria" },
    new CountriesModel { Code = "AZ", Name = "Azerbaijan" },
    new CountriesModel { Code = "BH", Name = "Bahrain" },
    new CountriesModel { Code = "BD", Name = "Bangladesh" },
    new CountriesModel { Code = "BY", Name = "Belarus" },
    new CountriesModel { Code = "BE", Name = "Belgium" },
    new CountriesModel { Code = "BZ", Name = "Belize" },
    new CountriesModel { Code = "BJ", Name = "Benin" },
    new CountriesModel { Code = "BO", Name = "Bolivia" },
    new CountriesModel { Code = "BA", Name = "Bosnia and Herzegovina" },
    new CountriesModel { Code = "BW", Name = "Botswana" },
    new CountriesModel { Code = "BR", Name = "Brazil" },
    new CountriesModel { Code = "BG", Name = "Bulgaria" },
    new CountriesModel { Code = "BF", Name = "Burkina Faso" },
    new CountriesModel { Code = "BI", Name = "Burundi" },
    new CountriesModel { Code = "KH", Name = "Cambodia" },
    new CountriesModel { Code = "CM", Name = "Cameroon" },
    new CountriesModel { Code = "CA", Name = "Canada" },
    new CountriesModel { Code = "CF", Name = "Central African Republic" },
    new CountriesModel { Code = "TD", Name = "Chad" },
    new CountriesModel { Code = "CL", Name = "Chile" },
    new CountriesModel { Code = "CN", Name = "China" },
    new CountriesModel { Code = "CO", Name = "Colombia" },
    new CountriesModel { Code = "HR", Name = "Croatia" },
    new CountriesModel { Code = "CU", Name = "Cuba" },
    new CountriesModel { Code = "CY", Name = "Cyprus" },
    new CountriesModel { Code = "CZ", Name = "Czech Republic" },
    new CountriesModel { Code = "DK", Name = "Denmark" },
    new CountriesModel { Code = "EC", Name = "Ecuador" },
    new CountriesModel { Code = "EG", Name = "Egypt" },
    new CountriesModel { Code = "SV", Name = "El Salvador" },
    new CountriesModel { Code = "EE", Name = "Estonia" },
    new CountriesModel { Code = "ET", Name = "Ethiopia" },
    new CountriesModel { Code = "FI", Name = "Finland" },
    new CountriesModel { Code = "FR", Name = "France" },
    new CountriesModel { Code = "GE", Name = "Georgia" },
    new CountriesModel { Code = "DE", Name = "Germany" },
    new CountriesModel { Code = "GH", Name = "Ghana" },
    new CountriesModel { Code = "GR", Name = "Greece" },
    new CountriesModel { Code = "GT", Name = "Guatemala" },
    new CountriesModel { Code = "HT", Name = "Haiti" },
    new CountriesModel { Code = "HN", Name = "Honduras" },
    new CountriesModel { Code = "HU", Name = "Hungary" },
    new CountriesModel { Code = "IS", Name = "Iceland" },
    new CountriesModel { Code = "IN", Name = "India" },
    new CountriesModel { Code = "ID", Name = "Indonesia" },
    new CountriesModel { Code = "IR", Name = "Iran" },
    new CountriesModel { Code = "IQ", Name = "Iraq" },
    new CountriesModel { Code = "IE", Name = "Ireland" },
    new CountriesModel { Code = "IT", Name = "Italy" },
    new CountriesModel { Code = "JP", Name = "Japan" },
    new CountriesModel { Code = "JO", Name = "Jordan" },
    new CountriesModel { Code = "KE", Name = "Kenya" },
    new CountriesModel { Code = "KR", Name = "South Korea" },
    new CountriesModel { Code = "KW", Name = "Kuwait" },
    new CountriesModel { Code = "LV", Name = "Latvia" },
    new CountriesModel { Code = "LB", Name = "Lebanon" },
    new CountriesModel { Code = "LY", Name = "Libya" },
    new CountriesModel { Code = "LT", Name = "Lithuania" },
    new CountriesModel { Code = "LU", Name = "Luxembourg" },
    new CountriesModel { Code = "MY", Name = "Malaysia" },
    new CountriesModel { Code = "MX", Name = "Mexico" },
    new CountriesModel { Code = "MA", Name = "Morocco" },
    new CountriesModel { Code = "NL", Name = "Netherlands" },
    new CountriesModel { Code = "NZ", Name = "New Zealand" },
    new CountriesModel { Code = "NI", Name = "Nicaragua" },
    new CountriesModel { Code = "NG", Name = "Nigeria" },
    new CountriesModel { Code = "NO", Name = "Norway" },
    new CountriesModel { Code = "PK", Name = "Pakistan" },
    new CountriesModel { Code = "PA", Name = "Panama" },
    new CountriesModel { Code = "PE", Name = "Peru" },
    new CountriesModel { Code = "PL", Name = "Poland" },
    new CountriesModel { Code = "PT", Name = "Portugal" },
    new CountriesModel { Code = "RO", Name = "Romania" },
    new CountriesModel { Code = "RU", Name = "Russia" },
    new CountriesModel { Code = "SA", Name = "Saudi Arabia" },
    new CountriesModel { Code = "RS", Name = "Serbia" },
    new CountriesModel { Code = "SK", Name = "Slovakia" },
    new CountriesModel { Code = "SI", Name = "Slovenia" },
    new CountriesModel { Code = "ZA", Name = "South Africa" },
    new CountriesModel { Code = "ES", Name = "Spain" },
    new CountriesModel { Code = "SE", Name = "Sweden" },
    new CountriesModel { Code = "CH", Name = "Switzerland" },
    new CountriesModel { Code = "TR", Name = "Turkey" },
    new CountriesModel { Code = "UA", Name = "Ukraine" },
    new CountriesModel { Code = "AE", Name = "United Arab Emirates" },
    new CountriesModel { Code = "GB", Name = "United Kingdom" },
    new CountriesModel { Code = "US", Name = "United States" },
    new CountriesModel { Code = "VE", Name = "Venezuela" },
    new CountriesModel { Code = "VN", Name = "Vietnam" }
            };
        }
    }
}
