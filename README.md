# Intermediate-Custom-Program

COS20007 
Object Oriented Programming Assignment 
Option 2 Intermediate custom program


COS20007
Object Oriented Programming
Assignment
Option 2 Intermediate custom program
Name: Chen Jia Ning
Student ID: 104391287
Class Diagram
The UML Class Diagram show the structure of the Shape Drawer program. At the centre of the design is the abstract Shape class, which provides shared attributes such as color, x, y, selected status, width, height and stroke width. It also defines important abstract methods including Draw(), DrawOutline(), IsAt() and Scale(). These method ensure that all shape types follow the same basic behaviour while allowing each one to implement its own drawing and scaling logic. Different types of shapes inherit from the Shape class, such as Circle1, Rectangle1, Line1, Name, Letter. Each subclass adds its own uniques properties and overrides the required methods to handle drawing and scaling differently. This shows polymorphism, because every shape reacts to the same command in its own way. To imporve shape creation and simplify user interaction, the system introduces a ShapeKind enumeration. This enum lists all supported shape types such as Circle, Rectangle, Line, LetterJ, LetterN, SmoothName and NormalName. Instead of referring to concrete classes directly, the program selectes shapes using this enum, improving readability and reducing coupling between classes.
The drawing class manages all shapes displayed on the canvas. It stores a list of Shape object and provides functions to add, remove, draw, select and scale all shapes at once. The composition relationship between Drawing and Shape shows that shapes belong to the drawing. This organisation supports code reuse, easier maintenance and future expansion of the system by allowing new shape types to be added without changing how Drawing class works.
The ShapeFactory class follows the Factory design pattern and is responsible for creating objects of the appropriate shape subclass based on the selected ShapeKind. It contains a CreateShape method that returna a new instance of the requested shape type. This factory centralises object creation and removes the need for the Drawing or UI components to know the specific constructors of each shape. As a result, adding new shape types becomes easier because onlt the factory needs to be updated.
Sequence Diagram
1. First Name on the canvas (CHEN)
The sequence diagram illustrates the process of drawing the first name shape within the Drawing system. When the Name object is created, the Drawing object adds it to its list of shapes. When the Draw() function is called, the Drawing object goes through each shape in the list and tells them to draw themselves. The diagram uses an alternative fragment (alt) to show the two drawing styles of the word “CHEN”. If the style type is ‘D’, the Name is drawn with smooth thick lines. Otherwise, it is drawn with normal thick lines. After the Name shape finishes drawing, control returns to the Drawing object. This loop continues for all shapes in the list, ensuring that all shapes is displayed correctly on the canvas after each mouse click.
2. Keyboard that will automatically scale down the size
The sequence diagram illustrates the process of scaling all shapes on the canvas. When the ScaleAllShapes() function called, the Drawing object loops throught its shape in the list and sends a Scale(0.8f) message to each shape. An alternative frament (alt) is used to show that different shape types handle the scaling operation in their own ways. For example, Circle1 scales its radius, Rectangle1 scales its width and height, while Line1 scales its start and end coordinates (startX, startY, endX and endY). Similarity, the text-based shape such as Name and Letter scales their width, height and stroke width. After each shape completes scaling, it returns a confirmation back to the Drawing object. This loop continues until all shapes have been scaled, ensuring that every shape displayed on the canvas is scaled correctly and consistently after user presses ‘S’ key on the keyboard.
