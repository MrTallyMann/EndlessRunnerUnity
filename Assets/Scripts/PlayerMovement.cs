using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    public float rightB = 6f;
    public float leftB = -6f;
    public TMP_Text Distance;
    public TMP_Text Score;
    public float CoinGrab = 0f;
    public static float A; //static allows you to move 
    public static float B;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.forward * speed * Time.deltaTime;

        float horizontalInput = Input.GetAxis("Horizontal"); // -1 (aristera) ews 1 (deksia)
        float newX = transform.position.x + horizontalInput * speed * Time.deltaTime;

        if (newX > rightB)
        {
            newX = rightB;
        }

        else if (newX < leftB)
        {
            newX = leftB;
        }

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        Distance.text = "Distance: " + (transform.position.z).ToString("0");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            CoinGrab += 0.5f;
            Score.text = "Score: " + (CoinGrab).ToString("0");
            Debug.Log(Score.text);
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
            A = CoinGrab;
            B = transform.position.z;
            Debug.Log(A);
            Debug.Log(B);
            SceneManager.LoadScene("EndScene");
        }
    }

}

