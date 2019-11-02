using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private GameObject objectAttached;

    private SpriteRenderer renderObjectAttached;
    private BoxCollider boxColliderObject;
    private Color silhouetteObjectAttached;
    private Color fullColor;
    private bool hasCollider = false;

    // Start is called before the first frame update
    void Start()
    {
        silhouetteObjectAttached = Color.black;
        fullColor = new Color(255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            renderObjectAttached = objectAttached.GetComponent<SpriteRenderer>();
        }
        catch (System.Exception)
        {
            throw;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Paint();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollider)
        {
            boxColliderObject = objectAttached.AddComponent(typeof(BoxCollider)) as BoxCollider;
            hasCollider = true;
        }
        foreach (ContactPoint contact in collision.contacts)
        {
            objectAttached.SetActive(true);
            renderObjectAttached.color = silhouetteObjectAttached;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        objectAttached.SetActive(false);
    }

    public void Paint()
    {
        renderObjectAttached.color = fullColor;
    }
}
