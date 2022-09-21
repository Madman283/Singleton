using Chapter.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CubeMover : MonoBehaviour
{
    public float scale = .1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameManager.Instance.lastKnownPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //change scene
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    var scenesCount = SceneManager.sceneCount;
        //    int currentIndex = SceneManager.GetActiveScene().buildIndex;
        //    int nextIndex = currentIndex + 1;
        //    // TO MOVE to the previous scene then use
        //    //  int nextIndex = currentIndex - 1;
        //    Debug.LogFormat("Next Scene Index:{0}, Scene Count:{1}, Scene Name:{2}", nextIndex, scenesCount, SceneManager.GetSceneAt(scenesCount - 1).name);
        //    SceneManager.LoadScene(nextIndex);
        //}
        //else if (Input.GetKey(KeyCode.X))
        //{
        //    var scenesCount = SceneManager.sceneCount;
        //    int currentIndex = SceneManager.GetActiveScene().buildIndex;
        //    int nextIndex = currentIndex - 1;
        //    // TO MOVE to the previous scene then use
        //    //  int nextIndex = currentIndex - 1;
        //    Debug.LogFormat("Next Scene Index:{0}, Scene Count:{1}, Scene Name:{2}", nextIndex, scenesCount, SceneManager.GetSceneAt(scenesCount - 1).name);
        //    SceneManager.LoadScene(nextIndex);
        //}
        //else
        //{
        //    float x = Input.GetAxis("Horizontal");
        //    float z = Input.GetAxis("Vertical");
        //    this.transform.Translate(new Vector3(x, 0, z) * scale);

        //    GameManager.Instance.lastKnownPosition = Vector3.zero;
        //    //transform.position = GameManager.Instance.lastKnownPosition = new Vector3(x,0,z) * scale;
        //}

        //float x = Input.GetAxis("Horizontal");
        //float z = Input.GetAxis("Vertical");
        
        this.transform.Translate (new Vector3(movementX, 0, movementY) * scale);
        GameManager.Instance.lastKnownPosition = this.transform.position;

    }
    float movementX, movementY;

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

}
