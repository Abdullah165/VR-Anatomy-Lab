# VR Anatomy Lab

An interactive VR educational application exploring human anatomy, built with Unity and the XR Interaction Toolkit. 


## Key Features
* **Physical Interaction:** Smoothly grab, inspect, and interact with 3D models of the Heart, Brain, Lungs, and Stomach.
* **Dynamic UI Systems:** Information panels update dynamically based on which object the user is currently holding.
* **Integrated Quizzes:** A built-in testing system that validates user knowledge with visual feedback (correct/incorrect states).
* **Immersive Environment:** A clean, laboratory/hospital-themed workspace designed around VR ergonomic best practices (accessible without teleportation).

## Technical Architecture

This project was built with a strong focus on clean, scalable code. 

**Decoupled Event-Driven Architecture**
To avoid rigid dependencies and "Spaghetti Code," the project utilizes a **ScriptableObject Event Architecture**. 
* 3D objects (Organs) and the Canvas UI have **zero direct references** to each other.
* When an organ is grabbed via the `XRGrabInteractable`, it fires data into an `OrganDefinitionEventChannelSO` or `QuizEventChannelSO`.
* The UI components simply listen to these ScriptableObject channels and update themselves dynamically. This allows for limitless organs to be added to the game without ever needing to modify the core UI scripts.
