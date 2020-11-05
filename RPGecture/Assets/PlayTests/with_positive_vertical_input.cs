namespace a_player
{
    using System.Collections;

    using NSubstitute;

    using NUnit.Framework;

    using UnityEngine;
    using UnityEngine.TestTools;

    public class with_positive_vertical_input
    {
        [UnityTest]
        public IEnumerator moves_forward()
        {
            GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
            floor.transform.localScale = new Vector3(50, 0.1f, 50);
            floor.transform.position = Vector3.zero;
            
            GameObject playerGameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            playerGameObject.AddComponent<CharacterController>();
            playerGameObject.transform.position = new Vector3(0, 0.1f, 0);

            Player player = playerGameObject.AddComponent<Player>();

            IPlayerInput testPlayerInput = Substitute.For<IPlayerInput>();

            testPlayerInput.Vertical.Returns(1f);

            player.PlayerInput = testPlayerInput;

            float startingZPosition = player.transform.position.z;
            yield return new WaitForSeconds(5f);
            float endingZPosition = player.transform.position.z;
            
            Assert.Greater(endingZPosition, startingZPosition);
        }
    }
} 