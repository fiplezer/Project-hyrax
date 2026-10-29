using UnityEngine;
using System.Threading;
using System.Collections;

public class DoorButton : MonoBehaviour, IInteractable
{
    public GameObject gameManager;
    private Animator animator;

    private void Start()
    {
       animator = GetComponent<Animator>();
    }
    public void Interact()
    {
        gameManager.GetComponent<TutorialMovementReader>().InteractWithButton();
        animator.SetTrigger("Active");
    }
}
