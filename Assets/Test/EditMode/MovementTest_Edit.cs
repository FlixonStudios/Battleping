using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MovementTest_Edit
    {
        float deltaTime = 0.1f;
        float baseThrust = 1f;
        Vector2 playerInputForce = new Vector2(0, 0);

        [Test]
        public void RightForceOnPlayer_HorizontalForce_VectorForRightOnly()
        {
            float horizontalInput = 1f;

            Vector2 expectedForce = new Vector2(0.1f, 0);                       
            
            PlayerForceControl playerForceControl = new PlayerForceControl(baseThrust);

            playerInputForce = playerForceControl.CalculateForce(horizontalInput, 0, deltaTime);

            Assert.AreEqual(expectedForce, playerInputForce);
        }
        [Test]
        public void LeftForceOnPlayer_HorizontalForce_VectorForLeftOnly()
        {
            float horizontalInput = -1f;

            Vector2 expectedForce = new Vector2(-0.1f, 0);

            PlayerForceControl playerForceControl = new PlayerForceControl(baseThrust);

            playerInputForce = playerForceControl.CalculateForce(horizontalInput, 0, deltaTime);

            Assert.AreEqual(expectedForce, playerInputForce);
        }
        
        [Test]
        public void UpForceOnPlayer_VerticalForce_VectorForUpOnly()
        {
            float verticalInput = 1f;

            Vector2 expectedForce = new Vector2(-0.1f, 0);

            PlayerForceControl playerForceControl = new PlayerForceControl(baseThrust);

            playerInputForce = playerForceControl.CalculateForce(0, verticalInput, deltaTime);

            Assert.AreEqual(expectedForce, playerInputForce);
        }

    }
}
