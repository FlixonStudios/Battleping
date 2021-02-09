using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MovementTest_Play
    {


        [UnityTest]
        public IEnumerator HorizontalInputOnly_HorizontalOutput()
        {
            var player = new GameObject().AddComponent<Player>();                       

            player.GetComponent<GameObject>().AddComponent<Rigidbody2D>();

            if (player.GetComponent<Joystick>() != null)
            {
                var joystick = player.GetComponent<Joystick>();
            }
            
            

            //var mathController = new GameObject().AddComponent<MathControllerBehaviour>();

            //player.currentMoveSpeed = 1;

            var expectedValue = 1f;
            
            var movementService = Substitute.For<IMovement>();

            player.MovementService = movementService;

            movementService.GetJoystickInputHorizontalRaw(joystick).Returns(1);



            var actualValue = player.GetComponent<Rigidbody2D>().velocity.x;

            yield return null;

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
