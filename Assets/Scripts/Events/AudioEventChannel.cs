using System;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(menuName = "Audio Event Channel")]
    public class AudioEventChannel : ScriptableObject
    {
        #region Public

        public event Action AudioPlayAction = delegate {  };
        
        public event Action AudioStopAction = delegate {  };
        
        public event Action AudioFinishAction = delegate {  };

        #endregion

        public void RaisePlayEvent()
        {
            AudioPlayAction();
        }

        public void RaiseStopEvent()
        {
            AudioStopAction();
        }

        public void RaiseFinishEvent()
        {
            AudioFinishAction();
        }
    }
}