using System.Collections;

using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    using NUnit.Framework;

    public class a_moving_cube
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator moving_forward_changes_position()
        {
            // Arrange
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = Vector3.zero;
            
            // Act
            for (int i = 0; i < 10; i++)
            {
                cube.transform.position += Vector3.forward;
                yield return null;

                // Assert
                Assert.AreEqual(i+1, cube.transform.position.z);
            }

            yield return null;
        }
    }
}
