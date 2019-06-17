namespace TrafficLights.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Enums;

    public class TrafficLight
    {
        private readonly int lightsCount;

        public TrafficLight(LightColors light)
        {
            this.Light = light;
            this.lightsCount = Enum.GetNames(typeof(LightColors)).Length;
        }

        public LightColors Light { get; private set; }

        public void ChangeLight()
        {
            var nextValue = (int)this.Light + 1;
            if (nextValue == this.lightsCount)
            {
                nextValue = 0;
            }

            var nextLight = (LightColors)nextValue;
            this.Light = nextLight;
        }
    }
}

