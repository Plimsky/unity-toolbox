using UnityEngine;

namespace Environment
{
    public class Floating : MonoBehaviour
    {
        public float Distance = 1;
        [Range(0, 2)] public float EaseAmount;
        public float WaitTime;
        public float Speed = 0.1f;
        public bool Cyclic = true;

        private float _actualDistance;
        private float _percentSpeed;
        private float _startDistance;
        private float _nextMoveTime;

        private Vector3 _positionStart;
        private Vector3 _positionEnd;
        private Vector3 _positionDestination;

        private void Start()
        {
            _startDistance = Mathf.Abs(transform.position.y - Distance);
            _positionStart = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            _positionEnd = new Vector3(transform.position.x, _startDistance, transform.position.z);
            _positionDestination = new Vector3(transform.position.x, _startDistance, transform.position.z);
        }

        void Update()
        {
            Vector3 velocity = CalculateMovement();
            transform.Translate(velocity);
        }

        private Vector3 CalculateMovement()
        {
            if (Time.time < _nextMoveTime)
                return Vector3.zero;

            _actualDistance = Vector3.Distance(transform.position, _positionDestination);
            _percentSpeed += Time.deltaTime * Speed / _actualDistance;
            _percentSpeed = Mathf.Clamp01(_percentSpeed);
            float easedPercentSpeed = Ease(_percentSpeed);


            Vector3 newPosition = Vector3.Lerp(transform.position, _positionDestination, easedPercentSpeed);

            if (_percentSpeed >= 1)
            {
                _percentSpeed = 0;
                _nextMoveTime = Time.time + WaitTime;

                if (Cyclic)
                {
                    _positionDestination = (_positionDestination == _positionEnd) ? _positionStart : _positionEnd;
                }
            }

            return newPosition - transform.position;
        }

        float Ease(float x)
        {
            float a = EaseAmount + 1;
            return Mathf.Pow(x, a) / (Mathf.Pow(x, a) + Mathf.Pow(1 - x, a));
        }
    }
}