using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toplayici : MonoBehaviour
{
    public GameObject MainCube;
    float yukseklik;

    void Start()
    {
       
    }

   
    void Update()
    {

        MainCube.transform.position = new Vector3(transform.position.x, yukseklik + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0,-yukseklik, 0);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Topla" && other.gameObject.GetComponent<Toplanan>().GetToplandiMi()==false)
        {
            yukseklik += 1;
            other.gameObject.GetComponent<Toplanan>().ToplandiYap();
            other.gameObject.GetComponent<Toplanan>().IndexAyarla(yukseklik);
            other.gameObject.transform.parent = MainCube.transform;

        }
    }
    public void YukseklikAzalt()
    {
        yukseklik--;
    }
}
