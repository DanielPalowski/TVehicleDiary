﻿using System.Diagnostics.Metrics;
using VehicleDiary.Models;

namespace VehicleDiary.Services
{
    public class CountryService
    {
        public List<DBCountriesModel> GetCountries()
        {
            return new List<DBCountriesModel>
            {
     new DBCountriesModel { Code = "AL", Name = "Albania" },
    new DBCountriesModel { Code = "DZ", Name = "Algeria" },
    new DBCountriesModel { Code = "AD", Name = "Andorra" },
    new DBCountriesModel { Code = "AO", Name = "Angola" },
    new DBCountriesModel { Code = "AR", Name = "Argentina" },
    new DBCountriesModel { Code = "AM", Name = "Armenia" },
    new DBCountriesModel { Code = "AU", Name = "Australia" },
    new DBCountriesModel { Code = "AT", Name = "Austria" },
    new DBCountriesModel { Code = "AZ", Name = "Azerbaijan" },
    new DBCountriesModel { Code = "BH", Name = "Bahrain" },
    new DBCountriesModel { Code = "BD", Name = "Bangladesh" },
    new DBCountriesModel { Code = "BY", Name = "Belarus" },
    new DBCountriesModel { Code = "BE", Name = "Belgium" },
    new DBCountriesModel { Code = "BZ", Name = "Belize" },
    new DBCountriesModel { Code = "BJ", Name = "Benin" },
    new DBCountriesModel { Code = "BO", Name = "Bolivia" },
    new DBCountriesModel { Code = "BA", Name = "Bosnia and Herzegovina" },
    new DBCountriesModel { Code = "BW", Name = "Botswana" },
    new DBCountriesModel { Code = "BR", Name = "Brazil" },
    new DBCountriesModel { Code = "BG", Name = "Bulgaria" },
    new DBCountriesModel { Code = "BF", Name = "Burkina Faso" },
    new DBCountriesModel { Code = "BI", Name = "Burundi" },
    new DBCountriesModel { Code = "KH", Name = "Cambodia" },
    new DBCountriesModel { Code = "CM", Name = "Cameroon" },
    new DBCountriesModel { Code = "CA", Name = "Canada" },
    new DBCountriesModel { Code = "CF", Name = "Central African Republic" },
    new DBCountriesModel { Code = "TD", Name = "Chad" },
    new DBCountriesModel { Code = "CL", Name = "Chile" },
    new DBCountriesModel { Code = "CN", Name = "China" },
    new DBCountriesModel { Code = "CO", Name = "Colombia" },
    new DBCountriesModel { Code = "HR", Name = "Croatia" },
    new DBCountriesModel { Code = "CU", Name = "Cuba" },
    new DBCountriesModel { Code = "CY", Name = "Cyprus" },
    new DBCountriesModel { Code = "CZ", Name = "Czech Republic" },
    new DBCountriesModel { Code = "DK", Name = "Denmark" },
    new DBCountriesModel { Code = "EC", Name = "Ecuador" },
    new DBCountriesModel { Code = "EG", Name = "Egypt" },
    new DBCountriesModel { Code = "SV", Name = "El Salvador" },
    new DBCountriesModel { Code = "EE", Name = "Estonia" },
    new DBCountriesModel { Code = "ET", Name = "Ethiopia" },
    new DBCountriesModel { Code = "FI", Name = "Finland" },
    new DBCountriesModel { Code = "FR", Name = "France" },
    new DBCountriesModel { Code = "GE", Name = "Georgia" },
    new DBCountriesModel { Code = "DE", Name = "Germany" },
    new DBCountriesModel { Code = "GH", Name = "Ghana" },
    new DBCountriesModel { Code = "GR", Name = "Greece" },
    new DBCountriesModel { Code = "GT", Name = "Guatemala" },
    new DBCountriesModel { Code = "HT", Name = "Haiti" },
    new DBCountriesModel { Code = "HN", Name = "Honduras" },
    new DBCountriesModel { Code = "HU", Name = "Hungary" },
    new DBCountriesModel { Code = "IS", Name = "Iceland" },
    new DBCountriesModel { Code = "IN", Name = "India" },
    new DBCountriesModel { Code = "ID", Name = "Indonesia" },
    new DBCountriesModel { Code = "IR", Name = "Iran" },
    new DBCountriesModel { Code = "IQ", Name = "Iraq" },
    new DBCountriesModel { Code = "IE", Name = "Ireland" },
    new DBCountriesModel { Code = "IT", Name = "Italy" },
    new DBCountriesModel { Code = "JP", Name = "Japan" },
    new DBCountriesModel { Code = "JO", Name = "Jordan" },
    new DBCountriesModel { Code = "KE", Name = "Kenya" },
    new DBCountriesModel { Code = "KR", Name = "South Korea" },
    new DBCountriesModel { Code = "KW", Name = "Kuwait" },
    new DBCountriesModel { Code = "LV", Name = "Latvia" },
    new DBCountriesModel { Code = "LB", Name = "Lebanon" },
    new DBCountriesModel { Code = "LY", Name = "Libya" },
    new DBCountriesModel { Code = "LT", Name = "Lithuania" },
    new DBCountriesModel { Code = "LU", Name = "Luxembourg" },
    new DBCountriesModel { Code = "MY", Name = "Malaysia" },
    new DBCountriesModel { Code = "MX", Name = "Mexico" },
    new DBCountriesModel { Code = "MA", Name = "Morocco" },
    new DBCountriesModel { Code = "NL", Name = "Netherlands" },
    new DBCountriesModel { Code = "NZ", Name = "New Zealand" },
    new DBCountriesModel { Code = "NI", Name = "Nicaragua" },
    new DBCountriesModel { Code = "NG", Name = "Nigeria" },
    new DBCountriesModel { Code = "NO", Name = "Norway" },
    new DBCountriesModel { Code = "PK", Name = "Pakistan" },
    new DBCountriesModel { Code = "PA", Name = "Panama" },
    new DBCountriesModel { Code = "PE", Name = "Peru" },
    new DBCountriesModel { Code = "PL", Name = "Poland" },
    new DBCountriesModel { Code = "PT", Name = "Portugal" },
    new DBCountriesModel { Code = "RO", Name = "Romania" },
    new DBCountriesModel { Code = "RU", Name = "Russia" },
    new DBCountriesModel { Code = "SA", Name = "Saudi Arabia" },
    new DBCountriesModel { Code = "RS", Name = "Serbia" },
    new DBCountriesModel { Code = "SK", Name = "Slovakia" },
    new DBCountriesModel { Code = "SI", Name = "Slovenia" },
    new DBCountriesModel { Code = "ZA", Name = "South Africa" },
    new DBCountriesModel { Code = "ES", Name = "Spain" },
    new DBCountriesModel { Code = "SE", Name = "Sweden" },
    new DBCountriesModel { Code = "CH", Name = "Switzerland" },
    new DBCountriesModel { Code = "TR", Name = "Turkey" },
    new DBCountriesModel { Code = "UA", Name = "Ukraine" },
    new DBCountriesModel { Code = "AE", Name = "United Arab Emirates" },
    new DBCountriesModel { Code = "GB", Name = "United Kingdom" },
    new DBCountriesModel { Code = "US", Name = "United States" },
    new DBCountriesModel { Code = "VE", Name = "Venezuela" },
    new DBCountriesModel { Code = "VN", Name = "Vietnam" }
            };
        }
    }
}
