using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MilesCarRental.Infrastructure.Mapper
{
    public static class MapperExtension
    {
        public static T MapToEntity<T>(this object value) => JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(value));
    }
}
