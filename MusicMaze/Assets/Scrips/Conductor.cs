using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public double songGuitarBpm = 123;

    //The number of seconds for each song beat
    public double secPerBeat;

    //Current song position, in seconds
    public double songPosition;

    //Current song position, in beats
    public double songPositionInBeats;

    //How many seconds have passed since the song started
    public double dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    // guitar music
    public AudioClip guitar;

    //The offset to the first beat of the song in seconds
    public double firstBeatOffset = 0.34D;


    // Start is called before the first frame update
    void Start()
    {

        musicSource.clip = guitar;

        //Calculate the number of seconds in each beat
        secPerBeat = 60D / songGuitarBpm;

        //Record the time when the music starts
        dspSongTime = (double)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (songPositionInBeats >= 15)
        {
            songPositionInBeats = 0;
            songPosition = 0;
        }

        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;

        
    }
}
