//Variables
ContactsController.prototype.tableBody 		 	 = null;
ContactsController.prototype.selectedContactRow  = null;
ContactsController.prototype.selectedContactData = null;
ContactsController.prototype.contactsData	     = null;

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
	this.selectedContactRow  = null;
	this.selectedContactData = null;
	this.contactsData 		 = null;

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
		this.contactsData 	= responseData.Data;

		$.each(responseData.Data, function(i, contact)
		{
			var currentTableRowId = "contactsTableRow_" + currentRowIndex;
			thisVar.tableBody.append("<tr id = '" + currentTableRowId + "'><td>" + contact.Name + "</td><td>" + contact.Email + "</td><td>" + contact.Phone + "</td></tr>");
			
			$("#" + currentTableRowId).click(function() { thisVar.onRowClick(currentTableRowId, contact.Id, i); });

			currentRowIndex++;
        });
	}
	else
    	alert("Ups!, Could not connect to server, please try again");
};

ContactsController.prototype.onRowClick =  function(tableRowId, contactId, contactDataIndex)
{
	if(this.selectedContactRow != null)
		this.selectedContactRow.removeClass("selectedRow");

	this.selectedContactRow = $("#" + tableRowId);
	this.selectedContactRow.addClass("selectedRow");
	this.selectedContactData = this.contactsData[contactDataIndex];
};

ContactsController.prototype.updateSelectedContact  =  function(name, email, phone)
{
	var thisVar = this;
	WebServiceClient.Instance.updateContact(this.selectedContactData.Id, name, email, phone, function(responseData) { thisVar.onUpdateContactCallback(responseData) });
}

ContactsController.prototype.onUpdateContactCallback =  function(responseData)
{
	if(responseData.Success)
		this.loadContacts();
	else
		alert("Ups!, Could not connect to server, please try again");
}