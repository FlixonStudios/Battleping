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

        [TestCase (-1, 0, -0.1f, 0)]
        [TestCase (1, 0, 0.1f, 0)]

        public void HorizontalForceOnPlayer_HorizontalForceOnly_VectorForHorizontalOnly
            (float horizontalInput, float verticalInput, float expectedHorizontalForce, float expectedVerticalForce)
        {
            Vector2 expectedForce = new Vector2(expectedHorizontalForce, expectedVerticalForce);

            PlayerForceControl playerForceControl = new PlayerForceControl(baseThrust);

            playerInputForce = playerForceControl.CalculateForce(horizontalInput, verticalInput, deltaTime);

            Assert.AreEqual(expectedForce, playerInputForce);
        }
        
        [Test]

        [TestCase(0, -1, 0, -0.1f)]
        [TestCase(0, 1, 0, 0.1f)]

        public void VerticalForceOnPlayer_VerticalForceOnly_VectorForVerticalOnly
            (float horizontalInput, float verticalInput, float expectedHorizontalForce, float expectedVerticalForce)
        {
            Vector2 expectedForce = new Vector2(expectedHorizontalForce, expectedVerticalForce);

            PlayerForceControl playerForceControl = new PlayerForceControl(baseThrust);

            playerInputForce = playerForceControl.CalculateForce(horizontalInput, verticalInput, deltaTime);

            Assert.AreEqual(expectedForce, playerInputForce);
        }

    }
}
