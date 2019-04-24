# Numberless numbers
This was my attempt to create a "Number" type that implements basic arithmetic operators (+, -, * , /) without using any number libraries.  It is valid for all positive and negative integers.

#### Implementation
There are, no doubt, numerous ways to implement this.  In my implementation, each number is just an "object" that links to the "next" object as well as the "previous" object.  It is basically a linked-list with a static reference to the Origin.

#### Operator dependencies

All higher level operators (+, -, *, etc...) were able to be composed of a three lower level operators:
* Increment
* Decrement
* Origin (A constant that represents "zero")

With those 3 builing blocks you can compose all higher level operators. (I used C#'s object reference equality to implement the Equality operator, because it was so straightforward, but it could also be done in terms over Increment, Decrement, and Origin.)

My operators, in order of dependency, looks like this:  
Lowest Level --> Highest Level:  
Origin, ++, --, ==, !=, >, >=, <, <=, - (negation), +, - (subtraction), *, /, and %

#### Writing system

To communicate the concept of the numbers visually (and also provide simple means of input and output), I created Parse() and ToString() methods.  I wanted to represent them in a way that discouraged my mental association to Indo-Arabic numerals, so I made up a different system, using Os to represent positive units, and Xs to represent negative units.

For example:
* "XXX" (conceptually equivalent to the Indo-Arabic "-3")
* "XX" (to "-2")
* "X" ("-1")
* "" ("0")
* "O" ("1")
* "OO" ("2")
* "OOO" ("3")

Obviously, numbers could be represented (and operations performed) much more efficiently using a place-value representation (like decimal or binary), but that seemed too familiar to how I have been typically think of numbers, so I wanted something more "raw", and I couldn't think of anything more raw than an amount of Os.
