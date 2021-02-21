using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class RandomAudioPlayer : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private bool randomizePitch = true;

        [SerializeField] private float pitchRandomRange = .2f;

        [SerializeField] private float playDelay;

        [SerializeField] private AudioClip[] clips;

        #endregion

        #region Private

        private AudioSource _audioSource;

        #endregion

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayRandomClip()
        {
            if (clips.Length == 0) return;
            
            _audioSource.pitch = randomizePitch ? 1f + Random.Range(-pitchRandomRange, pitchRandomRange) : 1f;
            _audioSource.clip = clips[Random.Range(0, clips.Length)];
            _audioSource.PlayDelayed(playDelay);
        }
    }
}