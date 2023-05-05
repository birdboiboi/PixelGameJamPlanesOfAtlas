using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioAnimation : Enemy
{
    public AudioClip[] dialog;
    int dialogCount = 0;
    public bool sayLine;

    public void Update()
    {
        if (sayLine)
        {
            TriggerDialogLine();
            sayLine = false;
        }
    }
    public void TriggerDialogLine()
    {
        Debug.Log("count " + dialogCount + " "+dialog.Length);
        audioSource.PlayOneShot(dialog[dialogCount]);

        if(dialogCount == dialog.Length-1)
        {
            
            dialogCount = 0;
        }
        else
        {
            dialogCount++;
        }
    }
}
