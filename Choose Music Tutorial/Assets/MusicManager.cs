using UnityEngine;
using TMPro;

public class MusicManager : MonoBehaviour
{
    public TextMeshProUGUI currentMusicPlayingText;

    //reference to music clips
    public Music[] musics;

    private string currentMusicID;

    private void Awake()
    {
        //create audiosources
        foreach (Music m in musics)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;
        }
    }

    public void ChangeMusic(string newMusicID)
    {
        //stop current music
        foreach (Music m in musics)
        {
            if (m.musicID == currentMusicID)
            {
                m.source.Stop();
                break;
            }
        }

        //change currentmusicID
        currentMusicID = newMusicID;

        //play new music
        foreach (Music m in musics)
        {
            if (m.musicID == currentMusicID)
            {
                m.source.Play();
                break;
            }
        }

        currentMusicPlayingText.text = "Currently Playing: " + currentMusicID;
    }
}