using UnityEngine;
using UnityEngine.SceneManagement;
public enum Function
{
    Sine,
    YEqualsX,
    YEqualsNegativeX,
    YEqualsSqrtX,
    YEqualsZero,
    Stop,
}
public class Controller : MonoBehaviour
{
    float elapsedTime;
    Vector3 targetPosition;
    Vector3 origin;
    Function function;
    public float horizontalMovementSpeed=4;
    public float amplitude=10;

    GameObject trailMaker;

    float trailMakerELapsedTime;

    void Start()
    {
        function = Function.Stop;
        origin = transform.position;;
        trailMaker = Instantiate((GameObject) Resources.Load("Dot"), transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += 2 * Time.deltaTime;
        trailMakerELapsedTime += 3f* Time.deltaTime;

        if (function != Function.Stop)
        {
            targetPosition = PointPosition(elapsedTime);
            transform.position = Vector3.Lerp(transform.position, targetPosition,
                1);
            trailMaker.transform.position = Vector3.Lerp(trailMaker.transform.position,
                PointPosition(trailMakerELapsedTime),1);          
        }
        else
        {
            trailMaker.GetComponent<TrailRenderer>().Clear();
            trailMaker.transform.position = transform.position;
        }
    }

    Vector3 PointPosition(float t)
    {
        float xPos=0;
        float yPos=0;
        switch (function)
        {
            case Function.Sine:
                xPos = horizontalMovementSpeed * t;
                yPos = Mathf.Sin(t * Mathf.PI);
                break;
            case Function.YEqualsZero:
                yPos = 0;
                xPos = horizontalMovementSpeed * t;
                break;
            case Function.Stop:
                xPos = 0;
                yPos = 0;
                break;
            case Function.YEqualsX:
                xPos = horizontalMovementSpeed * t;
                yPos = xPos;
                break;
            case Function.YEqualsNegativeX:
                xPos = horizontalMovementSpeed *t;
                yPos = -xPos;
                break;
            case Function.YEqualsSqrtX:
                xPos = horizontalMovementSpeed * t;
                yPos = 2 * Mathf.Sqrt(xPos);
                break;
        }
        Vector3 currentPos = new Vector3(xPos, yPos, 0);
        Vector3 targetPos =(Vector2)origin + (Vector2)currentPos;
        return targetPos;
    }

    public void SwitchFunction(int function)
    {
        this.function = (Function)function;
        origin = transform.position;
        elapsedTime = 0;
        trailMakerELapsedTime = 0;
    }

    public void StopFunction()
    {
        function = Function.Stop;        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mine")
        {
            SceneManager.LoadScene(0);
        }
    }
}
