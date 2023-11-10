namespace ApiLayer.Infrastructure.Tools
{
    public class JwtTokenDefaults
    {
        /*
          ValidAudience = "http://localhost",
        ValidIssuer = "http://localhost",
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sehmussehmussehmus1.")),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,c
         */

        public const string ValidAudience = "http://localhost"; //bunlar sabit değerleri olanlar 
        public const string ValidIssuer = "http://localhost";
        public const string Key = "sehmussehmussehmus1.";
        public const int Expire = 5;//token yaşam döngüsü süresi

    }
}
