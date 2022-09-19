## [Introduction to Lists](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0)

Lists are a sequential collection of values and they can hold references to any type. Unlike arrays, they have (effectively) unlimited length, they automatically track the number of actual elements in the list, and they have handy methods to work with multiple elements at a time.

---
## Creating and Adding
A list is a sequential data structure that can hold any type. Like arrays, you can use them to store any sequential information, like the letters of the alphabet, comments on a blogpost, the finishing times for a horse race, or items on a restaurant menu.

You create a list using the `new `keyword, like you would create any other class. You specify the type of element inside angle brackets: `< >`. In this example, the list is named `citiesList` and it holds instances of the type `string`. `List<string> citiesList = new List<string>();`


You can add elements to the list using the Add() method:`citiesList.Add("Delhi");`

You can access elements using indices and square brackets:`citiesList[0] = "New Delhi";`


In order to use lists, you’ll need to add this to the top of your file. We’ll explain this in detail later:`using System.Collections.Generic;`

---
## Object Initialization
Our first way to create lists and add items took multiple lines:

```
List<string> citiesList = new List<string>();
citiesList.Add("Delhi");
citiesList.Add("Los Angeles");
```

We can do it all in one line using object initialization:

`List<string> citiesList2 = new List<string> { "Delhi", "Los Angeles" };`

- Basic construction uses parentheses ( ) and no values.
- Object initialization uses curly braces { } and the actual values go in-between.

---
## Count and Contains
We can check on the status of our list in two ways.

We can find the number of elements in the list using the `Count` property:
```
List<string> citiesList = new List<string> { "Delhi", "Los Angeles" };
int numberCities = citiesList.Count;
// numberCities is 2
```
We can check if an element exists in a list using the `Contains()` method:

```
bool hasDelhi = citiesList.Contains("Delhi");
bool hasDubai = citiesList.Contains("Dubai");
// hasDelhi is true, hasDubai is false
```
---
## Removing
To remove a specific item from a list we use the `Remove() `method. It expects the specific item as an argument and it returns `true` if it was successfully removed. This code removes "Delhi" from the list and returns `true`:

```
List<string> citiesList = new List<string> { "Delhi", "Los Angeles", "Kyiv" };
bool success = citiesList.Remove("Delhi");
// success is true
```

If the specific item does NOT exist in the list, the method call returns false. Since "Dubai" isn’t in the list, success will be false:
```
success = citiesList.Remove("Dubai");
// success is false
```
If you remove an element in the middle of the list, all of the elements will be “shifted” down one index. In the first example, the list was originally:
`[ "Delhi", "Los Angeles", "Kyiv" ]`


After the call to `Remove("Delhi")`, the list becomes
`[ "Los Angeles", "Kyiv" ]`

---
## Clearing
If we need to remove all of the elements from a list, we could iterate through the entire list and call `Remove()`. The easier way is to use the `Clear()` method.
```
List<string> citiesList = new List<string> { "Delhi", "Los Angeles", "Kyiv" };
citiesList.Clear();
 
Console.WriteLine(citiesList.Count);
// Output: 0
```

---
## Accessing Out of Bounds
Effectively, we can add an infinite number of items to a list:

```
List<int> numbers = new List<int>();
 
for (int i = 0 ; i < 1000; i++)
{
  numbers.Add(i);
}
```

We can access and edit them using bracket notation:

```
int numberFive = numbers[4];
numbers[4] = 523;
```

We can only access indices which have been added to the list. 

Here are two tips to avoid this issue:

Imagine the list growing every time we add a number and shrinking every time we remove a number. Unlike arrays, there is no set length.
Check the `Count` of your lists before accessing an index, as shown below.

```
int index = 1001;
if (index < numbers.Count)
{
  Console.WriteLine(numbers[index])
}
```
---
## Working with Ranges
So far we have added, accessed, and removed single elements in a list. What if we wanted to add, access, or remove multiple elements at once?

In the world of lists we call a subsequence of elements a range. For example, this list has 5 elements:
`[ "first", "second", "third", "fourth", "fifth" ]`

We can say the range of elements from index 1 to 3 is:
`[ "second", "third", "fourth" ]`


Here are four common range-related methods:

