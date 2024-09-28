using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Chapter.Singleton
{
    public class GameManager : Singleton<GameManager>
    {
        private DateTime _sessionStartTime;
        private DateTime _sessionEndTime;

        private void Start()
        {
            //TODO:
            // - 플레이어 세이브 로드
            // - 세이브가 없으면 플레이어를 등록 씬으로 리다이렉션한다.
            // - 백엔드를 호출하고 일일 챌린지와 보상을 얻는다.

            _sessionStartTime = DateTime.Now;
            Debug.Log("Game session start @: " + DateTime.Now);
        }

        private void OnApplicationQuit()
        {
            _sessionEndTime = DateTime.Now;
            // TimeSpan은 시간의 간격을 나타낸다.
            // DateTime.Subtract는 2개의 시간의 차를 TimeSpan형으로 반환한다.
            TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime);

            Debug.Log("Game session ended @:" + DateTime.Now);
            Debug.Log("Game session lasted: " + timeDifference);
        }

        private void OnGUI()
        {
            if(GUILayout.Button("Next Scene"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

}
