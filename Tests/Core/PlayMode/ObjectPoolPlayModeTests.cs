using System.Collections;
using NUnit.Framework;
using ObjectPool.Runtime.Core.Domain;
using ObjectPool.Runtime.Core.InterfaceAdapters.Presenters;
using ObjectPool.Runtime.Core.InterfaceAdapters.RealtimeEngine;
using ObjectPool.Runtime.Core.View;
using UnityEngine;
using UnityEngine.TestTools;

namespace ObjectPool.Tests.PlayMode.Core
{
    public class ObjectPoolPlayModeTests
    {
        private IObjectPool<IRecyclableObjectView> _objectPool;
        private IGenerator<IRecyclableObjectView> _generator;
        private int _maxPoolSize = 100;

        [SetUp]
        public void SetUp()
        {
            Transform parentTransform = new GameObject("Parent").transform;
            GameObject recyclableGameObject = new GameObject("Recyclable");
            recyclableGameObject.AddComponent<SetActiveRecyclableObject>();
            
            _generator = new RecyclableObjectGenerator(parentTransform, recyclableGameObject);
            _objectPool = new RecyclableObjectPool(_generator, _maxPoolSize);
        }

        [TearDown]
        public void TearDown()
        {
            _objectPool = null;
            _generator = null;
        }
        
        [UnityTest]
        public IEnumerator GetObject_ReturnsAnObject()
        {
            yield return null;
            
            //Act
            IRecyclableObjectView recyclableObjectView = _objectPool.GetObject();

            //Assert
            Assert.NotNull(recyclableObjectView);
            
            int poolSize = _objectPool.GetPoolSize();
            Assert.AreEqual(poolSize, 1);
        }
        
        [UnityTest]
        public IEnumerator GetMultipleObject_PoolSizeIsAsExpected()
        {
            yield return null;
            
            //Act
            int totalObjectsToGet = 5;

            for (int i = 0; i < totalObjectsToGet; i++)
            {
                _objectPool.GetObject();
            }
            
            //Assert
            int poolSize = _objectPool.GetPoolSize();
            Assert.AreEqual(totalObjectsToGet, poolSize);
        }

        [UnityTest]
        public IEnumerator RecycleObject_PassedObject_RecycleThePassedObject()
        {
            yield return null;

            //Arrange
            IRecyclableObjectView recyclableObjectView = _objectPool.GetObject();

            //Act
            _objectPool.RecycleObject(recyclableObjectView);

            //Assert
            int poolSize = _objectPool.GetPoolSize();
            
            Assert.AreEqual(poolSize, 0);
        }

        [UnityTest]
        public IEnumerator RecycleAll_RecycleAllObjectsAndPoolSizeIsZero()
        {
            yield return null;

            //Arrange
            IRecyclableObjectView recyclableObjectView = _objectPool.GetObject();
            recyclableObjectView = _objectPool.GetObject();
            recyclableObjectView = _objectPool.GetObject();
            recyclableObjectView = _objectPool.GetObject();

            //Act
            _objectPool.RecycleAll();

            //Assert
            int poolSize = _objectPool.GetPoolSize();
            Assert.AreEqual(poolSize, 0);
        }
    }   
}