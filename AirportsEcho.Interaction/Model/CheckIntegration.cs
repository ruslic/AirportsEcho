using System.Net;

namespace AirportsEcho.Interaction.Model
{
    /// <summary>
    /// Ответ на проверку ресурса
    /// </summary>
    public class CheckIntegrationResponse
    {
        /// <summary>
        /// Адрес ресурса
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Http код ответа
        /// </summary>
        public HttpStatusCode? HttpStatusCode { get; set; }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
