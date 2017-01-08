# Advent Of Code 2016
An exercise in exercising.

Interested in doing the AoC yourself?  [Advent of Code 2016](http://adventofcode.com/2016).

I may have approached some problems incorrectly (utlimately or initially), but for my own efficacy, I'll summarize and provide some information about the problem and it's parts.

I decided I wanted to make this a public repo after completing Day 8. The code should be relatively clean for Day 7 and beyond, but I'm not interested in refactoring the first 6 projects at the moment.

- **Day 1:  No Time for a Taxicab  (Grid traversal)**

- **Day 2: Bathroom Security (Grid traversal)**

- **Day 3: Squares With Three Sides (Array traversal)**
  I remember thinking the Part 2 was *way* more difficult for me than it should have been.

- **Day 4: Security Through Obscurity (String manipulation?)**

- **Day 5: How About a Nice Game of Chess? (MD5 Hash library)**
  Fun!
- **Day 6: Signals and Noise (Array manipulation)**

- **Day 7: Internet Protocol Version 7 (Pattern detection)**
  This was the first time I had decided to use a `HashSet` object to solve a problem.  This was a fun problem and I'm relatively happy with the solution.

- **Day 8: Two-Factor Authentication (2D Grid manipulation)**
  - Part 1: I felt good about the solution. I've had to somewhat reacquaint myself with 2D array traversal (row/column and i/j indexing)
  - Part 2: Very cool; I had already made a `Print();` method and noticed something looked interesting about the results from part 1.

- **Day 9: Explosives in Cyberspace (Decompress encoded strings)**
  - Part 1: ***Not*** solved in a "good" way. Woops.
  - Part 2: Best solved recursively. Part 1 could not be extended for this. I'm happy with my solution for Part 2.

- **Day 10: Balance Bots (Binary Tree/List Traversal)**
  I felt good about the solution. Initially I found the problem a bit difficult to understand, but once I did, it was fun to solve. For part 2, somehow my input data was "corrupted" (the last instruction existed twice on the same line and it broke my parser); this must have been due to an accidental copy/paste. Once identified, part 2 didn't require much work/time.

- **Day 11: Part 1, solved; Part 2, Aghhhhhh!!!!**
  Difficulty: 10+

- **Day 12: Leonardo's Monorail (Execute assembly code; it's like MIPS!)**
  I went with the visitor pattern for this solution; albeit overengineered, I think it was elegant. The problem overall wasn't too difficult to approach, although I was a bit unsure of how to execute the `jnz` instruction at first if the source wasn't a register.

- **Day 13: A Maze of Twisty Little Cubicles (Bit Masking & Maze/Grid Traversal)**
Some of the grid traversal is kind of gross, but overall I think I had an efficient solution. *Note: This was the first time I've printed to the Console in color, ha!*

- **Day 14: One-Time Pad (MD5 Hash, Regular Expressions, Queue)**
  The commits/approach between part 1 of this problem and part 2 were fairly different.  The first approach continually incrimented an index, and if any candidates had not been verified and were outside the range, they were removed; if a candidate was added, all previous, still existing candidates were checked against that one. Since we were terminating after finding a pre-defined number of valid keys, it was possible that.

  The second approach (correct approach for all parts), was to queue all candidate keys up to 1000, initially. Then, we dequeue a single candidate, ensure the queue contains all candidates within a range of 1000 of that candidate, then inspect all, still existing (queued) candidate keys against the criteria. 

  There may be a bug in my code (fix indicated with a `todo` within the code): The candidate queue could be emptied if no candidates exist for comparison within a 1000 value range, and we're on our last cnadidate. This bug didn't appear in the test input or real input, so I'm not going to inspect it further.

- **Day 15: Timing is Everything (Math? Modulo operator; Logic)**
  Difficulty: 1.
  An easy one for a change. Fun. The most difficult part is conceptualizing the story.

- **Day 16: Dragon Checksum (String traversal; Logic)**
  Difficulty: 2, maybe 3.
  Fun; Nothing too tricky here. Was unfamiliar with a Dragon Curve.

- **Day 17: Two Steps Forward (Shortest path, longest path; Hashing; Regular expressions)**
  Difficulty: 4, maybe 5.
  A really fun problem with a little bit of everything.

- **Day 18: Like a Rogue (Computational efficiency)**
  Difficulty, 4 or 5.
  I started off on the "wrong" path. I recognized early on that circuit minimization could apply here, but I had already started down the road of using complex classes and was able to solve Part 1 without it. Part 2 demanded more efficiency, hence the rewrite from `Day18` to `Day18.Better`.  There was something satisfying about the massive speed increase between the two solutions.

- **Day 19: An Elephant Named Joseph (Algorithms?)**
  Difficulty, 6.
  Part 1 was concise and easy to understand. I knew there must be a mathematical way to approach it, and found what I thought was a somewhat good approach. Namely, decide how many participants/who to move based on whether or not there was an odd or even number. Part 2 was trickier. I went with a brute force `List` approach. The code was concise, but somewhat inefficient (`O(n) + O(n^2)`). I noticed the following (somewhat linear) results with respect to input size:
  
  |   Size    | Time (seconds) |
  | --------- | -------------- |
  |   100,000 |              1 |
  |   200,000 |              6 |
  |   300,000 |             14 |
  |   400,000 |             25 |
  |   500,000 |             45 |
  | 1,000,000 |            163 |

  As a result, with an input size of ~`3,000,000`, it took 1,690 seconds (~27 minutes) to run. I'm not proud of this, but it did produce the correct answer. It might be worth revisiting and figuring out a more optimal solution at some point. The difficulty rating is somewhat based on the lack of achieving a better solution.

- **Day 20: Firewall Rules (Algorithms; Computation efficiency; Linq)**
Difficulty, 8. If I had assigned only Part 1 a difficulty rating, it would have been a 2 or 3.  Thanks Part 2.  Part 2 was deceptively difficult.  I must not have been in a position in which a list contains non-unique, overlapping ranges and I need to get the distinct range of values, efficiently. I'm mostly satisfied with my solution, although I'd be interested to see more simple/efficient solutions. Execution time for part 2 was ~`75ms`.