- `AddRange()` — takes an array or list as an argument. Adds the values to the end of the list. Returns nothing.

- `InsertRange()` — takes an int and array or list as an argument. Adds the values at the int index. Returns nothing.

- `RemoveRange()` — takes two int values. The first int is the index at which to begin removing and the second int is the number of elements to remove. Returns nothing.

- `GetRange()` — takes two int values. The first int is the index of the first desired element and the second int is the number of elements in the desired range. Returns a list of the same type.


```
List<string> places = new List<string> { "first", "second" };
 
places.AddRange(new string[] { "fifth", "sixth" });
// List is  "first", "second", "fifth", "sixth" ]

places.InsertRange(2, new string[] { "third", "fourth"});
// List is [ "first", "second", "third", "fourth", "fifth", "sixth" ]

places.RemoveRange(4, 2);
// List is [ "first", "second", "third", "fourth" ]

List<string> newPlaces = places.GetRange(0, 3);
// New list is [ "first", "second", "third" ]
```

---
## Looping through Lists

With `for` loops, make sure to use `Count` to stay within the bounds of the list.

```
for (int i = 0; i < numbers.Count; i++)
{
   Console.WriteLine(numbers[i]);
}
```

With a `foreach` loop, the counting is handled for you:

```
foreach (int number in numbers)
{
   Console.WriteLine(number);
}
```

Generally, we prefer `foreach` loops because they require less typing and thus less chance for typos.

If the index is used in the operation — like printing out each index and element together — then we’ll use `for` loops.

---
## Generic Collections

The list class is in a group of classes called generic collections. They don’t exist in the default set of System classes, so we need to make a reference to them with this line.`using System.Collections.Generic;`

Generic collections are data structures that are defined with a generic type. Each class is defined generally without a specific type in mind. When we make an actual instance, we define the specific type:

```
List<string> citiesList = new List<string>();
List<Object> objects = new List<Object>();
```

Imagine it like a set of general instructions: in a toy store, we can tell the employees how to add and remove items from a shelf without specifying the type of toy. In the same way, we can use `Add() `and `Remove()` without knowing a lists’s data type.

For this reason, the formal class name of lists is `List<T>`. That `T` is a type parameter: it represents some type that we can specify later. The general instructions, however are neatly contained in the generic `List<T>` class.

Let’s see why this is useful by imagining the other, more difficult ways we could create “generic” collections:

- Use type-specific classes, like `StringList`, `IntList`, etc. — We would have to make a list class for EVERY type, defining the same properties and methods for each list class.

- Use a list containing Object types, `List<Object>` — Using Object means we can’t use any of the unique functionality of each type and it takes a lot of computing power to convert references to and from the `Object` type.

---
## [Review Lists](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0)
- A list, or `List<T>`, is a generic, sequential data structure. The specific type that it contains is specified upon instantiation.

- Lists are effectively unlimited. They “grow” and “shrink” as the number of elements rises and falls.

- List values can be accessed by index using square brackets: [ ].
To create an empty list, use a basic constructor. To create a list with values, use object initialization.

- `Add()` is used to add an element to a list.

- `Remove()` is used to remove an element from the list. It returns `true `if it is successful, `false` otherwise.

- `Count` is the number of elements in the array.

- `Contains()` returns `true` if the argument exists in the list, `false` otherwise.

- A sequence within a list is called a range. There are specific methods for working with ranges, including `GetRange()`, `AddRange()`, `InsertRange()`, and `RemoveRange()`.

- Lists are a type of generic collection, which are defined with generic type parameters. The type parameters are specified when instantiating any generic class.

- Use lists and dictionaries in your code by including this line at the top of your file:`using System.Collections.Generic;`

Finally, you may be wondering: if lists have so many great features, why did we bother with arrays at all?

The answer is (this an optional part of the lesson): under the hood, lists actually use arrays! When we construct a list, the C# compiler constructs an array and stores the elements there. If the list gets longer than the array’s length, the compiler copies the list elements to a new, longer array. To the developer, it just looks like the list is infinitely long.

Thus arrays are faster to use when you have a pre-determined number of elements, and lists are better to use when the number is unknown or you’d like the extra features. If you’d like to dive deeper into this concept, start with the Capacity property.
