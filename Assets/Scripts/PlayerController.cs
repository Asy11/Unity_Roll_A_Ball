using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public Text counttext;
    public Text winText;

    private Rigidbody rb;

    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed );

    }

    void OnTriggerEnter(Collider other)  // 트리거 콜라이더를 처음 접촉하면 알려주는 함수
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        counttext.text = "Count : " + count.ToString();

        if (count >= 6)
            winText.text = "Win!!";
    }

}