using System;

namespace DesignPattern.Command
{
    public abstract class ACommand
    {
        public string Name;
        public StateInput State;

        protected ACommand(string name, StateInput state)
        {
            if (name == null) throw new ArgumentNullException("name");
            Name = name;
            State = state;
        }

        public abstract void Execute(object player, object input);
    }
}