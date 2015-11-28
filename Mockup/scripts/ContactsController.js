//Variables
//ContactsController.prototype.templateVariable = null;

//Constructors
function ContactsController()
{
}

//Methods
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