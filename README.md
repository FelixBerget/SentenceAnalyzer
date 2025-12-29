This is my personal prosject for analyzing sentences with help from the Claude SDK, Json Deserialize and Neo4j database.
First i need to get a sentence randomly generated. This is done via the Claude SDK which generates a output that i then use.
I have standardized my prompt so that they always return in the same format for each sentence. Example of response expected is in sentence-data.json

Propmpt looks like this (I want a you analyze the following Italian sentence "Mi piace molto la lasagne italiana." Here are my requirements for the response
1. ONLY Json, nothing else and make sure that the response without editing is parseable
2. Make it so that it is ready to be used by a Neo4j graph database this means keeping track of relations, positions and splitting up the sentence into words
3. Make it simple so that each time i would query you this it would be the same answer for the same sentence analyzed
4. Make so the properties of words are if it is a verb, noun or adjective
5. Relations should be if someone owns or does something
6. I do not need descriptions of the relations
7. Keep relations to the following "SUBJECT_OF", "AFFECTS", "MODIFIES"
8. ID should be combination of word and type such as verb
9. Keep it to the 3 most important relations
10. Words are noted as word not w in their id
11. Keep the individual words to the variables, id, text, position and type
12. The words should be annotated as nodes like this "words": [)

I also have to trim down and remove some junk because the Json response from the prompt in C# contains stuff like the "```json" which is different from just copying the file from a browser prompt.
After the response from the prompt has been made ready it is then in the expected workflow used in the SentenceAnalyzer file. Which simply uses the built in JsonSerializer to Deserialize the string that contains the Json.
It does this easily because the Json has been set in a format so that the convertion is smooth. It also gets turned into a Sentence object which also contains Words and Relations.
Next in the workflow it is to send it to the database.
First before i run the project i start my docker compose that is there which sets up a local Neo4j database.
This is of course a temporary solution if i wanted to use this for real. Is in then it would have to be a actual database, but it made for good testing.
Then after Json Serializing i go to Neo4jService which has the function SendToServer which takes the Sentence object made by the Deserialization and uses it for a Query.
The Query simply goes through all the words one by one and makes a query for each that sends it to the database with all its values such as name and id.
Then it does the same for realtions, here i had to get creative since you cant parameter a relation in the executable query so i just make the string directly with the relation type from the object.
That is the basic flow.

However i added a bit more functionality.
First i added the ability to get all the words back from the Neo4j database which is of course practical in many cases.
I also made a function to search for a word in the database which also returns the words, there can be multiple since each word has a id based on the word itself and what type it is such as noun. Both of these return a list of words.
I also added testing just to show that i can mock, here it tests if there are no calls to the database like using the SendToServer function with a Sentence with 0 words and 0 relations.

