//Variables
//ContactsController.prototype.templateVariable = null;
ContactsController.prototype.tableBody = null;

//Constructors
function ContactsController()
{
	this.tableBody = $("#contactsTableBody");
}


//Methods

ContactsController.prototype.addContact = function(name, email, phone)
{
	var thisVar = this;
	WebServiceClient.Instance.addContact(name, email, phone, function(responseData) { thisVar.onAddContactCallback(responseData) });
};

ContactsController.prototype.onAddContactCallback =  function(responseData)
{
	if(responseData.Success)
		this.loadContacts();
	else
    	alert("Ups!, Could not connect to server, please try again");
}

ContactsController.prototype.loadContacts = function()
{
	this.tableBody.html("<p id='contactsLoadingText'>Loading...</p>");

	var thisVar = this;
	WebServiceClient.Instance.getContacts(function(responseData) { thisVar.onGetContactsCallback(responseData) });
};

ContactsController.prototype.onGetContactsCallback =  function(responseData)
{
	if(responseData.Success)
	{
		this.tableBody.html("");
		var thisVar = this;

		$.each(responseData.Data, function(i, contact)
		{
			thisVar.tableBody.append("<tr><td>" + contact.Name + "</td><td>" + contact.Email + "</td><td>" + contact.Phone + "</td></tr>");
			//alert(field);
            //$("div").append(field + " ");
        });
	}
	else
    	alert("Ups!, Could not connect to server, please try again");
}