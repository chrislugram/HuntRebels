using UnityEngine;
using System.Collections;

public static class Util {
	#region METHODS_CUSTOM
	public static string MilisecondsInClockFormat(int miliseconds){
		System.TimeSpan timeSpan = System.TimeSpan.FromMilliseconds ((double)miliseconds);
		return (timeSpan.Minutes.ToString ("D2") + ":" + timeSpan.Seconds.ToString ("D2"));
	}
	#endregion
}
