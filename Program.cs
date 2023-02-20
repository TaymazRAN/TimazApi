using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomoroApi
{
    //          200 - Status200OK                  - ok
    //          201 - Status201Created             - created(masalan baraye sakht karbare jadid)
    //          401 - Status401Unauthorized        - unauthorized(yani login nist) 
    //          403 - Status403Forbidden           - forbidden(dastresi nadarad. masalan ba karbar mamuli vared shode ast va dastresi b panel admin nadarad)
    //          422 - Status422UnprocessableEntity - unprocesable entity(yani darkhast shoma motevaghef shode ast. mamulan be khatere validation ha)

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
