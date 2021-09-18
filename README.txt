Unity Kata #13 - Hangman

What is Hangman?
 - A Pen&Paper Game for multiple people
 - 2 Groups of players: 1 Namer and X Guessers
 - Namer names a word, Guessers have to guess the word letter by letter
 - Namer wins if Guesser guess wrong too often (typically 6 turns)
	- every wrong guess draws parts to hangman figure, guessers lose if complete
 - Guessers win if they can guess the word
 
Current features:
 * basic hangman game with preset words

ToDo:
- implement losing functionality
- implement word guess functionality
- refactor Hangman_figure to use list of sprites for scalability
- enable adding words with " ", "-", "'"... but always SHOW THESE SYMBOLS
- add toString function to Hangman_Letter