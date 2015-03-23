using UnityEngine;
using System.Collections;

public class GSState{
	
	#region STATIC_ENUM_CONSTANTS
	#endregion
	
	#region FIELDS
	protected RootApp	rootApp;
	#endregion
	
	#region ACCESSORS
	#endregion
	
	#region METHODS_CUSTOM
	public virtual void InitState(){}
	public virtual void Activate(){}
	public virtual void Desactivate(){}
	#endregion
}
