using UnityEngine;
using UnityEngine.UI;

public class Jumpscare : MonoBehaviour
{
    [SerializeField] private GameObject jumpScareImage;
    private float jumpScareTimer;
    [SerializeField] private float jumpScareTime = 1f;

    private void Start()
    {
        if (jumpScareImage)
        {
            jumpScareImage.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        jumpScareTimer += Time.deltaTime;
        Debug.Log(jumpScareTimer);
        if (jumpScareTimer > jumpScareTime)
        {
            jumpScareImage.SetActive(true);
            //deactivate player movement
            //activate jumpscare
            //play jumpscare sound
            //kill player
        }
    }

    private void OnTriggerExit(Collider col)
    {
        jumpScareTimer = 0;
    }
}
