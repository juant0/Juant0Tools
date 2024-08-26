using UnityEngine;

namespace Juant0Tools
{
    /// <summary>
    /// Provides extension methods for the Vector3 structure.
    /// </summary>
    public static class Vector3Extension
    {
        /// <summary>
        /// Set new Vector3 object with modified x, y, or z components based on provided values.
        /// </summary>
        /// <param name="vector">The original Vector3 instance.</param>
        /// <param name="x">The new value for the x-coordinate.</param>
        /// <param name="y">The new value for the y-coordinate.</param>
        /// <param name="z">The new value for the z-coordinate.</param>
        /// <returns>A new Vector3 object with updated x, y, or z values.</returns>
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null) => new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);

        /// <summary>
        /// Adds specified values to the x, y, and z components of the vector.
        /// </summary>
        /// <param name="vector">The Vector3 instance to be added to.</param>
        /// <param name="x">The value to add to the x-coordinate.</param>
        /// <param name="y">The value to add to the y-coordinate.</param>
        /// <param name="z">The value to add to the z-coordinate.</param>
        /// <returns>A new Vector3 object resulting from the addition of x, y, and z to the original vector.</returns>
        public static Vector3 Add(this Vector3 vector, float x = 0, float y = 0, float z = 0) => new Vector3(vector.x + x, vector.y + y, vector.z + z);

    }
}
