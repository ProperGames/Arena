using Microsoft.Xna.Framework;

namespace Client.Environment
{
    abstract class Subsystem
    {
        public abstract void OnUpdate(GameTime gameTime);
    }
}
