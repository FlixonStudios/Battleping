using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MathController_EditTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Input_One_Get_One_DiminishingCurve()
        {
            
            MathController mathController = new MathController();

            float output = mathController.DiminishingExponentialFunction(0.5f);

            Assert.AreEqual(1f, output);
        }

        


        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator MathController_EditTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }


    }
}
