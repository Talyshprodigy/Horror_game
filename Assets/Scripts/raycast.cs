using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class raycast : MonoBehaviour
{
    private Camera camera;
    public int gold;
    public TextMeshProUGUI goldAmount;
    public GameObject playerKnife;
    public GameObject playerKey;
    private bool hasKey;
    private bool hasKnife;
    private int inventoryIndex;
    public GameObject knifeImage;
    public GameObject keyImage;
    public GameObject knife;
    void Start()
    {
        camera = GetComponent<Camera>();
        playerKnife.SetActive(false);
        playerKey.SetActive(false);
        hasKey = false;
        hasKnife = false;
        inventoryIndex = 0;
        knifeImage.SetActive(false);
        keyImage.SetActive(false);
    }

    void Update()
    {
        SwitchItems();
        Ray playerRay = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(playerRay, out hit, 100))
        {
            goldAmount.text = hit.collider.gameObject.name;
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (hit.collider.gameObject.CompareTag("gold"))
                {
                    Destroy(hit.transform.parent.gameObject);
                    gold += 18;
                    goldAmount.text = gold.ToString();
                }
                else if (hit.collider.gameObject.CompareTag("KnifeCabinet"))
                {
                    Destroy(hit.collider.gameObject);
                    hasKnife = true;
                }
                else if (hit.collider.gameObject.CompareTag("KeyCabinet"))
                {
                    Destroy(hit.collider.gameObject);
                    hasKey = true;
                }
                else if (hit.collider.gameObject.CompareTag("Enemy") && playerKnife.activeInHierarchy)
                {
                    Destroy(hit.collider.gameObject);
                }
            } 
        }
        else
        {
            goldAmount.text = "_";
        }
    }

    private void SwitchItems()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            inventoryIndex = 1;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            inventoryIndex = 2;
        }
        if (inventoryIndex == 2 && hasKnife)
        {
            playerKnife.SetActive(true);
            playerKey.SetActive(false);
            knifeImage.SetActive(true);
            keyImage.SetActive(false);
        }
        if (inventoryIndex == 1 && hasKey)
        {
            playerKey.SetActive(true);
            playerKnife.SetActive(false);
            keyImage.SetActive(true);
            knifeImage.SetActive(false);
        }
    }
}
