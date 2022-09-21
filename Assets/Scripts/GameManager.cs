using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Chapter.Singleton
{
    public class GameManager : Singleton<GameManager>
    {
        private DateTime _sessionStartTime;
        private DateTime _sessionEndTime;

        // Stores the current location of the cube as an instance variable
        // To access this from another script use the following
        // To read the position
        // Vector3 getPosition = GameManager.Instance.lastKnowPosition;
        // To set the position within the cubeMover script
        // GameManager.Instance.lastKnowPosition = this.transform.position;
        public Vector3 lastKnownPosition;
        

        public override void Reset()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = lastKnownPosition;
            }
            else
            {
                Debug.LogError("Cannot find game object with tag 'Player'!");
            }

        }
        void Start()
        {
            // TODO:
            // - Load player save
            // - If no save, redirect player to registration scene
            // - Call backend and get daily challenge and rewards 
            
          

            _sessionStartTime = DateTime.Now;
            Debug.Log(
                "Game session start @: " + DateTime.Now);
        }

        void OnApplicationQuit()
        {
            _sessionEndTime = DateTime.Now;

            TimeSpan timeDifference =
                _sessionEndTime.Subtract(_sessionStartTime);

            Debug.Log(
                "Game session ended @: " + DateTime.Now);
            Debug.Log(
                "Game session lasted: " + timeDifference);
        }

        //  Use this code in the UI code
        void OnGUI()
        {
            if (GUILayout.Button("Next Scene"))
            {
                var scenesCount = SceneManager.sceneCount;
                int currentIndex = SceneManager.GetActiveScene().buildIndex;
                int nextIndex = currentIndex + 1;
                // TO MOVE to the previous scene then use
                //  int nextIndex = currentIndex - 1;
                Debug.LogFormat("Next Scene Index:{0}, Scene Count:{1}, Scene Name:{2}", nextIndex, scenesCount, SceneManager.GetSceneAt(scenesCount - 1).name);
                SceneManager.LoadScene(nextIndex);

            }
            else if (GUILayout.Button("Prev Scene"))
            {
                var scenesCount = SceneManager.sceneCount;
                int currentIndex = SceneManager.GetActiveScene().buildIndex;
                int nextIndex = currentIndex - 1;
                // TO MOVE to the previous scene then use
                //  int nextIndex = currentIndex - 1;
                Debug.LogFormat("Next Scene Index:{0}, Scene Count:{1}, Scene Name:{2}", nextIndex, scenesCount, SceneManager.GetSceneAt(scenesCount - 1).name);
                SceneManager.LoadScene(nextIndex);

            }
        }
        
    }
}