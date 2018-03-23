namespace DesignPattern.Prototype
{
    public abstract class ASpawner
    {
        private ISpawnable _prototype;

        protected ASpawner(ISpawnable prototype)
        {
            _prototype = prototype;
        }

        public ISpawnable SpawnPrototype()
        {
            return _prototype.Clone();
        }
    }
}