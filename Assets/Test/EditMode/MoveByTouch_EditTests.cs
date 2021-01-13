using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MoveByTouch_EditTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void MoveByTouch_GetMoveByTouchScript_Test()
        {
            var gameObject = new GameObject();
            var moveByTouch = gameObject.AddComponent<MoveByTouchBehaviour>();

            Assert.IsNotNull(moveByTouch); //Test that there is a MoveByTouch class
        }
    }
}
