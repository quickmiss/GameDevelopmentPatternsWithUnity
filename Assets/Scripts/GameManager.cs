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
            // - �÷��̾� ���̺� �ε�
            // - ���̺갡 ������ �÷��̾ ��� ������ �����̷����Ѵ�.
            // - �鿣�带 ȣ���ϰ� ���� ç������ ������ ��´�.

            _sessionStartTime = DateTime.Now;
            Debug.Log("Game session start @: " + DateTime.Now);
        }

        private void OnApplicationQuit()
        {
            _sessionEndTime = DateTime.Now;
            // TimeSpan�� �ð��� ������ ��Ÿ����.
            // DateTime.Subtract�� 2���� �ð��� ���� TimeSpan������ ��ȯ�Ѵ�.
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
