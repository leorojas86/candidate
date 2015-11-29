//Variables
//ContactsController.prototype.templateVariable = null;

//Constructors
function ContactsController()
{
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
	var thisVar = this;
	WebServiceClient.Instance.getContacts(function(responseData) { thisVar.onGetContactsCallback(responseData) });
};

ContactsController.prototype.onGetContactsCallback =  function(responseData)
{
	if(responseData.Success)
	{
		$.each(responseData.Data, function(i, field)
		{
			alert(field);
            //$("div").append(field + " ");
        });
	}
	else
    	alert("Ups!, Could not connect to server, please try again");
}