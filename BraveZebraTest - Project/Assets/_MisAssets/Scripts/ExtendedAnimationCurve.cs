using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationCurveExtensions
{
    public static float GetTimeFromValue(this AnimationCurve curve,float requieredValue)
    {
        float errorRange = 0.3f;
        int checksPerSecond = 50;

        float duration = curve[curve.length - 1].time;

        int checks = Mathf.CeilToInt(duration * checksPerSecond);

        float currentTime = 0;

        float timeIncrease = 1f / (float)checksPerSecond;

        float currentBestTime = currentTime;
        float currentBestDistance = float.MaxValue;

        for (int i = 0; i < checks; i++)
        {
            float currentValue = curve.Evaluate(currentTime);

            float currentDistance = Mathf.Abs(currentValue - requieredValue);

            if (currentDistance < errorRange)
            {
                if (currentDistance < currentBestDistance)
                {
                    currentBestTime = currentTime;
                }
            }
            currentTime += timeIncrease;
            currentTime = Mathf.Clamp(currentTime, 0, duration);
        }

        return currentBestTime;
    }
}
