//Variables
AddContactDialog.prototype.addContactDiv = null;

//Constructors
function AddContactDialog()
{
	this.addContactDiv = $("#addContactDialog");
}

//Methods
AddContactDialog.prototype.show = function()
{
	$("#addContactDialog").dialog();
};