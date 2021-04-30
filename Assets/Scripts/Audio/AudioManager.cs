using System;
using Events;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private AudioEventChannel sfxEventChannel;

        [SerializeField] private AudioEventChannel musicEventChannel;

        #endregion

        private void OnEnable()
        {
            sfxEventChannel.AudioPlayAction += OnAudioPlay;
            sfxEventChannel.AudioStopAction += OnAudioStop;
            sfxEventChannel.AudioFinishAction += OnAudioFinish;
            
            musicEventChannel.AudioPlayAction += OnAudioPlay;
            musicEventChannel.AudioStopAction += OnAudioStop;
            musicEventChannel.AudioFinishAction += OnAudioFinish;
        }

        private void OnAudioPlay()
        {
        }

        private void OnAudioStop()
        {
        }

        private void OnAudioFinish()
        {
        }
    }
}