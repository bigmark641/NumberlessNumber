# NumberlessNumber
This was my attempt to create a "Number" type that implements basic arithmetic operators (+, -, * , /) without using any number libraries.  It is valid for all positive and negative integers.

There are, no doubt, numerous ways to implement this.  All higher level operators (+, -, *...) were able to be composed of a few lower level functions:
* Increment
* Decrement
* Origin (zero)

My implementation is basically a linked-list with a static reference to the Origin.

With those 3 builing blocks you can compose all higher level functions. (I used object reference equality to implement the Equality operation, but it could also be done in terms over Increment, Decrement, and Origin.)

My operations, in order of dependency, looks like this:
Lowest Level --> Highest Level:
Origin, ++, --, ==, !=, >, >=, <, <=, - (negation), +, - (subtraction), *, /, %

Instead of using number literals, I created Parse() and ToString() methods.  I wanted a way to represent them that did not look exactly like decimal numerals, so I chose to use Os to represent positive units, and Xs to represent negative units.  Example:
* "XXX" (conceptually equivalent to -3)
* "XX" (conceptually equivalent to -2)
* "X" (conceptually equivalent to -2)
* "" (conceptually equivalent to 0)
* "O" (conceptually equivalent to 1)
* "OO" (conceptually equivalent to 2)
* "OOO" (conceptually equivalent to 3)
