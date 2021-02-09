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
    public class MathControllerTest_Edit
    {
        [Test]

        public void InputValueMoreThanOneToDiminishingExponential_PositiveValue_OutputOne()
        {
            var inputValue = 999f;
            var expectedValue = 1f;
            var mathController = new MathController();

            Assert.AreEqual(expectedValue, mathController.DiminishingExponentialFunction(inputValue));
        }

        [Test]

        public void InputValueMoreThanOneToDiminishingExponential_NegativeValue_OutputOne()
        {
            var inputValue = -999f;
            var expectedValue = -1f;
            var mathController = new MathController();

            Assert.AreEqual(expectedValue, mathController.DiminishingExponentialFunction(inputValue));
        }

        [Test]

        public void InputOneToDiminishingExponential_NegativeValue_OutputNegativeOne()
        {
            var mathController = new MathController();
            var inputValue = -1f;
            var outputValue = mathController.DiminishingExponentialFunction(inputValue);
            var expectedValue = -1f;

            Assert.AreEqual(expectedValue, outputValue);
        }

        [Test]

        public void InputOneToDiminishingExponential_PositiveValue_OutputOne()
        {
            var mathController = new MathController();
            var inputValue = 1f;
            var outputValue = mathController.DiminishingExponentialFunction(inputValue);
            var expectedValue = 1f;

            Assert.AreEqual(expectedValue, outputValue);
        }

        [Test]

        public void InputZeroToDiminishingExponential_ZeroValue_OutputZero()
        {
            var mathController = new MathController();
            var inputValue = 0f;
            var outputValue = mathController.DiminishingExponentialFunction(inputValue);
            var expectedValue = 0f;

            Assert.AreEqual(expectedValue, outputValue);
        }

        [Test]

        public void InputHalfToDiminishingExponential_05Value_OutputLessThan05()
        {
            var mathController = new MathController();
            var inputValue = 0.5f;
            var outputValue = mathController.DiminishingExponentialFunction(inputValue);
            var expectedValue = Mathf.Pow(0.5f,4);

            Assert.AreEqual(expectedValue, outputValue);
        }
    }
}
