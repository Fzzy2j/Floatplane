using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.scripts
{
    public class Manager : MonoBehaviour
    {

        public static Manager I;
        public int PlaySceneId;

        public static bool paused { get; private set; }

        private void Start()
        {
            if (I == null)
            {
                DontDestroyOnLoad(gameObject);
                I = this;
                if (!paused) Manager.togglePause();
            }
            else if (I != this)
            {
                Destroy(gameObject);
            }
        }

        public static System.Random Random = new System.Random();

        public static int HighScore
        {
            get
            {
                return PlayerPrefs.GetInt("HighScore");
            }
            set
            {
                if (value < 0) return;
                PlayerPrefs.SetInt("HighScore", value);
                PlayerPrefs.Save();
            }
        }

        private List<ScheduledTask> scheduled = new List<ScheduledTask>();

        public class ScheduledTask
        {
            public ScheduledTask(Func<bool> run, int delay, int timeStamp)
            {
                this.run = run;
                this.delay = delay;
                this.timeStamp = timeStamp;
            }
            public Func<bool> run;
            public int delay;
            public int timeStamp;
            public bool repeat = true;
        }

        public ScheduledTask ScheduleTaskToRun(Func<bool> run, int delay)
        {
            var task = new ScheduledTask(run, delay, Environment.TickCount);
            scheduled.Add(task);
            return task;
        }

        public static void togglePause()
        {
            paused = !paused;
            if (paused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        
        private float pauseUiPosition;

        public float UiMoveDistance;
        private void Update()
        {
            if (Input.GetButtonDown("Pause/Cancel"))
            {
                togglePause();
            }
            if (paused)
            {
                pauseUiPosition = Mathf.Lerp(pauseUiPosition, UiMoveDistance, Time.unscaledDeltaTime * 10);
                ShipController.Instance.pauseUi.transform.localPosition = new Vector3(pauseUiPosition, 0, 0);
            }
            else
            {
                pauseUiPosition = Mathf.Lerp(pauseUiPosition, 0, Time.unscaledDeltaTime * 10);
                ShipController.Instance.pauseUi.transform.localPosition = new Vector3(pauseUiPosition, 0, 0);
            }
            for (int i = scheduled.Count - 1; i >= 0; i--)
            {
                var task = scheduled[i];
                if (Environment.TickCount - task.timeStamp > task.delay)
                {
                    bool repeat = task.run.Invoke();
                    if (repeat && task.repeat)
                        task.timeStamp = Environment.TickCount;
                    else
                        scheduled.RemoveAt(i);
                }
            }
        }

        public static bool IsPlaying()
        {
            return SceneManager.GetActiveScene().name == SceneManager.GetSceneByBuildIndex(I.PlaySceneId).name;
        }

        public void StartNewPlaySession()
        {
            SceneManager.LoadScene(PlaySceneId);
        }
    }
}