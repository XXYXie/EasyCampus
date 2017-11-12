# EasyCampus
Google Drive Link: https://drive.google.com/open?id=15pSCpDN_H5ajrmQ9w2P5g6ao2esaTyXh  
## Inspiration
When we were freshmen, we had a hard time getting ourselves familiarize with the campus: we didn't know which classes were in which buildings, and even if sometimes we knew the name of the building, we didn't know how to get there as fast as possible. Even if we have campus map, it was very confusing and abstract. As a result, we spent a lot of time finding buildings and sometimes we were even late for classes because of it. 
Therefore, in order to improve freshmen's experience, we want to use VR to help people feel and know the campus in a better way. Moreover, visitors can also get familiar with the campus before they visit.
## What it does
* This VR application shows you around the campus. 
* It automatically walk you through the shortest path to the building you want to go from where you are.
* If you just say where you want to go or a course you take, it can recognize words you say and lead you to the building.
* It displays description of a building near you and courses related to it.
## How we built it
We used Unity to build the campus and wrote scripts in C# to control VR related behaviors. We transformed the campus to a graph, and then utilized Bellman-Ford algorithm to find the best path to buildings. For voice control, we used Microsoft Azure Cognitive Services Speech API. 
## Challenges we ran into
* Adjust camera to a right position to prevent users from feeling dizzy when using this app. To fit both the first-person controller and cardboard camera, we used gyroscope to build a distinguisher between mouse motion and CardboardHead.
* Even though we learnt the shortest path algorithms at school, we were usually given a well-formatted graph. It was much harder to transform a campus map to nodes and edges because shapes of buildings and roads were difficult to parse. 
* Build models in Unity to reflect the campus. It took a lot of efforts for us to adjust details: lights, winds, and locations of buildings to make the campus more vivid and attractive.
* Adjust positions of texts to display when users are near a certain building.
## Accomplishments that we're proud of
* Built buildings and natural landscapes in Unity . 
* Successfully figured out the algorithm to find the shortest path in the campus.
* Utilized voice control. 
## What we learned
* Adjust VR camera in Unity.
* Add details to models in Unity.
* Use voice control.
## What's next
Incorporate the app on mobile phones or Hololens. Add more details to the campus: slopes, stairs, and interior of buildings. 
