using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

//Flag for it is necesary create distintc kind of build
public static class AppDevelopFlag{
	public static readonly bool	DEVELOP = true;
}

public static class AppLayers{
	public static readonly LayerMask	LAYER_PC = (LayerMask)10;
	public static readonly LayerMask	LAYER_ENEMY = (LayerMask)8;
	public static readonly LayerMask	LAYER_ENEMY_BULLET = (LayerMask)9;
	public static readonly LayerMask	LAYER_PC_BULLET = (LayerMask)11;
	public static readonly LayerMask	LAYER_GROUND = (LayerMask)12;
	public static readonly LayerMask	LAYER_TREE = (LayerMask)13;
}

public static class AppScenes{
	public static readonly string	SCENE_INIT = "Init";
	public static readonly string	SCENE_MAIN_MENU = "Menu";
	public static readonly string	SCENE_GAME = "Game";
}

public static class AppFiles{
	public static readonly string 	FILE_USER = Application.persistentDataPath+"/configuration.json";
	public static readonly string	RESOURCES_FILE_USER = "JSON/configuration";
}
