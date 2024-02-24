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

    public float bulletForce = 30f;

    private List<char> sequence = new List<char> { 'i', 'o', 'p' };
    private int currentIndex = 0;

    void Start()
    {
        sequence = Shuffle(sequence);
        UpdateSequenceText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && sequence[currentIndex] == 'i')
        {
            currentIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.O) && sequence[currentIndex] == 'o')
        {
            currentIndex++;
        }
        else if (Input.GetKeyDown(KeyCode.P) && sequence[currentIndex] == 'p')
        {
            currentIndex++;
        }

        if (currentIndex == sequence.Count)
        {
            shoot();
            sequence = Shuffle(sequence);
            currentIndex = 0;
        }

        UpdateSequenceText();
    }

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
        sequenceText.text = "Input Sequence: " + string.Join(", ", sequence.GetRange(currentIndex, sequence.Count - currentIndex));
    }
}
