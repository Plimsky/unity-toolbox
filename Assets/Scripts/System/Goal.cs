using System.Collections.Generic;
using UnityEngine;

namespace System
{
    public class Goal : MonoBehaviour
    {
        public List<string> TagList = new List<string>();

        public delegate void GoalReachHandler();

        public static event GoalReachHandler OnGoalReached;

        private void OnTriggerEnter(Collider other)
        {
            if ((TagList.Contains(other.gameObject.tag) ||
                 TagList.Count == 0) &&
                OnGoalReached != null)
                OnGoalReached();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((TagList.Contains(other.gameObject.tag) ||
                 TagList.Count == 0) &&
                OnGoalReached != null)
                OnGoalReached();
        }
    }
}