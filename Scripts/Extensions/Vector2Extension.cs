using UnityEngine;

namespace Juant0Tools
{
    /// <summary>
    /// Provides extension methods for the Vector2 structure.
    /// </summary>
    public static class Vector2Extension
    {
        /// <summary>
        /// Set new Vector2 object with modified x or y components based on provided values.
        /// </summary>
        /// <param name="vector">The original Vector2 instance.</param>
        /// <param name="x">The new value for the x-coordinate.</param>
        /// <param name="y">The new value for the y-coordinate.</param>
        /// <returns>A new Vector2 object with updated x or y values.</returns>
        public static Vector2 With(this Vector2 vector, float? x = null, float? y = null) => new Vector2(x ?? vector.x, y ?? vector.y);

        /// <summary>
        /// Adds specified values to the x and y components of the vector.
        /// </summary>
        /// <param name="vector">The Vector2 instance to be added to.</param>
        /// <param name="x">The value to add to the x-coordinate.</param>
        /// <param name="y">The value to add to the y-coordinate.</param>
        /// <returns>A new Vector2 object resulting from the addition of x and y to the original vector.</returns>
        public static Vector2 Add(this Vector2 vector, float x = 0, float y = 0) => new Vector2(vector.x + x, vector.y + y);

    }
}
