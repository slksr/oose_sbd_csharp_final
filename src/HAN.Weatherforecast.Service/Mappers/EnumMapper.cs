namespace HAN.Weatherforecast.Service.Mappers
{
    internal static class EnumMapper
    {
        /// <summary>
        /// Converts <paramref name="source"/> to type <typeparamref name="TTarget"/> based on the name of the enumeration value.
        /// </summary>
        /// <typeparam name="TTarget">The target type.</typeparam>
        /// <param name="source">The source enumeration value.</param>
        /// <returns>The converted value.</returns>
        /// <exception cref="InvalidOperationException">is thrown when the enumeration can't be mapped.</exception>
        public static TTarget MapTo<TTarget>(this Enum source)
            where TTarget : struct, Enum
        {
            var name = Enum.GetName(source.GetType(), source);
            if (Enum.TryParse<TTarget>(name, out var result))
            {
                return result;
            }

            throw new InvalidOperationException($"Unable to map value {source} from {source.GetType().FullName} to {typeof(TTarget).FullName}");
        }
    }
}
