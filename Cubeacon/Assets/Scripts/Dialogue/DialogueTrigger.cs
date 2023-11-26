using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("IncJSON")]
    [SerializeField] private TextAsset inkJSON;

    public void Start()
    {
       
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        // if (InputManager.GetInstance().GetInteractPressed())
        //{
        //    Debug.Log(inkJSON.text);
        //}
    }
}
