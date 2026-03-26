using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MusicianFinder_Back.WebAPI.Token
{
    // Classe utilitaire pour générer un JWT (Json Web Token)
    public class TokenTool
    {
        // Injection de l'outils pour accéder au fichier de config (injection de dépendance)
        private readonly IConfiguration _config;

        public TokenTool(IConfiguration config)
        {
            _config = config;
        }

        // Classe pour représenter les données dans le token :
        public class Data
        {
            public required long MusicianId { get; set; }
            public required string Role { get; set; }
        }

        // Méthode pour générer le token
        public string Generate(Data data)
        {
            // Ensemble des données contenues dans le token via l'objet de sécurité de type "Claim" (! sera visible depuis le token, ne pas y mettre d'information sensible)
            Claim[] claims = [
                // new Claim("clé", "valeur"), // Exemple de claim personnalisé
                new Claim(ClaimTypes.NameIdentifier, data.MusicianId.ToString()),
                new Claim(ClaimTypes.Role, data.Role)
            ];

            // Signature du token
            string secret = _config["Token:Key"] ?? throw new Exception("La clé du token est non définie dans l'environnement.");  // Token:Key -> Récupération de la clé secrète depuis le fichier de config (appsettings.json)
            byte[] key = Encoding.UTF8.GetBytes(secret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            // Le token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["Token:Issuer"],         // Identité qui émet le token (Token:Issuer est défini dans appsettings.json)
                audience: _config["Token:Audience"],     // Context d'utilisation du token (validité dans le scénario)
                expires: DateTime.Now.AddMinutes(_config.GetValue<int>("Token:Audience")),   // Date d'expiration (60 min, cfr. appsettings.json)
                claims: claims,                          // Objet de sécurité qui contient les données à transmettre
                signingCredentials: signingCredentials   // Signature
            );

            // Renvoi du token sous forme de string
            JwtSecurityTokenHandler tokenhandler = new JwtSecurityTokenHandler();

            return tokenhandler.WriteToken(token); // WriteToken : transforme en string
        }
    }
}
