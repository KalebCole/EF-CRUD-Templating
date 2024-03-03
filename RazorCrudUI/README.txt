JavaScript Validation Experiment

	1. What do you notice is different if anything?
		I did not notice any difference in the behavior of the page on my own when I was commenting and uncommenting the script tag. But, when I looked up the question, it states that it would undo any form of client-side validation.
		I am not sure where the client-side validation is happening in my code. I had assumed it was either from the data annotations in the model or from the asp-validation-for="ItemModel.Name" in the Create view, but I am not finding any signs that this is the reason.

	2. What do you think including this section does?
		It allows for client-side validation through some JavaScript, but I'm not sure where it is happening in my code.

Async Experiemnt
	1. Do you notice any difference?  If so what?
		I did not notice any difference between the two versions of the code. I believe that this has to do with Entity Framework Core's property of having the databse be stored in memory. I believe that if the database was stored on a physical server, then the async version would be faster.