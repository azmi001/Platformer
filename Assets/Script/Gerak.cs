using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class Gerak : MonoBehaviour
{
    public int kecepatan; //Kecepatan gerak
    public int kekuatanlompat; //variable kekuatan lompat
    public bool balik;
    public int pindah;
    Rigidbody2D lompat; //lompat sebagai nama dari RigidBody2D
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lompat = GetComponent<Rigidbody2D>();//inisialisasi rigidbody2D untuk awal lompat
    }

    // Update is called once per frame
    void Update()
    {
        //Control player
        if (Input.GetKey(KeyCode.D)) //Key D Untuk gerak ke kanan
        {
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime);
            pindah = -1;
        }
        else if (Input.GetKey(KeyCode.A)) //Key A untuk bergerak ke kiri
        {
            transform.Translate(Vector2.right * -kecepatan * Time.deltaTime);
            pindah = 1;
        }

        if (Input.GetKey(KeyCode.Mouse0)) //Mouse0 = klik kiri mouse1 = klik kanan
        {
            lompat.AddForce(new Vector2(0, kekuatanlompat));
        }

        //logik balik badan
        if (pindah > 0 && !balik)
        {
            flip();
        }
        else if (pindah < 0 && balik)
        {
            flip();
        }
    }

    //fungsi balik badan
    void flip()
    {
        balik = !balik;
        Vector3 Player = transform.localScale;
        Player.x *= -1;
        transform.localScale = Player;
    }
}
