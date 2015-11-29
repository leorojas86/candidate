//Variables
AddContactDialog.prototype.addContactDiv = null;
AddContactDialog.prototype.onAddClicked  = null;

//Constructors
function AddContactDialog()
{
	this.addContactDiv = $("#addContactDialog");

	var thisVar = this;
	$("#addContactDialogButton").click(function() { thisVar.onAddContactButtonClick(); });
	$("#addContactDialogGrayout").click(function() { thisVar.hide(); });
}

AddContactDialog.prototype.onAddContactButtonClick = function()
{
 	this.onAddClicked($("#name").val(), $("#email").val(), $("#password").val());
 	this.hide();
}

//Methods
AddContactDialog.prototype.show = function(onAddClicked)
{
	this.onAddClicked = onAddClicked;
	this.addContactDiv.show();
};

AddContactDialog.prototype.hide = function()
{
	this.addContactDiv.hide();
}