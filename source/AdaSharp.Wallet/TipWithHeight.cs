﻿using Newtonsoft.Json;

namespace AdaSharp
{
    public class TipWithHeight : Tip
    {
        [JsonProperty("height")]
        public UnitOfMeasure Height { get; set; }
    }
}