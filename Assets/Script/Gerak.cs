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
    public bool tanah; //Variable Sensor tanah
    public LayerMask targetLayer; 
    public Transform deteksitanah;
    public float jangkauan;

    //Animasi
    Animator anim; //sebagai variable animator

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lompat = GetComponent<Rigidbody2D>();//inisialisasi rigidbody2D untuk awal lompat
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //logik untuk animasi
        if(tanah == false)
        {
            anim.SetBool("lompat", true);
        }
        else 
        {
            anim.SetBool("lompat", false);
        }

        //sensor tanah
        tanah = Physics2D.OverlapCircle(deteksitanah.position, jangkauan, targetLayer);
        //Control player
        if (Input.GetKey(KeyCode.D)) //Key D Untuk gerak ke kanan
        {
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime);
            pindah = -1;
            anim.SetBool("Lari", true);//animasi lari
        }
        else if (Input.GetKey(KeyCode.A)) //Key A untuk bergerak ke kiri
        {
            transform.Translate(Vector2.right * -kecepatan * Time.deltaTime);
            pindah = 1;
            anim.SetBool("Lari", true);//animasi lari
        }
        else
        {
            anim.SetBool("Lari", false);//tidak berlari
        }

        //lompat dengan klik kiri mouse
        if (tanah==true && Input.GetKey(KeyCode.Mouse0))//Mouse0 = klik kiri mouse1 = klik kanan
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


