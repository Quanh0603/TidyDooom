using UnityEngine;

namespace GameTool.Assistants
{
    public static class Utilities
    {
        #region Camera

        public static Vector2 GetBoundMaxOfMainCamera(float distanceX = 0f, float distanceY = 0f)
        {
            Camera mainCamera = Camera.main;

            // Lấy vị trí của các viền của camera
            // ReSharper disable once PossibleNullReferenceException
            Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));
            topRight.z = 0;
            Vector2 boundMax = (Vector2)topRight - new Vector2(distanceX, distanceY);
            return boundMax;
        }

        public static Vector2 GetBoundMaxOfMainCamera(Camera camera, float distanceX = 0f, float distanceY = 0f)
        {
            // Lấy vị trí của các viền của camera
            Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
            topRight.z = 0;
            Vector2 boundMax = (Vector2)topRight - new Vector2(distanceX, distanceY);
            return boundMax;
        }

        #endregion

        #region Random

        /// Trả về 1 hoặc -1
        public static int RandomOneOrMinusOne()
        {
            int randomValue = Random.Range(0, 2) * 2 - 1;
            return randomValue;
        }

        /// Trả về 1 hoặc -1
        public static int GetOneOrMinusOne(float value)
        {
            return value switch
            {
                < 0 => -1,
                > 0 => 1,
                _ => RandomOneOrMinusOne()
            };
        }

        public static float RandomValue(float min, float max)
        {
            float randomValue = Random.Range(min, max) * RandomOneOrMinusOne();
            return randomValue;
        }

        /// Trả về True hoặc False
        public static bool RandomTrueOrFalse()
        {
            int randomValue = Random.Range(0, 2);
            return randomValue > 0;
        }

        #endregion

        #region Mathf

        public static float Round(float _value, int indexRound = 0)
        {
            return Mathf.Round(_value * Mathf.Pow(10, indexRound)) / Mathf.Pow(10, indexRound);
        }

        public static float Floor(float _value, int indexRound = 0)
        {
            return Mathf.Floor(_value * Mathf.Pow(10, indexRound)) / Mathf.Pow(10, indexRound);
        }

        public static float Ceil(float _value, int indexRound = 0)
        {
            return Mathf.Ceil(_value * Mathf.Pow(10, indexRound)) / Mathf.Pow(10, indexRound);
        }
        
        #endregion Mathf
    }
}