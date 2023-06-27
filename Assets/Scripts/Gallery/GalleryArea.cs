using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryArea : MonoBehaviour
{
    public GameObject taxiObje,button;
    public Animator galleryArea;
    private void OnTriggerStay(Collider other)
    {
        taxiObje.SetActive(false);
        galleryArea.SetBool("GalleryAnim", true);
        button.SetActive(true);
    }    
     
    private void OnTriggerExit(Collider other)
    {
        taxiObje.SetActive(true);
        galleryArea.SetBool("GalleryAnim", false);
        button.SetActive(false);
    }
}
