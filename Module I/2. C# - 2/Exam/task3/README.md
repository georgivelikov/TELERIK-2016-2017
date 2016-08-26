<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png" />

#### _Telerik Academy Season 2016-2017 / C# Advanced Exam - 31 May 2016_

# Task 3: Harry Potter 4D and the Chamber of Secrets

## Description

Harry potter is caught in one of the rooms of a **four-dimensional** cube-like structure, something like a hypercube (a.k.a tesseract). There are **many different rooms** in the hypercube, but **some of the rooms are filled with Basilisks**. The Basilisk are there for a purpose - to kill Harry Potter! Harry's job is to avoid any contact with the Basilisks, which means that **Harry should not be in the same room with a Basilisk**, because the Basilisk will kill him immediately. But since Harry is not a prophet, there's a possibility that he might choose a wrong move and enter in a room full of Basilisks. Also there's a chance that one of the Basilisks will catch Harry in his room, while he is calculating his next move. Take in consideration that it is **possible** for **two or more basilisks** to be in the same room.

![](https://upload.wikimedia.org/wikipedia/commons/d/d7/8-cell.gif)

**Your job is to predict what will be the outcome of a situation, described by a given sequence of commands.**

A single basilisk is identified by his name. The name for each unit is always **unique** (two units with the same name cannot exist in the hypercube), and the names are always represented by a **single letter** from the Latin alphabet ([a-z] plus [A-Z]), which means that there **cannot be more than 52 basilisks** in the hypercube.
Harry potter is also identified by a name, and his name is always the symbol **"@"**.

**All commands follow the same pattern**:
**"UNIT-NAME INSTRUCTION"**, where **"UNIT-NAME"** represents the LETTER which identifies the Unit that will be instructed and the **"INSTRUCTION"** represents the action to be executed by that unit.

**Instructions description and format:**
**"X"** is the parameter passed to the instruction, and is always a signed integer.
**"A"** corresponds to the **First Dimension**
**"B"** corresponds to the **Second Dimension**
**"C"** corresponds to the **Third Dimension**
**"D"** corresponds to the **Fourth Dimension**

**Explanation:**
Instruction of type: **"A X"**, is interpreted as **"Offset a Unit's First dimension with the value X"**.
Which means that if the Unit is currently at position `hypercube[4,4,4,4]`, he must move to position `hypercube[4+X,4,4,4]`.
Instruction of type: **"B X"**, is interpreted as **"Offset a Unit's Second dimension with the value X"**.
Which means that if the Unit is currently at position `hypercube[4,4,4,4]`, he must move to position `hypercube[4,4+X,4,4]`.
Instruction of type: **"C X"**, is interpreted as **"Offset a Unit's Third dimension with the value X"**.
Which means that if the Unit is currently at position `hypercube[4,4,4,4]`, he must move to position `hypercube[4,4,4+X,4]`.
Instruction of type: **"D X"**, is interpreted as **"Offset a Unit's Fourth dimension with the value X"**.
Which means that if the Unit is currently at position `hypercube[4,4,4,4]`, he must move to position `hypercube[4,4,4,4+X]`.

**If an instruction makes the unit move out of the targeted dimension's range, place the unit at the last possible coordinate, before it goes out of range.**

**THE GAME ENDS WHEN ONE OF THE FOLLOWING CONDITIONS ARE MET, AND YOUR OUTPUT MUST MATCH THE PATTERN CORRESPONDING TO THE CASE:**

**1. If Harry steps into a room with one or more basilisks - The output pattern is:**
**{BasiliskName}**: "Step **{HarryPotterMovesCount}** was the worst you ever made."
**{BasiliskName}**: "You will regret until the rest of your life... All 3 seconds of it!"
_Note_: if there is more than one basilisk in the room **{BasiliskName}** should be the on with **lexicographically smallest name**
_Example_:
**B**: "Step **3** was the worst you ever made."
**B**: "You will regret until the rest of your life... All 3 seconds of it!"

**2. If a Basilisk steps into the same room where Harry is - The output pattern is:**
**{BasiliskName}**: "You thought you could escape, didn't you?" - **{HarryPotterMovesCount}**
_Example_:
**J**: "You thought you could escape, didn't you?" - **6**

**3. If you receive "END" command and Harry Potter hasn't been caught by a basilisk - The output pattern is:**
**{HarryPotterName}**: "I am the chosen one!" - **{HarryPotterMovesCount}**
_Example_:
**@**: "I am the chosen one!" - **3**

## Input

The input data should be read from the console.

On the **first console line** you will receive **4 numbers**, separated by a single whitespace, each of which represents the **size of the corresponding dimension**.
On the **second console line** you will receive **4 numbers**, separated by a single whitespace, that represent the **initial coordinates of Harry Potter** in the hypercube.
On the **third console line** you will receive a number **S** which represents the count of basilisks crawling in the tesseract.
On each of the next **S lines** you will receive a **single letter** and **4 numbers**, separated by a single whitespace, where the letter represents the **name of the basilisk** and the numbers represent the **initial coordinates of that basilisk**.
On each of the next **X lines** you will receive a command in the following format **"UNIT-NAME INSTRUCTION"**, where **"UNIT-NAME"** represents the name of the Unit that will be instructed and the **"INSTRUCTION"** represents the action to be executed by that unit (don't forget that Harry Potter is also a unit).
Process commands until you receive **"END"** as an input, **or until one of the basilisks catches Harry Potter**.

The input data will always be valid and in the format described. There is no need to check it explicitly.

## Output

The output data should be printed on the console.
On the next 1 or 2 output lines, print the result of the given sequence of commands using the corresponding pattern as described above:

## Constraints
- **"UNIT-NAME"** will be a letter from the Latin alphabet **A-Z** or **a-z** for the Basilisks and **@** for Harry Potter.
- **"UNIT-NAME"** will always be unique (you cannot have 2 or more Units identified with the same symbol).
- **"S"** will be a positive integer between **1** and **52** inclusive
- **"X"** will always be a **signed integer** with **absolute value** between **0** and **200** inclusive.
- **Dimension size** will be a positive integer between **1** and **100** inclusive.
- **Instructions count** will be a positive integer between **1** and **10000** inclusive.
- **Time limit: 0.05 s**
- **Memory limit: 24 MiB**

## Examples

### Input
```
4 4 4 4
0 0 0 0
2
J 1 1 1 1
B 0 0 0 1
J A -1
J B -1
B D -1
END
```

### Output
```
B: "You thought you could escape, didn't you?" - 0
```

### Input
```
44 54 24 34
0 0 13 13
2
J 1 1 1 1
B 0 0 0 1
J A -1
J B -1
B D -1
@ D 20
J B 20
J B 20
@ D -30
@ D 100
@ A 100
@ B 100
@ C 100
J D 200
J A 200
J B 200
J C 200
END
```

### Output
```
J: "You thought you could escape, didn't you?" - 6
```

### Input
```
44 54 24 34
0 0 13 13
2
J 1 1 1 1
B 0 0 0 1
J A -1
J B -1
B D -1
@ D 20
J B 20
J B 20
@ D -30
J B 13
@ D 16
END
```

### Output
```
@: "I am the chosen one!" - 3
```

### Input
```
4 4 4 4
0 0 1 0
2
J 1 1 1 1
B 0 0 0 1
J A -1
J B -1
B D -1
@ C -1
END
```

### Output
```
B: "Step 1 was the worst you ever made."
B: "You will regret until the rest of your life... All 3 seconds of it!"
```

### Input
```
4 4 4 4
0 0 1 0
2
J 1 1 1 1
B 0 0 0 1
J A -1
J B -1
B D -1
@ C 100
@ C 14
@ C -100
END
```

### Output
```
B: "Step 3 was the worst you ever made."
B: "You will regret until the rest of your life... All 3 seconds of it!"
```
