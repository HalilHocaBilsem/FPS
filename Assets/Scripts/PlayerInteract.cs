using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private float distance = 3f;
    public Camera cam;
    [SerializeField]
    LayerMask mask;

    PlayerUI playerUI;
    InputManager inputManager;
    void Start()
    {
     playerUI=   GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        //  Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hit;
        if ( Physics.Raycast(ray, out hit, distance, mask))
        {
            var interactable=hit.collider.GetComponent<Interactable>();
            if (interactable!=null)
            {
                playerUI.UpdateText(interactable.Message);
                if (inputManager.playerInput.Onfoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
        else
        {
            playerUI.UpdateText("");
        }
       
    }
}
