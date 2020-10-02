using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region singleton
    private static AudioManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    [SerializeField] private AudioSource sfxSource = null;
    [SerializeField] private AudioSource bgmSource = null;

    [SerializeField] private AudioClip[] clipList = null;
    private Dictionary<string, AudioClip> clipDic = new Dictionary<string, AudioClip>();

    public static float SfxVolume { set { instance.sfxSource.volume = value; } }
    public static float BgmVolume { set { instance.bgmSource.volume = value; } }

    private void Start()
    {
        for (int i = 0; i < clipList.Length; i++)
        {
            clipDic.Add(clipList[i].name, clipList[i]);
        }
    }

    public static void PlaySFX(string sfxName, in Vector3? point = null)
    {
        instance.sfxSource.transform.position = point ?? Vector3.zero;
        instance.sfxSource.PlayOneShot(instance.clipDic[sfxName]);
    }
    public static void PlayBGM(string bgmName)
    {
        instance.bgmSource.clip = instance.clipDic[bgmName];
        instance.bgmSource.Play();
    }
}
