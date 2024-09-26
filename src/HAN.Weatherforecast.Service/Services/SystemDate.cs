namespace HAN.Weatherforecast.Service.Services
{
    /// <summary>
    /// Represents the system date
    /// </summary>
    public class SystemDate : ISystemDate
    {
        /// <inheritdoc />
        public DateTime Today => DateTime.Today;
    }
}
