# GenerateLine

##### Generating a string by mask. The task of the educational practice.


# About

##### This program generates and outputs to the console a list consisting of lines, each of which meets the conditions defined by the user using a special mask.


# The mask assumes the following control characters:
1. X - the position of the digital character.
2. C - the position of the Latin character in any case.
3. U - the position of the Latin character in uppercase.
4. D - the position of the Latin character in lowercase.
5. Z - position of the sign symbol (+ - * $ % # & @).
6. ? - the position of any Latin character or letter.
7. {} - the position of the text constant (the contents in curly brackets are output to the generated string without changing).

### After any mask character (with the exception of curly brackets) , a number can be specified that determines how many times this character is repeated in the generated string.

## The program also has the ability to save the generated data and masks to text files, read data from files, add data with the same masks to existing files, and handle typical errors.


# Example

### Mask: {+7 (}X3{) }X3{-}X2{-}X2
### Results : 
1. +7 (864) 645-34-09
2. +7 (456) 529-83-98
3. +7 (397) 987-01-72
