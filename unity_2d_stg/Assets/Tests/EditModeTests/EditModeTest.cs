using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class EditModeTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void EditModeTestSimplePasses()
        {
            // Use the Assert class to test conditions
			Assert.AreEqual(2, 1 + 1);
        }

		[Test]
		public void DecrementCounterFramePasses() {
			//EditModeTest.
			//DecrementCounterFramePasses decrement = new DecrementCounterFramePasses();
			//TestDecrementCounterFrame frame = new TestDecrementCounterFrame();

			//Assert.AreEqual(1, 2);
            // Use the Assert class to test conditions

			/*
			DecrementCounterFrame frame = new DecrementCounterFrame();
			Assert.IsNotNull(frame);
			{
				// 生成時は0.0f
				float defaultFrame = 0.0f;
				Assert.AreEqual(frame.GetMaxCounter(), defaultFrame);
				Assert.AreEqual(frame.GetCurrentCounter(), defaultFrame);
			}
			{
				float testFrame = 10.0f;
				// セットしたときにMaxCounterとCurrentCounterの一致を確認
				frame.SetCounter(10);
				Assert.AreEqual(frame.GetMaxCounter(), testFrame);
				Assert.AreEqual(frame.GetCurrentCounter(), testFrame);
			}
			*/

		}

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator EditModeTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
			Assert.AreEqual(2, 1 + 1);
        }
    }
}
