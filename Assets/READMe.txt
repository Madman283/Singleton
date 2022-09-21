Goal:
Use the modified Singleton and GameManager classes originally from Chapter 4 of the book to demonstrate using a Singleton to manage moving a character from one scene to another. Those files, Singleton.cs and GameManager.cs, are in the zip file attached to this assignment.
See: files in zip attachment, which include the images referenced in this document.

Watch the video which can be a model for your scene.


Design steps:
Create separate folders for Scripts, Materials and a folder for the Input System if you do that extra credit step.
There shouldn't be any single file in the Assets folder. All the scripts, materials, etc. should be in their own dedicated folders.

Create a scene where the user can move the cube along a plane (Movement on XZ axis, not Y). 
Copy this scene so that you have two identical scenes.
If you want to have both scenes open in the hierarchy see the following screens. NOTE: You will only see the first scene in the hierarchy.
See: OpenSceneAdditive.jpg and then AfterOpenSceneAdditive.jpg

In scene 2 change the material of the plane so that it is obvious to the user that they are in a different scene.
Create a User Interface that is available in both scenes. The UI has a Next button, a Previous Button, and a display of the current position of the cube.
See SampleLayout.jpg
See the Steps section for suggestions on how to create the scenes.

Go into the Build Settings (Main Menu: FIle->Build Settings) and add both scenes as scene in the image below.
See BuildSettings.jpg


Scripting:
When the user clicks the UI to move to scene 2 ("Next") the cube will start from the last position in the first scene.  
When the user clicks the UI to return to scene 1 ("Prev") the cube will start from the last position in the second scene.  

The button events can use the "OnGui" code that is commented out in the GameManager code. You will want to move that code to where the button event is handled.  Use the standard UI or for extra credit the UI Toolkit. Do not use the imGUI ( ie OnGui ) as Unity does not recommend this anymore.

About the GameManager

Purpose:
A purpose for the GameManager is to store data that is needed in common between all scenes. 

The lastKnownPosition field in the GameManager is NOT a static field. If it was marked static then our scripts could ignore the Singleton pattern. We agree to follow the Singleton pattern, and not get around it, just like how agree to follow the Rules of the Road.
To access the instance fields and methods of the GameManager we use the reference to the Instance property of that class.
GameManager.Instance gives the other scripts that access to the instance fields and methods.

How to read and update the lastKnownPosition field in the GameManager:
In the cubeMover script to set the value of the lastKnownPosition
GameManager.Instance.lastKnownPosition = this.transform.position;

To reset the cube when changing scenes the opposite occurs
this.transform.position= GameManager.Instance.lastKnownPosition


Steps:
1. Create a new 3D Core project named Assignment2_SingletonUI
2. Rename the default scene name to Scene1
3. Create these folders with the Assets folder: Scripts, Materials
4. Save any additional scenes to the Scenes folder.
5. Add a Plane and a Cube. Create materials and apply them to the Plane and Cube so that the Cube visually stands out from the Plane.
6. Add the GameManager and SIngleton scripts to a scripts folder of the project.
7. Create an empty GameManager object and attach the GameManager script to this GameObject.
8. Add a script to move the Cube along the Plane.
9. Copy Scene1 and name it Scene2.
10. Use a different material for the Plane in this scene so that it is obvious when the user switches from one scene to the next.
11. Include a screen snapshot in any of the scripts of this project in Visual Studio that shows where you have set one or more breakpoints.



EXTRA POINTS (Will be stored under extra credit for Assignment 2)
10 more points for:Using the Input System (New) and/or the UI Toolkit rather than the legacy libraries.
Another 10 points for keeping the cube within the boundaries of the plane (Hint: Boundaries see MeshRenderer)


If you are going to use both the Input System (New) and the UI Toolkit then you need to complete these steps as the UI Toolkit relies on the Legacy Input System
1. Option: Add the Input System and the UI Toolkit to the Scene. (See further instructions)
2. Add an Input System UI Input Module to the Cube so that you can use both the Input System and the UI Toolkit one game object.


References:

Input System:
https://learn.unity.com/project/using-the-input-system-in-unity?uv=2020.1

Using the Input System along with the UI Toolkit:
https://forum.unity.com/threads/ui-toolkit-with-new-input-system.1210977/


UI Toolkit:
https://docs.unity3d.com/2022.2/Documentation/Manual/UIElements.html 
https://docs.unity3d.com/2022.2/Documentation/Manual/UIE-get-started-with-runtime-ui.html
https://docs.unity3d.com/2022.2/Documentation/Manual/UIB-interface-overview.html
https://docs.unity3d.com/2022.2/Documentation/Manual/UIBuilder.html
https://docs.unity3d.com/2022.2/Documentation/Manual/UIE-LayoutEngine.html
https://docs.unity3d.com/2022.2/Documentation/Manual/UIE-VisualTree.html
https://docs.unity3d.com/2022.2/Documentation/Manual/UIE-simple-ui-toolkit-workflow.html
 (Example shows using the class argument for identifying particular UI Elements)

https://docs.unity3d.com/2022.2/Documentation/Manual/UIE-transition-event-example.html

NOTE: You can move the outermost container around the screen when the Position property of the Position section is set to Absolute. Once you have the UI in the position you want on the screen then you can keep it at Absolute or you can reset it to Relative.
See: UIToolkit_Builder_AbsolutePosition.jpg



