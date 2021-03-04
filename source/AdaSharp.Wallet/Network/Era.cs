﻿using Newtonsoft.Json;

namespace AdaSharp.Network
{
    // TODO: Sort eras in sequence - because someone will make a comment in the future.
    public enum Era
    {
        NotInitialized = 0,
        
        [JsonProperty("byron")]
        Byron = 1,

        [JsonProperty("allegra")]
        Allegra = 2,
        
        [JsonProperty("shelley")]
        Shelley = 3,

        [JsonProperty("mary")]
        Mary = 4
    }
}