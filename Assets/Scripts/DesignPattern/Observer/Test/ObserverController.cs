using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Observer.Test
{
    public class ObserverController : MonoBehaviour
    {
        public List<GameObject> CubeList = new List<GameObject>();

        Subject _cubeSubject = new Subject();

        private void Start()
        {
            foreach (var cubeObj in CubeList)
            {
                CubeEvent cubeEvent = Random.Range(0, 4) > 2 ? (CubeEvent) new LittleJumpEvent() : new BigJumpEvent();
                AObserverCube aObserverCube = new AObserverCube(cubeObj, cubeEvent);
                _cubeSubject.AddObserver(aObserverCube);
            }
        }

        private void Update()
        {
            //The boxes should jump if the sphere is cose to origo
            if (CubeList[0].transform.position.y < 0.5f)
            {
                _cubeSubject.Notify();
            }
        }
    }
}