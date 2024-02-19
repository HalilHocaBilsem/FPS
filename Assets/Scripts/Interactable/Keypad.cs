using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    GameObject door;
    bool isOpen;
    private void Start()
    {
        Message = "Aç/Kapat";
    }
    protected override void Interact()
    {
        isOpen = !isOpen;
        door.GetComponent<Animator>().SetBool("isOpen", isOpen);
    }
}
