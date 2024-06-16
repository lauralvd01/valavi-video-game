using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
        public static AudioManager Instance { get; private set; }
        [SerializeField] AudioSource musicSource;
        [SerializeField] AudioSource SFXSource;

        public AudioClip lvlcomplete; 
        public AudioClip ITEM;
        public AudioClip WAI;
        public AudioClip Lvlrst;

        void Awake(){
                Instance = this;
        }


        private void Start()
        {
                musicSource.clip = WAI;
                musicSource.loop = true; 
                musicSource.Play();

        }

        public void PlaySFX(AudioClip clip)
        {
                SFXSource.PlayOneShot(clip);
        }
                                
}