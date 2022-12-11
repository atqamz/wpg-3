using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElBekarat
{
    [System.Serializable]
    public struct AudioData
    {
        public string name;
        public AudioClip clip;
        public bool loop;
    }

    public class AudioManager : MonoBehaviour
    {
        private AudioSource bgmSource;
        private List<AudioSource> ambSourceList;
        private List<AudioSource> sfxSourceList;

        [Header("Audio Clips")]
        [SerializeField] private List<AudioData> bgmClipList;
        [SerializeField] private List<AudioData> ambClipList;
        [SerializeField] private List<AudioData> sfxClipList;

        // ============================================================================

        private void Start()
        {
            // testing
            PlayBGM(0);
            PlayAMB(0);
        }

        public void MuteBGM(bool _mute)
        {
            bgmSource.mute = _mute;

            foreach (AudioSource source in ambSourceList)
            {
                source.mute = _mute;
            }
        }

        public void MuteSFX(bool _mute)
        {
            foreach (AudioSource source in sfxSourceList)
            {
                source.mute = _mute;
            }
        }

        public void PlayBGM(string _name)
        {
            AudioData data = bgmClipList.Find(x => x.name == _name);
            if (data.clip != null)
            {
                bgmSource.clip = data.clip;
                bgmSource.loop = data.loop;
                bgmSource.Play();
            }
        }

        public void PlayBGM(int _index)
        {
            if (_index >= 0 && _index < bgmClipList.Count)
            {
                bgmSource.clip = bgmClipList[_index].clip;
                bgmSource.loop = bgmClipList[_index].loop;
                bgmSource.Play();
            }
        }

        public void StopBGM()
        {
            bgmSource.Stop();
        }

        public void PlayAMB(string _name)
        {
            AudioData data = ambClipList.Find(x => x.name == _name);
            if (data.clip != null)
            {
                foreach (AudioSource source in ambSourceList)
                {
                    if (!source.isPlaying)
                    {
                        source.clip = data.clip;
                        source.loop = data.loop;
                        source.Play();
                        return;
                    }
                }
            }
        }

        public void PlayAMB(int _index)
        {
            if (_index >= 0 && _index < ambClipList.Count)
            {
                foreach (AudioSource source in ambSourceList)
                {
                    if (!source.isPlaying)
                    {
                        source.clip = ambClipList[_index].clip;
                        source.loop = ambClipList[_index].loop;
                        source.Play();
                        return;
                    }
                }
            }
        }

        public void StopAMB(string _name)
        {
            AudioData data = ambClipList.Find(x => x.name == _name);
            if (data.clip != null)
            {
                foreach (AudioSource source in ambSourceList)
                {
                    if (source.clip == data.clip)
                    {
                        source.Stop();
                        return;
                    }
                }
            }
        }

        public void StopAMB(int _index)
        {
            if (_index >= 0 && _index < ambClipList.Count)
            {
                foreach (AudioSource source in ambSourceList)
                {
                    if (source.clip == ambClipList[_index].clip)
                    {
                        source.Stop();
                        return;
                    }
                }
            }
        }

        public void PlaySFX(string _name)
        {
            AudioData data = sfxClipList.Find(x => x.name == _name);
            if (data.clip != null)
            {
                foreach (AudioSource source in sfxSourceList)
                {
                    if (!source.isPlaying)
                    {
                        source.clip = data.clip;
                        source.loop = data.loop;
                        source.Play();
                        return;
                    }
                }
            }
        }

        public void StopSFX(string name)
        {
            AudioData data = sfxClipList.Find(x => x.name == name);
            if (data.clip != null)
            {
                foreach (AudioSource source in sfxSourceList)
                {
                    if (source.clip == data.clip)
                    {
                        source.Stop();
                        return;
                    }
                }
            }
        }

        // ============================================================================

        public static AudioManager Instance;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            bgmSource = GetComponent<AudioSource>();
            ambSourceList = new List<AudioSource>();
            sfxSourceList = new List<AudioSource>();
            FindAllAudioSources();
        }

        private void Reset()
        {
            bgmSource = GetComponent<AudioSource>();
            ambSourceList = new List<AudioSource>();
            sfxSourceList = new List<AudioSource>();
            FindAllAudioSources();
        }

        private void FindAllAudioSources()
        {
            foreach (AudioSource source in GetComponentsInChildren<AudioSource>())
            {
                if (source.gameObject.name.StartsWith("BGM"))
                {
                    bgmSource = source;
                }
                else if (source.gameObject.name.StartsWith("AMB"))
                {
                    ambSourceList.Add(source);
                }
                else if (source.gameObject.name.StartsWith("SFX"))
                {
                    sfxSourceList.Add(source);
                }
            }
        }

        // ============================================================================

        public void PlayNextBGM()
        {
            int index = bgmClipList.FindIndex(x => x.clip == bgmSource.clip);
            if (index < bgmClipList.Count - 1)
            {
                PlayBGM(index + 1);
            }
            else
            {
                PlayBGM(0);
            }
        }

        public void PlayNextAMB()
        {
            int index = ambClipList.FindIndex(x => x.clip == ambSourceList[0].clip);
            StopAMB(index);
            if (index < ambClipList.Count - 1)
            {
                PlayAMB(index + 1);
            }
            else
            {
                PlayAMB(0);
            }
        }

        public void PlayPreviousBGM()
        {
            int index = bgmClipList.FindIndex(x => x.clip == bgmSource.clip);
            if (index > 0)
            {
                PlayBGM(index + 1);
            }
            else
            {
                PlayBGM(bgmClipList.Count - 1);
            }
        }

        public void PlayPreviousAMB()
        {
            int index = ambClipList.FindIndex(x => x.clip == ambSourceList[0].clip);
            StopAMB(index);
            if (index > 0)
            {
                PlayAMB(index - 1);
            }
            else
            {
                PlayAMB(ambClipList.Count - 1);
            }
        }
    }
}