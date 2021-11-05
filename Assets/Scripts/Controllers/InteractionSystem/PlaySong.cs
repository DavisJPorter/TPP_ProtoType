using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JDATE
{



public class PlaySong : InteractibleBase
{
        public AudioSource playSound;
        public override void OnInteract()
        {
            base.OnInteract();
            playSound.Play();
        }
    }
}
