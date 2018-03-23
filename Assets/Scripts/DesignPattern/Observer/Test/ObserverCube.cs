using UnityEngine;

namespace DesignPattern.Observer.Test
{
    public class AObserverCube : AObserver
    {
        private GameObject _cubeObj;
        private CubeEvent _cubeEvent;

        public AObserverCube(GameObject cubeObj, CubeEvent cubeEvent)
        {
            _cubeObj = cubeObj;
            _cubeEvent = cubeEvent;
        }

        public override void OnNotify()
        {
            Jump(_cubeEvent.GetJumpForce());
        }

        private void Jump(float jumpForce)
        {
            if (_cubeObj.transform.position.y < 0.55f)
            {
                _cubeObj.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            }
        }
    }
}