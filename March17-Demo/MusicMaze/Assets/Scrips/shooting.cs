using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shooting : MonoBehaviour
{
    
    public TextMeshProUGUI sequenceText;

    public Transform firePoint;
    public GameObject bulletPrefab;

    public AudioSource src;
    public AudioClip shoot1, shoot2, shoot3;

    public float bulletForce = 30f;

    private List<char> sequence = new List<char> { 'i', 'o', 'p' };
    private int currentIndex = 0;

    void Start()
    {   
        //shuffle the combo needed to shoot
        sequence = Shuffle(sequence);
        //show the combo
        UpdateSequenceText();
    }

    void Update()
    {   // if player hits a key that is that the combo, current index increases 
        if (Input.GetKeyDown(KeyCode.I) && sequence[currentIndex] == 'i')
        {   
            // load sound 
            src.clip = shoot1;
            // play sound 
            src.Play();
            // increase index 
            currentIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.O) && sequence[currentIndex] == 'o')
        {
            src.clip = shoot2;
            src.Play();
            currentIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.P) && sequence[currentIndex] == 'p')
        {
            src.clip = shoot3;
            src.Play();
            currentIndex++;
        }

        // once player finish combo, or index reaches limit 
        if (currentIndex == sequence.Count)
        {   
            //shoot a projectile 
            shoot();
            // get new combo 
            sequence = Shuffle(sequence);
            //reset index value 
            currentIndex = 0;
        }
        // update remaining combo needed 
        UpdateSequenceText();
    }

    //shuffle code, shuffles the array 
    List<char> Shuffle(List<char> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            char temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
        return list;
    }

    void shoot()
    {
        // new bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // get rigidbody 
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //apply direction and force
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void UpdateSequenceText()
    {
        // just updates the text
        sequenceText.text = "Input Sequence: " + string.Join(", ", sequence.GetRange(currentIndex, sequence.Count - currentIndex));
    }
}
