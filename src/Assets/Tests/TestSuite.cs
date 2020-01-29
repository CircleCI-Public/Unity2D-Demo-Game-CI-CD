using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

namespace Tests
{
    public class TestSuite
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestSuiteSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator EnemyMovesLeft()
        {
            GameObject Enemy = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Enemy.prefab");
            GameObject myEnemy = GameObject.Instantiate(Enemy, new Vector3(0, 10, 0), Quaternion.identity);
            float initialXPos = Enemy.transform.position.x;
            yield return new WaitForSeconds(1f);
            Assert.Less(myEnemy.transform.position.x, initialXPos);
            Object.Destroy(myEnemy.gameObject);
        }
    }
}
