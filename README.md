# Comma-Sprinkler

C# application that modifies sentences based on a specfic set of rules. <br>
This was one of the problems from the International Collegiate Programming Contest (ACM-ICPC) World Finals 2018.

## Rules And Logic

As practice will tell you, the English rules for comma placement are complex, frustrating, and often ambiguous. Many people, even the English, will, in practice, ignore them, and, apply custom rules, or, no rules, at all. Doctor Comma Sprinkler solved this issue by developing a set of rules that sprinkles commas in a sentence with no ambiguity and little simplicity. In this problem you will help Dr. Sprinkler by producing an algorithm to automatically apply her rules.

1• If a word anywhere in the text is preceded by a comma, find all occurrences of that word in the text, and put a comma before each of those occurrences, except in the case where such an occurrence is the first word of a sentence or already preceded by a comma.

2• If a word anywhere in the text is succeeded by a comma, find all occurrences of that word in the text, and put a comma after each of those occurrences, except in the case where such an occurrence is the last word of a sentence or already succeeded by a
comma.

3• Apply rules 1 and 2 repeatedly until no new commas can be added using either of them.

## Example

Display the result after applying Dr. Sprinkler’s algorithm to the original text. Consider the sample text below:

`please sit spot. sit spot, sit. spot here now here.`
 
Because there is a comma after spot in the second sentence, a comma should be added after spot in the third sentence as well (but not the first sentence, since it is the last word of that sentence). Also, because there is a comma before the word sit in the second sentence, one should be added before that word in the first sentence (but no comma is added before the word sit beginning the second sentence because it is the first word of that sentence). Finally, notice that once a comma is added after spot in the third sentence, there exists a comma before the first occurrence of the word here. Therefore, a comma is also added before the other occurrence of the word here. There are no more commas to be added so the final result is: 

`please, sit spot. sit spot, sit. spot, here now, here.`

## Input Constraints

The input contains one line of text, containing at least 2 characters and at most 1000000 characters. Each character is either a lowercase letter, a comma, a period, or a space. We define a word to be a maximal sequence of letters within the text. The text adheres to the following constraints:

1• The text begins with a word.

2• Between every two words in the text, there is either a single space, a comma followed by a space, or a period followed by a space (denoting the end of a sentence and the
beginning of a new one).

3• The last word of the text is followed by a period with no trailing space.

## Output 

### Sample Input 1
`please sit spot. sit spot, sit. spot here now here.`
### Sample Output 1
`please, sit spot. sit spot, sit. spot, here now, here.`

### Sample Input 2
`one, two. one tree. four tree. four four. five four. six five.`
### Sample Output 2
`one, two. one, tree. four, tree. four, four. five, four. six five.`


