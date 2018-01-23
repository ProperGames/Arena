using System;
using System.Collections.Generic;

namespace Client.Game
{
    class Layer : Framework.Layer
    {
        public Layer(Framework.LayerConfig config) : base(config)
        {
        }

        protected override Tuple<bool, List<Tools.Message>> Initialise()
        {
            return new Tuple<bool, List<Tools.Message>>(true, new List<Tools.Message>() { });
        }
    }
}
