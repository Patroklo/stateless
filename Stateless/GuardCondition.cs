using System;

namespace Stateless
{
    public partial class StateMachine<TState, TTrigger>
    {
        internal class GuardCondition
        {
            readonly Reflection.InvocationInfo _methodDescription;

            internal GuardCondition(Func<bool> guard, Reflection.InvocationInfo description)
            {
                if (guard == null)
                {
                    throw new ArgumentNullException(nameof(guard));
                }
                Guard = guard;

                if (description == null)
                {
                    throw new ArgumentNullException(nameof(description));
                }
                _methodDescription = description;
            }
            internal Func<bool> Guard { get; }

            // Return the description of the guard method: the caller-defined description if one
            // was provided, else the name of the method itself
            internal string Description => _methodDescription.Description;

            // Return a more complete description of the guard method
            internal Reflection.InvocationInfo MethodDescription => _methodDescription;
        }
    }
}