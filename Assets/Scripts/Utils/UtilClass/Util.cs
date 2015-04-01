using UnityEngine;
using System.Collections;

public static class Util {
	#region METHODS_CUSTOM
	public static string MilisecondsInClockFormat(int miliseconds){
		return string.Format ("{0:HH:mm:ss}", miliseconds);
	}
	#endregion
}
