using UnityEngine;
using System.Threading;
using System.Collections;

public class DoorButton : MonoBehaviour, IInteractable
{
    public GameObject gameManager;
    public void Interact()
    {
        gameManager.GetComponent<TutorialMovementReader>().InteractWithButton();
    }
}
