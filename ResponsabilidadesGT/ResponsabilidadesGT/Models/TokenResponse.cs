
namespace ResponsabilidadesGT.Models
{
    using System;
    using Newtonsoft.Json;

    public class TokenResponse
    {
        #region Properties
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "jwt")]
        public string Token { get; set; }
        [JsonProperty(PropertyName = "id_user")]
        public string Iduser { get; set; }



        #endregion
    }
}
