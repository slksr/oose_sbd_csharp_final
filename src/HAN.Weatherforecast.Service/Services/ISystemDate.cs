namespace HAN.Weatherforecast.Service.Services
{
    /// <summary>
    /// Represents the system date
    /// </summary>
    /// <remarks>
    /// This interface makes it possible to change the system date during test automation
    /// </remarks>
    internal interface ISystemDate
    {
        /// <summary>
        /// Get the current date
        /// </summary>
        DateTime Today { get; }
    }
}
