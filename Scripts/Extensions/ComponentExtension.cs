using UnityEngine;
/// <summary>
/// Provides extension methods for GameObject to simplify component handling.
/// </summary>

namespace Juant0Tools
{
    public static class ComponentExtension
    {
        /// <summary>
        /// Retrieves an existing component of type T from the GameObject or adds one if it doesn't exist.
        /// </summary>
        /// <typeparam name="T">The type of the component to retrieve or add.</typeparam>
        /// <param name="go">The GameObject to retrieve or add the component to.</param>
        /// <returns>The existing component of type T if found, otherwise a new component of type T added to the GameObject.</returns>
        public static T SetCompoment<T>(this GameObject go) where T : Component
        {
            if (go.TryGetComponent(out T compoment))
                return compoment;
            return go.AddComponent<T>();
        }
    }
}
