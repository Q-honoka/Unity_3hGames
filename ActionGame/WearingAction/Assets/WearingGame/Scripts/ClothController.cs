using UnityEngine;

public class ClothController : MonoBehaviour
{
    [SerializeField, Header("落下スピード")]
    private float fallSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClothMove();
    }

    /// <summary>
    /// 服が落ちる
    /// </summary>
    private void ClothMove()
    {
        transform.Translate(transform.up * -fallSpeed * Time.deltaTime);

        if(transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }
}
