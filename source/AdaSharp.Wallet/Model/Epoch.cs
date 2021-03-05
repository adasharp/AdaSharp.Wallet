using Newtonsoft.Json;

namespace AdaSharp.Model
{
    public class Epoch
    {
        [JsonProperty("epoch_number")]
        public int Number { get; set; }

        // TODO: Change data type to DateTime.
        [JsonProperty("epoch_start_time")]
        public string StartTime { get; set; }

        public Epoch()
        { }

        /// <remarks>
        /// Created specifically to make the unit test code easier to read.
        /// </remarks>
        internal Epoch(int epochNumber, string epochStartTime)
        {
            Number = epochNumber;
            StartTime = epochStartTime;
        }
    }
}