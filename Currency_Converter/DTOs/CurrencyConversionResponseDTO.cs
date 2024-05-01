using Newtonsoft.Json;

namespace Currency_Converter.DTOs
{
    internal record CurrencyConversionResponseDTO
    {
        [JsonProperty("result")]
        public string Result { get; init; }

        [JsonProperty("documentation")]
        public Uri Documentation { get; init; }

        [JsonProperty("terms_of_use")]
        public Uri TermsOfUse { get; init; }

        [JsonProperty("time_last_update_unix")]
        public long TimeLastUpdateUnix { get; init; }

        [JsonProperty("time_last_update_utc")]
        public string TimeLastUpdateUtc { get; init; }

        [JsonProperty("time_next_update_unix")]
        public long TimeNextUpdateUnix { get; init; }

        [JsonProperty("time_next_update_utc")]
        public string TimeNextUpdateUtc { get; init; }

        [JsonProperty("base_code")]
        public string BaseCode { get; init; }

        [JsonProperty("target_code")]
        public string TargetCode { get; init; }

        [JsonProperty("conversion_rate")]
        public double ConversionRate { get; init; }

        [JsonProperty("conversion_result")]
        public long ConversionResult { get; init; }
    }
}
