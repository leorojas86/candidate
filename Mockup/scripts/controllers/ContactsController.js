//Variables
ContactsController.prototype.tableBody 		 	= null;
ContactsController.prototype.selectedContactRow = null;
ContactsController.prototype.selectedContactId  = null;

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

		var thisVar 		= this;
		var currentRowIndex = 0;

		$.each(responseData.Data, function(i, contact)
		{
			var currentTableRowId = "contactsTableRow_" + currentRowIndex;
			thisVar.tableBody.append("<tr id = '" + currentTableRowId + "'><td>" + contact.Name + "</td><td>" + contact.Email + "</td><td>" + contact.Phone + "</td></tr>");
			
			$("#" + currentTableRowId).click(function() { thisVar.onRowClick(currentTableRowId, contact.Id); });
			/*$("#" + currentTableRowId).children('td').each(function() 
			{ 
				this.value.click(function() { thisVar.onRowClick(currentTableRowId, contact.Id); });
			});*/

			currentRowIndex++;
        });
	}
	else
    	alert("Ups!, Could not connect to server, please try again");
}

ContactsController.prototype.onRowClick =  function(tableRowId, contactId)
{
	if(this.selectedContactRow != null)
		this.selectedContactRow.removeClass("selectedRow");

	this.selectedContactRow = $("#" + tableRowId);
	this.selectedContactRow.addClass("selectedRow");
	this.selectedContactId  = contactId;
}