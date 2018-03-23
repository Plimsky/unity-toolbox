using UnityEngine;

namespace System.Utils
{
    public class TestCameraShake : MonoBehaviour
    {
        public CameraShake CameraShakeScript;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(CameraShakeScript.Shake(.8f, 1f));
                Debug.Log("Clicking Camera Shaking");
            }
        }
    }
}